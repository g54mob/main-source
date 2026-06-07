using System;
using NGenerics.Util;

namespace NGenerics.Patterns.Visitor
{
	public class GeneralVisitor<T> : IVisitor<T>
	{
		private bool completed;

		private readonly Predicate<T> predicate;

		public bool HasCompleted
		{
			get
			{
				return completed;
			}
			set
			{
				completed = value;
			}
		}

		public GeneralVisitor(Predicate<T> hasCompletedPredicate)
		{
			Guard.ArgumentNotNull(hasCompletedPredicate, "hasCompletedPredicate");
			predicate = hasCompletedPredicate;
		}

		public void Visit(T obj)
		{
			completed = predicate(obj);
		}
	}
}
