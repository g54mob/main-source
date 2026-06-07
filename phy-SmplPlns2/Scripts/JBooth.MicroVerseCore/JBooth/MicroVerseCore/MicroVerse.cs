using System.Collections.Generic;
using System.Linq;
using JBooth.MicroSplat;
using UnityEngine;
using UnityEngine.Events;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class MicroVerse : MonoBehaviour
	{
		public delegate void TerrainLayersChanged(TerrainLayer[] newLayers);

		public enum InvalidateType
		{
			All = 0,
			Splats = 1,
			Tree = 2
		}

		public class DataCache
		{
			public Dictionary<Terrain, RenderTexture> heightMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, RenderTexture> normalMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, OcclusionData> occlusionDatas = new Dictionary<Terrain, OcclusionData>();

			public Dictionary<Terrain, RenderTexture> indexMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, RenderTexture> weightMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, RenderTexture> curvatureMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, RenderTexture> flowMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, RenderTexture> holeMaps = new Dictionary<Terrain, RenderTexture>();

			public Dictionary<Terrain, TreeData> treeDatas = new Dictionary<Terrain, TreeData>();

			public Dictionary<Terrain, DetailData> detailDatas = new Dictionary<Terrain, DetailData>();
		}

		public Options options = new Options();

		public static UnityEvent OnFinishedUpdating = new UnityEvent();

		public static UnityEvent OnBeginUpdating = new UnityEvent();

		public static UnityEvent OnCancelUpdating = new UnityEvent();

		private bool needHoleSync;

		private int holeCount;

		[Tooltip("You can use this list to explicitly set the terrains instead of having them parented under the MicroVerse object")]
		public Terrain[] explicitTerrains;

		private Terrain[] _terrains;

		private static MicroVerse _instance = null;

		private SpawnProcessor spawnProcessor;

		private InvalidateType invalidateType;

		private bool needUpdate;

		private Bounds invalidateBounds;

		private Bounds lastInvalidBounds;

		private bool boundsSet;

		private bool firstUpdate;

		private bool _isHeightSyncd;

		private bool _isModifyingTerrain;

		private bool _isAddingHeightStamp;

		private static ComputeShader heightSeamShader = null;

		private static int _Mapping = Shader.PropertyToID("_Mapping");

		private float[] indexRemap = new float[32];

		private GraphicsBuffer indexRemapBuffer;

		private static int _TerrainIndex = Shader.PropertyToID("_TerrainIndex");

		private static int _TerrainWeight = Shader.PropertyToID("_TerrainWeight");

		private static int _NeighborIndex = Shader.PropertyToID("_NeighborIndex");

		private static int _NeighborWeight = Shader.PropertyToID("_NeighborWeight");

		private static int _Width = Shader.PropertyToID("_Width");

		private static int _Height = Shader.PropertyToID("_Height");

		private static ComputeShader alphaSeamShader = null;

		private List<IModifier> allModifiers = new List<IModifier>(256);

		private List<IHeightModifier> heightmapModifiers = new List<IHeightModifier>(64);

		private List<ITextureModifier> splatmapModifiers = new List<ITextureModifier>(64);

		private List<IHoleModifier> holeModifiers = new List<IHoleModifier>(16);

		private DataCache dataCache;

		private List<Terrain> modifiedTerrains = new List<Terrain>();

		private static ComputeShader rasterToTerrain = null;

		public TextureArrayConfig msConfig;

		public Terrain[] terrains
		{
			get
			{
				if (explicitTerrains != null && explicitTerrains.Length != 0)
				{
					Terrain[] array = explicitTerrains;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] == null)
						{
							return _terrains;
						}
					}
					return explicitTerrains;
				}
				return _terrains;
			}
			private set
			{
				_terrains = value;
			}
		}

		public static MicroVerse instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				_instance = Object.FindFirstObjectByType<MicroVerse>();
				return _instance;
			}
		}

		public bool IsHeightSyncd
		{
			get
			{
				return _isHeightSyncd;
			}
			private set
			{
				_isHeightSyncd = value;
			}
		}

		public bool IsModifyingTerrain
		{
			get
			{
				return _isModifyingTerrain;
			}
			set
			{
				bool isModifyingTerrain = _isModifyingTerrain;
				_isModifyingTerrain = value;
				if (!value && isModifyingTerrain && OnFinishedUpdating != null)
				{
					OnFinishedUpdating.Invoke();
				}
			}
		}

		public bool IsAddingHeightStamp
		{
			get
			{
				return _isAddingHeightStamp;
			}
			set
			{
				_isAddingHeightStamp = value;
			}
		}

		public static bool noAsyncReadback { get; private set; }

		public static event TerrainLayersChanged OnTerrainLayersChanged;

		private void Awake()
		{
			_instance = this;
			SyncTerrainList();
		}

		private Terrain[] GetAllTerrains()
		{
			if (explicitTerrains != null && explicitTerrains.Length != 0)
			{
				return explicitTerrains;
			}
			return GetComponentsInChildren<Terrain>();
		}

		public void SyncTerrainList()
		{
			if (spawnProcessor == null)
			{
				spawnProcessor = new SpawnProcessor();
			}
			if (explicitTerrains != null && explicitTerrains.Length != 0)
			{
				bool flag = true;
				Terrain[] array = explicitTerrains;
				foreach (Terrain terrain in array)
				{
					if (terrain == null)
					{
						flag = false;
						Debug.LogError("Explicit terrain list has Null terrain in it, please fix");
						break;
					}
					if (!terrain.drawInstanced)
					{
						terrain.drawInstanced = true;
					}
				}
				if (flag)
				{
					return;
				}
			}
			if (options.settings.terrainSearchMethod == Options.Settings.TerrainSearchMethod.Hierarchy)
			{
				terrains = GetComponentsInChildren<Terrain>();
			}
			else
			{
				terrains = Object.FindObjectsByType<Terrain>(FindObjectsSortMode.None);
			}
			if (terrains.Length == 0)
			{
				return;
			}
			for (int j = 0; j < terrains.Length; j++)
			{
				Terrain terrain2 = terrains[j];
				if (terrain2 == null)
				{
					Debug.LogError("Terrain is null, removing from MicroVerse update");
					List<Terrain> list = new List<Terrain>(terrains);
					list.RemoveAt(j);
					terrains = list.ToArray();
					j--;
				}
				else if (terrain2.terrainData == null)
				{
					Debug.LogError("Terrain " + terrain2.name + " does not TerrainData and is not a valid Unity terrain, removing from MicroVerse update");
					List<Terrain> list2 = new List<Terrain>(terrains);
					list2.RemoveAt(j);
					terrains = list2.ToArray();
					j--;
				}
				else if (!terrain2.drawInstanced)
				{
					terrain2.drawInstanced = true;
				}
			}
		}

		public void Invalidate(Bounds? bounds = null, InvalidateType type = InvalidateType.All)
		{
			if (!boundsSet && bounds.HasValue)
			{
				invalidateBounds = bounds.Value;
				boundsSet = true;
			}
			else if (bounds.HasValue)
			{
				invalidateBounds.Encapsulate(bounds.Value);
			}
			else
			{
				invalidateBounds = new Bounds(Vector3.zero, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
			}
			if (!needUpdate)
			{
				invalidateType = type;
			}
			else if (invalidateType != type)
			{
				invalidateType = InvalidateType.All;
			}
			needUpdate = true;
		}

		private void Update()
		{
			if (Application.isPlaying)
			{
				if (needUpdate)
				{
					needUpdate = false;
					Modify(writeToCPU: false, noAsync: false, boundsCull: true);
				}
				spawnProcessor.ApplyTrees();
				spawnProcessor.ApplyDetails();
				spawnProcessor.CheckDone();
			}
		}

		public void LateUpdate()
		{
			if (IsModifyingTerrain)
			{
				bool flag = false;
				if (SpawnProcessor.IsModifyingTerrain)
				{
					flag = true;
				}
				if (!flag)
				{
					IsModifyingTerrain = false;
					boundsSet = false;
				}
			}
		}

		private void OnEnable()
		{
			firstUpdate = true;
		}

		private void OnDisable()
		{
			_instance = null;
		}

		private void RequestHeightSaveback()
		{
			if (!IsHeightSyncd && modifiedTerrains.Count > 0)
			{
				int num = options.settings.maxHeightSaveBackPerFrame;
				if (num < 1)
				{
					num = 1;
				}
				if (num > modifiedTerrains.Count)
				{
					num = modifiedTerrains.Count;
				}
				for (int i = 0; i < num; i++)
				{
					Terrain terrain = modifiedTerrains[0];
					modifiedTerrains.RemoveAt(0);
					terrain.terrainData.SyncHeightmap();
				}
				if (modifiedTerrains.Count == 0)
				{
					IsHeightSyncd = true;
				}
			}
		}

		public void SaveBackToTerrain(bool forceFinishSpawnProcssing = false)
		{
			SyncTerrainList();
			if (forceFinishSpawnProcssing)
			{
				spawnProcessor.ApplyTrees();
				spawnProcessor.ApplyDetails();
			}
			Terrain[] array = terrains;
			foreach (Terrain terrain in array)
			{
				terrain.terrainData.SyncTexture(TerrainData.AlphamapTextureName);
				terrain.terrainData.SyncHeightmap();
				if (needHoleSync)
				{
					terrain.terrainData.SyncTexture(TerrainData.HolesTextureName);
				}
			}
			needHoleSync = false;
			modifiedTerrains.Clear();
			IsHeightSyncd = true;
		}

		private bool DoTerrainLayersMatch(TerrainLayer[] a, TerrainLayer[] b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}
			for (int i = 0; i < a.Length; i++)
			{
				if ((object)a[i] != b[i])
				{
					return false;
				}
			}
			return true;
		}

		private void SanatizeTerrainLayers(List<ITextureModifier> splatmapModifiers, Terrain[] allTerrains)
		{
			List<TerrainLayer> list = new List<TerrainLayer>();
			Terrain[] array = terrains;
			foreach (Terrain terrain in array)
			{
				foreach (ITextureModifier splatmapModifier in splatmapModifiers)
				{
					splatmapModifier.InqTerrainLayers(terrain, list);
				}
			}
			list.RemoveAll((TerrainLayer item) => item == null);
			TerrainLayer[] array2 = (from x in list.Distinct()
				orderby x?.name
				select x).ToArray();
			bool flag = false;
			array = allTerrains;
			foreach (Terrain terrain2 in array)
			{
				if (!DoTerrainLayersMatch(array2, terrain2.terrainData.terrainLayers))
				{
					flag = true;
				}
			}
			if (flag)
			{
				array = terrains;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].terrainData.terrainLayers = array2;
				}
			}
			if (MicroVerse.OnTerrainLayersChanged != null)
			{
				MicroVerse.OnTerrainLayersChanged(array2);
			}
		}

		private void SeamHeightMaps(DataCache dataCache)
		{
			if (heightSeamShader == null)
			{
				heightSeamShader = (ComputeShader)Resources.Load("MicroVerseHeightSeamer");
			}
			Terrain[] array = terrains;
			foreach (Terrain terrain in array)
			{
				if (terrain.leftNeighbor != null && terrains.Contains(terrain.leftNeighbor))
				{
					int kernelIndex = heightSeamShader.FindKernel("CSLeft");
					RenderTexture renderTexture = dataCache.heightMaps[terrain];
					heightSeamShader.SetTexture(kernelIndex, "_Terrain", renderTexture);
					heightSeamShader.SetTexture(kernelIndex, "_Neighbor", dataCache.heightMaps[terrain.leftNeighbor]);
					heightSeamShader.SetInt("_Width", renderTexture.width - 1);
					heightSeamShader.SetInt("_Height", renderTexture.height - 1);
					heightSeamShader.Dispatch(kernelIndex, Mathf.CeilToInt((float)renderTexture.height / 512f), 1, 1);
				}
				if (terrain.rightNeighbor != null && terrains.Contains(terrain.rightNeighbor))
				{
					int kernelIndex2 = heightSeamShader.FindKernel("CSRight");
					RenderTexture renderTexture2 = dataCache.heightMaps[terrain];
					heightSeamShader.SetTexture(kernelIndex2, "_Terrain", renderTexture2);
					heightSeamShader.SetTexture(kernelIndex2, "_Neighbor", dataCache.heightMaps[terrain.rightNeighbor]);
					heightSeamShader.SetInt("_Width", renderTexture2.width - 1);
					heightSeamShader.SetInt("_Height", renderTexture2.height - 1);
					heightSeamShader.Dispatch(kernelIndex2, Mathf.CeilToInt((float)renderTexture2.height / 512f), 1, 1);
				}
				if (terrain.topNeighbor != null && terrains.Contains(terrain.topNeighbor))
				{
					int kernelIndex3 = heightSeamShader.FindKernel("CSUp");
					RenderTexture renderTexture3 = dataCache.heightMaps[terrain];
					heightSeamShader.SetTexture(kernelIndex3, "_Terrain", renderTexture3);
					heightSeamShader.SetTexture(kernelIndex3, "_Neighbor", dataCache.heightMaps[terrain.topNeighbor]);
					heightSeamShader.SetInt("_Width", renderTexture3.width - 1);
					heightSeamShader.SetInt("_Height", renderTexture3.height - 1);
					heightSeamShader.Dispatch(kernelIndex3, Mathf.CeilToInt((float)renderTexture3.width / 512f), 1, 1);
				}
				if (terrain.bottomNeighbor != null && terrains.Contains(terrain.bottomNeighbor))
				{
					int kernelIndex4 = heightSeamShader.FindKernel("CSDown");
					RenderTexture renderTexture4 = dataCache.heightMaps[terrain];
					heightSeamShader.SetTexture(kernelIndex4, "_Terrain", renderTexture4);
					heightSeamShader.SetTexture(kernelIndex4, "_Neighbor", dataCache.heightMaps[terrain.bottomNeighbor]);
					heightSeamShader.SetInt("_Width", renderTexture4.width - 1);
					heightSeamShader.SetInt("_Height", renderTexture4.height - 1);
					heightSeamShader.Dispatch(kernelIndex4, Mathf.CeilToInt((float)renderTexture4.width / 512f), 1, 1);
				}
			}
		}

		private float FindIndex(TerrainLayer[] protos, TerrainLayer layer)
		{
			for (int i = 0; i < protos.Length; i++)
			{
				if (protos[i] == layer)
				{
					return i;
				}
			}
			return -1f;
		}

		private void MapIndecies(int kernelIndex, Terrain terrain, Terrain neighbor)
		{
			TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;
			TerrainLayer[] terrainLayers2 = neighbor.terrainData.terrainLayers;
			int num = terrainLayers2.Length;
			for (int i = 0; i < num; i++)
			{
				indexRemap[i] = FindIndex(terrainLayers, terrainLayers2[i]);
			}
			indexRemapBuffer.SetData(indexRemap);
			alphaSeamShader.SetBuffer(kernelIndex, _Mapping, indexRemapBuffer);
		}

		private void SeamAlphaMaps(DataCache dataCache)
		{
			if (alphaSeamShader == null)
			{
				alphaSeamShader = (ComputeShader)Resources.Load("MicroVerseAlphaSeamer");
			}
			if (indexRemapBuffer == null)
			{
				indexRemapBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 32, 4);
			}
			Terrain[] array = terrains;
			foreach (Terrain terrain in array)
			{
				if (!(dataCache.indexMaps[terrain] == null))
				{
					if (terrain.leftNeighbor != null && terrains.Contains(terrain.leftNeighbor) && dataCache.indexMaps[terrain.leftNeighbor] != null)
					{
						int kernelIndex = alphaSeamShader.FindKernel("CSLeft");
						MapIndecies(kernelIndex, terrain, terrain.leftNeighbor);
						alphaSeamShader.SetTexture(kernelIndex, _TerrainIndex, dataCache.indexMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex, _TerrainWeight, dataCache.weightMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex, _NeighborIndex, dataCache.indexMaps[terrain.leftNeighbor]);
						alphaSeamShader.SetTexture(kernelIndex, _NeighborWeight, dataCache.weightMaps[terrain.leftNeighbor]);
						alphaSeamShader.SetInt(_Width, dataCache.indexMaps[terrain].width - 1);
						alphaSeamShader.SetInt(_Height, dataCache.indexMaps[terrain].height - 1);
						alphaSeamShader.Dispatch(kernelIndex, Mathf.CeilToInt((float)dataCache.indexMaps[terrain].height / 512f), 1, 1);
					}
					if (terrain.rightNeighbor != null && terrains.Contains(terrain.rightNeighbor) && dataCache.indexMaps[terrain.rightNeighbor] != null)
					{
						int kernelIndex2 = alphaSeamShader.FindKernel("CSRight");
						MapIndecies(kernelIndex2, terrain, terrain.rightNeighbor);
						alphaSeamShader.SetTexture(kernelIndex2, _TerrainIndex, dataCache.indexMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex2, _TerrainWeight, dataCache.weightMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex2, _NeighborIndex, dataCache.indexMaps[terrain.rightNeighbor]);
						alphaSeamShader.SetTexture(kernelIndex2, _NeighborWeight, dataCache.weightMaps[terrain.rightNeighbor]);
						alphaSeamShader.SetInt(_Width, dataCache.indexMaps[terrain].width - 1);
						alphaSeamShader.SetInt(_Height, dataCache.indexMaps[terrain].height - 1);
						alphaSeamShader.Dispatch(kernelIndex2, Mathf.CeilToInt((float)dataCache.indexMaps[terrain].height / 512f), 1, 1);
					}
					if (terrain.topNeighbor != null && terrains.Contains(terrain.topNeighbor) && dataCache.indexMaps[terrain.topNeighbor] != null)
					{
						int kernelIndex3 = alphaSeamShader.FindKernel("CSUp");
						MapIndecies(kernelIndex3, terrain, terrain.topNeighbor);
						alphaSeamShader.SetTexture(kernelIndex3, _TerrainIndex, dataCache.indexMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex3, _TerrainWeight, dataCache.weightMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex3, _NeighborIndex, dataCache.indexMaps[terrain.topNeighbor]);
						alphaSeamShader.SetTexture(kernelIndex3, _NeighborWeight, dataCache.weightMaps[terrain.topNeighbor]);
						alphaSeamShader.SetInt(_Width, dataCache.indexMaps[terrain].width - 1);
						alphaSeamShader.SetInt(_Height, dataCache.indexMaps[terrain].height - 1);
						alphaSeamShader.Dispatch(kernelIndex3, Mathf.CeilToInt((float)dataCache.indexMaps[terrain].height / 512f), 1, 1);
					}
					if (terrain.bottomNeighbor != null && terrains.Contains(terrain.bottomNeighbor) && dataCache.indexMaps[terrain.bottomNeighbor] != null)
					{
						int kernelIndex4 = alphaSeamShader.FindKernel("CSDown");
						MapIndecies(kernelIndex4, terrain, terrain.bottomNeighbor);
						alphaSeamShader.SetTexture(kernelIndex4, _TerrainIndex, dataCache.indexMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex4, _TerrainWeight, dataCache.weightMaps[terrain]);
						alphaSeamShader.SetTexture(kernelIndex4, _NeighborIndex, dataCache.indexMaps[terrain.bottomNeighbor]);
						alphaSeamShader.SetTexture(kernelIndex4, _NeighborWeight, dataCache.weightMaps[terrain.bottomNeighbor]);
						alphaSeamShader.SetInt(_Width, dataCache.indexMaps[terrain].width - 1);
						alphaSeamShader.SetInt(_Height, dataCache.indexMaps[terrain].height - 1);
						alphaSeamShader.Dispatch(kernelIndex4, Mathf.CeilToInt((float)dataCache.indexMaps[terrain].height / 512f), 1, 1);
					}
				}
			}
			indexRemapBuffer.Release();
			indexRemapBuffer = null;
		}

		private void CullTerrainList(bool boundsCull)
		{
			if (boundsCull)
			{
				List<Terrain> list = new List<Terrain>(terrains.Length);
				Bounds bounds = invalidateBounds;
				if (lastInvalidBounds.size.x < 99999f)
				{
					bounds.Encapsulate(lastInvalidBounds);
				}
				lastInvalidBounds = invalidateBounds;
				for (int i = 0; i < terrains.Length; i++)
				{
					if (TerrainUtil.ComputeTerrainBounds(terrains[i]).Intersects(bounds))
					{
						list.Add(terrains[i]);
					}
				}
				terrains = list.ToArray();
			}
			if (modifiedTerrains.Count == 0)
			{
				modifiedTerrains = new List<Terrain>(terrains);
			}
			else
			{
				if (invalidateType != InvalidateType.All)
				{
					return;
				}
				Terrain[] array = terrains;
				foreach (Terrain item in array)
				{
					if (!modifiedTerrains.Contains(item))
					{
						modifiedTerrains.Add(item);
					}
				}
			}
		}

		private void RevisionAllStamps()
		{
		}

		public void Modify(bool writeToCPU = false, bool noAsync = false, bool boundsCull = false)
		{
			noAsyncReadback = noAsync;
			if (!base.enabled)
			{
				return;
			}
			RevisionAllStamps();
			IsModifyingTerrain = true;
			CancelModify(cancelRoads: false);
			if (OnBeginUpdating != null)
			{
				OnBeginUpdating.Invoke();
			}
			IsHeightSyncd = false;
			SyncTerrainList();
			Terrain[] allTerrains = terrains;
			CullTerrainList(boundsSet);
			if (terrains.Length == 0)
			{
				CancelModify();
				return;
			}
			GetComponentsInChildren(allModifiers);
			heightmapModifiers.Clear();
			splatmapModifiers.Clear();
			holeModifiers.Clear();
			if (IsUsingMicroSplat())
			{
				for (int i = 0; i < allModifiers.Count; i++)
				{
					IModifier modifier = allModifiers[i];
					if (modifier is IHeightModifier && modifier.IsEnabled())
					{
						heightmapModifiers.Add(modifier as IHeightModifier);
					}
				}
				GetComponentsInChildren(includeInactive: true, splatmapModifiers);
				GetComponentsInChildren(includeInactive: true, holeModifiers);
			}
			else
			{
				for (int j = 0; j < allModifiers.Count; j++)
				{
					IModifier modifier2 = allModifiers[j];
					if (modifier2 is IHeightModifier && modifier2.IsEnabled())
					{
						heightmapModifiers.Add(modifier2 as IHeightModifier);
					}
					if (modifier2 is ITextureModifier && modifier2.IsEnabled())
					{
						splatmapModifiers.Add(modifier2 as ITextureModifier);
					}
					if (modifier2 is IHoleModifier && modifier2.IsEnabled() && (modifier2 as IHoleModifier).IsValidHoleStamp())
					{
						holeModifiers.Add(modifier2 as IHoleModifier);
					}
				}
			}
			allModifiers.RemoveAll((IModifier p) => !p.IsEnabled());
			allModifiers = allModifiers.Distinct().ToList();
			spawnProcessor.InitSystem();
			foreach (IModifier allModifier in allModifiers)
			{
				allModifier.Initialize();
			}
			Terrain[] array;
			if (options.settings.keepLayersInSync || IsUsingMicroSplat())
			{
				SanatizeTerrainLayers(splatmapModifiers, allTerrains);
			}
			else
			{
				List<TerrainLayer> list = new List<TerrainLayer>(256);
				array = terrains;
				foreach (Terrain terrain in array)
				{
					Bounds bounds = TerrainUtil.ComputeTerrainBounds(terrain);
					foreach (ITextureModifier splatmapModifier in splatmapModifiers)
					{
						if (bounds.Intersects(splatmapModifier.GetBounds()))
						{
							splatmapModifier.InqTerrainLayers(terrain, list);
						}
					}
					terrain.terrainData.terrainLayers = list.Distinct().ToArray();
					list.Clear();
				}
			}
			splatmapModifiers.RemoveAll((ITextureModifier p) => !p.IsEnabled());
			bool needCurvatureMap = false;
			bool needFlowMap = false;
			array = terrains;
			foreach (Terrain terrain2 in array)
			{
				foreach (ITextureModifier splatmapModifier2 in splatmapModifiers)
				{
					needCurvatureMap |= splatmapModifier2.NeedCurvatureMap();
					needFlowMap |= splatmapModifier2.NeedFlowMap();
				}
				foreach (IHoleModifier holeModifier in holeModifiers)
				{
					needCurvatureMap |= holeModifier.NeedCurvatureMap();
					needFlowMap |= holeModifier.NeedFlowMap();
				}
				spawnProcessor.InitTerrain(terrain2, invalidateType, ref needCurvatureMap, ref needFlowMap);
			}
			dataCache = new DataCache();
			int heightmapResolution = terrains[0].terrainData.heightmapResolution;
			int alphamapResolution = terrains[0].terrainData.alphamapResolution;
			int num2 = heightmapResolution - 1;
			if (alphamapResolution > num2)
			{
				num2 = alphamapResolution;
			}
			int num3 = num2;
			if (num3 > 1024)
			{
				num3 = 1024;
			}
			if (num3 < 512)
			{
				num3 = 512;
			}
			array = terrains;
			foreach (Terrain terrain3 in array)
			{
				HeightmapData heightmapData = new HeightmapData(terrain3);
				new Vector3(heightmapData.RealSize.x, heightmapData.RealHeight, heightmapData.RealSize.y);
				Bounds bounds2 = terrain3.terrainData.bounds;
				bounds2.center = terrain3.transform.position;
				bounds2.center += new Vector3(bounds2.size.x * 0.5f, 0f, bounds2.size.z * 0.5f);
				OcclusionData occlusionData = new OcclusionData(terrain3, num3);
				dataCache.occlusionDatas.Add(terrain3, occlusionData);
				dataCache.heightMaps.Add(terrain3, GenerateHeightmap(heightmapData, heightmapModifiers, bounds2, occlusionData));
			}
			SeamHeightMaps(dataCache);
			array = terrains;
			foreach (Terrain terrain4 in array)
			{
				dataCache.normalMaps.Add(terrain4, MapGen.GenerateNormalMap(terrain4, dataCache.heightMaps, heightmapResolution, heightmapResolution));
			}
			array = terrains;
			foreach (Terrain terrain5 in array)
			{
				Bounds terrainBounds = TerrainUtil.ComputeTerrainBounds(terrain5);
				OcclusionData od = dataCache.occlusionDatas[terrain5];
				HeightmapData heightmapData2 = new HeightmapData(terrain5);
				new Vector3(heightmapData2.RealSize.x, heightmapData2.RealHeight, heightmapData2.RealSize.y);
				RenderTexture renderTexture = (needCurvatureMap ? MapGen.GenerateCurvatureMap(terrain5, dataCache.normalMaps, alphamapResolution, alphamapResolution) : null);
				dataCache.curvatureMaps[terrain5] = renderTexture;
				RenderTexture renderTexture2 = (needFlowMap ? MapGen.GenerateFlowMap(terrain5, dataCache.heightMaps) : null);
				dataCache.flowMaps[terrain5] = renderTexture2;
				RenderTexture heightMap = dataCache.heightMaps[terrain5];
				RenderTexture normalMap = dataCache.normalMaps[terrain5];
				TextureData textureData = new TextureData(terrain5, 0, heightMap, normalMap, renderTexture, renderTexture2);
				GenerateSplatmaps(textureData, splatmapModifiers, terrainBounds, od);
				dataCache.indexMaps[terrain5] = textureData.indexMap;
				dataCache.weightMaps[terrain5] = textureData.weightMap;
			}
			if (holeModifiers.Count > 0)
			{
				holeCount = holeModifiers.Count;
				array = terrains;
				foreach (Terrain terrain6 in array)
				{
					OcclusionData od2 = dataCache.occlusionDatas[terrain6];
					HoleData holeData = new HoleData(terrain6, dataCache.heightMaps[terrain6], dataCache.normalMaps[terrain6], dataCache.curvatureMaps[terrain6], dataCache.flowMaps[terrain6], dataCache.indexMaps[terrain6], dataCache.weightMaps[terrain6]);
					RenderTextureFormat holesRenderTextureFormat = Terrain.holesRenderTextureFormat;
					int holesResolution = terrain6.terrainData.holesResolution;
					RenderTexture renderTexture3 = RenderTexture.GetTemporary(holesResolution, holesResolution, 0, holesRenderTextureFormat, RenderTextureReadWrite.Linear);
					RenderTexture renderTexture4 = RenderTexture.GetTemporary(holesResolution, holesResolution, 0, holesRenderTextureFormat, RenderTextureReadWrite.Linear);
					RenderTexture.active = renderTexture3;
					GL.Clear(clearDepth: false, clearColor: true, Color.white);
					foreach (IHoleModifier holeModifier2 in holeModifiers)
					{
						if (holeModifier2.IsValidHoleStamp() && holeModifier2.IsEnabled())
						{
							holeModifier2.ApplyHoleStamp(renderTexture3, renderTexture4, holeData, od2);
							RenderTexture renderTexture5 = renderTexture4;
							RenderTexture renderTexture6 = renderTexture3;
							renderTexture3 = renderTexture5;
							renderTexture4 = renderTexture6;
						}
					}
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(renderTexture4);
					dataCache.holeMaps.Add(terrain6, renderTexture3);
				}
			}
			else if (holeCount > 0)
			{
				holeCount = 0;
				needHoleSync = false;
				array = terrains;
				foreach (Terrain terrain7 in array)
				{
					new HoleData(terrain7, dataCache.heightMaps[terrain7], dataCache.normalMaps[terrain7], dataCache.curvatureMaps[terrain7], dataCache.flowMaps[terrain7], dataCache.indexMaps[terrain7], dataCache.weightMaps[terrain7]);
					RenderTextureFormat holesRenderTextureFormat2 = Terrain.holesRenderTextureFormat;
					int holesResolution2 = terrain7.terrainData.holesResolution;
					RenderTexture renderTexture7 = (RenderTexture.active = RenderTexture.GetTemporary(holesResolution2, holesResolution2, 0, holesRenderTextureFormat2));
					GL.Clear(clearDepth: false, clearColor: true, Color.white);
					terrain7.terrainData.CopyActiveRenderTextureToTexture(TerrainData.HolesTextureName, 0, new RectInt(0, 0, renderTexture7.width, renderTexture7.height), new Vector2Int(0, 0), allowDelayedCPUSync: true);
				}
				RenderTexture.active = null;
			}
			spawnProcessor.GenerateSpawnables(terrains, dataCache);
			SeamHeightMaps(dataCache);
			SeamAlphaMaps(dataCache);
			array = terrains;
			foreach (Terrain terrain8 in array)
			{
				if (holeModifiers.Count > 0)
				{
					RenderTexture renderTexture8 = (RenderTexture.active = dataCache.holeMaps[terrain8]);
					terrain8.terrainData.CopyActiveRenderTextureToTexture(TerrainData.HolesTextureName, 0, new RectInt(0, 0, renderTexture8.width, renderTexture8.height), new Vector2Int(0, 0), !writeToCPU);
					needHoleSync = !writeToCPU;
					RenderTexture.ReleaseTemporary(renderTexture8);
				}
				RenderTexture renderTexture10 = dataCache.indexMaps[terrain8];
				RenderTexture renderTexture11 = dataCache.weightMaps[terrain8];
				RenderTexture renderTexture12 = dataCache.heightMaps[terrain8];
				RenderTexture temp = dataCache.normalMaps[terrain8];
				RenderTexture renderTexture13 = dataCache.curvatureMaps[terrain8];
				RenderTexture renderTexture14 = dataCache.flowMaps[terrain8];
				OcclusionData occlusionData2 = dataCache.occlusionDatas[terrain8];
				if (invalidateType != InvalidateType.Tree)
				{
					RasterizeSplatMaps(terrain8, renderTexture10, renderTexture11, writeToCPU);
				}
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(renderTexture10);
				RenderTexture.ReleaseTemporary(renderTexture11);
				if (invalidateType == InvalidateType.All)
				{
					RenderTexture.active = renderTexture12;
					terrain8.terrainData.CopyActiveRenderTextureToHeightmap(new RectInt(0, 0, renderTexture12.width, renderTexture12.height), new Vector2Int(0, 0), writeToCPU ? TerrainHeightmapSyncControl.HeightAndLod : TerrainHeightmapSyncControl.None);
				}
				RenderTexture.active = null;
				if (renderTexture14 != null)
				{
					RenderTexture.ReleaseTemporary(renderTexture14);
				}
				if (renderTexture13 != null)
				{
					RenderTexture.ReleaseTemporary(renderTexture13);
				}
				RenderTexture.ReleaseTemporary(temp);
				RenderTexture.ReleaseTemporary(renderTexture12);
				occlusionData2.Dispose();
			}
			foreach (IModifier allModifier2 in allModifiers)
			{
				allModifier2.Dispose();
			}
			if (firstUpdate)
			{
				array = terrains;
				for (int num = 0; num < array.Length; num++)
				{
					array[num].terrainData.SyncHeightmap();
				}
				modifiedTerrains.Clear();
				firstUpdate = false;
			}
		}

		public void CancelModify(bool cancelRoads = true)
		{
			if (OnCancelUpdating != null)
			{
				OnCancelUpdating.Invoke();
			}
			spawnProcessor.Cancel(dataCache);
		}

		private static void GenerateSplatmaps(TextureData splatmapData, List<ITextureModifier> splatmapModifiers, Bounds terrainBounds, OcclusionData od, bool writeToCPU = false)
		{
			if (splatmapModifiers.Count == 0 || od.terrain.terrainData.terrainLayers.Length == 0)
			{
				return;
			}
			List<TerrainLayer> list = new List<TerrainLayer>();
			foreach (ITextureModifier splatmapModifier in splatmapModifiers)
			{
				splatmapModifier.InqTerrainLayers(splatmapData.terrain, list);
			}
			if (list.Count == 0)
			{
				return;
			}
			TerrainData terrainData = splatmapData.terrain.terrainData;
			RenderTextureDescriptor desc = new RenderTextureDescriptor(terrainData.alphamapWidth, terrainData.alphamapHeight, RenderTextureFormat.ARGB32, 0);
			desc.sRGB = false;
			desc.enableRandomWrite = true;
			desc.autoGenerateMips = false;
			RenderTexture renderTexture = RenderTexture.GetTemporary(desc);
			RenderTexture renderTexture2 = RenderTexture.GetTemporary(desc);
			RenderTexture renderTexture3 = RenderTexture.GetTemporary(desc);
			RenderTexture renderTexture4 = RenderTexture.GetTemporary(desc);
			renderTexture.name = "MicroVerse::GenerateSplats::indexMap0";
			renderTexture3.name = "MicroVerse::GenerateSplats::indexMap1";
			renderTexture2.name = "MicroVerse::GenerateSplats::weightMap0";
			renderTexture4.name = "MicroVerse::GenerateSplats::weightMap1";
			RenderTexture.active = renderTexture;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = renderTexture2;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = renderTexture3;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = renderTexture4;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = null;
			renderTexture.filterMode = FilterMode.Point;
			renderTexture3.filterMode = FilterMode.Point;
			renderTexture2.filterMode = FilterMode.Point;
			renderTexture4.filterMode = FilterMode.Point;
			renderTexture.wrapMode = TextureWrapMode.Clamp;
			renderTexture3.wrapMode = TextureWrapMode.Clamp;
			renderTexture2.wrapMode = TextureWrapMode.Clamp;
			renderTexture4.wrapMode = TextureWrapMode.Clamp;
			for (int num = splatmapModifiers.Count - 1; num >= 0; num--)
			{
				ITextureModifier textureModifier = splatmapModifiers[num];
				if (textureModifier.GetBounds().Intersects(terrainBounds) && textureModifier.ApplyTextureStamp(renderTexture, renderTexture3, renderTexture2, renderTexture4, splatmapData, od))
				{
					RenderTexture renderTexture5 = renderTexture3;
					RenderTexture renderTexture6 = renderTexture;
					renderTexture = renderTexture5;
					renderTexture3 = renderTexture6;
					RenderTexture renderTexture7 = renderTexture4;
					renderTexture6 = renderTexture2;
					renderTexture2 = renderTexture7;
					renderTexture4 = renderTexture6;
				}
			}
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(renderTexture4);
			RenderTexture.ReleaseTemporary(renderTexture3);
			splatmapData.indexMap = renderTexture;
			splatmapData.weightMap = renderTexture2;
		}

		private void RasterizeSplatMaps(Terrain terrain, RenderTexture indexMap, RenderTexture weightMap, bool writeToCPU)
		{
			int alphamapTextureCount = terrain.terrainData.alphamapTextureCount;
			if (alphamapTextureCount != 0)
			{
				if (rasterToTerrain == null)
				{
					rasterToTerrain = (ComputeShader)Resources.Load("MicroVerseRasterToTerrain");
				}
				int kernelIndex = rasterToTerrain.FindKernel("CSMain");
				rasterToTerrain.SetTexture(kernelIndex, "_WeightMap", weightMap);
				rasterToTerrain.SetTexture(kernelIndex, "_IndexMap", indexMap);
				RenderTexture[] array = new RenderTexture[alphamapTextureCount];
				Texture2D alphamapTexture = terrain.terrainData.GetAlphamapTexture(0);
				RenderTextureDescriptor desc = new RenderTextureDescriptor(alphamapTexture.width, alphamapTexture.height);
				desc.graphicsFormat = alphamapTexture.graphicsFormat;
				desc.sRGB = false;
				desc.enableRandomWrite = true;
				for (int i = 0; i < alphamapTextureCount; i++)
				{
					RenderTexture temporary = RenderTexture.GetTemporary(desc);
					temporary.name = "MicroVerse:BackToTerrain";
					array[i] = temporary;
					rasterToTerrain.SetTexture(kernelIndex, "_Result" + i, temporary);
				}
				if (alphamapTextureCount > 1)
				{
					rasterToTerrain.shaderKeywords = new string[1] { "_COUNT_" + alphamapTextureCount };
				}
				else
				{
					rasterToTerrain.shaderKeywords = new string[0];
				}
				rasterToTerrain.Dispatch(kernelIndex, Mathf.CeilToInt((float)alphamapTexture.width / 8f), Mathf.CeilToInt((float)alphamapTexture.height / 8f), 1);
				for (int j = 0; j < alphamapTextureCount; j++)
				{
					RenderTexture.active = array[j];
					terrain.terrainData.CopyActiveRenderTextureToTexture(TerrainData.AlphamapTextureName, j, new RectInt(0, 0, array[j].width, array[j].height), new Vector2Int(0, 0), !writeToCPU);
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(array[j]);
				}
				RenderTexture.active = null;
			}
		}

		private static RenderTexture GenerateHeightmap(HeightmapData heightmapData, List<IHeightModifier> heightmapModifiers, Bounds terrainBounds, OcclusionData od, bool writeToCPU = false)
		{
			RenderTextureDescriptor descriptor = heightmapData.terrain.terrainData.heightmapTexture.descriptor;
			descriptor.width = heightmapData.terrain.terrainData.heightmapResolution;
			descriptor.height = descriptor.width;
			descriptor.enableRandomWrite = true;
			RenderTexture renderTexture = RenderTexture.GetTemporary(descriptor);
			RenderTexture renderTexture2 = RenderTexture.GetTemporary(descriptor);
			renderTexture.wrapMode = TextureWrapMode.Clamp;
			renderTexture2.wrapMode = TextureWrapMode.Clamp;
			renderTexture.name = "MicroVerse::GenerateHeights:rt1";
			renderTexture2.name = "MicroVerse::GenerateHeights:rt2";
			RenderTexture.active = renderTexture;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = renderTexture2;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			foreach (IHeightModifier heightmapModifier in heightmapModifiers)
			{
				if (heightmapModifier.GetBounds().Intersects(terrainBounds) && heightmapModifier.ApplyHeightStamp(renderTexture, renderTexture2, heightmapData, od))
				{
					RenderTexture renderTexture3 = renderTexture2;
					RenderTexture renderTexture4 = renderTexture;
					renderTexture = renderTexture3;
					renderTexture2 = renderTexture4;
				}
			}
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(renderTexture2);
			return renderTexture;
		}

		public bool IsUsingMicroSplat()
		{
			return msConfig != null;
		}
	}
}
