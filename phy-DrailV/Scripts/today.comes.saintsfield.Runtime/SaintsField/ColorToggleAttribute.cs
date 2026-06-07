using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class ColorToggleAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string CompName;

		public readonly int Index;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public ColorToggleAttribute(string compName = null, int index = 0)
		{
			CompName = compName;
			Index = index;
		}
	}
}
