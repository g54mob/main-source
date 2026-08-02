using UnityEngine;

namespace Polarith.UnityUtils
{
	public sealed class OpenRangeMaxAttribute : PropertyAttribute
	{
		private float max;

		public float Max => max;

		public OpenRangeMaxAttribute(float max)
		{
			this.max = max;
		}
	}
}
