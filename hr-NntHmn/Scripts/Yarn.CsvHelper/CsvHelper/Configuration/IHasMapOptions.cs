namespace CsvHelper.Configuration
{
	public interface IHasMapOptions<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasTypeConverter<TClass, TMember>, IHasIndex<TClass, TMember>, IHasName<TClass, TMember>, IHasOptional<TClass, TMember>, IHasConvertUsing<TClass, TMember>, IHasDefault<TClass, TMember>, IHasConstant<TClass, TMember>, IHasValidate<TClass, TMember>
	{
	}
}
