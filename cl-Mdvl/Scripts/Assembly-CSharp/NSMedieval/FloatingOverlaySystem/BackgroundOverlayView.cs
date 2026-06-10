using NSEipix.Base;

namespace NSMedieval.FloatingOverlaySystem
{
	public class BackgroundOverlayView : FloatingOverlayView
	{
		private void Start()
		{
			MonoSingleton<FloatingOverlayManager>.Instance.RegisterBackgroundView(this);
		}
	}
}
