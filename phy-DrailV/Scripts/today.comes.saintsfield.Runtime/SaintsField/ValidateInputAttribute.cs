using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class ValidateInputAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string Callback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public ValidateInputAttribute(string callback)
		{
			Callback = callback;
		}
	}
}
