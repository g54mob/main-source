namespace CsvHelper.Configuration
{
	public interface IHasNameIndexOptions<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasTypeConverter<TClass, TMember>, IHasDefault<TClass, TMember>, IHasValidate<TClass, TMember>
	{
	}
}
