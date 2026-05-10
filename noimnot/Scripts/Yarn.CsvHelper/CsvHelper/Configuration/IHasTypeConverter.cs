using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	public interface IHasTypeConverter<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasTypeConverterOptions<TClass, TMember> TypeConverter(ITypeConverter typeConverter);

		IHasTypeConverterOptions<TClass, TMember> TypeConverter<TConverter>() where TConverter : ITypeConverter;
	}
}
