using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
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
