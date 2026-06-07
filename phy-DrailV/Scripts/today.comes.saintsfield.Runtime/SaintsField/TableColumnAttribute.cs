using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TableColumnAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string Title;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "__LABEL_FIELD__";

		public TableColumnAttribute(string title)
		{
			Title = title;
		}
	}
}
