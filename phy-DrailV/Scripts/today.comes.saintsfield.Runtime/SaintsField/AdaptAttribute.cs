using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	public class AdaptAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly EUnit EUnit;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public AdaptAttribute(EUnit eUnit)
		{
			EUnit = eUnit;
		}
	}
}
