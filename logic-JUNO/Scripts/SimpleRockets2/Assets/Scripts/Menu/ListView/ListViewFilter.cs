using System.Collections.Generic;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewFilter
	{
		public bool Enabled { get; set; }

		public bool InvertEnabledLogic { get; set; }

		public IReadOnlyList<string> Keywords { get; }

		public string Text { get; }

		public string Tooltip { get; }

		public ListViewFilterType Type { get; }

		public ListViewFilter(string text, string tooltip, ListViewFilterType type, bool invertEnabledLogic, params string[] keywords)
		{
			Text = text;
			Tooltip = tooltip;
			Type = type;
			InvertEnabledLogic = invertEnabledLogic;
			Keywords = new List<string>(keywords);
		}
	}
}
