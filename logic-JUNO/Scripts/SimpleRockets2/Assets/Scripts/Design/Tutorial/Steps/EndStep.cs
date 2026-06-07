namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class EndStep : InfoStep
	{
		public EndStep(TutorialScript tutorialScript)
			: base(tutorialScript)
		{
		}

		public override void Start()
		{
			base.Start();
			base.TutorialScript.CompleteTutorial();
		}

		public override void Update()
		{
		}
	}
}
