using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class IndexAttribute : Attribute
	{
		public int Index { get; private set; }

		public int IndexEnd { get; private set; }

		public IndexAttribute(int index, int indexEnd = -1)
		{
		}
	}
}
