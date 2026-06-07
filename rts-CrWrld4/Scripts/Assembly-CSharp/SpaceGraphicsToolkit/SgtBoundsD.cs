using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtBoundsD
	{
		public bool set;

		public double minX;

		public double minY;

		public double minZ;

		public double maxX;

		public double maxY;

		public double maxZ;

		public double SizeX => 0.0;

		public double SizeY => 0.0;

		public double SizeZ => 0.0;

		public SgtVector3D Center => default(SgtVector3D);

		public SgtVector3D Size => default(SgtVector3D);

		public double ExtentsX => 0.0;

		public double ExtentsY => 0.0;

		public double ExtentsZ => 0.0;

		public SgtVector3D Extents => default(SgtVector3D);

		public void Add(SgtVector3D xyz)
		{
		}

		public bool Contains(SgtVector3D xyz)
		{
			return false;
		}

		public bool Contains(long x, long y, long z)
		{
			return false;
		}

		public void Clear()
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(SgtBoundsD a, SgtBoundsD b)
		{
			return false;
		}

		public static bool operator !=(SgtBoundsD a, SgtBoundsD b)
		{
			return false;
		}

		public static explicit operator Bounds(SgtBoundsD a)
		{
			return default(Bounds);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
