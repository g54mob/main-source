namespace CsvHelper.Configuration
{
	public interface IBuildableClass<TClass>
	{
		ClassMap<TClass> Build();
	}
}
