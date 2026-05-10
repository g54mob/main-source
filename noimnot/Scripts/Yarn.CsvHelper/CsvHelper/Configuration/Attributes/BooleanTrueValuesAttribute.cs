using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class BooleanTrueValuesAttribute : Attribute
	{
		public string[] TrueValues { get; private set; }

		public BooleanTrueValuesAttribute(string trueValue)
		{
		}

		public BooleanTrueValuesAttribute(params string[] trueValues)
		{
		}
	}
}
