namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageRunStep : FuselageOffsetStep
	{
		public FuselageRunStep(TutorialStepBuilderContext context, int partId, float startRun, float targetRun, string stepText = null)
			: base(context, partId, FuselageSectionType.Middle, 0, startRun, targetRun, stepText)
		{
		}

		public FuselageRunStep(TutorialStepBuilderContext context, string partName, float startRun, float targetRun, string stepText = null)
			: this(context, context.GetPartIdByName(partName), startRun, targetRun, stepText)
		{
		}
	}
}
