using System;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Graphs
{
	[Serializable]
	public struct Action
	{
		[SerializeField]
		public int2 hexPos;

		[SerializeField]
		public byte height;

		[SerializeField]
		public VoxelType inType;

		[SerializeField]
		public VoxelType outType;

		[SerializeField]
		public int actionId;

		public Action(int2 hexPos, byte height, VoxelType inType, VoxelType outType, int actionId)
		{
			this.hexPos = default(int2);
			this.height = 0;
			this.inType = default(VoxelType);
			this.outType = default(VoxelType);
			this.actionId = 0;
		}

		public Action GetReverse()
		{
			return default(Action);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
