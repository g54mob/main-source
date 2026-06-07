using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public class SgtStarfieldStar
	{
		public static SgtStarfieldStar Temp;

		public int Variant;

		public Color Color;

		public float Radius;

		public float Angle;

		public Vector3 Position;

		public float PulseSpeed;

		public float PulseRange;

		public float PulseOffset;

		public void CopyFrom(SgtStarfieldStar other)
		{
		}
	}
}
