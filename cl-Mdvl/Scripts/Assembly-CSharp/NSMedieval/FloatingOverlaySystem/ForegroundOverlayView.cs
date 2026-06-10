using NSEipix.Base;

namespace NSMedieval.FloatingOverlaySystem
{
	public class ForegroundOverlayView : FloatingOverlayView
	{
		private void Start()
		{
			MonoSingleton<FloatingOverlayManager>.Instance.RegisterForegroundView(this);
		}
	}
}
