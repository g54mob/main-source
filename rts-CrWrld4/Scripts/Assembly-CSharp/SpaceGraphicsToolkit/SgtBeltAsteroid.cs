using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public class SgtBeltAsteroid
	{
		public static SgtBeltAsteroid Temp;

		public int Variant;

		public Color Color;

		public float Radius;

		public float Height;

		public float Angle;

		public float Spin;

		public float OrbitAngle;

		public float OrbitSpeed;

		public float OrbitDistance;

		public void CopyFrom(SgtBeltAsteroid other)
		{
		}
	}
}
