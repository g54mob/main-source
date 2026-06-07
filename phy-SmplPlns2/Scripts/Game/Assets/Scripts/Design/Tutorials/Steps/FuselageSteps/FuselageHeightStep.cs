namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageHeightStep : FuselageSizeStep
	{
		public FuselageHeightStep(TutorialStepBuilderContext context, int partId, FuselageEndType endType, float startHeight, float targetHeight, string stepText = null)
			: base(context, partId, endType, FuselageSizeType.Height, startHeight, targetHeight, stepText)
		{
		}

		public FuselageHeightStep(TutorialStepBuilderContext context, string partName, FuselageEndType endType, float startHeight, float targetHeight, string stepText = null)
			: this(context, context.GetPartIdByName(partName), endType, startHeight, targetHeight, stepText)
		{
		}
	}
}
