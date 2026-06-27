using System;
using System.Linq;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency
{
	internal class MultiDimensionalArrayEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (!(comparands.Expectation is Array { Rank: not 1 } array))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			if (AreComparable(comparands, array, AssertionChain.GetOrCreate().For(context)))
			{
				if (array.Length == 0)
				{
					return EquivalencyResult.EquivalencyProven;
				}
				Digit digit = BuildDigitsRepresentingAllIndices(array);
				do
				{
					int[] indices = digit.GetIndices();
					object value = ((Array)comparands.Subject).GetValue(indices);
					string index = string.Join(",", indices);
					object value2 = array.GetValue(indices);
					IEquivalencyValidationContext context2 = context.AsCollectionItem<object>(index);
					valueChildNodes.AssertEquivalencyOf(new Comparands(value, value2, typeof(object)), context2);
				}
				while (digit.Increment());
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static Digit BuildDigitsRepresentingAllIndices(Array subjectAsArray)
		{
			return Enumerable.Range(0, subjectAsArray.Rank).Reverse().Aggregate(null, (Digit next, int rank) => new Digit(subjectAsArray.GetLength(rank), next));
		}

		private static bool AreComparable(Comparands comparands, Array expectationAsArray, AssertionChain assertionChain)
		{
			if (IsArray(comparands.Subject, assertionChain) && HaveSameRank(comparands.Subject, expectationAsArray, assertionChain))
			{
				return HaveSameDimensions(comparands.Subject, expectationAsArray, assertionChain);
			}
			return false;
		}

		private static bool IsArray(object type, AssertionChain assertionChain)
		{
			assertionChain.ForCondition(type != null).FailWith("Cannot compare a multi-dimensional array to <null>.").Then.ForCondition(type is Array).FailWith("Cannot compare a multi-dimensional array to something else.");
			return assertionChain.Succeeded;
		}

		private static bool HaveSameDimensions(object subject, Array expectation, AssertionChain assertionChain)
		{
			bool flag = true;
			for (int i = 0; i < expectation.Rank; i++)
			{
				int length = ((Array)subject).GetLength(i);
				int length2 = expectation.GetLength(i);
				assertionChain.ForCondition(length2 == length).FailWith("Expected dimension {0} to contain {1} item(s), but found {2}.", i, length2, length);
				flag &= assertionChain.Succeeded;
			}
			return flag;
		}

		private static bool HaveSameRank(object subject, Array expectation, AssertionChain assertionChain)
		{
			Array array = (Array)subject;
			assertionChain.ForCondition(array.Rank == expectation.Rank).FailWith("Expected {context:array} to have {0} dimension(s), but it has {1}.", expectation.Rank, array.Rank);
			return assertionChain.Succeeded;
		}
	}
}
