using System;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainResources
{
	[Serializable]
	public class ResourceData
	{
		public ETerrainMaterial Type { get; set; }

		public double Value { get; set; }

		public ResourceData()
		{
		}

		public ResourceData(ETerrainMaterial type, double value)
		{
			Type = type;
			Value = value;
		}
	}
}
