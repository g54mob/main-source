using DV.CabControls;
using DV.Utils;

public static class MouseWheelHoverScrollerExtensions
{
	public static bool IsGrabbedOrHoverScrolled(this ControlImplBase control)
	{
		if (!control.IsGrabbed())
		{
			return control.IsHoverScrolled();
		}
		return true;
	}

	public static bool IsHoverScrolled(this ControlImplBase control)
	{
		if (control.gameObject == SingletonBehaviour<MouseWheelHoverScroller>.Instance.CurrentItem)
		{
			return SingletonBehaviour<MouseWheelHoverScroller>.Instance.IsScrolling;
		}
		return false;
	}
}
