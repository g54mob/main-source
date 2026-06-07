namespace DV.Tutorial.QT
{
	public class MetaTutorialHackService : ATutorialService
	{
		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			QuickTutorialHost.MetaTutorialHackActive = true;
		}

		public override void StopService(bool fullyCompleted)
		{
			QuickTutorialHost.MetaTutorialHackActive = false;
		}

		public override void UpdateService()
		{
		}
	}
}
