using System;
using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Utils
{
	public class DebugMenu
	{
		public abstract class MenuEntry
		{
			public string Name { get; set; }

			public bool IsSelected { get; private set; }

			public abstract bool IsSelectable { get; }

			protected string Label => null;

			internal MenuEntry(string name)
			{
			}

			internal abstract void Draw();

			internal virtual void Submit()
			{
			}

			internal virtual void Select()
			{
			}

			internal virtual void Deselect()
			{
			}
		}

		public class MenuNavigationEntry : MenuEntry
		{
			public MenuNavigationEntry Parent { get; private set; }

			public List<MenuEntry> ChildEntries { get; private set; }

			public bool IsExpanded { get; private set; }

			public override bool IsSelectable => false;

			public Vector2 Scroll { get; set; }

			internal MenuNavigationEntry(string name, MenuNavigationEntry parent)
				: base(null)
			{
			}

			internal override void Draw()
			{
			}

			internal override void Select()
			{
			}

			internal override void Submit()
			{
			}

			internal void Add(MenuEntry newEntry)
			{
			}

			internal MenuEntry FindFirstSelectable()
			{
				return null;
			}

			private void CloseAllChildsExcept(MenuEntry expandedEntry)
			{
			}

			private void Close()
			{
			}

			internal override void Deselect()
			{
			}
		}

		public class LabelEntry : MenuEntry
		{
			public override bool IsSelectable => false;

			internal LabelEntry(string name)
				: base(null)
			{
			}

			internal override void Draw()
			{
			}
		}

		public class ButtonEntry : MenuEntry
		{
			private readonly Action callback;

			private readonly DebugMenu debugMenu;

			public override bool IsSelectable => false;

			internal ButtonEntry(string name, Action callback, DebugMenu debugMenu)
				: base(null)
			{
			}

			internal override void Draw()
			{
			}

			internal override void Submit()
			{
			}
		}

		public class TextFieldEntry : MenuEntry
		{
			public string Value { get; private set; }

			public override bool IsSelectable => false;

			internal TextFieldEntry(string name, string defaultValue)
				: base(null)
			{
			}

			internal override void Draw()
			{
			}
		}

		private string name;

		private MenuNavigationEntry root;

		public bool Active { get; private set; }

		public DebugMenu(string name)
		{
		}

		public void Clear()
		{
		}

		public LabelEntry AddLabel(string path)
		{
			return null;
		}

		public LabelEntry AddLabel(params string[] path)
		{
			return null;
		}

		public ButtonEntry AddButton(Action clickCallback, string path)
		{
			return null;
		}

		public ButtonEntry AddButton(Action clickCallback, params string[] path)
		{
			return null;
		}

		public TextFieldEntry AddTextField(string defaultValue, string path)
		{
			return null;
		}

		public TextFieldEntry AddTextField(string defaultValue, params string[] path)
		{
			return null;
		}

		public void Toggle()
		{
		}

		public void Draw()
		{
		}

		public void Up()
		{
		}

		public void Down()
		{
		}

		public void Right()
		{
		}

		public void Left()
		{
		}

		public void Submit()
		{
		}

		private static int Mod(int x, int m)
		{
			return 0;
		}

		private void Add(MenuEntry entry, string[] path)
		{
		}

		private (int, MenuNavigationEntry) GetCurrentSelection()
		{
			return default((int, MenuNavigationEntry));
		}
	}
}
