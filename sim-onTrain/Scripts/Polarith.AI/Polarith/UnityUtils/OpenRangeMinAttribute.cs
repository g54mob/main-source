using UnityEngine;

namespace Polarith.UnityUtils
{
	public sealed class OpenRangeMinAttribute : PropertyAttribute
	{
		private float min;

		public float Min => min;

		public OpenRangeMinAttribute(float min)
		{
			this.min = min;
		}
	}
}
