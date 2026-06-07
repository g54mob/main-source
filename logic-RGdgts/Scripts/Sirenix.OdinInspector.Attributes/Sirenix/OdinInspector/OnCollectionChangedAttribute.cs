using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class OnCollectionChangedAttribute : Attribute
	{
		public string Before;

		public string After;

		public OnCollectionChangedAttribute()
		{
		}

		public OnCollectionChangedAttribute(string after)
		{
		}

		public OnCollectionChangedAttribute(string before, string after)
		{
		}
	}
}
