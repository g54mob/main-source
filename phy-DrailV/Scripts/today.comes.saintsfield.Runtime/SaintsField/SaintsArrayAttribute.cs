using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	public class SaintsArrayAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string PropertyName;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy { get; }

		public SaintsArrayAttribute(string propertyName = null, string groupBy = "")
		{
			PropertyName = propertyName;
			GroupBy = groupBy;
		}
	}
}
