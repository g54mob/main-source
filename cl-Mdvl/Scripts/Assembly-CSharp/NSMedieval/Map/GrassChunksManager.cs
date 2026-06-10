using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Map
{
	public class GrassChunksManager : MonoSingleton<GrassChunksManager>
	{
		private const int GrassChunkSizeX = 32;

		private const int GrassChunkSizeY = 4;

		private const int GrassChunkSizeZ = 32;

		[NonSerialized]
		private int mapSizeX;

		[NonSerialized]
		private int mapSizeY;

		[NonSerialized]
		private int mapSizeZ;

		[SerializeField]
		private GameObject grassObjectPrefab;

		[NonSerialized]
		private List<GrassChunk> grassChunks;

		[NonSerialized]
		private int[] nodeToChunk;

		[NonSerialized]
		private bool grassEnabledFromSettings;

		public void Setup(VillageMap map)
		{
			mapSizeX = map.Size.x;
			mapSizeY = map.Size.y;
			mapSizeZ = map.Size.z;
			grassChunks = new List<GrassChunk>();
			map.SnowGrassWetnessManager.GrassChangedEvent += OnGrassChanged;
			nodeToChunk = new int[mapSizeX * mapSizeY * mapSizeZ];
			RefreshRenderEnabled();
			if (GrassChunk.Material == null)
			{
				GrassChunk.Material = grassObjectPrefab.GetComponent<MeshRenderer>().sharedMaterial;
				GrassChunk.Mesh = grassObjectPrefab.GetComponent<MeshFilter>().sharedMesh;
				RenderParams renderParams = new RenderParams(GrassChunk.Material);
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				renderParams.lightProbeUsage = LightProbeUsage.Off;
				renderParams.reflectionProbeUsage = ReflectionProbeUsage.Off;
				GrassChunk.RenderParams = renderParams;
			}
		}

		private void Start()
		{
			MonoSingleton<OptionsController>.Instance.GrassChangedEvent += OnGrassOptionsChanged;
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.GrassChangedEvent -= OnGrassOptionsChanged;
			}
			if (VillageManager.ActiveVillage != null)
			{
				VillageMap map = VillageManager.ActiveVillage.Map;
				if (map.SnowGrassWetnessManager != null)
				{
					map.SnowGrassWetnessManager.GrassChangedEvent -= OnGrassChanged;
				}
			}
		}

		private void RefreshRenderEnabled()
		{
			if (MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				grassEnabledFromSettings = !MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.GrassHidden;
			}
		}

		private void OnPreCullCallback(Camera activeCamera)
		{
			if (!grassEnabledFromSettings || !LoadingController.IsLoadingComplete || MonoSingleton<LoadingController>.IsApplicationIsQuitting() || activeCamera == null || !activeCamera.enabled || (activeCamera.cameraType & UnityEngine.CameraType.Reflection) != 0)
			{
				return;
			}
			string text = activeCamera.name;
			if (!(text == "UI_world_camera") && !(text == "OutlineRenderCamera"))
			{
				GrassChunk.WorldLayerLevel = MonoSingleton<World>.Instance.LayerLevel;
				GrassChunk.CurrentCameraWorldPosition = activeCamera.gameObject.transform.position;
				GeometryUtility.CalculateFrustumPlanes(activeCamera, GrassChunk.CurrentCameraFrustumPlanes);
				int i = 0;
				for (int count = grassChunks.Count; i < count; i++)
				{
					grassChunks[i].RenderChunk();
				}
			}
		}

		private void OnGrassOptionsChanged()
		{
			RefreshRenderEnabled();
		}

		private void OnGrassChanged(PooledHashSet<int> added, PooledHashSet<int> removed)
		{
			foreach (int item in added)
			{
				int index = nodeToChunk[item];
				grassChunks[index].AddNode(item);
			}
			foreach (int item2 in removed)
			{
				int index2 = nodeToChunk[item2];
				grassChunks[index2].RemoveNode(item2);
			}
		}

		public void SpawnGrassChunks()
		{
			for (int i = 0; i < mapSizeX; i += 32)
			{
				for (int j = 0; j < mapSizeZ; j += 32)
				{
					for (int k = 0; k < mapSizeY; k += 4)
					{
						int sizeX = math.min(32, mapSizeX - i);
						int sizeY = math.min(4, mapSizeY - k);
						int sizeZ = math.min(32, mapSizeZ - j);
						InstantiateGrassChunk(i, k, j, sizeX, sizeY, sizeZ);
					}
				}
			}
		}

		private void InstantiateGrassChunk(int x, int y, int z, int sizeX, int sizeY, int sizeZ)
		{
			GrassChunk grassChunk = new GrassChunk();
			int count = grassChunks.Count;
			grassChunks.Add(grassChunk);
			grassChunk.Setup(x, y, z, sizeX, sizeY, sizeZ);
			SnowGrassWetnessManager snowGrassWetnessManager = VillageManager.ActiveVillage.Map.SnowGrassWetnessManager;
			for (int i = x; i < x + sizeX; i++)
			{
				for (int j = y; j < y + sizeY; j++)
				{
					for (int k = z; k < z + sizeZ; k++)
					{
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(i, j, k);
						nodeToChunk[num] = count;
						if (snowGrassWetnessManager.GetGrassHealth(num) > 0f)
						{
							grassChunk.AddNode(num);
						}
					}
				}
			}
		}
	}
}
