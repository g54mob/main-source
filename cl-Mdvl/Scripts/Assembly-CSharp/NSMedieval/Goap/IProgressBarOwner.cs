using NSMedieval.FloatingOverlaySystem;

namespace NSMedieval.Goap
{
	public interface IProgressBarOwner
	{
		ProgressBarFloatingElement GetProgressBar(OverlayProgressBarType type = OverlayProgressBarType.None);

		void DestroyProgressBar(OverlayProgressBarType type);
	}
}
