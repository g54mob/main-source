using System;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class TypeConverterAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public ITypeConverter TypeConverter { get; private set; }

		public TypeConverterAttribute(Type typeConverterType)
		{
			if (typeConverterType == null)
			{
				throw new ArgumentNullException("typeConverterType");
			}
			TypeConverter = ObjectResolver.Current.Resolve(typeConverterType) as ITypeConverter;
			if (TypeConverter == null)
			{
				throw new ArgumentException("Type '" + typeConverterType.FullName + "' does not implement ITypeConverter");
			}
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverter = TypeConverter;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverter = TypeConverter;
		}
	}
}
