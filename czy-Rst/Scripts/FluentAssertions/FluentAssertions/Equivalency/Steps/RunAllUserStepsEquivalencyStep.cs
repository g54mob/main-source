namespace FluentAssertions.Equivalency.Steps
{
	public class RunAllUserStepsEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			foreach (IEquivalencyStep userEquivalencyStep in context.Options.UserEquivalencySteps)
			{
				if (userEquivalencyStep.Handle(comparands, context, valueChildNodes) == EquivalencyResult.EquivalencyProven)
				{
					return EquivalencyResult.EquivalencyProven;
				}
			}
			return EquivalencyResult.ContinueWithNext;
		}
	}
}
