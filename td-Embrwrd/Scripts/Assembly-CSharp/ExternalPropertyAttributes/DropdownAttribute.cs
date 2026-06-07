using System;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class DropdownAttribute : DrawerAttribute
	{
		public string ValuesName { get; private set; }

		public DropdownAttribute(string valuesName)
		{
		}
	}
}
