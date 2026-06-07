using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class AnimatorStateAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string AnimFieldName;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy => "__LABEL_FIELD__";

		public AnimatorStateAttribute(string animator = null)
		{
			AnimFieldName = animator;
		}
	}
}
