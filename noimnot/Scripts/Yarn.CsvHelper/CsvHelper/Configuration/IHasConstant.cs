namespace CsvHelper.Configuration
{
	public interface IHasConstant<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasMap<TClass> Constant(TMember value);
	}
}
