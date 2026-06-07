using System;
using UnityEngine;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class RangeVectorAttribute : PropertyAttribute
	{
		public readonly Vector3 min;

		public readonly Vector3 max;

		public bool Valid { get; }

		public RangeVectorAttribute(float[] min, float[] max)
		{
		}
	}
}
