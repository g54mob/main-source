using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozyPropertyTypeAttribute : PropertyAttribute
	{
		public bool color;

		public float min;

		public float max;

		public CozyPropertyTypeAttribute()
		{
			color = false;
		}

		public CozyPropertyTypeAttribute(bool isColorType)
		{
			color = isColorType;
		}

		public CozyPropertyTypeAttribute(bool isColorType, float min, float max)
		{
			color = isColorType;
			this.min = min;
			this.max = max;
		}
	}
}
