using ModApi.Planet.CustomData;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetBiomeVertexData
	{
		public int BiomeIndex;

		public float BiomeStrength;

		public Color Color;

		public PlanetVertexData CommonData;

		public CustomPlanetVertexData[] CustomData;

		public double[] Data;

		public double Height;

		public double HeightTotal;

		public PlanetBiomeVertexData()
		{
			Data = new double[10];
			CustomData = CustomPlanetVertexData.Create();
		}

		public void ResetCustomData()
		{
			CustomPlanetVertexData[] customData = CustomData;
			for (int i = 0; i < customData.Length; i++)
			{
				customData[i].Reset();
			}
		}
	}
}
