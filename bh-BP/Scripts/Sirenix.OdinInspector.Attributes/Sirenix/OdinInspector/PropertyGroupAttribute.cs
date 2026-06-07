using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public abstract class PropertyGroupAttribute : Attribute
	{
		public string GroupID;

		public string GroupName;

		public float Order;

		public bool HideWhenChildrenAreInvisible;

		public string VisibleIf;

		public bool AnimateVisibility;

		public PropertyGroupAttribute(string groupId, float order)
		{
		}

		public PropertyGroupAttribute(string groupId)
		{
		}

		public PropertyGroupAttribute Combine(PropertyGroupAttribute other)
		{
			return null;
		}

		protected virtual void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
