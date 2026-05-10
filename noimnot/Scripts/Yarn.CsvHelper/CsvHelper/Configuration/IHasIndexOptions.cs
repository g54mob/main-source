namespace CsvHelper.Configuration
{
	public interface IHasIndexOptions<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasTypeConverter<TClass, TMember>, IHasName<TClass, TMember>, IHasDefault<TClass, TMember>, IHasValidate<TClass, TMember>
	{
	}
}
