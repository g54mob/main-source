using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
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
