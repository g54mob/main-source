namespace NGenerics.Patterns.Specification
{
	public class AndSpecification<T> : CompositeSpecification<T>
	{
		public AndSpecification(ISpecification<T> left, ISpecification<T> right)
			: base(left, right)
		{
		}

		public override bool IsSatisfiedBy(T item)
		{
			if (base.Left.IsSatisfiedBy(item))
			{
				return base.Right.IsSatisfiedBy(item);
			}
			return false;
		}
	}
}
