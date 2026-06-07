using Assets.Scripts.UI;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Menu.MainMenu
{
	public class NewsScript : WidgetScript
	{
		private FlyoutScript _flyout;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
		}

		protected void Start()
		{
			_flyout = GetComponentInParent<FlyoutScript>();
		}

		private void OnCreditsButtonClicked(Widget widget)
		{
			widget.FindParentWidget("main-ui").FindWidget("credits").Show(force: true);
			_flyout.Close();
		}
	}
}
