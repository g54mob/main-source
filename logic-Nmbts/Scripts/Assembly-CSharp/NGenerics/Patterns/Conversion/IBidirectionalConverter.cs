namespace NGenerics.Patterns.Conversion
{
	public interface IBidirectionalConverter<T1, T2>
	{
		T1 Convert(T2 input);

		T2 Convert(T1 input);
	}
}
