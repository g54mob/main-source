using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class BooleanFalseValuesAttribute : Attribute
	{
		public string[] FalseValues { get; private set; }

		public BooleanFalseValuesAttribute(string falseValue)
		{
		}

		public BooleanFalseValuesAttribute(params string[] falseValues)
		{
		}
	}
}
