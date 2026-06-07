using System;

namespace NGenerics.Patterns.Specification
{
	public abstract class AbstractSpecification<T> : ISpecification<T>
	{
		public abstract bool IsSatisfiedBy(T item);

		ISpecification<T> ISpecification<T>.And(ISpecification<T> right)
		{
			return And(right);
		}

		ISpecification<T> ISpecification<T>.Or(ISpecification<T> right)
		{
			return Or(right);
		}

		ISpecification<T> ISpecification<T>.Xor(ISpecification<T> right)
		{
			return Xor(right);
		}

		ISpecification<T> ISpecification<T>.Not()
		{
			return Not();
		}

		public static AbstractSpecification<T> operator &(AbstractSpecification<T> left, ISpecification<T> right)
		{
			return AndInternal(left, right);
		}

		public static AbstractSpecification<T> operator &(AbstractSpecification<T> left, Predicate<T> right)
		{
			return AndInternal(left, new PredicateSpecification<T>(right));
		}

		public static AbstractSpecification<T> operator |(AbstractSpecification<T> left, ISpecification<T> right)
		{
			return OrInternal(left, right);
		}

		public static AbstractSpecification<T> operator |(AbstractSpecification<T> left, Predicate<T> right)
		{
			return OrInternal(left, new PredicateSpecification<T>(right));
		}

		public static AbstractSpecification<T> operator !(AbstractSpecification<T> operand)
		{
			return NotInternal(operand);
		}

		public static AbstractSpecification<T> operator ^(AbstractSpecification<T> left, ISpecification<T> right)
		{
			return XorInternal(left, right);
		}

		public static AbstractSpecification<T> operator ^(AbstractSpecification<T> left, Predicate<T> right)
		{
			return XorInternal(left, new PredicateSpecification<T>(right));
		}

		public AbstractSpecification<T> And(ISpecification<T> right)
		{
			return AndInternal(this, right);
		}

		public AbstractSpecification<T> Or(ISpecification<T> right)
		{
			return OrInternal(this, right);
		}

		public AbstractSpecification<T> Xor(ISpecification<T> right)
		{
			return XorInternal(this, right);
		}

		public AbstractSpecification<T> Not()
		{
			return NotInternal(this);
		}

		public AbstractSpecification<T> And(Predicate<T> right)
		{
			return AndInternal(this, new PredicateSpecification<T>(right));
		}

		public AbstractSpecification<T> Or(Predicate<T> right)
		{
			return OrInternal(this, new PredicateSpecification<T>(right));
		}

		public AbstractSpecification<T> Xor(Predicate<T> right)
		{
			return XorInternal(this, new PredicateSpecification<T>(right));
		}

		private static AbstractSpecification<T> OrInternal(ISpecification<T> left, ISpecification<T> right)
		{
			return new OrSpecification<T>(left, right);
		}

		private static AbstractSpecification<T> AndInternal(ISpecification<T> left, ISpecification<T> right)
		{
			return new AndSpecification<T>(left, right);
		}

		private static AbstractSpecification<T> XorInternal(ISpecification<T> left, ISpecification<T> right)
		{
			return new XorSpecification<T>(left, right);
		}

		private static AbstractSpecification<T> NotInternal(ISpecification<T> operand)
		{
			return new NotSpecification<T>(operand);
		}
	}
}
