using System.Collections.Generic;
using AwesomeTechnologies.Utility.BVHTree;
using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationStudio;
using AwesomeTechnologies.VegetationSystem;
using AwesomeTechnologies.VegetationSystem.Biomes;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	[ExecuteInEditMode]
	public class MeshTerrain : MonoBehaviour, IVegetationStudioTerrain
	{
		private List<ObjectData> _objects;

		public List<BVHTriangle> Tris;

		private List<BVHNode> _nodes;

		private List<BVHTriangle> _finalPrims;

		public int CurrentTabIndex;

		public MeshTerrainData MeshTerrainData;

		public List<MeshTerrainTerrainSource> MeshTerrainTerrainSourceList = new List<MeshTerrainTerrainSource>();

		public List<MeshTerrainMeshSource> MeshTerrainMeshSourceList = new List<MeshTerrainMeshSource>();

		public bool ShowDebugInfo;

		public bool NeedGeneration;

		private Material _debugMaterial;

		public bool MultiLevelRaycast;

		public bool AutoAddToVegegetationSystem;

		private NativeArray<LBVHNODE> _nativeNodes;

		private NativeArray<LBVHTriangle> _nativePrims;

		private bool _initDone;

		public bool Filterlods;

		public List<BVHRaycastContainer> RaycastContainerList = new List<BVHRaycastContainer>();

		public string TerrainType => "Mesh terrain";

		public Bounds TerrainBounds
		{
			get
			{
				if ((bool)MeshTerrainData)
				{
					return MeshTerrainData.Bounds;
				}
				return default(Bounds);
			}
		}

		public void GenerateMeshTerrain()
		{
			_objects = new List<ObjectData>();
			for (int i = 0; i <= MeshTerrainMeshSourceList.Count - 1; i++)
			{
				if (!(MeshTerrainMeshSourceList[i].MeshRenderer.GetComponent<MeshFilter>().sharedMesh == null))
				{
					ObjectData item = new ObjectData(MeshTerrainMeshSourceList[i].MeshRenderer, (int)MeshTerrainMeshSourceList[i].TerrainSourceID);
					if (item.IsValid)
					{
						_objects.Add(item);
					}
				}
			}
			BVH.Build(ref _objects, out _nodes, out Tris, out _finalPrims);
			BVH.BuildLbvhData(_nodes, _finalPrims, out MeshTerrainData.lNodes, out MeshTerrainData.lPrims);
			MeshTerrainData.Bounds = CalculateTerrainBounds();
			CreateNativeArrays();
			VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
		}

		private Bounds CalculateTerrainBounds()
		{
			Bounds result = default(Bounds);
			for (int i = 0; i <= MeshTerrainMeshSourceList.Count - 1; i++)
			{
				if (i == 0)
				{
					if ((bool)MeshTerrainMeshSourceList[i].MeshRenderer)
					{
						result = MeshTerrainMeshSourceList[i].MeshRenderer.bounds;
					}
				}
				else if ((bool)MeshTerrainMeshSourceList[i].MeshRenderer)
				{
					result.Encapsulate(MeshTerrainMeshSourceList[i].MeshRenderer.bounds);
				}
			}
			return result;
		}

		public void AddMeshRenderer(GameObject go, TerrainSourceID terrainSourceID)
		{
			MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				if (!Filterlods || (!componentsInChildren[i].name.ToUpper().Contains("LOD1") && !componentsInChildren[i].name.ToUpper().Contains("LOD2") && !componentsInChildren[i].name.ToUpper().Contains("LOD3")))
				{
					MeshTerrainMeshSource item = new MeshTerrainMeshSource
					{
						MeshRenderer = componentsInChildren[i],
						TerrainSourceID = terrainSourceID,
						MaterialPropertyBlock = new MaterialPropertyBlock()
					};
					MeshTerrainMeshSourceList.Add(item);
				}
			}
			NeedGeneration = true;
		}

		private Color GetMeshTerrainSourceTypeColor(TerrainSourceID terrainSourceID)
		{
			switch (terrainSourceID)
			{
			case TerrainSourceID.TerrainSourceID1:
				return Color.green;
			case TerrainSourceID.TerrainSourceID2:
				return Color.red;
			case TerrainSourceID.TerrainSourceID3:
				return Color.blue;
			case TerrainSourceID.TerrainSourceID4:
				return Color.yellow;
			case TerrainSourceID.TerrainSourceID5:
				return Color.grey;
			case TerrainSourceID.TerrainSourceID6:
				return Color.magenta;
			case TerrainSourceID.TerrainSourceID7:
				return Color.cyan;
			case TerrainSourceID.TerrainSourceID8:
				return Color.white;
			default:
				return Color.green;
			}
		}

		public void AddTerrain(GameObject go, TerrainSourceID terrainSourceID)
		{
			Terrain[] componentsInChildren = go.GetComponentsInChildren<Terrain>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				MeshTerrainTerrainSource item = new MeshTerrainTerrainSource
				{
					Terrain = componentsInChildren[i],
					TerrainSourceID = terrainSourceID,
					MaterialPropertyBlock = new MaterialPropertyBlock()
				};
				MeshTerrainTerrainSourceList.Add(item);
				NeedGeneration = true;
			}
		}

		private void OnEnable()
		{
			_debugMaterial = Resources.Load("MeshTerrainDebugMaterial", typeof(Material)) as Material;
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

		private void CreateNativeArrays()
		{
			DisposeNativeArrays();
			if (!(MeshTerrainData == null))
			{
				_nativeNodes = new NativeArray<LBVHNODE>(MeshTerrainData.lNodes.ToArray(), Allocator.Persistent);
				_nativePrims = new NativeArray<LBVHTriangle>(MeshTerrainData.lPrims.ToArray(), Allocator.Persistent);
			}
		}

		private void DisposeNativeArrays()
		{
			if (_nativeNodes.IsCreated)
			{
				_nativeNodes.Dispose();
			}
			if (_nativePrims.IsCreated)
			{
				_nativePrims.Dispose();
			}
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
			DisposeNativeArrays();
		}

		public bool HasMeshRenderer(MeshRenderer meshRenderer)
		{
			for (int i = 0; i <= MeshTerrainMeshSourceList.Count - 1; i++)
			{
				if (MeshTerrainMeshSourceList[i].MeshRenderer == meshRenderer)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasTerrain(Terrain terrain)
		{
			for (int i = 0; i <= MeshTerrainTerrainSourceList.Count - 1; i++)
			{
				if (MeshTerrainTerrainSourceList[i].Terrain == terrain)
				{
					return true;
				}
			}
			return false;
		}

		private void Update()
		{
			DrawDebuginfo();
		}

		private void DrawDebuginfo()
		{
			if (!ShowDebugInfo)
			{
				return;
			}
			for (int i = 0; i <= MeshTerrainMeshSourceList.Count - 1; i++)
			{
				if (MeshTerrainMeshSourceList[i].MaterialPropertyBlock == null)
				{
					MeshTerrainMeshSource value = MeshTerrainMeshSourceList[i];
					value.MaterialPropertyBlock = new MaterialPropertyBlock();
					MeshTerrainMeshSourceList[i] = value;
				}
				DrawMeshRenderer(MeshTerrainMeshSourceList[i].MeshRenderer, MeshTerrainMeshSourceList[i].MaterialPropertyBlock, MeshTerrainMeshSourceList[i].TerrainSourceID);
			}
		}

		private void DrawMeshRenderer(MeshRenderer meshRenderer, MaterialPropertyBlock materialPropertyBlock, TerrainSourceID terrainSourceID)
		{
			if (!meshRenderer)
			{
				return;
			}
			MeshFilter component = meshRenderer.gameObject.GetComponent<MeshFilter>();
			if ((bool)component && (bool)component.sharedMesh)
			{
				Matrix4x4 matrix = Matrix4x4.TRS(meshRenderer.transform.position, meshRenderer.transform.rotation, meshRenderer.transform.lossyScale);
				materialPropertyBlock.SetColor("_Color", GetMeshTerrainSourceTypeColor(terrainSourceID));
				for (int i = 0; i <= component.sharedMesh.subMeshCount - 1; i++)
				{
					Graphics.DrawMesh(component.sharedMesh, matrix, _debugMaterial, 0, null, i, materialPropertyBlock);
				}
			}
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
			if (!_nativeNodes.IsCreated)
			{
				CreateNativeArrays();
			}
			if (!_nativeNodes.IsCreated)
			{
				return dependsOn;
			}
			Rect other = RectExtension.CreateRectFromBounds(TerrainBounds);
			if (!cellBoundsRect.Overlaps(other))
			{
				return dependsOn;
			}
			dependsOn = new BVHTerrainCellSampleJob2
			{
				VegetationCellBoundsList = vegetationCellBoundsList,
				Nodes = _nativeNodes,
				TerrainRect = RectExtension.CreateRectFromBounds(TerrainBounds)
			}.Schedule(vegetationCellBoundsList.Length, 32, dependsOn);
			return dependsOn;
		}

		public JobHandle SampleTerrain(NativeList<VegetationSpawnLocationInstance> spawnLocationList, VegetationInstanceData instanceData, int sampleCount, Rect spawnRect, JobHandle dependsOn)
		{
			if (!_initDone)
			{
				return dependsOn;
			}
			if (!_nativeNodes.IsCreated)
			{
				CreateNativeArrays();
			}
			Rect rect = RectExtension.CreateRectFromBounds(TerrainBounds);
			if (!spawnRect.Overlaps(rect))
			{
				return dependsOn;
			}
			BVHRaycastContainer item = new BVHRaycastContainer
			{
				Rays = new NativeArray<BVHRay>(sampleCount, Allocator.TempJob),
				RaycastHits = new NativeArray<HitInfo>(sampleCount, Allocator.TempJob),
				RaycastHitList = new NativeList<HitInfo>(sampleCount * 2, Allocator.TempJob),
				TempHi = new NativeArray<HitInfo>(sampleCount, Allocator.TempJob)
			};
			RaycastContainerList.Add(item);
			dependsOn = new CreateBVHRaycastJob
			{
				SpawnLocationList = spawnLocationList.AsDeferredJobArray(),
				Rays = item.Rays,
				TerrainRect = rect
			}.Schedule(dependsOn);
			if (MultiLevelRaycast)
			{
				dependsOn = new SampleBVHTreeMultiLevelJob
				{
					Rays = item.Rays,
					HitInfos = item.RaycastHitList,
					NativeNodes = _nativeNodes,
					NativePrims = _nativePrims,
					TempHi = item.TempHi
				}.Schedule(dependsOn);
				dependsOn = new UpdateBVHInstanceListMultiLevelJob
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
					TerrainSourceID = instanceData.TerrainSourceID,
					TextureMaskData = instanceData.TextureMaskData,
					Excluded = instanceData.Excluded,
					HeightmapSampled = instanceData.HeightmapSampled,
					RaycastHits = item.RaycastHitList.AsDeferredJobArray()
				}.Schedule(dependsOn);
			}
			else
			{
				dependsOn = new SampleBVHTreeJob
				{
					Rays = item.Rays,
					HitInfos = item.RaycastHits,
					NativeNodes = _nativeNodes,
					NativePrims = _nativePrims,
					TempHi = item.TempHi
				}.Schedule(sampleCount, 32, dependsOn);
				dependsOn = new UpdateBVHInstanceListJob
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
					TerrainSourceID = instanceData.TerrainSourceID,
					TextureMaskData = instanceData.TextureMaskData,
					Excluded = instanceData.Excluded,
					RaycastHits = item.RaycastHits,
					HeightmapSampled = instanceData.HeightmapSampled,
					SpawnLocationList = spawnLocationList.AsDeferredJobArray()
				}.Schedule(dependsOn);
			}
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

		public virtual void CompleteSplatmapGeneration()
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
				RaycastContainerList[i].Rays.Dispose();
				RaycastContainerList[i].RaycastHits.Dispose();
				RaycastContainerList[i].RaycastHitList.Dispose();
				RaycastContainerList[i].TempHi.Dispose();
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
			Gizmos.DrawWireCube(TerrainBounds.center, TerrainBounds.size);
		}
	}
}
