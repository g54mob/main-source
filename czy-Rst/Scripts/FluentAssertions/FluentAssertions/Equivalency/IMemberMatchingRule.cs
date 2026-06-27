using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency
{
	public interface IMemberMatchingRule
	{
		IMember Match(IMember expectedMember, object subject, INode parent, IEquivalencyOptions options, AssertionChain assertionChain);
	}
}
