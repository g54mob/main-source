using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class HeaderPrefixAttribute : Attribute
	{
		public string Prefix { get; private set; }

		public HeaderPrefixAttribute()
		{
		}

		public HeaderPrefixAttribute(string prefix)
		{
		}
	}
}
