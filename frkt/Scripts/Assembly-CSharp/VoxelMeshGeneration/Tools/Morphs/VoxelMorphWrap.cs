using System;

namespace VoxelMeshGeneration.Tools.Morphs
{
	public struct VoxelMorphWrap : IEquatable<VoxelMorphData>
	{
		public readonly bool enabled;

		public readonly RGBAtlasColor color;

		public readonly bool dontChangeColor;

		public VoxelMorphWrap(bool enabled, RGBAtlasColor color)
		{
			this.enabled = false;
			this.color = default(RGBAtlasColor);
			dontChangeColor = false;
		}

		public VoxelMorphWrap(bool enabled)
		{
			this.enabled = false;
			color = default(RGBAtlasColor);
			dontChangeColor = false;
		}

		public bool Equals(VoxelMorphData other)
		{
			return false;
		}
	}
}
