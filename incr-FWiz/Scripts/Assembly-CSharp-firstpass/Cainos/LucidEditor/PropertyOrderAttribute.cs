using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class PropertyOrderAttribute : Attribute
	{
		public readonly int propertyOrder;

		public PropertyOrderAttribute(int propertyOrder)
		{
		}
	}
}
