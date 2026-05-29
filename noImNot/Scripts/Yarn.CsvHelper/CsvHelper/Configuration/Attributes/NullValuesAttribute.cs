using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class NullValuesAttribute : Attribute
	{
		public string[] NullValues { get; private set; }

		public NullValuesAttribute(string nullValue)
		{
		}

		public NullValuesAttribute(params string[] nullValues)
		{
		}
	}
}
