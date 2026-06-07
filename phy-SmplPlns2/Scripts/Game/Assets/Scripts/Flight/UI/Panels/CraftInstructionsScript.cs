using System.Collections;
using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class CraftInstructionsScript : PanelDialogScript
	{
		private TextWidget _instructionsText;

		private bool _notice;

		private Widget _showOnStart;

		public override bool IsModal => false;

		public string Text
		{
			get
			{
				return _instructionsText.Text;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					_instructionsText.Text = value;
				}
				else
				{
					_instructionsText.Text = "This craft does not have any instructions.";
				}
				StartCoroutine(ResizeCoroutine());
			}
		}

		public override void Close()
		{
			base.Close();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_showOnStart = widget.FindWidget("show-on-startup-button");
			_instructionsText = base.Widget.FindWidget<TextWidget>("craft-instructions-text");
			UpdateShowOnStartButton();
		}

		public void ShowXmlModNotice(bool show)
		{
			_notice = show;
			base.Widget.FindWidget("xml-mod-notice").Visible = show;
		}

		private void OnCloseButtonClicked(Widget widget)
		{
			Close();
		}

		private void OnShowOnStartClicked(Widget widget)
		{
			bool flag = PlayerPrefs.GetInt("CraftInstructionsVisible") > 0;
			PlayerPrefs.SetInt("CraftInstructionsVisible", (!flag) ? 1 : 0);
			UpdateShowOnStartButton();
		}

		private void OnXmlModClicked(Widget widget)
		{
			Widget widget2 = base.Widget.FindWidget("xml-mod-details");
			widget2.Visible = !widget2.Visible;
		}

		private IEnumerator ResizeCoroutine()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			TextMeshProUGUI textMeshPro = _instructionsText.TextMeshPro;
			float a = 500f;
			if (float.TryParse(base.Widget.Stylesheet.GetConstant("MaxHeight"), out var result))
			{
				a = result;
			}
			_ = textMeshPro.textBounds.size;
			base.Widget.FindWidget("scroll-view").Height = Mathf.Min(a, textMeshPro.textBounds.size.y + (_notice ? 100f : 50f));
		}

		private void UpdateShowOnStartButton()
		{
			bool flag = PlayerPrefs.GetInt("CraftInstructionsVisible", 1) > 0;
			_showOnStart.EnableClass("checked", flag);
		}
	}
}
