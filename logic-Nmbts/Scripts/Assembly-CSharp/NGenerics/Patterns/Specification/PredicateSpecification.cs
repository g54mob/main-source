using System;
using NGenerics.Util;

namespace NGenerics.Patterns.Specification
{
	public class PredicateSpecification<T> : AbstractSpecification<T>
	{
		private readonly Predicate<T> predicate;

		public Predicate<T> Predicate
		{
			get
			{
				return predicate;
			}
		}

		public PredicateSpecification(Predicate<T> predicate)
		{
			Guard.ArgumentNotNull(predicate, "predicate");
			this.predicate = predicate;
		}

		public override bool IsSatisfiedBy(T item)
		{
			return predicate(item);
		}
	}
}
