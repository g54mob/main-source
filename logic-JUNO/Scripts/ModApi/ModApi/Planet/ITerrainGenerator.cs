using System;
using ModApi.Planet.Modifiers.Material;
using UnityEngine;

namespace ModApi.Planet
{
	public interface ITerrainGenerator : IDisposable
	{
		int BiomeCount { get; }

		float LegacyHeightMax { get; }

		float LegacyHeightMin { get; }

		float SeaLevel { get; }

		IPlanetTerrainData TerrainData { get; }

		TerrainMaterialModifier TerrainMaterialModifier { get; }

		int TerrainQuadVertexCount { get; }

		WaterMaterialModifier WaterMaterialModifier { get; }

		TerrainGeneratorCacheData GetCacheData();

		double GetHeight(Vector3d normalizedPosition);

		double GetHeight(Vector3d normalizedPosition, TerrainGeneratorCacheData cacheData);

		QuadMeshDataFlags GetRequiredTerrainMeshData();

		QuadMeshDataFlags GetRequiredWaterMeshData();

		Material GetTerrainMaterial(IQuadSphereQuad quad);

		PlanetVertexData GetVertexData(VertexDataRequestType type, Vector3d normalizedPosition, Vector3d? normal = null, TerrainGeneratorCacheData cacheData = null);

		PlanetVertexData GetVertexDataBiomeAndHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData);

		void GetVertexDataBiomeAndHeightPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData);

		PlanetVertexData GetVertexDataBiomePass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData);

		void GetVertexDataFinalPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData);

		PlanetVertexData GetVertexDataFinalPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData);

		PlanetVertexData GetVertexDataHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData);

		PlanetVertexData GetVertexDataWaterPass(TerrainGeneratorCacheData cacheData = null);

		PlanetVertexData GetVertexDataWaterPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData);

		Material GetWaterMaterial(IQuadSphereQuad quad);

		void InitializeQuadSphere(IQuadSphere quadSphere);

		void RegisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback);

		void RegisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback);

		void UnregisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback);

		void UnregisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback);
	}
}
