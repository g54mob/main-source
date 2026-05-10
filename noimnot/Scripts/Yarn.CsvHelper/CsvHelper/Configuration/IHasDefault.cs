namespace CsvHelper.Configuration
{
	public interface IHasDefault<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasDefaultOptions<TClass, TMember> Default(TMember defaultValue);

		IHasDefaultOptions<TClass, TMember> Default(string defaultValue);
	}
}
