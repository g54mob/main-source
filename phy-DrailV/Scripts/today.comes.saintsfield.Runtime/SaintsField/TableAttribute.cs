using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Playa;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TableAttribute : PropertyAttribute, ISaintsAttribute, IPlayaAttribute
	{
		public readonly bool HideAddButton;

		public readonly bool HideRemoveButton;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy => "__LABEL_FIELD__";

		public TableAttribute(bool hideAddButton = false, bool hideRemoveButton = false)
		{
			HideAddButton = hideAddButton;
			HideRemoveButton = hideRemoveButton;
		}
	}
}
