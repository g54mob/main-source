using System;
using ModApi.Planet.Modifiers.Material;
using UnityEngine;

namespace ModApi.Planet
{
	public class TerrainGeneratorDisposed : ITerrainGenerator, IDisposable
	{
		private static TerrainGeneratorCacheData _disposedCacheData;

		private ITerrainGenerator _source;

		private PlanetVertexData _vertexData;

		public int BiomeCount => _source.BiomeCount;

		public float LegacyHeightMax => _source.LegacyHeightMax;

		public float LegacyHeightMin => _source.LegacyHeightMin;

		public float SeaLevel => _source.SeaLevel;

		public IPlanetTerrainData TerrainData => _source.TerrainData;

		public TerrainMaterialModifier TerrainMaterialModifier => _source.TerrainMaterialModifier;

		public int TerrainQuadVertexCount => _source.TerrainQuadVertexCount;

		public WaterMaterialModifier WaterMaterialModifier => _source.WaterMaterialModifier;

		public TerrainGeneratorDisposed(ITerrainGenerator terrainGenerator)
		{
			_source = terrainGenerator;
			TerrainGeneratorCacheData terrainGeneratorCacheData = _disposedCacheData;
			if (terrainGeneratorCacheData == null || terrainGeneratorCacheData.BiomeCount != terrainGenerator.BiomeCount || terrainGeneratorCacheData.TerrainQuadVertexCount != terrainGeneratorCacheData.TerrainQuadVertexCount)
			{
				terrainGeneratorCacheData = (_disposedCacheData = new TerrainGeneratorCacheData(terrainGenerator.BiomeCount, terrainGenerator.TerrainQuadVertexCount));
			}
			_vertexData = new PlanetVertexData(terrainGeneratorCacheData);
		}

		public void Dispose()
		{
		}

		public TerrainGeneratorCacheData GetCacheData()
		{
			return _source.GetCacheData();
		}

		public double GetHeight(Vector3d normalizedPosition)
		{
			return 0.0;
		}

		public double GetHeight(Vector3d normalizedPosition, TerrainGeneratorCacheData cacheData)
		{
			return 0.0;
		}

		public QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			return _source.GetRequiredTerrainMeshData();
		}

		public QuadMeshDataFlags GetRequiredWaterMeshData()
		{
			return _source.GetRequiredWaterMeshData();
		}

		public Material GetTerrainMaterial(IQuadSphereQuad quad)
		{
			return _source.GetTerrainMaterial(quad);
		}

		public PlanetVertexData GetVertexData(VertexDataRequestType type, Vector3d normalizedPosition, Vector3d? normal = null, TerrainGeneratorCacheData cacheData = null)
		{
			return _vertexData;
		}

		public PlanetVertexData GetVertexDataBiomeAndHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _vertexData;
		}

		public void GetVertexDataBiomeAndHeightPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData)
		{
		}

		public PlanetVertexData GetVertexDataBiomePass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _vertexData;
		}

		public PlanetVertexData GetVertexDataFinalPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _vertexData;
		}

		public void GetVertexDataFinalPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData)
		{
		}

		public PlanetVertexData GetVertexDataHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _vertexData;
		}

		public PlanetVertexData GetVertexDataWaterPass(TerrainGeneratorCacheData cacheData)
		{
			return _vertexData;
		}

		public PlanetVertexData GetVertexDataWaterPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _vertexData;
		}

		public Material GetWaterMaterial(IQuadSphereQuad quad)
		{
			return _source.GetWaterMaterial(quad);
		}

		public void InitializeQuadSphere(IQuadSphere quadSphere)
		{
		}

		public void RegisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
		}

		public void RegisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
		}

		public void UnregisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
		}

		public void UnregisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
		}
	}
}
