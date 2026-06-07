namespace Jundroo.Juicy.Widgets.Extra
{
	public interface IWidgetAnimation
	{
		event WidgetAnimationDelegate Complete;

		void Start();

		void Stop(bool complete);
	}
}
