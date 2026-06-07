using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class RateAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly int Min;

		public readonly int Max;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy => "__LABEL_FIELD__";

		public RateAttribute(int min, int max)
		{
			Min = min;
			Max = max;
		}
	}
}
