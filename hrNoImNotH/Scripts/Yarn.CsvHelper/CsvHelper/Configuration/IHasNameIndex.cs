namespace CsvHelper.Configuration
{
	public interface IHasNameIndex<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasNameIndexOptions<TClass, TMember> NameIndex(int index);
	}
}
