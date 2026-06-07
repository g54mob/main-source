using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FormatAttribute : Attribute
	{
		public string[] Formats { get; private set; }

		public FormatAttribute(string format)
		{
		}

		public FormatAttribute(params string[] formats)
		{
		}
	}
}
