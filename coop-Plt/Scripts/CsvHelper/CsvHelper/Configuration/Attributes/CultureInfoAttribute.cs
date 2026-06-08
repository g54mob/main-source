using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class CultureInfoAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public CultureInfo CultureInfo { get; private set; }

		public CultureInfoAttribute(string culture)
		{
			CultureInfo = CultureInfo.GetCultureInfo(culture);
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.CultureInfo = CultureInfo;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.CultureInfo = CultureInfo;
		}
	}
}
