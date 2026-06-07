namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageLengthStep : FuselageOffsetStep
	{
		public FuselageLengthStep(TutorialStepBuilderContext context, int partId, FuselageEndType endType, float startLength, float targetLength, string stepText = null)
			: base(context, partId, (endType == FuselageEndType.Front) ? FuselageSectionType.Front : FuselageSectionType.Back, 2, startLength, targetLength, stepText)
		{
		}

		public FuselageLengthStep(TutorialStepBuilderContext context, string partName, FuselageEndType endType, float startLength, float targetLength, string stepText = null)
			: this(context, context.GetPartIdByName(partName), endType, startLength, targetLength, stepText)
		{
		}
	}
}
