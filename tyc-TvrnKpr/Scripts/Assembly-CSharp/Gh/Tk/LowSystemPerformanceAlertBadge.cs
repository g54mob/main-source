namespace Gh.Tk
{
	public class LowSystemPerformanceAlertBadge : AlertBadgeBase
	{
		protected override bool UpdateInternal()
		{
			return false;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
