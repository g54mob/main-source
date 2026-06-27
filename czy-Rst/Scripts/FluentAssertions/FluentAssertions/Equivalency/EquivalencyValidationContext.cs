using System;
using FluentAssertions.Equivalency.Execution;
using FluentAssertions.Equivalency.Tracing;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency
{
	public class EquivalencyValidationContext : IEquivalencyValidationContext
	{
		private Tracer tracer;

		public INode CurrentNode { get; }

		public Reason Reason { get; set; }

		public Tracer Tracer => tracer ?? (tracer = new Tracer(CurrentNode, TraceWriter));

		public IEquivalencyOptions Options { get; }

		private CyclicReferenceDetector CyclicReferenceDetector { get; set; }

		public ITraceWriter TraceWriter { get; set; }

		public EquivalencyValidationContext(INode root, IEquivalencyOptions options)
		{
			Options = options;
			CurrentNode = root;
			CyclicReferenceDetector = new CyclicReferenceDetector();
		}

		public IEquivalencyValidationContext AsNestedMember(IMember expectationMember)
		{
			return new EquivalencyValidationContext(expectationMember, Options)
			{
				Reason = Reason,
				TraceWriter = TraceWriter,
				CyclicReferenceDetector = CyclicReferenceDetector
			};
		}

		public IEquivalencyValidationContext AsCollectionItem<TItem>(string index)
		{
			return new EquivalencyValidationContext(Node.FromCollectionItem<TItem>(index, CurrentNode), Options)
			{
				Reason = Reason,
				TraceWriter = TraceWriter,
				CyclicReferenceDetector = CyclicReferenceDetector
			};
		}

		public IEquivalencyValidationContext AsDictionaryItem<TKey, TExpectation>(TKey key)
		{
			return new EquivalencyValidationContext(Node.FromDictionaryItem<TExpectation>(key, CurrentNode), Options)
			{
				Reason = Reason,
				TraceWriter = TraceWriter,
				CyclicReferenceDetector = CyclicReferenceDetector
			};
		}

		public IEquivalencyValidationContext Clone()
		{
			return new EquivalencyValidationContext(CurrentNode, Options)
			{
				Reason = Reason,
				TraceWriter = TraceWriter,
				CyclicReferenceDetector = CyclicReferenceDetector
			};
		}

		public bool IsCyclicReference(object expectation)
		{
			bool flag = expectation != null;
			if (flag)
			{
				EqualityStrategy equalityStrategy = Options.GetEqualityStrategy(expectation.GetType());
				bool flag2 = ((equalityStrategy == EqualityStrategy.Members || equalityStrategy == EqualityStrategy.ForceMembers) ? true : false);
				flag = flag2;
			}
			bool value = flag;
			ObjectReference reference = new ObjectReference(expectation, CurrentNode.Subject.PathAndName, value);
			return CyclicReferenceDetector.IsCyclicReference(reference);
		}

		public override string ToString()
		{
			return FormattableString.Invariant($"{{Path=\"{CurrentNode.Subject.PathAndName}\"}}");
		}
	}
}
