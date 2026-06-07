namespace NGenerics.Patterns.Specification
{
	public class XorSpecification<T> : CompositeSpecification<T>
	{
		public XorSpecification(ISpecification<T> left, ISpecification<T> right)
			: base(left, right)
		{
		}

		public override bool IsSatisfiedBy(T item)
		{
			return base.Left.IsSatisfiedBy(item) ^ base.Right.IsSatisfiedBy(item);
		}
	}
}
