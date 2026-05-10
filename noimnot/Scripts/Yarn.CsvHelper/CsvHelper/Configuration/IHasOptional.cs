namespace CsvHelper.Configuration
{
	public interface IHasOptional<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasOptionalOptions<TClass, TMember> Optional();
	}
}
