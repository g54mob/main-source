namespace CsvHelper.Configuration
{
	public interface IHasDefaultOptions<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasValidate<TClass, TMember>
	{
	}
}
