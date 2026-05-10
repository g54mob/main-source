using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class DefaultAttribute : Attribute
	{
		public object Default { get; private set; }

		public DefaultAttribute(object defaultValue)
		{
		}
	}
}
