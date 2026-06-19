using System;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public struct Vector3Serialziable
	{
		public float X;

		public float Y;

		public float Z;

		public Vector3Serialziable(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static implicit operator Vector3(Vector3Serialziable v)
		{
			return new Vector3(v.X, v.Y, v.Z);
		}

		public static implicit operator Vector3Serialziable(Vector3 v)
		{
			return new Vector3Serialziable(v.x, v.y, v.z);
		}
	}
}
