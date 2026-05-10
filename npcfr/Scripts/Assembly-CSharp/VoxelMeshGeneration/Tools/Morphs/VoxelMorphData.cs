using System;
using Unity.Mathematics;

namespace VoxelMeshGeneration.Tools.Morphs
{
	public struct VoxelMorphData : IEquatable<VoxelMorphData>
	{
		public int3 voxelIndex;

		public bool enabled;

		public readonly RGBAtlasColor color;

		public readonly bool dontChangeColor;

		public VoxelMorphData(int3 voxelIndex, VoxelMorphWrap wrap)
		{
			this.voxelIndex = default(int3);
			enabled = false;
			color = default(RGBAtlasColor);
			dontChangeColor = false;
		}

		public bool Equals(VoxelMorphData other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
