namespace FluentAssertions.Equivalency
{
	public abstract class EquivalencyStep<T> : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (!typeof(T).IsAssignableFrom(comparands.GetExpectedType(context.Options)))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			return OnHandle(comparands, context, valueChildNodes);
		}

		protected abstract EquivalencyResult OnHandle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency nestedValidator);
	}
}
