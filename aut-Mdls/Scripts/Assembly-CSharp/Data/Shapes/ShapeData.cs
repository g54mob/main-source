using System;
using System.Collections.Generic;
using Logic.Shapes;
using UnityEngine;

namespace Data.Shapes
{
	[Serializable]
	public class ShapeData
	{
		public Vector3Int Bounds;

		public Hash128 VoxelHash;

		public Hash128 ColorHash;

		public List<Voxel> OccupiedVoxels;

		public Voxel[] Voxels;

		public Texture2D GridIcon;

		public Texture2D SmoothIcon;

		public RotationIndependentHash RotationIndependantHash;

		private ShapeHashPair CachedHash;

		public ShapeHashPair GetShapeHash()
		{
			if (!CachedHash.VoxelHash.isValid)
			{
				CachedHash = new ShapeHashPair
				{
					VoxelHash = VoxelHash,
					ColorHash = ColorHash
				};
			}
			return CachedHash;
		}

		public bool IsEmpty()
		{
			if (Voxels.Length == 0)
			{
				return true;
			}
			Voxel[] voxels = Voxels;
			for (int i = 0; i < voxels.Length; i++)
			{
				if (voxels[i].IsOccupied)
				{
					return false;
				}
			}
			return true;
		}

		public bool Equals(ShapeData other)
		{
			if (VoxelHash == other.VoxelHash)
			{
				return ColorHash == other.ColorHash;
			}
			return false;
		}

		public bool Equals(ShapeDataSO other)
		{
			if ((object)other == null)
			{
				return false;
			}
			return Equals(other.Data);
		}

		public static bool operator ==(ShapeData a, ShapeData b)
		{
			if ((object)a == null)
			{
				return (object)b == null;
			}
			if ((object)b == null)
			{
				return false;
			}
			return a.Equals(b);
		}

		public static bool operator !=(ShapeData a, ShapeData b)
		{
			return !(a == b);
		}

		public int CompareTo(ShapeData other)
		{
			return GetHashCode().CompareTo(other.GetHashCode());
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return GetShapeHash().GetHashCode();
		}
	}
}
