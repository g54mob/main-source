public static class TransitionCameraControlExtension
{
	public static bool Contains(this TransitionCameraControl superset, TransitionCameraControl subset)
	{
		return (superset & subset) == subset;
	}
}
