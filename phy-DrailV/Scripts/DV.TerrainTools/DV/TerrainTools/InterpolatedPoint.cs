using System;
using UnityEngine;

namespace DV.TerrainTools
{
	public class InterpolatedPoint
	{
		public Vector3 position;

		public float lerpFactor = -1f;

		public int firstPointIndex = -1;

		public InterpolatedPoint(Vector3 position, float lerpFactor, int firstPointIndex)
		{
			this.position = position;
			if (lerpFactor < 0f || lerpFactor > 1f)
			{
				throw new ArgumentOutOfRangeException("lerpFactor");
			}
			this.lerpFactor = lerpFactor;
			if (firstPointIndex < 0)
			{
				throw new ArgumentOutOfRangeException("firstPointIndex");
			}
			this.firstPointIndex = firstPointIndex;
		}
	}
}
