using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class CultureInfoAttribute : Attribute
	{
		public CultureInfo CultureInfo { get; private set; }

		public CultureInfoAttribute(string culture)
		{
		}
	}
}
