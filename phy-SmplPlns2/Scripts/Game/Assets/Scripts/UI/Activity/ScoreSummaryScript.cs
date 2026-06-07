using System.Collections.Generic;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Activity
{
	public class ScoreSummaryScript : WidgetScript
	{
		private Dictionary<string, TextWidget> _columns = new Dictionary<string, TextWidget>();

		public LeaderboardsScript Leaderboards { get; set; }

		public void CreateScoreColumn(string columnId, string className)
		{
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("score-summary-column", base.Widget);
			widget.AddClass(className);
			TextWidget component = widget.GetComponent<TextWidget>();
			_columns[columnId] = component;
		}

		public void SetText(string columnId, string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				_columns[columnId].Visible = true;
				_columns[columnId].Text = text;
			}
			else
			{
				_columns[columnId].Visible = false;
			}
		}

		private void OnScoreButtonClicked(Widget widget)
		{
			Leaderboards?.ToggleLeaderboards();
		}
	}
}
