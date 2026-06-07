using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class EditorToolbar
	{
		[SerializeField]
		private Color _activeTabColor = Color.green;

		[SerializeField]
		private int _numTabsPerRow = 3;

		[SerializeField]
		private EditorToolbarTab[] _tabs;

		[SerializeField]
		private int _activeTabIndex;

		public int ActiveTabIndex => _activeTabIndex;

		public EditorToolbarTab ActiveTab => _tabs[_activeTabIndex];

		public Color ActiveTabColor
		{
			get
			{
				return _activeTabColor;
			}
			set
			{
				_activeTabColor = value;
			}
		}

		public int NumTabsPerRow
		{
			get
			{
				return _numTabsPerRow;
			}
			set
			{
				_numTabsPerRow = Mathf.Max(1, value);
			}
		}

		public int NumTabs => _tabs.Length;

		public EditorToolbar(EditorToolbarTab[] tabs, int numTabsPerRow, Color activeTabColor)
		{
			_tabs = tabs;
			_activeTabColor = activeTabColor;
			_numTabsPerRow = numTabsPerRow;
		}

		public EditorToolbarTab GetTabByIndex(int tabIndex)
		{
			return _tabs[tabIndex];
		}
	}
}
