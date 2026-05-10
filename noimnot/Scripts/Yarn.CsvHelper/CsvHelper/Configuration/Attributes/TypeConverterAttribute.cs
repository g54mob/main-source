using System;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TypeConverterAttribute : Attribute
	{
		public ITypeConverter TypeConverter { get; private set; }

		public TypeConverterAttribute(Type typeConverterType)
		{
		}
	}
}
