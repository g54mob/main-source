using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class NameAttribute : Attribute
	{
		public string[] Names { get; private set; }

		public NameAttribute(string name)
		{
		}

		public NameAttribute(params string[] names)
		{
		}
	}
}
