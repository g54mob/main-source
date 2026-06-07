using System;
using UnityEngine;

namespace Parabox.Stl
{
	internal struct StlVector3 : IEquatable<StlVector3>
	{
		private const float k_Resolution = 10000f;

		public float x;

		public float y;

		public float z;

		public StlVector3(Vector3 v)
		{
			x = 0f;
			y = 0f;
			z = 0f;
		}

		public StlVector3(float x, float y, float z)
		{
			this.x = 0f;
			this.y = 0f;
			this.z = 0f;
		}

		public static explicit operator Vector3(StlVector3 vec)
		{
			return default(Vector3);
		}

		public static explicit operator StlVector3(Vector3 vec)
		{
			return default(StlVector3);
		}

		public bool Equals(StlVector3 other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(StlVector3 a, StlVector3 b)
		{
			return false;
		}

		public static bool operator !=(StlVector3 a, StlVector3 b)
		{
			return false;
		}
	}
}
