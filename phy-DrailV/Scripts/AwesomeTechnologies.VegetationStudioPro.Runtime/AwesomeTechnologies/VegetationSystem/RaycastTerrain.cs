using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationStudio;
using AwesomeTechnologies.VegetationSystem.Biomes;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[ExecuteInEditMode]
	public class RaycastTerrain : MonoBehaviour, IVegetationStudioTerrain
	{
		public Bounds RaycastTerrainBounds = new Bounds(Vector3.zero, new Vector3(100f, 20f, 100f));

		public LayerMask RaycastLayerMask;

		public int MaxHits = 4;

		public List<RaycastContainers> RaycastContainerList = new List<RaycastContainers>();

		public ObjectPool<RaycastContainers> RaycastContainerPool = new ObjectPool<RaycastContainers>();

		public TerrainSourceID TerrainSourceID;

		public bool AutoAddToVegegetationSystem;

		private bool _initDone;

		public Vector3 TerrainPosition = Vector3.zero;

		public string TerrainType => "Raycast terrain";

		public Bounds TerrainBounds => new Bounds(RaycastTerrainBounds.center + TerrainPosition, RaycastTerrainBounds.size);

		private void Reset()
		{
			RaycastTerrainBounds = new Bounds(Vector3.zero, new Vector3(100f, 20f, 100f));
			TerrainPosition = base.transform.position;
		}

		public void RefreshTerrainData()
		{
		}

		public void RefreshTerrainData(Bounds bounds)
		{
		}

		public JobHandle SampleCellHeight(NativeArray<Bounds> vegetationCellBoundsList, float worldspaceHeightCutoff, Rect cellBoundsRect, JobHandle dependsOn = default(JobHandle))
		{
			if (!_initDone)
			{
				return dependsOn;
			}
			Rect rect = RectExtension.CreateRectFromBounds(TerrainBounds);
			if (!cellBoundsRect.Overlaps(rect))
			{
				return dependsOn;
			}
			return new RaycastTerranCellSampleJob
			{
				VegetationCellBoundsList = vegetationCellBoundsList,
				TerrainMinHeight = TerrainBounds.center.y - TerrainBounds.extents.y,
				TerrainMaxHeight = TerrainBounds.center.y + TerrainBounds.extents.y,
				TerrainRect = rect
			}.Schedule(vegetationCellBoundsList.Length, 32, dependsOn);
		}

		public JobHandle SampleTerrain(NativeList<VegetationSpawnLocationInstance> spawnLocationList, VegetationInstanceData instanceData, int sampleCount, Rect spawnRect, JobHandle dependsOn)
		{
			if (!_initDone)
			{
				return dependsOn;
			}
			Vector3 floatingOriginOffset = VegetationStudioManager.GetFloatingOriginOffset();
			Rect rect = RectExtension.CreateRectFromBounds(TerrainBounds);
			if (!spawnRect.Overlaps(rect))
			{
				return dependsOn;
			}
			MaxHits = 1;
			RaycastContainers raycastContainers = RaycastContainerPool.Get();
			raycastContainers.RaycastCommands = new NativeArray<RaycastCommand>(sampleCount, Allocator.TempJob);
			raycastContainers.RaycastHits = new NativeArray<RaycastHit>(sampleCount * MaxHits, Allocator.TempJob);
			RaycastContainerList.Add(raycastContainers);
			dependsOn = new CreateRaycastCommandsJob
			{
				SpawnLocationList = spawnLocationList.AsDeferredJobArray(),
				LayerMask = RaycastLayerMask,
				MaxHits = MaxHits,
				RaycastCommands = raycastContainers.RaycastCommands,
				FloatingOriginOffset = floatingOriginOffset
			}.Schedule(dependsOn);
			dependsOn = RaycastCommand.ScheduleBatch(raycastContainers.RaycastCommands, raycastContainers.RaycastHits, 32, dependsOn);
			dependsOn = new UpdateInstanceListJob
			{
				Position = instanceData.Position,
				Rotation = instanceData.Rotation,
				Scale = instanceData.Scale,
				TerrainNormal = instanceData.TerrainNormal,
				BiomeDistance = instanceData.BiomeDistance,
				TerrainTextureData = instanceData.TerrainTextureData,
				RandomNumberIndex = instanceData.RandomNumberIndex,
				DistanceFalloff = instanceData.DistanceFalloff,
				VegetationMaskDensity = instanceData.VegetationMaskDensity,
				VegetationMaskScale = instanceData.VegetationMaskScale,
				TerrainSourceIDs = instanceData.TerrainSourceID,
				TextureMaskData = instanceData.TextureMaskData,
				Excluded = instanceData.Excluded,
				RaycastHits = raycastContainers.RaycastHits,
				HeightmapSampled = instanceData.HeightmapSampled,
				SpawnLocationList = spawnLocationList.AsDeferredJobArray(),
				TerrainRect = rect,
				FloatingOriginOffset = floatingOriginOffset,
				TerrainSourceID = (byte)TerrainSourceID
			}.Schedule(dependsOn);
			return dependsOn;
		}

		public bool NeedsSplatMapUpdate(Bounds updateBounds)
		{
			return false;
		}

		public void PrepareSplatmapGeneration(bool clearLockedTextures)
		{
		}

		public void GenerateSplatMapBiome(Bounds updateBounds, BiomeType biomeType, List<PolygonBiomeMask> polygonBiomeMaskList, List<TerrainTextureSettings> terrainTextureSettingsList, float heightCurveSampleHeight, float worldSpaceSeaLevel, bool clearLockedTextures)
		{
		}

		public void CompleteSplatmapGeneration()
		{
		}

		public JobHandle SampleConcaveLocation(VegetationInstanceData instanceData, float minHeightDifference, float distance, bool inverse, bool average, Rect spawnRect, JobHandle dependsOn)
		{
			_ = _initDone;
			return dependsOn;
		}

		public void Init()
		{
		}

		public void DisposeTemporaryMemory()
		{
			for (int i = 0; i <= RaycastContainerList.Count - 1; i++)
			{
				if (RaycastContainerList[i].RaycastCommands.IsCreated)
				{
					RaycastContainerList[i].RaycastCommands.Dispose();
				}
				RaycastContainerList[i].RaycastHits.Dispose();
				RaycastContainerPool.Release(RaycastContainerList[i]);
			}
			RaycastContainerList.Clear();
		}

		public void OverrideTerrainMaterial()
		{
		}

		public void RestoreTerrainMaterial()
		{
		}

		public void VerifySplatmapAccess()
		{
		}

		public void UpdateTerrainMaterial(float worldspaceSeaLevel, float worldspaceMaxTerrainHeight, TerrainTextureSettings terrainTextureSettings)
		{
		}

		public JobHandle ProcessSplatmapRules(List<TerrainTextureRule> terrainTextureRuleList, VegetationInstanceData instanceData, bool include, Rect cellRect, JobHandle dependsOn)
		{
			return dependsOn;
		}

		public bool HasTerrainTextures()
		{
			return false;
		}

		public Texture2D GetTerrainTexture(int index)
		{
			return null;
		}

		public TerrainLayer[] GetTerrainLayers()
		{
			return new TerrainLayer[0];
		}

		public void SetTerrainLayers(TerrainLayer[] terrainLayers)
		{
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube(RaycastTerrainBounds.center + TerrainPosition + VegetationStudioManager.GetFloatingOriginOffset(), RaycastTerrainBounds.size);
		}

		private void Update()
		{
			if (!Application.isPlaying)
			{
				TerrainPosition = base.transform.position;
			}
		}

		private void OnEnable()
		{
			_initDone = true;
			if (AutoAddToVegegetationSystem && Application.isPlaying)
			{
				VegetationStudioManager.AddTerrain(base.gameObject, forceAdd: false);
			}
			else
			{
				VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
			}
		}

		public void RefreshTerrain()
		{
			VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
			VegetationStudioManager.ClearCache(TerrainBounds);
		}

		public void RefreshTerrain(Bounds bounds)
		{
			VegetationStudioManager.RefreshTerrainArea(bounds);
			VegetationStudioManager.ClearCache(bounds);
		}

		private void OnDisable()
		{
			_initDone = false;
			if (AutoAddToVegegetationSystem && Application.isPlaying)
			{
				VegetationStudioManager.RemoveTerrain(base.gameObject);
			}
			else
			{
				VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
			}
		}
	}
}
