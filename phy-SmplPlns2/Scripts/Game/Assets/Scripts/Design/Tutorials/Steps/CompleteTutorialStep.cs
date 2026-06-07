namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class CompleteTutorialStep : TutorialStep
	{
		public CompleteTutorialStep(TutorialStepBuilderContext context, string stepText = null)
			: base(context, stepText)
		{
		}

		protected override void OnStart()
		{
			base.OnStart();
			base.Tutorial.Complete();
		}
	}
}
