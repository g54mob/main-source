using System;
using UnityEngine;

namespace PugWorldGen
{
	[AttributeUsage(AttributeTargets.Field)]
	public class RangeVectorAttribute : PropertyAttribute
	{
		public float min;

		public float max;

		public RangeVectorAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
