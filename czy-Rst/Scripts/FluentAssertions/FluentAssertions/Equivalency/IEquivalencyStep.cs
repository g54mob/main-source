namespace FluentAssertions.Equivalency
{
	public interface IEquivalencyStep
	{
		EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes);
	}
}
