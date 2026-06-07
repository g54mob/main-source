using ModApi.Planet;
using ModApi.Planet.CustomData;
using UnityEngine;

namespace Assets.Scripts.Terrain.CustomData
{
	public abstract class CustomCreateQuadDataFromCustomVertexData<T> : CustomCreateQuadData where T : CustomPlanetVertexData
	{
		protected int CustomPlanetVertexDataIndex { get; }

		public CustomCreateQuadDataFromCustomVertexData(string customPlanetVertexDataId)
		{
			CustomPlanetVertexDataIndex = CustomPlanetVertexData.GetIndex(customPlanetVertexDataId);
			if (CustomPlanetVertexDataIndex < 0)
			{
				Debug.LogError("Unable to find CustomPlanetVertexData with id '" + customPlanetVertexDataId + "'");
			}
		}

		public sealed override void OnQuadDataGenerated(TerrainGeneratorCacheData terrainGeneratorCacheData, CreateQuadData createQuadData)
		{
			int customPlanetVertexDataIndex = CustomPlanetVertexDataIndex;
			if (customPlanetVertexDataIndex >= 0)
			{
				PlanetVertexData[] vertexDataResults = terrainGeneratorCacheData.VertexDataResults;
				int num = vertexDataResults.Length;
				for (int i = 0; i < num; i++)
				{
					OnQuadDataGenerated(i, (T)vertexDataResults[i].CustomData[customPlanetVertexDataIndex]);
				}
			}
		}

		protected abstract void OnQuadDataGenerated(int vertexIndex, T vertexData);
	}
}
