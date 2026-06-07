using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public class SgtBackdropQuad
	{
		public static SgtBackdropQuad Temp;

		public int Variant;

		public Color Color;

		public float Radius;

		public float Angle;

		public Vector3 Position;

		public void CopyFrom(SgtBackdropQuad other)
		{
		}
	}
}
