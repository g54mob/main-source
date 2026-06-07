namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageRiseStep : FuselageOffsetStep
	{
		public FuselageRiseStep(TutorialStepBuilderContext context, int partId, float startRise, float targetRise, string stepText = null)
			: base(context, partId, FuselageSectionType.Middle, 1, startRise, targetRise, stepText)
		{
		}

		public FuselageRiseStep(TutorialStepBuilderContext context, string partName, float startRise, float targetRise, string stepText = null)
			: this(context, context.GetPartIdByName(partName), startRise, targetRise, stepText)
		{
		}
	}
}
