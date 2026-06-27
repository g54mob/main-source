using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class StructuralEqualityEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (!context.CurrentNode.IsRoot && !context.Options.IsRecursive)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			if (comparands.Expectation == null)
			{
				assertionChain.BecauseOf(context.Reason).FailWith("Expected {context:subject} to be <null>{reason}, but found {0}.", comparands.Subject);
			}
			else if (comparands.Subject == null)
			{
				assertionChain.BecauseOf(context.Reason).FailWith("Expected {context:object} to be {0}{reason}, but found {1}.", comparands.Expectation, comparands.Subject);
			}
			else
			{
				IMember[] array = GetMembersFromExpectation(context.CurrentNode, comparands, context.Options).ToArray();
				if (context.CurrentNode.IsRoot && array.Length == 0)
				{
					throw new InvalidOperationException("No members were found for comparison. Please specify some members to include in the comparison or choose a more meaningful assertion.");
				}
				IMember[] array2 = array;
				foreach (IMember selectedMember in array2)
				{
					AssertMemberEquality(comparands, context, valueChildNodes, selectedMember, context.Options);
				}
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static void AssertMemberEquality(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency parent, IMember selectedMember, IEquivalencyOptions options)
		{
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			IMember member = FindMatchFor(selectedMember, context.CurrentNode, comparands.Subject, options, assertionChain);
			if (member != null)
			{
				Comparands comparands2 = new Comparands
				{
					Subject = member.GetValue(comparands.Subject),
					Expectation = selectedMember.GetValue(comparands.Expectation),
					CompileTimeType = selectedMember.Type
				};
				selectedMember.AdjustForRemappedSubject(member);
				parent.AssertEquivalencyOf(comparands2, context.AsNestedMember(selectedMember));
			}
		}

		private static IMember FindMatchFor(IMember selectedMember, INode currentNode, object subject, IEquivalencyOptions config, AssertionChain assertionChain)
		{
			IEnumerable<IMember> source = from rule in config.MatchingRules
				let match = rule.Match(selectedMember, subject, currentNode, config, assertionChain)
				where match != null
				select match;
			if (config.IgnoreNonBrowsableOnSubject)
			{
				source = source.Where((IMember member) => member.IsBrowsable);
			}
			return source.FirstOrDefault();
		}

		private static IEnumerable<IMember> GetMembersFromExpectation(INode currentNode, Comparands comparands, IEquivalencyOptions options)
		{
			IEnumerable<IMember> enumerable = Array.Empty<IMember>();
			foreach (IMemberSelectionRule selectionRule in options.SelectionRules)
			{
				enumerable = selectionRule.SelectMembers(currentNode, enumerable, new MemberSelectionContext(comparands.CompileTimeType, comparands.RuntimeType, options));
			}
			return enumerable;
		}
	}
}
