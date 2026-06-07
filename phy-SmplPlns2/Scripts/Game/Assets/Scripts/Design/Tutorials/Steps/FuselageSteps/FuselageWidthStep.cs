namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageWidthStep : FuselageSizeStep
	{
		public FuselageWidthStep(TutorialStepBuilderContext context, int partId, FuselageEndType endType, float startWidth, float targetWidth, string stepText = null)
			: base(context, partId, endType, FuselageSizeType.Width, startWidth, targetWidth, stepText)
		{
		}

		public FuselageWidthStep(TutorialStepBuilderContext context, string partName, FuselageEndType endType, float startWidth, float targetWidth, string stepText = null)
			: this(context, context.GetPartIdByName(partName), endType, startWidth, targetWidth, stepText)
		{
		}
	}
}
