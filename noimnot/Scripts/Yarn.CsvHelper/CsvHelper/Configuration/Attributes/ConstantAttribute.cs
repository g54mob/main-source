using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ConstantAttribute : Attribute
	{
		public object Constant { get; private set; }

		public ConstantAttribute(object constant)
		{
		}
	}
}
