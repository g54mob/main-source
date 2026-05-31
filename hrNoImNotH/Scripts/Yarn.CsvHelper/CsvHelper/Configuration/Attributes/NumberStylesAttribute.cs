using System;
using System.Globalization;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class NumberStylesAttribute : Attribute
	{
		public NumberStyles NumberStyles { get; private set; }

		public NumberStylesAttribute(NumberStyles numberStyles)
		{
		}
	}
}
