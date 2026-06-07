using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public interface IFlyout
	{
		string Id { get; }

		bool IsClosing { get; }

		bool IsOpen { get; }

		string Title { get; set; }

		Widget Widget { get; }

		float Width { get; }

		event FlyoutDelegate Closed;

		event FlyoutDelegate HeaderClicked;

		event FlyoutDelegate Opened;

		void Close();

		void Show(bool show);
	}
}
