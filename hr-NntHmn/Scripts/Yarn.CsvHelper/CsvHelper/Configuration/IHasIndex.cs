namespace CsvHelper.Configuration
{
	public interface IHasIndex<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasIndexOptions<TClass, TMember> Index(int index, int indexEnd = -1);
	}
}
