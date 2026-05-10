using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class NameIndexAttribute : Attribute
	{
		public int NameIndex { get; private set; }

		public NameIndexAttribute(int nameIndex)
		{
		}
	}
}
