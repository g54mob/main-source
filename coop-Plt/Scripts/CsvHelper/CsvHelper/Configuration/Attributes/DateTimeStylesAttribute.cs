using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class DateTimeStylesAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public DateTimeStyles DateTimeStyles { get; private set; }

		public DateTimeStylesAttribute(DateTimeStyles dateTimeStyles)
		{
			DateTimeStyles = dateTimeStyles;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.DateTimeStyle = DateTimeStyles;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.DateTimeStyle = DateTimeStyles;
		}
	}
}
