using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentAssertions.Collections.MaximumMatching
{
	internal class MaximumMatchingProblem<TValue>
	{
		public List<Predicate<TValue>> Predicates { get; } = new List<Predicate<TValue>>();

		public List<Element<TValue>> Elements { get; } = new List<Element<TValue>>();

		public MaximumMatchingProblem(IEnumerable<Expression<Func<TValue, bool>>> predicates, IEnumerable<TValue> elements)
		{
			Predicates.AddRange(predicates.Select((Expression<Func<TValue, bool>> predicate, int index) => new Predicate<TValue>(predicate, index)));
			Elements.AddRange(elements.Select((TValue element, int index) => new Element<TValue>(element, index)));
		}

		public MaximumMatchingSolution<TValue> Solve()
		{
			return new MaximumMatchingSolver<TValue>(this).Solve();
		}
	}
}
