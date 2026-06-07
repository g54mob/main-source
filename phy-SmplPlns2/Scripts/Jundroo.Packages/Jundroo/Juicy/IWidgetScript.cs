using Jundroo.Juicy.Widgets;

namespace Jundroo.Juicy
{
	public interface IWidgetScript
	{
		bool HandleChildEvents { get; }

		void OnWidgetInitialized(Widget widget);
	}
}
