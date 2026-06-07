using System;

namespace Sirenix.OdinInspector
{
	public class PropertyOrderAttribute : Attribute
	{
		public float Order;

		public PropertyOrderAttribute()
		{
		}

		public PropertyOrderAttribute(float order)
		{
		}
	}
}
