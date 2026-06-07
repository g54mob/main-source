using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class SpriteToggleAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string CompName;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy { get; }

		public SpriteToggleAttribute(string imageOrSpriteRenderer = null, string groupBy = "")
		{
			CompName = imageOrSpriteRenderer;
			GroupBy = groupBy;
		}
	}
}
