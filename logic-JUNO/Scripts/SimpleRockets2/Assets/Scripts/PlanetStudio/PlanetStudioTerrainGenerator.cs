using System;
using System.Collections.Generic;
using ModApi.Planet;
using ModApi.Planet.Modifiers.Material;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetStudioTerrainGenerator : ITerrainGenerator, IDisposable
	{
		private List<Color> _biomeColors;

		private TerrainGenerator _terrainGenerator;

		public int BiomeCount => TerrainGenerator.TerrainData.Biomes.Count;

		public float LegacyHeightMax => _terrainGenerator.LegacyHeightMax;

		public float LegacyHeightMin => _terrainGenerator.LegacyHeightMin;

		public PlanetMapSet MapSet
		{
			get
			{
				return TerrainGenerator.TerrainData.MapSet;
			}
			set
			{
				((PlanetTerrainDataScript)TerrainGenerator.TerrainData).MapSet = value;
			}
		}

		public float SeaLevel => _terrainGenerator.SeaLevel;

		public bool ShowBiomes { get; set; }

		public IPlanetTerrainData TerrainData => _terrainGenerator.TerrainData;

		public TerrainGenerator TerrainGenerator => _terrainGenerator;

		public TerrainMaterialModifier TerrainMaterialModifier => _terrainGenerator.TerrainMaterialModifier;

		public int TerrainQuadVertexCount => _terrainGenerator.TerrainQuadVertexCount;

		public WaterMaterialModifier WaterMaterialModifier => _terrainGenerator.WaterMaterialModifier;

		public PlanetStudioTerrainGenerator(TerrainGenerator terrainGenerator)
		{
			_terrainGenerator = terrainGenerator;
			_biomeColors = new List<Color>();
			_biomeColors.Add(Color.white);
			_biomeColors.Add(Color.red);
			_biomeColors.Add(Color.green);
			_biomeColors.Add(Color.blue);
			_biomeColors.Add(Color.yellow);
			_biomeColors.Add(Color.magenta);
			_biomeColors.Add(Color.cyan);
		}

		public void Dispose()
		{
			_terrainGenerator.Dispose();
		}

		public TerrainGeneratorCacheData GetCacheData()
		{
			return _terrainGenerator.GetCacheData();
		}

		public double GetHeight(Vector3d normalizedPosition)
		{
			return _terrainGenerator.GetHeight(normalizedPosition);
		}

		public double GetHeight(Vector3d normalizedPosition, TerrainGeneratorCacheData cacheData)
		{
			return _terrainGenerator.GetHeight(normalizedPosition, cacheData);
		}

		public QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			return _terrainGenerator.GetRequiredTerrainMeshData();
		}

		public QuadMeshDataFlags GetRequiredWaterMeshData()
		{
			return _terrainGenerator.GetRequiredWaterMeshData();
		}

		public Material GetTerrainMaterial(IQuadSphereQuad quad)
		{
			return _terrainGenerator.GetTerrainMaterial(quad);
		}

		public PlanetVertexData GetVertexData(VertexDataRequestType type, Vector3d normalizedPosition, Vector3d? normal = null, TerrainGeneratorCacheData cacheData = null)
		{
			return _terrainGenerator.GetVertexData(type, normalizedPosition, normal, cacheData);
		}

		public PlanetVertexData GetVertexDataBiomeAndHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _terrainGenerator.GetVertexDataBiomeAndHeightPass(normalizedPosition, quadVertexIndex, cacheData);
		}

		public void GetVertexDataBiomeAndHeightPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData)
		{
			_terrainGenerator.GetVertexDataBiomeAndHeightPass(inputs, cacheData);
		}

		public PlanetVertexData GetVertexDataBiomePass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _terrainGenerator.GetVertexDataBiomePass(normalizedPosition, quadVertexIndex, cacheData);
		}

		public PlanetVertexData GetVertexDataFinalPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			if (ShowBiomes)
			{
				PlanetMapSet.MapSampleResult mapSampleResult = MapSet.CreateSampleResult();
				MapSet.SampleMaps(normalizedPosition, mapSampleResult, null);
				Color black = Color.black;
				for (int i = 0; i < mapSampleResult.NumBiomes; i++)
				{
					black += mapSampleResult.GetBiomeStrength(i) * _biomeColors[i];
				}
				PlanetVertexData obj = cacheData.VertexDataResults[quadVertexIndex];
				obj.Color = black;
				return obj;
			}
			return _terrainGenerator.GetVertexDataFinalPass(normalizedPosition, normal, quadVertexIndex, cacheData);
		}

		public void GetVertexDataFinalPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData)
		{
			_terrainGenerator.GetVertexDataFinalPass(inputs, cacheData);
		}

		public PlanetVertexData GetVertexDataHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _terrainGenerator.GetVertexDataHeightPass(normalizedPosition, quadVertexIndex, cacheData);
		}

		public PlanetVertexData GetVertexDataWaterPass(TerrainGeneratorCacheData cacheData)
		{
			return _terrainGenerator.GetVertexDataWaterPass(cacheData);
		}

		public PlanetVertexData GetVertexDataWaterPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			return _terrainGenerator.GetVertexDataWaterPass(normalizedPosition, normal, quadVertexIndex, cacheData);
		}

		public Material GetWaterMaterial(IQuadSphereQuad quad)
		{
			return _terrainGenerator.GetWaterMaterial(quad);
		}

		public void InitializeQuadSphere(IQuadSphere quadSphere)
		{
			_terrainGenerator.InitializeQuadSphere(quadSphere);
		}

		public void RegisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			_terrainGenerator.RegisterTerrainMaterialRequestedCallback(materialRequestedCallback);
		}

		public void RegisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			_terrainGenerator.RegisterWaterMaterialRequestedCallback(materialRequestedCallback);
		}

		public void UnregisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			_terrainGenerator.UnregisterTerrainMaterialRequestedCallback(materialRequestedCallback);
		}

		public void UnregisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			_terrainGenerator.UnregisterWaterMaterialRequestedCallback(materialRequestedCallback);
		}
	}
}
