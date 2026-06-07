using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class RequiredAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string ErrorMessage;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public RequiredAttribute(string errorMessage = null)
		{
			ErrorMessage = errorMessage;
		}
	}
}
