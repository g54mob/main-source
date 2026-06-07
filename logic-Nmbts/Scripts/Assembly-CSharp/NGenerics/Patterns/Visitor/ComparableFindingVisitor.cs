using System;

namespace NGenerics.Patterns.Visitor
{
	public sealed class ComparableFindingVisitor<T> : IFindingIVisitor<T>, IVisitor<T> where T : IComparable
	{
		private readonly T searchValue;

		public bool HasCompleted { get; private set; }

		public bool Found
		{
			get
			{
				return HasCompleted;
			}
		}

		public T SearchValue
		{
			get
			{
				return searchValue;
			}
		}

		public ComparableFindingVisitor(T searchValue)
		{
			this.searchValue = searchValue;
		}

		public void Visit(T obj)
		{
			if (obj.CompareTo(searchValue) == 0)
			{
				HasCompleted = true;
			}
		}
	}
}
