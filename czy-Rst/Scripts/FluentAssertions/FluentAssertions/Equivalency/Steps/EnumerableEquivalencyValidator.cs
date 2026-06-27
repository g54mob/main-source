using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Equivalency.Execution;
using FluentAssertions.Equivalency.Tracing;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	internal class EnumerableEquivalencyValidator
	{
		private const int FailedItemsFastFailThreshold = 10;

		private readonly AssertionChain assertionChain;

		private readonly IValidateChildNodeEquivalency parent;

		private readonly IEquivalencyValidationContext context;

		private List<int> unmatchedSubjectIndexes;

		public bool Recursive { get; init; }

		public OrderingRuleCollection OrderingRules { get; init; }

		public EnumerableEquivalencyValidator(AssertionChain assertionChain, IValidateChildNodeEquivalency parent, IEquivalencyValidationContext context)
		{
			this.assertionChain = assertionChain;
			this.parent = parent;
			this.context = context;
			Recursive = false;
		}

		public void Execute<T>(object[] subject, T[] expectation)
		{
			if (!AssertIsNotNull(expectation, subject) || !AssertCollectionsHaveSameCount(subject, expectation))
			{
				return;
			}
			if (Recursive)
			{
				using (context.Tracer.WriteBlock((INode member) => FormattableString.Invariant($"Structurally comparing {subject} and expectation {expectation} at {member.Expectation}")))
				{
					AssertElementGraphEquivalency(subject, expectation, context.CurrentNode);
					return;
				}
			}
			using (context.Tracer.WriteBlock((INode member) => FormattableString.Invariant($"Comparing subject {subject} and expectation {expectation} at {member.Expectation} using simple value equality")))
			{
				AssertionExtensions.Should(subject).BeEquivalentTo(expectation, "");
			}
		}

		private bool AssertIsNotNull(object expectation, object[] subject)
		{
			assertionChain.ForCondition(expectation != null).FailWith("Expected {context:subject} to be <null>, but found {0}.", new object[1] { subject });
			return assertionChain.Succeeded;
		}

		private bool AssertCollectionsHaveSameCount<T>(ICollection<object> subject, ICollection<T> expectation)
		{
			assertionChain.AssertEitherCollectionIsNotEmpty(subject, expectation).Then.AssertCollectionHasEnoughItems(subject, expectation).Then.AssertCollectionHasNotTooManyItems(subject, expectation);
			return assertionChain.Succeeded;
		}

		private void AssertElementGraphEquivalency<T>(object[] subjects, T[] expectations, INode currentNode)
		{
			unmatchedSubjectIndexes = Enumerable.Range(0, subjects.Length).ToList();
			if (OrderingRules.IsOrderingStrictFor(new ObjectInfo(new Comparands(subjects, expectations, typeof(T[])), currentNode)))
			{
				AssertElementGraphEquivalencyWithStrictOrdering(subjects, expectations);
			}
			else
			{
				AssertElementGraphEquivalencyWithLooseOrdering(subjects, expectations);
			}
		}

		private void AssertElementGraphEquivalencyWithStrictOrdering<T>(object[] subjects, T[] expectations)
		{
			int num = 0;
			foreach (int index in Enumerable.Range(0, expectations.Length))
			{
				T expectation = expectations[index];
				using (context.Tracer.WriteBlock((INode member) => FormattableString.Invariant($"Strictly comparing expectation {expectation} at {member.Expectation} to item with index {index} in {subjects}")))
				{
					if (StrictlyMatchAgainst(subjects, expectation, index))
					{
						continue;
					}
					num++;
					if (num >= 10)
					{
						context.Tracer.WriteLine((INode member) => $"Aborting strict order comparison of collections after {10} items failed at {member.Expectation}");
						break;
					}
				}
			}
		}

		private void AssertElementGraphEquivalencyWithLooseOrdering<T>(object[] subjects, T[] expectations)
		{
			int num = 0;
			foreach (int index in Enumerable.Range(0, expectations.Length))
			{
				T expectation = expectations[index];
				using (context.Tracer.WriteBlock((INode member) => FormattableString.Invariant($"Finding the best match of {expectation} within all items in {subjects} at {member.Expectation}[{index}]")))
				{
					if (LooselyMatchAgainst(subjects, expectation, index))
					{
						continue;
					}
					num++;
					if (num >= 10)
					{
						context.Tracer.WriteLine((INode member) => $"Fail failing loose order comparison of collection after {10} items failed at {member.Expectation}");
						break;
					}
				}
			}
		}

		private bool LooselyMatchAgainst<T>(IList<object> subjects, T expectation, int expectationIndex)
		{
			AssertionResultSet assertionResultSet = new AssertionResultSet();
			int index = 0;
			GetTraceMessage getTraceMessage = (INode member) => $"Comparing subject at {member.Subject}[{index}] with the expectation at {member.Expectation}[{expectationIndex}]";
			int num = -1;
			for (int num2 = 0; num2 < unmatchedSubjectIndexes.Count; num2++)
			{
				index = unmatchedSubjectIndexes[num2];
				object subject = subjects[index];
				using (context.Tracer.WriteBlock(getTraceMessage))
				{
					string[] failures = TryToMatch(subject, expectation, expectationIndex);
					assertionResultSet.AddSet(index, failures);
					if (assertionResultSet.ContainsSuccessfulSet())
					{
						context.Tracer.WriteLine((INode _) => "It's a match");
						num = num2;
						break;
					}
					context.Tracer.WriteLine((INode _) => $"Contained {failures.Length} failures");
				}
			}
			if (num != -1)
			{
				unmatchedSubjectIndexes.RemoveAt(num);
			}
			string[] theFailuresForTheSetWithTheFewestFailures = assertionResultSet.GetTheFailuresForTheSetWithTheFewestFailures(expectationIndex);
			foreach (string failure in theFailuresForTheSetWithTheFewestFailures)
			{
				assertionChain.AddPreFormattedFailure(failure);
			}
			return num != -1;
		}

		private string[] TryToMatch<T>(object subject, T expectation, int expectationIndex)
		{
			using AssertionScope assertionScope = new AssertionScope();
			parent.AssertEquivalencyOf(new Comparands(subject, expectation, typeof(T)), context.AsCollectionItem<T>(expectationIndex));
			return assertionScope.Discard();
		}

		private bool StrictlyMatchAgainst<T>(object[] subjects, T expectation, int expectationIndex)
		{
			using AssertionScope assertionScope = new AssertionScope();
			object subject = subjects[expectationIndex];
			IEquivalencyValidationContext equivalencyValidationContext = context.AsCollectionItem<T>(expectationIndex);
			parent.AssertEquivalencyOf(new Comparands(subject, expectation, typeof(T)), equivalencyValidationContext);
			return !assertionScope.HasFailures();
		}
	}
}
