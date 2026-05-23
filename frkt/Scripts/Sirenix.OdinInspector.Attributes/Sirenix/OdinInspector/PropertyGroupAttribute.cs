using System;
using System.Diagnostics;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public abstract class PropertyGroupAttribute : Attribute
	{
		[HideInInspector]
		public string GroupID;

		[Delayed]
		[ValidateInput("ValidateGroupName", null, InfoMessageType.Error)]
		public string GroupName;

		[HideInInspector]
		public float Order;

		[LabelWidth(200f)]
		public bool HideWhenChildrenAreInvisible;

		[LabelWidth(200f)]
		public bool AnimateVisibility;

		public string VisibleIf;

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

		private static bool ValidateGroupName(string value, ref string errorMessage)
		{
			return false;
		}
	}
}
