using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Net;
using Assets.Scripts.UI;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Flight.UI
{
	public class DemoTutorialScript : WidgetScript
	{
		private int _pageNumber;

		private Widget _pageWidget;

		private TextWidget _titleText;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_titleText = widget.FindWidget<TextWidget>("title-text");
			if (!Game.Instance.Settings.App.SeenNotifications.Contains("DemoTutorial"))
			{
				Game.Instance.Settings.App.AddNotification("DemoTutorial");
				ShowQuickStartGuide();
			}
		}

		public void ShowQuickStartGuide()
		{
			base.Widget.FindWidget("demo-tutorial-panel").Show(force: true);
			ShowPage(1);
		}

		private void CloseQuickStartGuide()
		{
			base.Widget.FindWidget("demo-tutorial-panel").Hide(null, force: true);
		}

		private string HighlightText(string text)
		{
			foreach (Match item in Regex.Matches(text, "\\[(.+?)\\]"))
			{
				text = text.Replace(item.Value, "<color=#3B8DFF>" + item.Groups[1].Value + "</color>");
			}
			return text;
		}

		private void OnBackClicked(Widget widget)
		{
			ShowPage(_pageNumber - 1);
		}

		private void OnCloseClicked(Widget widget)
		{
			CloseQuickStartGuide();
		}

		private void OnNextClicked(Widget widget)
		{
			ShowPage(_pageNumber + 1);
		}

		private void ShowPage(int pageNumber)
		{
			_pageNumber = pageNumber;
			Widget widget = base.Widget.FindWidget($"page-{pageNumber}");
			if (widget != null)
			{
				_pageWidget?.Hide(null, force: true);
				_pageWidget = widget;
				_pageWidget.Show(force: true);
				_titleText.Text = widget.Data;
				{
					foreach (TextWidget item in _pageWidget.FindWidgetsByClass("shortcuts"))
					{
						if (item != null)
						{
							item.Text = HighlightText(item.Text);
						}
					}
					return;
				}
			}
			CloseQuickStartGuide();
			FlightSceneScript.Instance.FlightUI.ShowMessage("Have fun and thanks for playing!");
		}

		private void ShowSurvey()
		{
			bool flag = false;
			if (Game.Instance.Settings.App.NumberOfApplicationRuns >= 10 && !Game.Instance.Settings.App.SeenNotifications.Contains("DemoSurvey-3"))
			{
				Game.Instance.Settings.App.AddNotification("DemoSurvey-3");
				flag = true;
			}
			else if (Game.Instance.Settings.App.NumberOfApplicationRuns >= 15 && !Game.Instance.Settings.App.SeenNotifications.Contains("DemoSurveyClicked") && !Game.Instance.Settings.App.SeenNotifications.Contains("DemoSurvey-4"))
			{
				Game.Instance.Settings.App.AddNotification("DemoSurvey-4");
				flag = true;
			}
			if (flag)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Got a minute? We'd love to hear what you think about the demo so far!", "Demo Survey");
				messageDialogScript.CancelButtonText = "No";
				messageDialogScript.OkayButtonText = "Yes";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					Game.Instance.Settings.App.AddNotification("DemoSurveyClicked");
					d.Close();
					WebUtility.OpenUrl("http://www.simpleplanes.com/r/Survey", useInGameOverlayIfAvailable: false);
				};
			}
		}
	}
}
