namespace DV.Tutorial.QT
{
	public abstract class ATutorialService
	{
		public abstract void StartService(QuickTutorialHost host, QuickTutorialPhase phase);

		public abstract void StopService(bool fullyCompleted);

		public abstract void UpdateService();
	}
}
