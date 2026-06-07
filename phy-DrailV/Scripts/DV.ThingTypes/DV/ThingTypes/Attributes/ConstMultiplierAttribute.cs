using UnityEngine;

namespace DV.ThingTypes.Attributes
{
	public class ConstMultiplierAttribute : PropertyAttribute
	{
		public float constValue;

		public string constDisplayName;

		public ConstMultiplierAttribute(float constValue, string constDisplayName = "const")
		{
			this.constValue = constValue;
			this.constDisplayName = constDisplayName;
		}
	}
}
