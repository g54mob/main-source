using System;
using UnityEngine;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class RangeVectorAttribute : PropertyAttribute
	{
		public readonly Vector3 min = Vector3.zero;

		public readonly Vector3 max = Vector3.zero;

		public bool Valid { get; } = true;

		public RangeVectorAttribute(float[] min, float[] max)
		{
			if (min.Length > 3 || max.Length > 3)
			{
				Valid = false;
				return;
			}
			switch (min.Length)
			{
			case 3:
				this.min.x = min[0];
				this.min.y = min[1];
				this.min.z = min[2];
				break;
			case 2:
				this.min.x = min[0];
				this.min.y = min[1];
				break;
			case 1:
				this.min.x = min[0];
				break;
			}
			switch (max.Length)
			{
			case 3:
				this.max.x = max[0];
				this.max.y = max[1];
				this.max.z = max[2];
				break;
			case 2:
				this.max.x = max[0];
				this.max.y = max[1];
				break;
			case 1:
				this.max.x = max[0];
				break;
			}
		}
	}
}
