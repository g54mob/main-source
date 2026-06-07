using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class DisplayAsStringAttribute : Attribute
	{
		public bool Overflow;

		public DisplayAsStringAttribute()
		{
			Overflow = true;
		}

		public DisplayAsStringAttribute(bool overflow)
		{
			Overflow = overflow;
		}
	}
}
