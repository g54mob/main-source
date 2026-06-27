namespace FluentAssertions.Equivalency
{
	public interface IValidateChildNodeEquivalency
	{
		void AssertEquivalencyOf(Comparands comparands, IEquivalencyValidationContext context);
	}
}
