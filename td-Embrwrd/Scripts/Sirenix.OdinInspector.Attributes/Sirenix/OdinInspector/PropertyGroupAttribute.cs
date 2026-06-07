using System;
using System.Diagnostics;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public abstract class PropertyGroupAttribute : Attribute
	{
		[HideInInspector]
		public string GroupID;

		[ValidateInput("ValidateGroupName", null, InfoMessageType.Error)]
		[Delayed]
		public string GroupName;

		[HideInInspector]
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

		private static bool ValidateGroupName(string value, ref string errorMessage)
		{
			return false;
		}
	}
}
