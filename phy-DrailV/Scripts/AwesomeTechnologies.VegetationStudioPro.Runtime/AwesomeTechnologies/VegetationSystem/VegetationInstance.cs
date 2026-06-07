using Unity.Mathematics;

namespace AwesomeTechnologies.VegetationSystem
{
	public struct VegetationInstance
	{
		public float3 Position;

		public quaternion Rotation;

		public float3 Scale;

		public float3 TerrainNormal;

		public float BiomeDistance;

		public byte TerrainTextureData;

		public int RandomNumberIndex;

		public float DistanceFalloff;

		public float VegetationMaskDensity;

		public float VegetationMaskScale;

		public byte TerrainSourceID;

		public byte TextureMaskData;

		public byte Excluded;

		public byte HeightmapSampled;
	}
}
