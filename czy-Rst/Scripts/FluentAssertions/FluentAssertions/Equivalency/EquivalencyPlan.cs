using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Equivalency.Steps;

namespace FluentAssertions.Equivalency
{
	public class EquivalencyPlan : IEnumerable<IEquivalencyStep>, IEnumerable
	{
		private List<IEquivalencyStep> steps = GetDefaultSteps();

		public IEnumerator<IEquivalencyStep> GetEnumerator()
		{
			return steps.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add<TStep>() where TStep : IEquivalencyStep, new()
		{
			InsertBefore<SimpleEqualityEquivalencyStep, TStep>();
		}

		public void AddAfter<TPredecessor, TStep>() where TStep : IEquivalencyStep, new()
		{
			int num = Math.Max(steps.Count - 1, 0);
			IEquivalencyStep equivalencyStep = steps.LastOrDefault((IEquivalencyStep s) => s is TPredecessor);
			if (equivalencyStep != null)
			{
				num = Math.Min(num, steps.LastIndexOf(equivalencyStep) + 1);
			}
			steps.Insert(num, new TStep());
		}

		public void Insert<TStep>() where TStep : IEquivalencyStep, new()
		{
			steps.Insert(0, new TStep());
		}

		public void InsertBefore<TSuccessor, TStep>() where TStep : IEquivalencyStep, new()
		{
			int index = Math.Max(steps.Count - 1, 0);
			IEquivalencyStep equivalencyStep = steps.LastOrDefault((IEquivalencyStep s) => s is TSuccessor);
			if (equivalencyStep != null)
			{
				index = steps.LastIndexOf(equivalencyStep);
			}
			steps.Insert(index, new TStep());
		}

		public void Remove<TStep>() where TStep : IEquivalencyStep
		{
			steps.RemoveAll((IEquivalencyStep s) => s is TStep);
		}

		public void Clear()
		{
			steps.Clear();
		}

		public void Reset()
		{
			steps = GetDefaultSteps();
		}

		private static List<IEquivalencyStep> GetDefaultSteps()
		{
			return new List<IEquivalencyStep>(16)
			{
				new RunAllUserStepsEquivalencyStep(),
				new AutoConversionStep(),
				new ReferenceEqualityEquivalencyStep(),
				new GenericDictionaryEquivalencyStep(),
				new XDocumentEquivalencyStep(),
				new XElementEquivalencyStep(),
				new XAttributeEquivalencyStep(),
				new DictionaryEquivalencyStep(),
				new MultiDimensionalArrayEquivalencyStep(),
				new GenericEnumerableEquivalencyStep(),
				new EnumerableEquivalencyStep(),
				new StringEqualityEquivalencyStep(),
				new EnumEqualityStep(),
				new ValueTypeEquivalencyStep(),
				new StructuralEqualityEquivalencyStep(),
				new SimpleEqualityEquivalencyStep()
			};
		}
	}
}
