﻿//
// Copyright (c) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;

using Gtk;

using Mono.TextEditor;
using MonoDevelop.Core;
using MonoDevelop.DesignerSupport.Toolbox;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.SourceEditor
{
	static class ClipboardRingService
	{
		const int clipboardRingSize = 20;
		const int toolboxNameMaxLength = 250;
		static readonly List<ClipboardToolboxNode> clipboardRing = new List<ClipboardToolboxNode> ();

		public static event EventHandler Updated;

		static ClipboardRingService ()
		{
			ClipboardActions.CopyOperation.Copy += AddToClipboardRing;
		}

		static void AddToClipboardRing (string text)
		{
			if (string.IsNullOrEmpty (text))
				return;

			//if already in ring, grab the existing node
			ClipboardToolboxNode newNode = null;
			foreach (var node in clipboardRing) {
				if (node.Text == text) {
					clipboardRing.Remove (node);
					newNode = node;
					break;
				}
			}

			clipboardRing.Add (newNode ?? CreateClipboardToolboxItem (text));

			while (clipboardRing.Count > clipboardRingSize) {
				clipboardRing.RemoveAt (0);
			}

			Updated?.Invoke (null, EventArgs.Empty);
		}

		static ClipboardToolboxNode CreateClipboardToolboxItem (string text)
		{
			var item = new ClipboardToolboxNode (text);

			string [] lines = text.Split ('\n');
			for (int i = 0; i < 3 && i < lines.Length; i++) {
				if (i > 0)
					item.Description += Environment.NewLine;
				string line = lines [i];
				if (line.Length > 16)
					line = line.Substring (0, 16) + "...";
				item.Description += line;
			}

			return item;
		}

		static string EscapeAndTruncateName (string text)
		{
			var sb = StringBuilderCache.Allocate ();
			foreach (char ch in text) {
				switch (ch) {
				case '\t': sb.Append ("\\t"); break;
				case '\r': sb.Append ("\\r"); break;
				case '\n': sb.Append ("\\n"); break;
				default: sb.Append (ch); break;
				}
				if (sb.Length >= toolboxNameMaxLength) {
					break;
				}
			}
			return StringBuilderCache.ReturnAndFree (sb);
		}

		public static IEnumerable<ItemToolboxNode> GetToolboxItems ()
		{
			return clipboardRing;
		}

		class ClipboardToolboxNode : ItemToolboxNode, ITextToolboxNode
		{
			static readonly ToolboxItemFilterAttribute filterAtt = new ToolboxItemFilterAttribute ("text/plain", ToolboxItemFilterType.Allow);
			static readonly string category = GettextCatalog.GetString ("Clipboard Ring");
			static readonly Xwt.Drawing.Image icon = DesktopService.GetIconForFile ("a.txt", IconSize.Menu);

			public ClipboardToolboxNode (string text)
			{
				Text = text;

				ItemFilters.Add (filterAtt);
				Category = category;
				Icon = icon;
			}

			public string Text { get; private set; }

			public override string Name {
				get {
					return base.Name.Length > 0 ? base.Name : (base.Name = EscapeAndTruncateName (Text));
				}
				set => base.Name = value;
			}

			public override bool Filter (string keyword)
			{
				return Text.IndexOf (keyword, StringComparison.InvariantCultureIgnoreCase) >= 0;
			}

			public string GetDragPreview (Document document)
			{
				return Text;
			}

			public void InsertAtCaret (Document document)
			{
				document.Editor.InsertAtCaret (Text);
			}

			public bool IsCompatibleWith (Document document)
			{
				return true;
			}
		}
	}
}
