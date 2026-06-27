using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Collections
{
	[DebuggerNonUserCode]
	public class SubsequentOrderingAssertions<T> : GenericCollectionAssertions<IEnumerable<T>, T>
	{
		private readonly IOrderedEnumerable<T> previousOrderedEnumerable;

		private bool subsequentOrdering;

		public SubsequentOrderingAssertions(IEnumerable<T> actualValue, IOrderedEnumerable<T> previousOrderedEnumerable, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
			this.previousOrderedEnumerable = previousOrderedEnumerable;
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> ThenBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return ThenBeInAscendingOrder(propertyExpression, GenericCollectionAssertions<IEnumerable<T>, T, GenericCollectionAssertions<IEnumerable<T>, T>>.GetComparer<TSelector>(), because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> ThenBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return ThenBeOrderedBy(propertyExpression, comparer, SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> ThenBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return ThenBeInDescendingOrder(propertyExpression, GenericCollectionAssertions<IEnumerable<T>, T, GenericCollectionAssertions<IEnumerable<T>, T>>.GetComparer<TSelector>(), because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> ThenBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return ThenBeOrderedBy(propertyExpression, comparer, SortOrder.Descending, because, becauseArgs);
		}

		private AndConstraint<SubsequentOrderingAssertions<T>> ThenBeOrderedBy<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, SortOrder direction, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			subsequentOrdering = true;
			return BeOrderedBy(propertyExpression, comparer, direction, because, becauseArgs);
		}

		internal sealed override IOrderedEnumerable<T> GetOrderedEnumerable<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, SortOrder direction, ICollection<T> unordered)
		{
			if (subsequentOrdering)
			{
				Func<T, TSelector> keySelector = propertyExpression.Compile();
				if (direction != SortOrder.Ascending)
				{
					return previousOrderedEnumerable.ThenByDescending(keySelector, comparer);
				}
				return previousOrderedEnumerable.ThenBy(keySelector, comparer);
			}
			return base.GetOrderedEnumerable(propertyExpression, comparer, direction, unordered);
		}
	}
}
