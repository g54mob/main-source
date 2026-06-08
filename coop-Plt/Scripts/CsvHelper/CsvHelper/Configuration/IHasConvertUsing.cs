namespace CsvHelper.Configuration
{
	public interface IHasConvertUsing<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasMap<TClass> ConvertUsing(ConvertFromString<TMember> convertExpression);

		IHasMap<TClass> ConvertUsing(ConvertToString<TClass> convertExpression);
	}
}
