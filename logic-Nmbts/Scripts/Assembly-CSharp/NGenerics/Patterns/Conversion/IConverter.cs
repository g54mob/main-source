namespace NGenerics.Patterns.Conversion
{
	public interface IConverter<TInput, TOutput>
	{
		TOutput Convert(TInput input);
	}
}
