using System.Collections.Generic;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.Vegetation.Masks;
using AwesomeTechnologies.Vegetation.PersistentStorage;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationCellSpawner
	{
		public NativeList<JobHandle> JobHandleList;

		public NativeList<JobHandle> CellJobHandleList;

		public NativeArray<float> RandomNumbers;

		public List<IVegetationStudioTerrain> VegetationStudioTerrainList;

		public List<VegetationPackagePro> VegetationPackageProList;

		public List<VegetationPackageProModelInfo> VegetationPackageProModelsList;

		public VegetationSettings VegetationSettings;

		public VegetationSystemPro VegetationSystemPro;

		public PersistentVegetationStorage PersistentVegetationStorage;

		public List<VegetationCell> CompactMemoryCellList;

		public VegetationInstanceDataPool VegetationInstanceDataPool;

		public float WorldspaceSeaLevel;

		public void Init()
		{
			JobHandleList = new NativeList<JobHandle>(64, Allocator.Persistent);
			CellJobHandleList = new NativeList<JobHandle>(64, Allocator.Persistent);
			GenerateRandomNumberList();
			VegetationInstanceDataPool = new VegetationInstanceDataPool();
		}

		private void GenerateRandomNumberList()
		{
			Random.InitState(0);
			RandomNumbers = new NativeArray<float>(10000, Allocator.Persistent);
			for (int i = 0; i <= RandomNumbers.Length - 1; i++)
			{
				RandomNumbers[i] = Random.Range(0f, 1f);
			}
		}

		private int GetFirstUnityTerrainIndex()
		{
			for (int i = 0; i <= VegetationStudioTerrainList.Count - 1; i++)
			{
				if (VegetationStudioTerrainList[i] is UnityTerrain)
				{
					return i;
				}
			}
			return -1;
		}

		public void PrepareVegetationCell(VegetationCell vegetationCell)
		{
			int num = 0;
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				num += VegetationPackageProList[i].VegetationInfoList.Count;
				VegetationPackageInstances item = new VegetationPackageInstances(VegetationPackageProList[i].VegetationInfoList.Count);
				vegetationCell.VegetationPackageInstancesList.Add(item);
			}
			vegetationCell.VegetationInstanceDataList.Capacity = num;
			vegetationCell.Prepared = true;
		}

		private JobHandle ExecuteSpawnRules(VegetationCell vegetationCell, Rect vegetationCellRect, int vegetationPackageIndex, int vegetationItemIndex)
		{
			int firstUnityTerrainIndex = GetFirstUnityTerrainIndex();
			VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[vegetationPackageIndex].VegetationInfoList[vegetationItemIndex];
			VegetationPackagePro vegetationPackagePro = VegetationPackageProList[vegetationPackageIndex];
			VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[vegetationPackageIndex].VegetationItemModelList[vegetationItemIndex];
			BiomeType biomeType = VegetationPackageProList[vegetationPackageIndex].BiomeType;
			int biomeSortOrder = VegetationPackageProList[vegetationPackageIndex].BiomeSortOrder;
			float vegetationItemDensity = VegetationSettings.GetVegetationItemDensity(vegetationItemInfoPro.VegetationType);
			if (vegetationCell.VegetationPackageInstancesList[vegetationPackageIndex].LoadStateList[vegetationItemIndex] == 1)
			{
				return default(JobHandle);
			}
			vegetationCell.VegetationPackageInstancesList[vegetationPackageIndex].LoadStateList[vegetationItemIndex] = 1;
			bool flag = biomeType == BiomeType.Default || vegetationCell.HasBiome(biomeType);
			if (vegetationItemDensity < 0.05f)
			{
				flag = false;
			}
			NativeList<MatrixInstance> nativeList = vegetationCell.VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemMatrixList[vegetationItemIndex];
			nativeList.Clear();
			if (!vegetationItemInfoPro.EnableRuntimeSpawn)
			{
				flag = false;
			}
			if (vegetationItemInfoPro.UseVegetationMask)
			{
				bool flag2 = false;
				if (vegetationCell.VegetationMaskList != null)
				{
					for (int i = 0; i <= vegetationCell.VegetationMaskList.Count - 1; i++)
					{
						if (vegetationCell.VegetationMaskList[i].HasVegetationTypeIndex(vegetationItemInfoPro.VegetationTypeIndex))
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					flag = false;
				}
			}
			JobHandle jobHandle = default(JobHandle);
			if (flag)
			{
				VegetationInstanceData vegetationInstanceData = VegetationInstanceDataPool.GetObject();
				vegetationInstanceData.Clear();
				vegetationCell.VegetationInstanceDataList.Add(vegetationInstanceData);
				float num = vegetationItemInfoPro.SampleDistance / vegetationItemDensity;
				float num2 = 1f;
				float num3 = Mathf.Clamp(num / num2, 0.1f, vegetationCell.VegetationCellBounds.size.x / 2f);
				int num4 = Mathf.CeilToInt(vegetationCell.VegetationCellBounds.size.x / num3);
				int num5 = Mathf.CeilToInt(vegetationCell.VegetationCellBounds.size.z / num3);
				int num6 = (nativeList.Capacity = num4 * num5);
				vegetationInstanceData.SpawnLocations.ResizeUninitialized(num6);
				if (firstUnityTerrainIndex > -1)
				{
					vegetationInstanceData.ResizeUninitialized(num6);
					jobHandle = new InitInstanceData
					{
						HeightmapSampled = vegetationInstanceData.HeightmapSampled.AsDeferredJobArray(),
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray()
					}.Schedule(num6, 256, jobHandle);
				}
				else
				{
					vegetationInstanceData.SetCapasity(num6);
				}
				float defaultSpawnChance = 0f;
				if (biomeType == BiomeType.Default)
				{
					defaultSpawnChance = 1f;
				}
				jobHandle = new CalculateCellSpawnLocationsWideJob
				{
					SpawnLocations = vegetationInstanceData.SpawnLocations.AsDeferredJobArray(),
					CellSize = vegetationCell.VegetationCellBounds.size,
					CellCorner = vegetationCell.VegetationCellBounds.center - vegetationCell.VegetationCellBounds.extents,
					SampleDistance = num,
					RandomizePosition = vegetationItemInfoPro.RandomizePosition,
					Density = 1f,
					DefaultSpawnChance = defaultSpawnChance,
					RandomNumbers = RandomNumbers,
					CellRect = vegetationCellRect,
					CellIndex = vegetationCell.Index,
					Seed = vegetationItemInfoPro.Seed + VegetationSettings.Seed,
					UseSamplePointOffset = vegetationItemInfoPro.UseSamplePointOffset,
					SamplePointMinOffset = vegetationItemInfoPro.SamplePointMinOffset,
					SamplePointMaxOffset = vegetationItemInfoPro.SamplePointMaxOffset,
					XSamples = num4,
					ZSamples = num5,
					CalculatedSampleDistance = num3
				}.Schedule(num6, 64, jobHandle);
				if (vegetationCell.BiomeMaskList != null)
				{
					for (int j = 0; j <= vegetationCell.BiomeMaskList.Count - 1; j++)
					{
						if (vegetationCell.BiomeMaskList[j].BiomeSortOrder >= biomeSortOrder)
						{
							jobHandle = vegetationCell.BiomeMaskList[j].FilterSpawnLocations(vegetationInstanceData.SpawnLocations, biomeType, num6, jobHandle);
						}
					}
				}
				if (vegetationItemInfoPro.UseNoiseCutoff)
				{
					jobHandle = new PerlinNoiseCutoffJob
					{
						InversePerlinMask = vegetationItemInfoPro.NoiseCutoffInverse,
						PerlinCutoff = vegetationItemInfoPro.NoiseCutoffValue,
						PerlinScale = vegetationItemInfoPro.NoiseCutoffScale,
						Offset = vegetationItemInfoPro.NoiseCutoffOffset,
						SpawnLocationList = vegetationInstanceData.SpawnLocations.AsDeferredJobArray()
					}.Schedule(num6, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseNoiseDensity)
				{
					jobHandle = new PerlinNoiseDensityJob
					{
						InversePerlinMask = vegetationItemInfoPro.NoiseDensityInverse,
						PerlinScale = vegetationItemInfoPro.NoiseDensityScale,
						Offset = vegetationItemInfoPro.NoiseDensityOffset,
						SpawnLocationList = vegetationInstanceData.SpawnLocations.AsDeferredJobArray()
					}.Schedule(num6, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseTextureMaskDensityRules)
				{
					for (int k = 0; k <= vegetationItemInfoPro.TextureMaskDensityRuleList.Count - 1; k++)
					{
						TextureMaskGroup textureMaskGroup = vegetationPackagePro.GetTextureMaskGroup(vegetationItemInfoPro.TextureMaskDensityRuleList[k].TextureMaskGroupID);
						if (textureMaskGroup != null)
						{
							jobHandle = textureMaskGroup.SampleDensityMask(vegetationInstanceData, vegetationCellRect, vegetationItemInfoPro.TextureMaskDensityRuleList[k], jobHandle);
						}
					}
				}
				jobHandle = new FilterSpawnLocationsChanceJob
				{
					SpawnLocationList = vegetationInstanceData.SpawnLocations.AsDeferredJobArray(),
					RandomNumbers = RandomNumbers,
					Density = vegetationItemInfoPro.Density
				}.Schedule(num6, 64, jobHandle);
				for (int l = 0; l <= VegetationStudioTerrainList.Count - 1; l++)
				{
					jobHandle = VegetationStudioTerrainList[l].SampleTerrain(vegetationInstanceData.SpawnLocations, vegetationInstanceData, num6, vegetationCellRect, jobHandle);
				}
				if (vegetationItemInfoPro.UseTerrainSourceExcludeRule)
				{
					jobHandle = new TerrainSourceExcludeRuleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						TerrainSourceID = vegetationInstanceData.TerrainSourceID.AsDeferredJobArray(),
						TerrainSourceRule = vegetationItemInfoPro.TerrainSourceExcludeRule
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseTerrainSourceIncludeRule)
				{
					jobHandle = new TerrainSourceIncludeRuleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						TerrainSourceID = vegetationInstanceData.TerrainSourceID.AsDeferredJobArray(),
						TerrainSourceRule = vegetationItemInfoPro.TerrainSourceIncludeRule
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseSteepnessRule)
				{
					jobHandle = new InstanceSteepnessRuleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						TerrainNormal = vegetationInstanceData.TerrainNormal.AsDeferredJobArray(),
						RandomNumberIndex = vegetationInstanceData.RandomNumberIndex.AsDeferredJobArray(),
						MinSteepness = vegetationItemInfoPro.MinSteepness,
						MaxSteepness = vegetationItemInfoPro.MaxSteepness,
						Advanced = vegetationItemInfoPro.UseAdvancedSteepnessRule,
						SteepnessRuleCurveArray = vegetationItemModelInfo.SteepnessRuleCurveArray,
						RandomNumbers = RandomNumbers
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseHeightRule)
				{
					jobHandle = new InstanceHeightRuleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						Position = vegetationInstanceData.Position.AsDeferredJobArray(),
						RandomNumberIndex = vegetationInstanceData.RandomNumberIndex.AsDeferredJobArray(),
						MinHeight = vegetationItemInfoPro.MinHeight + WorldspaceSeaLevel,
						MaxHeight = vegetationItemInfoPro.MaxHeight + WorldspaceSeaLevel,
						Advanced = vegetationItemInfoPro.UseAdvancedHeightRule,
						HeightRuleCurveArray = vegetationItemModelInfo.HeightRuleCurveArray,
						RandomNumbers = RandomNumbers,
						MaxCurveHeight = vegetationItemInfoPro.MaxCurveHeight
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (!vegetationItemInfoPro.UseVegetationMask && vegetationCell.VegetationMaskList != null)
				{
					for (int m = 0; m <= vegetationCell.VegetationMaskList.Count - 1; m++)
					{
						jobHandle = vegetationCell.VegetationMaskList[m].SampleMask(vegetationInstanceData, vegetationItemInfoPro.VegetationType, jobHandle);
					}
				}
				else if (vegetationCell.VegetationMaskList != null)
				{
					for (int n = 0; n <= vegetationCell.VegetationMaskList.Count - 1; n++)
					{
						jobHandle = vegetationCell.VegetationMaskList[n].SampleIncludeVegetationMask(vegetationInstanceData, vegetationItemInfoPro.VegetationTypeIndex, jobHandle);
					}
					if (vegetationCell.VegetationMaskList.Count > 0)
					{
						jobHandle = new ProcessIncludeVegetationMaskJob
						{
							Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
							Scale = vegetationInstanceData.Scale.AsDeferredJobArray(),
							RandomNumberIndex = vegetationInstanceData.RandomNumberIndex.AsDeferredJobArray(),
							VegetationMaskDensity = vegetationInstanceData.VegetationMaskDensity.AsDeferredJobArray(),
							VegetationMaskScale = vegetationInstanceData.VegetationMaskScale.AsDeferredJobArray(),
							RandomNumbers = RandomNumbers
						}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
					}
				}
				if (vegetationItemInfoPro.UseConcaveLocationRule)
				{
					for (int num8 = 0; num8 <= VegetationStudioTerrainList.Count - 1; num8++)
					{
						jobHandle = VegetationStudioTerrainList[num8].SampleConcaveLocation(vegetationInstanceData, vegetationItemInfoPro.ConcaveLoactionMinHeightDifference, vegetationItemInfoPro.ConcaveLoactionDistance, vegetationItemInfoPro.ConcaveLocationInverse, vegetationItemInfoPro.ConcaveLoactionAverage, vegetationCellRect, jobHandle);
					}
				}
				if (vegetationItemInfoPro.UseTextureMaskIncludeRules)
				{
					for (int num9 = 0; num9 <= vegetationItemInfoPro.TextureMaskIncludeRuleList.Count - 1; num9++)
					{
						TextureMaskGroup textureMaskGroup2 = vegetationPackagePro.GetTextureMaskGroup(vegetationItemInfoPro.TextureMaskIncludeRuleList[num9].TextureMaskGroupID);
						if (textureMaskGroup2 != null)
						{
							jobHandle = textureMaskGroup2.SampleIncludeMask(vegetationInstanceData, vegetationCellRect, vegetationItemInfoPro.TextureMaskIncludeRuleList[num9], jobHandle);
						}
					}
					jobHandle = new FilterIncludeMaskJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						TextureMaskData = vegetationInstanceData.TextureMaskData.AsDeferredJobArray()
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseTextureMaskExcludeRules)
				{
					for (int num10 = 0; num10 <= vegetationItemInfoPro.TextureMaskExcludeRuleList.Count - 1; num10++)
					{
						TextureMaskGroup textureMaskGroup3 = vegetationPackagePro.GetTextureMaskGroup(vegetationItemInfoPro.TextureMaskExcludeRuleList[num10].TextureMaskGroupID);
						if (textureMaskGroup3 != null)
						{
							jobHandle = textureMaskGroup3.SampleExcludeMask(vegetationInstanceData, vegetationCellRect, vegetationItemInfoPro.TextureMaskExcludeRuleList[num10], jobHandle);
						}
					}
				}
				if (vegetationItemInfoPro.UseTextureMaskScaleRules)
				{
					for (int num11 = 0; num11 <= vegetationItemInfoPro.TextureMaskScaleRuleList.Count - 1; num11++)
					{
						TextureMaskGroup textureMaskGroup4 = vegetationPackagePro.GetTextureMaskGroup(vegetationItemInfoPro.TextureMaskScaleRuleList[num11].TextureMaskGroupID);
						if (textureMaskGroup4 != null)
						{
							jobHandle = textureMaskGroup4.SampleScaleMask(vegetationInstanceData, vegetationCellRect, vegetationItemInfoPro.TextureMaskScaleRuleList[num11], jobHandle);
						}
					}
				}
				jobHandle = new OffsetAndRotateScaleVegetationInstanceMathJob
				{
					RandomNumbers = RandomNumbers,
					Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
					Scale = vegetationInstanceData.Scale.AsDeferredJobArray(),
					Position = vegetationInstanceData.Position.AsDeferredJobArray(),
					Rotation = vegetationInstanceData.Rotation.AsDeferredJobArray(),
					RandomNumberIndex = vegetationInstanceData.RandomNumberIndex.AsDeferredJobArray(),
					TerrainNormal = vegetationInstanceData.TerrainNormal.AsDeferredJobArray(),
					VegetationRotationType = vegetationItemInfoPro.Rotation,
					MinScale = vegetationItemInfoPro.MinScale,
					MaxScale = vegetationItemInfoPro.MaxScale,
					Offset = vegetationItemInfoPro.Offset,
					RotationOffset = vegetationItemInfoPro.RotationOffset,
					ScaleMultiplier = vegetationItemInfoPro.ScaleMultiplier,
					MinUpOffset = vegetationItemInfoPro.MinUpOffset,
					MaxUpOffset = vegetationItemInfoPro.MaxUpOffset
				}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				if (vegetationItemInfoPro.UseNoiseScaleRule)
				{
					jobHandle = new PerlinNoiseScaleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						Position = vegetationInstanceData.Position.AsDeferredJobArray(),
						Scale = vegetationInstanceData.Scale.AsDeferredJobArray(),
						PerlinScale = vegetationItemInfoPro.NoiseScaleScale,
						MinScale = vegetationItemInfoPro.NoiseScaleMinScale,
						MaxScale = vegetationItemInfoPro.NoiseScaleMaxScale,
						InversePerlinMask = vegetationItemInfoPro.NoiseScaleInverse,
						Offset = vegetationItemInfoPro.NoiseScaleOffset
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseBiomeEdgeScaleRule && biomeType != BiomeType.Default)
				{
					jobHandle = new BiomeEdgeDistanceScaleRuleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						Scale = vegetationInstanceData.Scale.AsDeferredJobArray(),
						BiomeDistance = vegetationInstanceData.BiomeDistance.AsDeferredJobArray(),
						MinScale = vegetationItemInfoPro.BiomeEdgeScaleMinScale,
						MaxScale = vegetationItemInfoPro.BiomeEdgeScaleMaxScale,
						MaxDistance = vegetationItemInfoPro.BiomeEdgeScaleDistance,
						InverseScale = vegetationItemInfoPro.BiomeEdgeScaleInverse
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseBiomeEdgeIncludeRule && biomeType != BiomeType.Default)
				{
					jobHandle = new BiomeEdgeDistanceIncludeRuleJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						BiomeDistance = vegetationInstanceData.BiomeDistance.AsDeferredJobArray(),
						MaxDistance = vegetationItemInfoPro.BiomeEdgeIncludeDistance,
						Inverse = vegetationItemInfoPro.BiomeEdgeIncludeInverse
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				if (vegetationItemInfoPro.UseTerrainTextureIncludeRules)
				{
					for (int num12 = 0; num12 <= VegetationStudioTerrainList.Count - 1; num12++)
					{
						jobHandle = VegetationStudioTerrainList[num12].ProcessSplatmapRules(vegetationItemInfoPro.TerrainTextureIncludeRuleList, vegetationInstanceData, include: true, vegetationCellRect, jobHandle);
					}
				}
				if (vegetationItemInfoPro.UseTerrainTextureExcludeRules)
				{
					for (int num13 = 0; num13 <= VegetationStudioTerrainList.Count - 1; num13++)
					{
						jobHandle = VegetationStudioTerrainList[num13].ProcessSplatmapRules(vegetationItemInfoPro.TerrainTextureExcludeRuleList, vegetationInstanceData, include: false, vegetationCellRect, jobHandle);
					}
				}
				if (vegetationItemInfoPro.UseDistanceFalloff)
				{
					jobHandle = new DistanceFalloffJob
					{
						Excluded = vegetationInstanceData.Excluded.AsDeferredJobArray(),
						RandomNumberIndex = vegetationInstanceData.RandomNumberIndex.AsDeferredJobArray(),
						DistanceFalloff = vegetationInstanceData.DistanceFalloff.AsDeferredJobArray(),
						RandomNumbers = RandomNumbers,
						DistanceFalloffStartDistance = vegetationItemInfoPro.DistanceFalloffStartDistance
					}.Schedule(vegetationInstanceData.Excluded, 64, jobHandle);
				}
				jobHandle = new NewCreateInstanceMatrixJob
				{
					Excluded = vegetationInstanceData.Excluded,
					Position = vegetationInstanceData.Position,
					Scale = vegetationInstanceData.Scale,
					Rotation = vegetationInstanceData.Rotation,
					DistanceFalloff = vegetationInstanceData.DistanceFalloff,
					VegetationInstanceMatrixList = nativeList
				}.Schedule(jobHandle);
			}
			if (!flag)
			{
				if ((bool)PersistentVegetationStorage && !PersistentVegetationStorage.DisablePersistentStorage)
				{
					PersistentVegetationInfo persistentVegetationInfo = PersistentVegetationStorage.GetPersistentVegetationCell(vegetationCell.Index)?.GetPersistentVegetationInfo(vegetationItemInfoPro.VegetationItemID);
					if (persistentVegetationInfo != null && persistentVegetationInfo.VegetationItemList.Count > 0)
					{
						persistentVegetationInfo.CopyToNativeArray();
						nativeList.ResizeUninitialized(persistentVegetationInfo.NativeVegetationItemArray.Length);
						jobHandle = new LoadPersistentStorageToMatrixWideJob
						{
							InstanceList = persistentVegetationInfo.NativeVegetationItemArray,
							VegetationInstanceMatrixList = nativeList.AsDeferredJobArray(),
							VegetationSystemPosition = VegetationSystemPro.VegetationSystemPosition
						}.Schedule(nativeList, 64, jobHandle);
					}
				}
			}
			else if ((bool)PersistentVegetationStorage && !PersistentVegetationStorage.DisablePersistentStorage)
			{
				PersistentVegetationInfo persistentVegetationInfo2 = PersistentVegetationStorage.GetPersistentVegetationCell(vegetationCell.Index)?.GetPersistentVegetationInfo(vegetationItemInfoPro.VegetationItemID);
				if (persistentVegetationInfo2 != null && persistentVegetationInfo2.VegetationItemList.Count > 0)
				{
					persistentVegetationInfo2.CopyToNativeArray();
					jobHandle = new LoadPersistentStorageToMatrixJob
					{
						InstanceList = persistentVegetationInfo2.NativeVegetationItemArray,
						VegetationInstanceMatrixList = nativeList,
						VegetationSystemPosition = VegetationSystemPro.VegetationSystemPosition
					}.Schedule(jobHandle);
				}
			}
			JobHandle.ScheduleBatchedJobs();
			return jobHandle;
		}

		public JobHandle SpawnVegetationCell(VegetationCell vegetationCell, out bool hasInstancedIndirect)
		{
			hasInstancedIndirect = false;
			JobHandleList.Clear();
			Rect rectangle = vegetationCell.Rectangle;
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				for (int j = 0; j <= VegetationPackageProList[i].VegetationInfoList.Count - 1; j++)
				{
					VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[i].VegetationInfoList[j];
					JobHandleList.Add(ExecuteSpawnRules(vegetationCell, rectangle, i, j));
					if (vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.InstancedIndirect)
					{
						hasInstancedIndirect = true;
					}
				}
			}
			if (JobHandleList.Length > 0)
			{
				CompactMemoryCellList.Add(vegetationCell);
				return JobHandle.CombineDependencies(JobHandleList);
			}
			return default(JobHandle);
		}

		public JobHandle SpawnVegetationCell(VegetationCell vegetationCell, string vegetationItemID, out bool hasInstancedIndirect)
		{
			hasInstancedIndirect = false;
			Rect rectangle = vegetationCell.Rectangle;
			VegetationItemIndexes vegetationItemIndexes = VegetationSystemPro.GetVegetationItemIndexes(vegetationItemID);
			if (vegetationItemIndexes.VegetationPackageIndex >= 0)
			{
				if (VegetationPackageProList[vegetationItemIndexes.VegetationPackageIndex].VegetationInfoList[vegetationItemIndexes.VegetationItemIndex].VegetationRenderMode == VegetationRenderMode.InstancedIndirect)
				{
					hasInstancedIndirect = true;
				}
				CompactMemoryCellList.Add(vegetationCell);
				return ExecuteSpawnRules(vegetationCell, rectangle, vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
			}
			return default(JobHandle);
		}

		public JobHandle SpawnVegetationCell(VegetationCell vegetationCell, int currentDistanceBand, out bool hasInstancedIndirect, bool billboardsOnly)
		{
			hasInstancedIndirect = false;
			if (billboardsOnly)
			{
				vegetationCell.LoadedBillboards = true;
			}
			else
			{
				vegetationCell.LoadedDistanceBand = currentDistanceBand;
			}
			JobHandleList.Clear();
			Rect rectangle = vegetationCell.Rectangle;
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				for (int j = 0; j <= VegetationPackageProList[i].VegetationInfoList.Count - 1; j++)
				{
					VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[i].VegetationInfoList[j];
					if (billboardsOnly && (!vegetationItemInfoPro.UseBillboards || vegetationItemInfoPro.VegetationType != VegetationType.Tree))
					{
						continue;
					}
					int distanceBand = vegetationItemInfoPro.GetDistanceBand();
					if (currentDistanceBand <= distanceBand)
					{
						JobHandleList.Add(ExecuteSpawnRules(vegetationCell, rectangle, i, j));
						if (vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.InstancedIndirect)
						{
							hasInstancedIndirect = true;
						}
					}
				}
			}
			if (JobHandleList.Length > 0)
			{
				CompactMemoryCellList.Add(vegetationCell);
				return JobHandle.CombineDependencies(JobHandleList);
			}
			return default(JobHandle);
		}

		public void Dispose()
		{
			if (JobHandleList.IsCreated)
			{
				JobHandleList.Dispose();
			}
			if (CellJobHandleList.IsCreated)
			{
				CellJobHandleList.Dispose();
			}
			if (RandomNumbers.IsCreated)
			{
				RandomNumbers.Dispose();
			}
			VegetationInstanceDataPool.Dispose();
		}
	}
}
