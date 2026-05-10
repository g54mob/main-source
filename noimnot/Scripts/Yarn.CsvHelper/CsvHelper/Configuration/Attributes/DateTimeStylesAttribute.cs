using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class DateTimeStylesAttribute : Attribute
	{
		public DateTimeStyles DateTimeStyles { get; private set; }

		public DateTimeStylesAttribute(DateTimeStyles dateTimeStyles)
		{
		}
	}
}
