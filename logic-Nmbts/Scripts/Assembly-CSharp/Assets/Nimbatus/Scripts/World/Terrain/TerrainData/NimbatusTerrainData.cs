using System;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainData
{
	[Serializable]
	public struct NimbatusTerrainData
	{
		public float Volume;

		public ushort MaterialType;

		public NimbatusTerrainData(float volume, ushort type)
		{
			Volume = volume;
			MaterialType = type;
		}
	}
}
