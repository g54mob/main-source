using System;
using UnityEngine;

namespace Placemaker
{
	public class Voxel : MonoBehaviour, IComparable<Voxel>
	{
		[SerializeField]
		public VoxelType type;

		[SerializeField]
		public byte height;

		[SerializeField]
		public int cost;

		int IComparable<Voxel>.CompareTo(Voxel other)
		{
			return 0;
		}
	}
}
