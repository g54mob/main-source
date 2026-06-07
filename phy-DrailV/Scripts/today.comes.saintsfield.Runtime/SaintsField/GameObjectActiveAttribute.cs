using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class GameObjectActiveAttribute : PropertyAttribute, ISaintsAttribute
	{
		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";
	}
}
