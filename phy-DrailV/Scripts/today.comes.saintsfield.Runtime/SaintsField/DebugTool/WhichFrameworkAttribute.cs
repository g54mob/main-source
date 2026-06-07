using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField.DebugTool
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class WhichFrameworkAttribute : PropertyAttribute, ISaintsAttribute
	{
		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";
	}
}
