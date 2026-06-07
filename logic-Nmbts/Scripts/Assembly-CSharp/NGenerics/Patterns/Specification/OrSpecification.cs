namespace NGenerics.Patterns.Specification
{
	public class OrSpecification<T> : CompositeSpecification<T>
	{
		public OrSpecification(ISpecification<T> left, ISpecification<T> right)
			: base(left, right)
		{
		}

		public override bool IsSatisfiedBy(T item)
		{
			if (!base.Left.IsSatisfiedBy(item))
			{
				return base.Right.IsSatisfiedBy(item);
			}
			return true;
		}
	}
}
