using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class PropertySpaceAttribute : Attribute
	{
		public float SpaceBefore;

		public float SpaceAfter;

		public PropertySpaceAttribute()
		{
		}

		public PropertySpaceAttribute(float spaceBefore)
		{
		}

		public PropertySpaceAttribute(float spaceBefore, float spaceAfter)
		{
		}
	}
}
