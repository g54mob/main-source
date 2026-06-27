using FluentAssertions.Equivalency.Tracing;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency
{
	public interface IEquivalencyValidationContext
	{
		INode CurrentNode { get; }

		Reason Reason { get; }

		Tracer Tracer { get; }

		IEquivalencyOptions Options { get; }

		bool IsCyclicReference(object expectation);

		IEquivalencyValidationContext AsNestedMember(IMember expectationMember);

		IEquivalencyValidationContext AsCollectionItem<TItem>(string index);

		IEquivalencyValidationContext AsDictionaryItem<TKey, TExpectation>(TKey key);

		IEquivalencyValidationContext Clone();
	}
}
