using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Menu.MainMenu
{
	public class CreditsScript : WidgetScript
	{
		private ScrollViewWidget _scrollView;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_scrollView.gameObject.AddComponent<AutoScrollCreditsScript>();
		}

		protected virtual void Update()
		{
			_ = _scrollView.ScrollRect;
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}

		private void Close()
		{
			base.Widget.Hide();
		}

		private void OnCloseClicked(Widget widget)
		{
			Close();
		}
	}
}
