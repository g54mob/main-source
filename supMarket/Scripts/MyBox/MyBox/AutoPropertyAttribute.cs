using System;
using UnityEngine;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Field)]
	public class AutoPropertyAttribute : PropertyAttribute
	{
		public readonly AutoPropertyMode Mode;

		public readonly string PredicateMethodName;

		public readonly Type PredicateMethodTarget;

		public readonly bool AllowEmpty;

		public AutoPropertyAttribute(AutoPropertyMode mode = AutoPropertyMode.Children, string predicateMethodName = null, Type predicateMethodTarget = null, bool allowEmpty = false)
		{
		}
	}
}
