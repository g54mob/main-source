using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class FlagsDropdownAttribute : PropertyAttribute, ISaintsAttribute
	{
		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy => "";
	}
}
