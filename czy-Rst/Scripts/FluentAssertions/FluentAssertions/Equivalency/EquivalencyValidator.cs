using System;
using FluentAssertions.Equivalency.Tracing;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency
{
	internal class EquivalencyValidator : IValidateChildNodeEquivalency
	{
		private const int MaxDepth = 10;

		public void AssertEquality(Comparands comparands, EquivalencyValidationContext context)
		{
			using AssertionScope assertionScope = new AssertionScope();
			RecursivelyAssertEquivalencyOf(comparands, context);
			if (context.TraceWriter != null)
			{
				assertionScope.AppendTracing(context.TraceWriter.ToString());
			}
		}

		private void RecursivelyAssertEquivalencyOf(Comparands comparands, IEquivalencyValidationContext context)
		{
			AssertEquivalencyOf(comparands, context);
		}

		public void AssertEquivalencyOf(Comparands comparands, IEquivalencyValidationContext context)
		{
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context).BecauseOf(context.Reason);
			if (ShouldContinueThisDeep(context.CurrentNode, context.Options, assertionChain))
			{
				if (!context.IsCyclicReference(comparands.Expectation))
				{
					TryToProveNodesAreEquivalent(comparands, context);
				}
				else if (context.Options.CyclicReferenceHandling == CyclicReferenceHandling.ThrowException)
				{
					assertionChain.FailWith("Expected {context:subject} to be {0}{reason}, but it contains a cyclic reference.", comparands.Expectation);
				}
				else
				{
					AssertEquivalencyForCyclicReference(comparands, assertionChain);
				}
			}
		}

		private static bool ShouldContinueThisDeep(INode currentNode, IEquivalencyOptions options, AssertionChain assertionChain)
		{
			int num;
			if (!options.AllowInfiniteRecursion)
			{
				num = ((currentNode.Depth <= 10) ? 1 : 0);
				if (num == 0)
				{
					assertionChain.FailWith($"The maximum recursion depth of {10} was reached.  ");
				}
			}
			else
			{
				num = 1;
			}
			return (byte)num != 0;
		}

		private static void AssertEquivalencyForCyclicReference(Comparands comparands, AssertionChain assertionChain)
		{
			if (comparands.Subject != comparands.Expectation && comparands.Subject == null)
			{
				assertionChain.ReuseOnce();
				comparands.Subject.Should().BeSameAs(comparands.Expectation, "");
			}
		}

		private void TryToProveNodesAreEquivalent(Comparands comparands, IEquivalencyValidationContext context)
		{
			using (context.Tracer.WriteBlock((INode node) => node.Expectation.Description))
			{
				foreach (IEquivalencyStep item in AssertionConfiguration.Current.Equivalency.Plan)
				{
					if (item.Handle(comparands, context, this) == EquivalencyResult.EquivalencyProven)
					{
						context.Tracer.WriteLine(GetMessage(item));
						return;
					}
				}
				throw new NotSupportedException($"Do not know how to compare {comparands.Subject} and {comparands.Expectation}. Please report an issue through https://www.fluentassertions.com.");
			}
			static GetTraceMessage GetMessage(IEquivalencyStep step)
			{
				return (INode _) => "Equivalency was proven by " + step.GetType().Name;
			}
		}
	}
}
