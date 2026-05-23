using System;
using Unity.Mathematics;

namespace Effectors.ReceiveMethods.Index
{
	public readonly struct IndexEffectorFeedback : IEquatable<IndexEffectorFeedback>
	{
		public readonly int3 index;

		public readonly float voxelProgressBeforeInfluence;

		public readonly float voxelProgressAfterInfluence;

		public readonly float absorbedInfluence;

		public IndexEffectorFeedback(int3 index)
		{
			this.index = default(int3);
			voxelProgressBeforeInfluence = 0f;
			voxelProgressAfterInfluence = 0f;
			absorbedInfluence = 0f;
		}

		public IndexEffectorFeedback(int3 index, float voxelProgressBeforeInfluence, float voxelProgressAfterInfluence, float absorbedInfluence)
		{
			this.index = default(int3);
			this.voxelProgressBeforeInfluence = 0f;
			this.voxelProgressAfterInfluence = 0f;
			this.absorbedInfluence = 0f;
		}

		public bool Equals(IndexEffectorFeedback other)
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
	}
}
