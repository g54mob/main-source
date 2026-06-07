using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class PropertyOrderAttribute : Attribute
	{
		public int Order;

		public PropertyOrderAttribute()
		{
		}

		public PropertyOrderAttribute(int order)
		{
			Order = order;
		}
	}
}
