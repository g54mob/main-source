namespace FluentAssertions.Equivalency.Steps
{
	public class ReferenceEqualityEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (comparands.Subject != comparands.Expectation)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			return EquivalencyResult.EquivalencyProven;
		}
	}
}
