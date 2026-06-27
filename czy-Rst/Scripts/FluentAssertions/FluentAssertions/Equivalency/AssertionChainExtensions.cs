using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency
{
	internal static class AssertionChainExtensions
	{
		public static AssertionChain For(this AssertionChain chain, IEquivalencyValidationContext context)
		{
			chain.OverrideCallerIdentifier(() => context.CurrentNode.Subject.Description);
			return chain.WithReportable("configuration", () => context.Options.ToString()).BecauseOf(context.Reason);
		}
	}
}
