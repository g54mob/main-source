using System;
using LVA.Organs.EffectorsPerception.Collectors;
using Unity.Mathematics;

namespace Effectors.ReceiveMethods.Index
{
	public readonly struct IndexEffectorSignal : IEquatable<IndexEffectorSignal>
	{
		public readonly int3 voxelIndex;

		public readonly float influence;

		public readonly InfluenceProcessType influenceProcessType;

		public IndexEffectorSignal(int3 voxelIndex, float influence, InfluenceProcessType influenceProcessType = InfluenceProcessType.Sum)
		{
			this.voxelIndex = default(int3);
			this.influence = 0f;
			this.influenceProcessType = default(InfluenceProcessType);
		}

		public bool Equals(IndexEffectorSignal other)
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
