using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class NumberStylesAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public NumberStyles NumberStyles { get; private set; }

		public NumberStylesAttribute(NumberStyles numberStyles)
		{
			NumberStyles = numberStyles;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.NumberStyles = NumberStyles;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.NumberStyles = NumberStyles;
		}
	}
}
