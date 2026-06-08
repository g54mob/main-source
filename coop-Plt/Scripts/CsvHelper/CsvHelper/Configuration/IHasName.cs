namespace CsvHelper.Configuration
{
	public interface IHasName<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasNameOptions<TClass, TMember> Name(params string[] names);
	}
}
