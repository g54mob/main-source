using NGenerics.Util;

namespace NGenerics.Patterns.Specification
{
	public abstract class CompositeSpecification<T> : AbstractSpecification<T>
	{
		public ISpecification<T> Left { get; set; }

		public ISpecification<T> Right { get; set; }

		protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			Left = left;
			Right = right;
		}
	}
}
