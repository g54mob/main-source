using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions.Common;

namespace FluentAssertions.Execution
{
	internal static class GivenSelectorExtensions
	{
		private sealed class CollectionWithIndex<T> : ICollection<T>, IEnumerable<T>, IEnumerable
		{
			public ICollection<T> Items { get; }

			public int Index { get; }

			public int Count => Items.Count;

			public bool IsReadOnly => Items.IsReadOnly;

			public CollectionWithIndex(ICollection<T> items, int index)
			{
				Items = items;
				Index = index;
			}

			public void Add(T item)
			{
				Items.Add(item);
			}

			public void Clear()
			{
				Items.Clear();
			}

			public bool Contains(T item)
			{
				return Items.Contains(item);
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				Items.CopyTo(array, arrayIndex);
			}

			public IEnumerator<T> GetEnumerator()
			{
				return Items.GetEnumerator();
			}

			public bool Remove(T item)
			{
				return Items.Remove(item);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return Items.GetEnumerator();
			}
		}

		public static ContinuationOfGiven<IEnumerable<T>> AssertCollectionIsNotNull<T>(this GivenSelector<IEnumerable<T>> givenSelector)
		{
			return givenSelector.ForCondition((IEnumerable<T> items) => items != null).FailWith("but found collection is <null>.");
		}

		public static ContinuationOfGiven<ICollection<T>> AssertEitherCollectionIsNotEmpty<T>(this GivenSelector<ICollection<T>> givenSelector, int length)
		{
			return givenSelector.ForCondition((ICollection<T> items) => items.Count > 0 || length == 0).FailWith("but found empty collection.").Then.ForCondition((ICollection<T> items) => items.Count == 0 || length > 0).FailWith("but found {0}.", (ICollection<T> items) => items);
		}

		public static ContinuationOfGiven<ICollection<T>> AssertCollectionHasEnoughItems<T>(this GivenSelector<IEnumerable<T>> givenSelector, int length)
		{
			return givenSelector.Given((IEnumerable<T> items) => items.ConvertOrCastToCollection()).AssertCollectionHasEnoughItems(length);
		}

		public static ContinuationOfGiven<ICollection<T>> AssertCollectionHasEnoughItems<T>(this GivenSelector<ICollection<T>> givenSelector, int length)
		{
			return givenSelector.ForCondition((ICollection<T> items) => items.Count >= length).FailWith("but {0} contains {1} item(s) less.", (ICollection<T> items) => items, (ICollection<T> items) => length - items.Count);
		}

		public static ContinuationOfGiven<ICollection<T>> AssertCollectionHasNotTooManyItems<T>(this GivenSelector<ICollection<T>> givenSelector, int length)
		{
			return givenSelector.ForCondition((ICollection<T> items) => items.Count <= length).FailWith("but {0} contains {1} item(s) too many.", (ICollection<T> items) => items, (ICollection<T> items) => items.Count - length);
		}

		public static ContinuationOfGiven<ICollection<T>> AssertCollectionsHaveSameCount<T>(this GivenSelector<ICollection<T>> givenSelector, int length)
		{
			return givenSelector.AssertEitherCollectionIsNotEmpty(length).Then.AssertCollectionHasEnoughItems(length).Then.AssertCollectionHasNotTooManyItems(length);
		}

		public static ContinuationOfGiven<ICollection<TActual>> AssertCollectionsHaveSameItems<TActual, TExpected>(this GivenSelector<ICollection<TActual>> givenSelector, ICollection<TExpected> expected, Func<ICollection<TActual>, ICollection<TExpected>, int> findIndex)
		{
			return givenSelector.Given((Func<ICollection<TActual>, ICollection<TActual>>)((ICollection<TActual> actual) => new CollectionWithIndex<TActual>(actual, findIndex(actual, expected)))).ForCondition((ICollection<TActual> diff) => diff.As<CollectionWithIndex<TActual>>().Index == -1).FailWith("but {0} differs at index {1}.", (ICollection<TActual> diff) => diff.As<CollectionWithIndex<TActual>>().Items, (ICollection<TActual> diff) => diff.As<CollectionWithIndex<TActual>>().Index);
		}
	}
}
