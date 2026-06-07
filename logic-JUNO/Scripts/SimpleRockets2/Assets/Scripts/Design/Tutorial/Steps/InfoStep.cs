namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class InfoStep : TutorialStep
	{
		private string _message;

		public InfoStep(TutorialScript tutorialScript, TutorialPanelScript.TutorialPanelType panelType = TutorialPanelScript.TutorialPanelType.Okay)
			: base(-1, tutorialScript)
		{
			base.PanelType = panelType;
		}

		public override void Start()
		{
			base.Start();
			DisplayStep(base.StepText);
		}

		public override void Update()
		{
		}
	}
}
