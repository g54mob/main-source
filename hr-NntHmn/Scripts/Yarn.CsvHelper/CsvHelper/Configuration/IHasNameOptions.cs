namespace CsvHelper.Configuration
{
	public interface IHasNameOptions<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasTypeConverter<TClass, TMember>, IHasNameIndex<TClass, TMember>, IHasDefault<TClass, TMember>, IHasValidate<TClass, TMember>
	{
	}
}
