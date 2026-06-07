namespace NGenerics.Patterns.Specification
{
	public interface ISpecification<T>
	{
		bool IsSatisfiedBy(T item);

		ISpecification<T> And(ISpecification<T> right);

		ISpecification<T> Or(ISpecification<T> right);

		ISpecification<T> Xor(ISpecification<T> right);

		ISpecification<T> Not();
	}
}
