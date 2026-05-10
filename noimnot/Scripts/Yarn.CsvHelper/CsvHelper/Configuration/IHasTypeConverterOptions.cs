namespace CsvHelper.Configuration
{
	public interface IHasTypeConverterOptions<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasDefault<TClass, TMember>, IHasValidate<TClass, TMember>
	{
	}
}
