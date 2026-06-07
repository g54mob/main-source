using System;
using System.Collections.Generic;
using AwesomeTechnologies.VegetationStudio;
using AwesomeTechnologies.VegetationSystem;
using AwesomeTechnologies.VegetationSystem.Biomes;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AwesomeTechnologies.TerrainSystem
{
	public class TerrainSystemPro : MonoBehaviour
	{
		public VegetationSystemPro VegetationSystemPro;

		public int CurrentTabIndex;

		public int VegetationPackageIndex;

		public int VegetationPackageTextureIndex;

		public bool ShowCurvesMenu = true;

		public bool ShowNoiseMenu = true;

		private void Reset()
		{
			VegetationSystemPro = GetComponent<VegetationSystemPro>();
		}

		private List<IVegetationStudioTerrain> GetOverlapTerrainList(Bounds updateBounds)
		{
			List<IVegetationStudioTerrain> list = new List<IVegetationStudioTerrain>();
			for (int i = 0; i <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; i++)
			{
				if (VegetationSystemPro.VegetationStudioTerrainList[i].NeedsSplatMapUpdate(updateBounds))
				{
					list.Add(VegetationSystemPro.VegetationStudioTerrainList[i]);
				}
			}
			return list;
		}

		private void PrepareTextureCurves()
		{
			for (int i = 0; i <= VegetationSystemPro.VegetationPackageProList.Count - 1; i++)
			{
				VegetationSystemPro.VegetationPackageProList[i].PrepareNativeArrayTextureCurves();
			}
		}

		private void DisposeTextureCurves()
		{
			for (int i = 0; i <= VegetationSystemPro.VegetationPackageProList.Count - 1; i++)
			{
				VegetationSystemPro.VegetationPackageProList[i].DisposeNativeArrayTextureCurves();
			}
		}

		public Texture2D GetTerrainTexture(int index)
		{
			for (int i = 0; i <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; i++)
			{
				IVegetationStudioTerrain vegetationStudioTerrain = VegetationSystemPro.VegetationStudioTerrainList[i];
				if (vegetationStudioTerrain.HasTerrainTextures())
				{
					return vegetationStudioTerrain.GetTerrainTexture(index);
				}
			}
			return null;
		}

		public void GetSplatPrototypesFromTerrain(VegetationPackagePro vegetationPackage)
		{
			for (int i = 0; i <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; i++)
			{
				IVegetationStudioTerrain vegetationStudioTerrain = VegetationSystemPro.VegetationStudioTerrainList[i];
				if (!vegetationStudioTerrain.HasTerrainTextures())
				{
					continue;
				}
				TerrainLayer[] terrainLayers = vegetationStudioTerrain.GetTerrainLayers();
				for (int j = 0; j <= vegetationPackage.TerrainTextureList.Count - 1; j++)
				{
					if (j < terrainLayers.Length)
					{
						vegetationPackage.TerrainTextureList[j].Texture = terrainLayers[j].diffuseTexture;
						vegetationPackage.TerrainTextureList[j].TextureNormals = terrainLayers[j].normalMapTexture;
						vegetationPackage.TerrainTextureList[j].Offset = terrainLayers[j].tileOffset;
						vegetationPackage.TerrainTextureList[j].TileSize = terrainLayers[j].tileSize;
					}
				}
				break;
			}
		}

		public void SetSplatPrototypes(VegetationPackagePro vegetationPackage)
		{
			TerrainLayer[] array = new TerrainLayer[vegetationPackage.TerrainTextureList.Count];
			for (int i = 0; i <= vegetationPackage.TerrainTextureList.Count - 1; i++)
			{
				TerrainTextureInfo terrainTextureInfo = vegetationPackage.TerrainTextureList[i];
				TerrainLayer terrainLayer = terrainTextureInfo.TerrainLayer;
				if (terrainLayer == null)
				{
					terrainLayer = (terrainTextureInfo.TerrainLayer = new TerrainLayer
					{
						diffuseTexture = terrainTextureInfo.Texture,
						normalMapTexture = terrainTextureInfo.TextureNormals,
						tileSize = terrainTextureInfo.TileSize,
						tileOffset = terrainTextureInfo.Offset
					});
				}
				else
				{
					terrainLayer.diffuseTexture = terrainTextureInfo.Texture;
					terrainLayer.normalMapTexture = terrainTextureInfo.TextureNormals;
					terrainLayer.tileSize = terrainTextureInfo.TileSize;
					terrainLayer.tileOffset = terrainTextureInfo.Offset;
				}
				array[i] = terrainLayer;
			}
			for (int j = 0; j <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; j++)
			{
				IVegetationStudioTerrain vegetationStudioTerrain = VegetationSystemPro.VegetationStudioTerrainList[j];
				if (vegetationStudioTerrain.HasTerrainTextures())
				{
					vegetationStudioTerrain.SetTerrainLayers(array);
				}
			}
		}

		private TerrainLayer SaveTerrainLayer(TerrainLayer terrainLayer, VegetationPackagePro vegetationPackagePro)
		{
			return null;
		}

		public void GenerateSplatMap(bool clearLockedTextures, IVegetationStudioTerrain iVegetationStudioTerrain)
		{
			if (!VegetationSystemPro)
			{
				return;
			}
			VegetationSystemPro.ClearCache(iVegetationStudioTerrain.TerrainBounds);
			PrepareTextureCurves();
			float num = VegetationSystemPro.VegetationSystemBounds.center.y - VegetationSystemPro.VegetationSystemBounds.extents.y + VegetationSystemPro.SeaLevel;
			float heightCurveSampleHeight = VegetationSystemPro.VegetationSystemBounds.center.y + VegetationSystemPro.VegetationSystemBounds.extents.y - num;
			VegetationPackagePro vegetationPackageFromBiome = VegetationSystemPro.GetVegetationPackageFromBiome(BiomeType.Default);
			if (vegetationPackageFromBiome == null)
			{
				Debug.LogWarning("You need a default biome in order to generate splatmaps. ");
				return;
			}
			iVegetationStudioTerrain.PrepareSplatmapGeneration(clearLockedTextures);
			iVegetationStudioTerrain.GenerateSplatMapBiome(VegetationSystemPro.VegetationSystemBounds, BiomeType.Default, null, vegetationPackageFromBiome.TerrainTextureSettingsList, heightCurveSampleHeight, num, clearLockedTextures);
			List<BiomeType> additionalBiomeList = VegetationSystemPro.GetAdditionalBiomeList();
			List<VegetationPackagePro> list = new List<VegetationPackagePro>();
			for (int i = 0; i <= additionalBiomeList.Count - 1; i++)
			{
				list.Add(VegetationSystemPro.GetVegetationPackageFromBiome(additionalBiomeList[i]));
			}
			BiomeSortOrderComparer comparer = new BiomeSortOrderComparer();
			list.Sort(comparer);
			for (int j = 0; j <= list.Count - 1; j++)
			{
				VegetationPackagePro vegetationPackagePro = list[j];
				if (vegetationPackagePro.GenerateBiomeSplamap)
				{
					List<PolygonBiomeMask> biomeMasks = VegetationStudioManager.GetBiomeMasks(vegetationPackagePro.BiomeType);
					iVegetationStudioTerrain.GenerateSplatMapBiome(VegetationSystemPro.VegetationSystemBounds, vegetationPackagePro.BiomeType, biomeMasks, vegetationPackagePro.TerrainTextureSettingsList, heightCurveSampleHeight, num, clearLockedTextures);
				}
			}
			JobHandle.ScheduleBatchedJobs();
			iVegetationStudioTerrain.CompleteSplatmapGeneration();
			DisposeTextureCurves();
		}

		public void GenerateSplatMap(bool clearLockedTextures)
		{
			List<IVegetationStudioTerrain> overlapTerrainList = GetOverlapTerrainList(VegetationSystemPro.VegetationSystemBounds);
			_ = overlapTerrainList.Count;
			for (int i = 0; i <= overlapTerrainList.Count - 1; i++)
			{
				GenerateSplatMap(clearLockedTextures, overlapTerrainList[i]);
				GC.Collect();
			}
		}

		public void GenerateSplatMapParallel(bool clearLockedTextures)
		{
			if (!VegetationSystemPro)
			{
				return;
			}
			VegetationSystemPro.ClearCache();
			List<IVegetationStudioTerrain> overlapTerrainList = GetOverlapTerrainList(VegetationSystemPro.VegetationSystemBounds);
			PrepareTextureCurves();
			float num = VegetationSystemPro.VegetationSystemBounds.center.y - VegetationSystemPro.VegetationSystemBounds.extents.y + VegetationSystemPro.SeaLevel;
			float heightCurveSampleHeight = VegetationSystemPro.VegetationSystemBounds.center.y + VegetationSystemPro.VegetationSystemBounds.extents.y - num;
			VegetationPackagePro vegetationPackageFromBiome = VegetationSystemPro.GetVegetationPackageFromBiome(BiomeType.Default);
			if (vegetationPackageFromBiome == null)
			{
				Debug.LogWarning("You need a default biome in order to generate splatmaps. ");
				return;
			}
			_ = overlapTerrainList.Count;
			for (int i = 0; i <= overlapTerrainList.Count - 1; i++)
			{
				overlapTerrainList[i].PrepareSplatmapGeneration(clearLockedTextures);
			}
			for (int j = 0; j <= overlapTerrainList.Count - 1; j++)
			{
				overlapTerrainList[j].GenerateSplatMapBiome(VegetationSystemPro.VegetationSystemBounds, BiomeType.Default, null, vegetationPackageFromBiome.TerrainTextureSettingsList, heightCurveSampleHeight, num, clearLockedTextures);
			}
			List<BiomeType> additionalBiomeList = VegetationSystemPro.GetAdditionalBiomeList();
			List<VegetationPackagePro> list = new List<VegetationPackagePro>();
			for (int k = 0; k <= additionalBiomeList.Count - 1; k++)
			{
				list.Add(VegetationSystemPro.GetVegetationPackageFromBiome(additionalBiomeList[k]));
			}
			BiomeSortOrderComparer comparer = new BiomeSortOrderComparer();
			list.Sort(comparer);
			for (int l = 0; l <= list.Count - 1; l++)
			{
				VegetationPackagePro vegetationPackagePro = list[l];
				if (vegetationPackagePro.GenerateBiomeSplamap)
				{
					List<PolygonBiomeMask> biomeMasks = VegetationStudioManager.GetBiomeMasks(vegetationPackagePro.BiomeType);
					for (int m = 0; m <= overlapTerrainList.Count - 1; m++)
					{
						overlapTerrainList[m].GenerateSplatMapBiome(VegetationSystemPro.VegetationSystemBounds, vegetationPackagePro.BiomeType, biomeMasks, vegetationPackagePro.TerrainTextureSettingsList, heightCurveSampleHeight, num, clearLockedTextures);
					}
				}
			}
			JobHandle.ScheduleBatchedJobs();
			for (int n = 0; n <= overlapTerrainList.Count - 1; n++)
			{
				overlapTerrainList[n].CompleteSplatmapGeneration();
			}
			DisposeTextureCurves();
		}

		public void ShowTerrainHeatmap(bool value)
		{
			if (!VegetationSystemPro)
			{
				return;
			}
			VegetationSystemPro.ShowHeatMap = value;
			if (value)
			{
				float worldspaceSeaLevel = VegetationSystemPro.VegetationSystemBounds.center.y - VegetationSystemPro.VegetationSystemBounds.extents.y + VegetationSystemPro.SeaLevel;
				float worldspaceMaxTerrainHeight = VegetationSystemPro.VegetationSystemBounds.center.y + VegetationSystemPro.VegetationSystemBounds.extents.y;
				for (int i = 0; i <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; i++)
				{
					VegetationSystemPro.VegetationStudioTerrainList[i].OverrideTerrainMaterial();
					TerrainTextureSettings terrainTextureSettings = VegetationSystemPro.VegetationPackageProList[VegetationPackageIndex].TerrainTextureSettingsList[VegetationPackageTextureIndex];
					VegetationSystemPro.VegetationStudioTerrainList[i].UpdateTerrainMaterial(worldspaceSeaLevel, worldspaceMaxTerrainHeight, terrainTextureSettings);
				}
			}
			else
			{
				for (int j = 0; j <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; j++)
				{
					VegetationSystemPro.VegetationStudioTerrainList[j].RestoreTerrainMaterial();
				}
			}
		}

		public void UpdateTerrainHeatmap()
		{
			if (VegetationSystemPro.ShowHeatMap)
			{
				float worldspaceSeaLevel = VegetationSystemPro.VegetationSystemBounds.center.y - VegetationSystemPro.VegetationSystemBounds.extents.y + VegetationSystemPro.SeaLevel;
				float worldspaceMaxTerrainHeight = VegetationSystemPro.VegetationSystemBounds.center.y + VegetationSystemPro.VegetationSystemBounds.extents.y;
				for (int i = 0; i <= VegetationSystemPro.VegetationStudioTerrainList.Count - 1; i++)
				{
					TerrainTextureSettings terrainTextureSettings = VegetationSystemPro.VegetationPackageProList[VegetationPackageIndex].TerrainTextureSettingsList[VegetationPackageTextureIndex];
					VegetationSystemPro.VegetationStudioTerrainList[i].UpdateTerrainMaterial(worldspaceSeaLevel, worldspaceMaxTerrainHeight, terrainTextureSettings);
				}
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnSceneSaving(Scene scene, string path)
		{
			ShowTerrainHeatmap(value: false);
		}
	}
}
