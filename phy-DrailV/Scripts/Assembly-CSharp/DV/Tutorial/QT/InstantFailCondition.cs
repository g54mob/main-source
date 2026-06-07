namespace DV.Tutorial.QT
{
	public class InstantFailCondition : AQuickTutorialCondition
	{
		private string message;

		public InstantFailCondition(string message)
		{
			this.message = message;
		}

		public override string Check()
		{
			return message;
		}

		public static QuickTutorial CreateTutorial(string message)
		{
			QuickTutorial quickTutorial = new QuickTutorial(userControlAllowed: false);
			quickTutorial.AddStartingCheck(new InstantFailCondition(message));
			new QuickTutorialPhase().Add(new NOPStep());
			return quickTutorial;
		}
	}
}
