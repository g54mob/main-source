using NGenerics.Util;

namespace NGenerics.Patterns.Specification
{
	public class NotSpecification<T> : AbstractSpecification<T>
	{
		private readonly ISpecification<T> specification;

		public ISpecification<T> Specification
		{
			get
			{
				return specification;
			}
		}

		public NotSpecification(ISpecification<T> specification)
		{
			Guard.ArgumentNotNull(specification, "specification");
			this.specification = specification;
		}

		public override bool IsSatisfiedBy(T item)
		{
			return !specification.IsSatisfiedBy(item);
		}
	}
}
