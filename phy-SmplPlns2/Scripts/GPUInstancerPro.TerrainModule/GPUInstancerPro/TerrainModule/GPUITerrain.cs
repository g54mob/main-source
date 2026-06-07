using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public abstract class GPUITerrain : MonoBehaviour, IEquatable<GPUITerrain>
	{
		public enum GPUITerrainHolesSampleMode
		{
			Initialization = 0,
			Runtime = 1,
			None = 2
		}

		public abstract class GPUITerrainPaintingProxy : MonoBehaviour
		{
			public abstract void FinalizePainting(bool saveTerrainData);
		}

		[SerializeField]
		protected Bounds _bounds;

		[SerializeField]
		protected Texture2D[] _bakedDetailTextures;

		[SerializeField]
		public bool isAutoFindTreeManager = true;

		[SerializeField]
		public bool isAutoFindDetailManager = true;

		[SerializeField]
		public GPUITerrainHolesSampleMode terrainHolesSampleMode;

		[NonSerialized]
		protected Transform _cachedTransform;

		[NonSerialized]
		protected Vector3 _cachedPosition;

		[NonSerialized]
		private RenderTexture _heightmapTexture;

		[NonSerialized]
		protected TreeInstance[] _treeInstances;

		[NonSerialized]
		protected RenderTexture[] _detailDensityTextures;

		[NonSerialized]
		protected Matrix4x4 _matrixOffset = Matrix4x4.identity;

		[NonSerialized]
		protected IGPUIProceduralDetailModifier _proceduralDetailModifier;

		protected TreePrototype[] _treePrototypes;

		protected DetailPrototype[] _detailPrototypes;

		public static readonly TreeInstance[] EMPTY_TREE_INSTANCES = new TreeInstance[0];

		public static RenderTexture DUMMY_HOLES_TEXTURE;

		internal static List<GPUITerrain> _terrainsSearchingForTreeManager;

		internal static List<GPUITerrain> _terrainsSearchingForDetailManager;

		private static readonly Vector4 _kDecodeDot = new Vector4(1f, 0.003921569f, 1.53787E-05f, 6.030863E-08f);

		public GPUITreeManager TreeManager { get; private set; }

		public TreePrototype[] TreePrototypes => _treePrototypes;

		internal int[] TreePrototypeIndexes { get; private set; }

		public GPUIDetailManager DetailManager { get; private set; }

		public DetailPrototype[] DetailPrototypes => _detailPrototypes;

		internal int[] DetailPrototypeIndexes { get; private set; }

		public bool IsInitialized { get; private set; }

		public bool IsDetailDensityTexturesLoaded { get; protected set; }

		protected virtual void Awake()
		{
			LoadTerrain();
		}

		protected virtual void OnEnable()
		{
			if (!IsInitialized)
			{
				Initialize();
			}
			if (DetailManager != null)
			{
				DetailManager.RequireUpdate();
			}
			if (TreeManager != null)
			{
				TreeManager.RequireUpdate();
			}
		}

		protected virtual void OnDisable()
		{
			Dispose();
		}

		public virtual void LoadTerrain()
		{
			if (_cachedTransform == null)
			{
				_cachedTransform = base.transform;
			}
			if (_treePrototypes == null)
			{
				_treePrototypes = new TreePrototype[0];
			}
			if (_detailPrototypes == null)
			{
				_detailPrototypes = new DetailPrototype[0];
			}
			SetTerrainBounds();
			NotifyTransformChanges();
		}

		public virtual bool LoadTerrainData()
		{
			LoadTerrain();
			return true;
		}

		protected virtual void Initialize()
		{
			Dispose();
			if (!LoadTerrainData())
			{
				return;
			}
			CreateHeightmapTexture();
			IsInitialized = true;
			if (TreeManager != null)
			{
				if (!TreeManager.AddTerrain(this))
				{
					SetTreeManager(TreeManager);
				}
			}
			else if (Application.isPlaying && isAutoFindTreeManager)
			{
				AutoFindTreeManager();
			}
			if (DetailManager != null)
			{
				if (!DetailManager.AddTerrain(this))
				{
					SetDetailManager(DetailManager);
				}
			}
			else if (Application.isPlaying && isAutoFindDetailManager)
			{
				AutoFindDetailManager();
			}
		}

		protected virtual void Dispose()
		{
			IsInitialized = false;
			DisposeDetailDensityTextures();
			DisposeHeightmapTexture();
			DisposeHolesTexture();
			_treeInstances = null;
			if (TreeManager != null)
			{
				TreeManager.RemoveTerrain(this);
			}
			else if (_terrainsSearchingForTreeManager != null)
			{
				int num = _terrainsSearchingForTreeManager.IndexOf(this);
				if (num >= 0)
				{
					_terrainsSearchingForTreeManager.RemoveAt(num);
				}
			}
			if (DetailManager != null)
			{
				DetailManager.RemoveTerrain(this);
			}
			else if (_terrainsSearchingForDetailManager != null)
			{
				int num2 = _terrainsSearchingForDetailManager.IndexOf(this);
				if (num2 >= 0)
				{
					_terrainsSearchingForDetailManager.RemoveAt(num2);
				}
			}
			if (DUMMY_HOLES_TEXTURE != null)
			{
				DUMMY_HOLES_TEXTURE.DestroyRenderTexture();
			}
		}

		public void AutoFindTreeManager()
		{
			GPUIRenderingSystem.InitializeRenderingSystem();
			if (!(TreeManager == null))
			{
				return;
			}
			foreach (GPUIManager activeGPUIManager in GPUIRenderingSystem.Instance.ActiveGPUIManagers)
			{
				if (activeGPUIManager is GPUITreeManager gPUITreeManager && gPUITreeManager != null)
				{
					TreeManager = gPUITreeManager;
					if (!TreeManager.AddTerrain(this))
					{
						SetTreeManager(TreeManager);
					}
					return;
				}
			}
			if (_terrainsSearchingForTreeManager == null)
			{
				_terrainsSearchingForTreeManager = new List<GPUITerrain>();
			}
			_terrainsSearchingForTreeManager.Add(this);
		}

		public void AutoFindDetailManager()
		{
			GPUIRenderingSystem.InitializeRenderingSystem();
			if (!(DetailManager == null))
			{
				return;
			}
			foreach (GPUIManager activeGPUIManager in GPUIRenderingSystem.Instance.ActiveGPUIManagers)
			{
				if (activeGPUIManager is GPUIDetailManager gPUIDetailManager && gPUIDetailManager != null)
				{
					DetailManager = gPUIDetailManager;
					if (!DetailManager.AddTerrain(this))
					{
						SetDetailManager(DetailManager);
					}
					return;
				}
			}
			if (_terrainsSearchingForDetailManager == null)
			{
				_terrainsSearchingForDetailManager = new List<GPUITerrain>();
			}
			_terrainsSearchingForDetailManager.Add(this);
		}

		protected void DisposeDetailDensityTextures()
		{
			IsDetailDensityTexturesLoaded = false;
			if (_detailDensityTextures != null)
			{
				for (int i = 0; i < _detailDensityTextures.Length; i++)
				{
					DisposeDetailDensityTexture(i);
				}
				_detailDensityTextures = null;
			}
		}

		protected virtual void DisposeHeightmapTexture()
		{
		}

		protected virtual void DisposeHolesTexture()
		{
		}

		protected void DisposeDetailDensityTexture(int index)
		{
			RenderTexture renderTexture = _detailDensityTextures[index];
			if (renderTexture != null && renderTexture.name.Contains("_GPUIDetailLayer_"))
			{
				renderTexture.DestroyRenderTexture();
				_detailDensityTextures[index] = null;
			}
		}

		internal virtual void SetTerrainDetailObjectDistance(float value)
		{
		}

		internal virtual void SetTerrainTreeDistance(float value)
		{
		}

		public void CreateHeightmapTexture()
		{
			_heightmapTexture = LoadHeightmapTexture();
		}

		protected abstract RenderTexture LoadHeightmapTexture();

		public void CreateDetailTextures()
		{
			LoadDetailDensityTextures();
			IsDetailDensityTexturesLoaded = true;
		}

		protected virtual void LoadDetailDensityTextures()
		{
			int num = ((DetailPrototypes != null) ? DetailPrototypes.Length : 0);
			ResizeDetailDensityTextureArray(num);
			bool flag = IsBakedDetailTextures();
			for (int i = 0; i < num; i++)
			{
				CreateDetailTexture(base.name, i);
				if (!IsReadTerrainDetails(i))
				{
					_detailDensityTextures[i].ClearRenderTexture();
				}
				else if (flag)
				{
					BlitBakedDetailTexture(i);
				}
			}
			ExecuteProceduralDetails();
			RequireDetailUpdate(!Application.isPlaying);
		}

		protected void ExecuteProceduralDetails()
		{
			if (DetailManager != null)
			{
				DetailManager.ExecuteProceduralDetails(this);
			}
			if (_proceduralDetailModifier != null)
			{
				_proceduralDetailModifier.Execute(this);
			}
		}

		protected void CreateDetailTexture(string terrainName, int index)
		{
			if (_detailDensityTextures[index] == null)
			{
				_detailDensityTextures[index] = GPUITerrainUtility.CreateDetailRenderTexture(GetDetailResolution(), terrainName + "_GPUIDetailLayer_" + index);
			}
		}

		protected void ResizeDetailDensityTextureArray(int detailCount)
		{
			int detailResolution = GetDetailResolution();
			if (_detailDensityTextures == null)
			{
				_detailDensityTextures = new RenderTexture[detailCount];
			}
			else if (_detailDensityTextures.Length != detailCount)
			{
				for (int i = detailCount; i < _detailDensityTextures.Length; i++)
				{
					DisposeDetailDensityTexture(i);
				}
				Array.Resize(ref _detailDensityTextures, detailCount);
			}
			if (IsBakedDetailTextures())
			{
				ResizeBakedDetailTextureArray(detailCount);
			}
			for (int j = 0; j < detailCount; j++)
			{
				RenderTexture renderTexture = _detailDensityTextures[j];
				if (renderTexture != null && renderTexture.width != detailResolution)
				{
					DisposeDetailDensityTexture(j);
					renderTexture = null;
				}
				if (renderTexture == null)
				{
					CreateDetailTexture(base.name, j);
				}
			}
		}

		protected virtual void ResizeBakedDetailTextureArray(int detailCount)
		{
			if (_bakedDetailTextures == null)
			{
				_bakedDetailTextures = new Texture2D[detailCount];
			}
			else if (_bakedDetailTextures.Length != detailCount)
			{
				Array.Resize(ref _bakedDetailTextures, detailCount);
			}
		}

		protected void BlitBakedDetailTexture(int index)
		{
			Texture2D bakedDetailTexture = GetBakedDetailTexture(index);
			if (bakedDetailTexture != null)
			{
				GPUITextureUtility.CopyTextureSamplerWithComputeShader(bakedDetailTexture, _detailDensityTextures[index]);
			}
			else
			{
				_detailDensityTextures[index].ClearRenderTexture();
			}
		}

		protected abstract int GetDetailResolution();

		internal void GenerateVegetation(GPUIDetailPrototypeData detailPrototypeData, GraphicsBuffer transformBuffer, GPUIDataBuffer<GPUICounterData> counterBuffer, Vector3 cameraPos, float detailObjectDistance, Texture2D healthyDryNoiseTexture, int[] sizeAndIndexes)
		{
			if (!IsInitialized)
			{
				return;
			}
			if (_heightmapTexture == null)
			{
				CreateHeightmapTexture();
				if (_heightmapTexture == null)
				{
					return;
				}
			}
			if (!IsDetailDensityTexturesLoaded)
			{
				CreateDetailTextures();
			}
			if (_detailDensityTextures == null)
			{
				return;
			}
			Vector3 position = GetPosition();
			if (!IsTerrainWithinViewDistance(cameraPos, detailObjectDistance))
			{
				return;
			}
			if (DetailPrototypeIndexes == null)
			{
				DetermineDetailPrototypeIndexes(DetailManager);
			}
			int num = sizeAndIndexes[1];
			int subSettingCount = detailPrototypeData.GetSubSettingCount();
			Texture texture = null;
			if (terrainHolesSampleMode == GPUITerrainHolesSampleMode.Runtime)
			{
				texture = GetHolesTexture();
			}
			bool flag = HasMatrixOffset();
			ComputeShader cS_VegetationGenerator = GPUITerrainConstants.CS_VegetationGenerator;
			if (HasTwoChannelHeightmap())
			{
				cS_VegetationGenerator.EnableKeyword(GPUITerrainConstants.Kw_GPUI_TWO_CHANNEL_HEIGHTMAP);
			}
			else
			{
				cS_VegetationGenerator.DisableKeyword(GPUITerrainConstants.Kw_GPUI_TWO_CHANNEL_HEIGHTMAP);
			}
			for (int i = 0; i < DetailPrototypeIndexes.Length && i < _detailDensityTextures.Length; i++)
			{
				int num2 = DetailPrototypeIndexes[i];
				if (num2 % 1000 != num || !detailPrototypeData.TryGetParameterBufferIndex(out sizeAndIndexes[2]))
				{
					continue;
				}
				int num3 = num2 / 1000;
				if (subSettingCount <= num3 || !detailPrototypeData.GetSubSettings(num3).TryGetParameterBufferIndex(out sizeAndIndexes[3]))
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find Detail Prototype Sub Setting parameter buffer index.");
					continue;
				}
				RenderTexture renderTexture = _detailDensityTextures[i];
				if (!(renderTexture == null))
				{
					int width = renderTexture.width;
					if (detailPrototypeData.isUseDensityReduction && detailPrototypeData.densityReduceDistance < detailObjectDistance)
					{
						cS_VegetationGenerator.EnableKeyword(GPUITerrainConstants.Kw_GPUI_DETAIL_DENSITY_REDUCE);
					}
					else
					{
						cS_VegetationGenerator.DisableKeyword(GPUITerrainConstants.Kw_GPUI_DETAIL_DENSITY_REDUCE);
					}
					if (terrainHolesSampleMode == GPUITerrainHolesSampleMode.Runtime && texture != null)
					{
						cS_VegetationGenerator.EnableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
						cS_VegetationGenerator.SetTexture(0, GPUITerrainConstants.PROP_terrainHoleTexture, texture);
					}
					else
					{
						cS_VegetationGenerator.DisableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
					}
					cS_VegetationGenerator.SetBuffer(0, GPUIConstants.PROP_gpuiTransformBuffer, transformBuffer);
					cS_VegetationGenerator.SetBuffer(0, GPUITerrainConstants.PROP_detailCounterBuffer, counterBuffer);
					cS_VegetationGenerator.SetBuffer(0, GPUIConstants.PROP_parameterBuffer, GPUIRenderingSystem.Instance.ParameterBuffer);
					cS_VegetationGenerator.SetTexture(0, GPUITerrainConstants.PROP_terrainDetailTexture, renderTexture);
					cS_VegetationGenerator.SetTexture(0, GPUITerrainConstants.PROP_heightmapTexture, _heightmapTexture);
					cS_VegetationGenerator.SetInt(GPUITerrainConstants.PROP_detailTextureSize, width);
					cS_VegetationGenerator.SetInt(GPUITerrainConstants.PROP_heightmapTextureSize, _heightmapTexture.width);
					cS_VegetationGenerator.SetVector(GPUITerrainConstants.PROP_startPosition, position);
					cS_VegetationGenerator.SetVector(GPUITerrainConstants.PROP_terrainSize, GetSize());
					cS_VegetationGenerator.SetInts(GPUIConstants.PROP_sizeAndIndexes, sizeAndIndexes);
					cS_VegetationGenerator.SetVector(GPUITerrainConstants.PROP_cameraPos, cameraPos);
					cS_VegetationGenerator.SetFloat(GPUITerrainConstants.PROP_density, GetDetailDensity(i));
					cS_VegetationGenerator.SetFloat(GPUITerrainConstants.PROP_detailObjectDistance, detailObjectDistance);
					cS_VegetationGenerator.SetTexture(0, GPUITerrainConstants.PROP_healthyDryNoiseTexture, healthyDryNoiseTexture);
					if (flag)
					{
						cS_VegetationGenerator.EnableKeyword("GPUI_TRANSFORM_OFFSET");
						cS_VegetationGenerator.SetMatrix(GPUIConstants.PROP_gpuiTransformOffset, _matrixOffset);
					}
					else
					{
						cS_VegetationGenerator.DisableKeyword("GPUI_TRANSFORM_OFFSET");
					}
					cS_VegetationGenerator.DispatchXZ(0, width, width);
				}
			}
		}

		public bool IsTerrainWithinViewDistance(Vector3 cameraPos, float detailObjectDistance)
		{
			Bounds terrainWorldBounds = GetTerrainWorldBounds();
			if (!terrainWorldBounds.Contains(cameraPos) && Mathf.Sqrt(terrainWorldBounds.SqrDistance(cameraPos)) > detailObjectDistance)
			{
				return false;
			}
			return true;
		}

		public virtual bool NotifyTransformChanges()
		{
			if (_cachedPosition != _cachedTransform.position)
			{
				_cachedPosition = _cachedTransform.position;
				RequireTreeUpdate();
				RequireDetailUpdate(forceImmediateUpdate: true);
				return true;
			}
			return false;
		}

		protected virtual void LoadTreeInstances()
		{
		}

		protected void ConvertToGPUITreeData(GPUITreeManager treeManager)
		{
			if (treeManager._enableTreeInstanceColors)
			{
				TreeInstance[] treeInstances = GetTreeInstances();
				for (int i = 0; i < treeInstances.Length; i++)
				{
					TreeInstance treeInstance = treeInstances[i];
					Color color = treeInstance.color;
					treeInstance.color = DecodeFloatRGBA(color);
					treeInstances[i] = treeInstance;
				}
			}
		}

		private static Color32 DecodeFloatRGBA(Vector4 enc)
		{
			byte[] bytes = BitConverter.GetBytes(Vector4.Dot(enc, _kDecodeDot));
			return new Color32(bytes[0], bytes[1], bytes[2], bytes[3]);
		}

		public void ReloadTerrainData()
		{
			if (IsInitialized)
			{
				Initialize();
			}
			if (DetailManager != null)
			{
				DetailManager.OnTerrainsModified();
				DetailManager.RequireUpdate();
			}
			if (TreeManager != null)
			{
				TreeManager.OnTerrainsModified();
				TreeManager.RequireUpdate();
			}
		}

		public void RequireTreeUpdate(bool reloadTreeInstances = false)
		{
			if (TreeManager != null)
			{
				TreeManager.RequireUpdate(reloadTreeInstances);
			}
		}

		public void RequireDetailUpdate(bool forceImmediateUpdate = false, bool reloadTerrainDetailTextures = false)
		{
			if (DetailManager != null)
			{
				DetailManager.RequireUpdate(forceImmediateUpdate, reloadTerrainDetailTextures);
			}
		}

		public void DetermineTreePrototypeIndexes(GPUITreeManager treeManager)
		{
			if (treeManager == null)
			{
				return;
			}
			if (TreePrototypes == null)
			{
				if (TreePrototypeIndexes == null || TreePrototypeIndexes.Length != 0)
				{
					TreePrototypeIndexes = new int[0];
				}
				return;
			}
			if (TreePrototypeIndexes == null || TreePrototypeIndexes.Length != TreePrototypes.Length)
			{
				TreePrototypeIndexes = new int[TreePrototypes.Length];
			}
			for (int i = 0; i < TreePrototypes.Length; i++)
			{
				TreePrototypeIndexes[i] = treeManager.DetermineTreePrototypeIndex(TreePrototypes[i]);
			}
		}

		public void DetermineDetailPrototypeIndexes(GPUIDetailManager detailManager)
		{
			if (detailManager == null)
			{
				return;
			}
			if (DetailPrototypes == null)
			{
				DetailPrototypeIndexes = new int[0];
				return;
			}
			if (DetailPrototypeIndexes == null || DetailPrototypeIndexes.Length != DetailPrototypes.Length)
			{
				DetailPrototypeIndexes = new int[DetailPrototypes.Length];
			}
			for (int i = 0; i < DetailPrototypes.Length; i++)
			{
				DetailPrototypeIndexes[i] = detailManager.DetermineDetailPrototypeIndex(DetailPrototypes[i]);
			}
		}

		public int GetFristTerrainTreePrototypeIndex(int managerPrototypeIndex)
		{
			if (TreePrototypeIndexes == null)
			{
				return -1;
			}
			for (int i = 0; i < TreePrototypeIndexes.Length; i++)
			{
				if (TreePrototypeIndexes[i] == managerPrototypeIndex)
				{
					return i;
				}
			}
			return -1;
		}

		public void GetTerrainTreePrototypeIndexes(int managerPrototypeIndex, ref List<int> terrainPrototypeIndexes)
		{
			if (terrainPrototypeIndexes == null)
			{
				if (terrainPrototypeIndexes == null)
				{
					terrainPrototypeIndexes = new List<int>();
				}
			}
			else
			{
				terrainPrototypeIndexes.Clear();
			}
			if (TreePrototypeIndexes == null)
			{
				return;
			}
			for (int i = 0; i < TreePrototypeIndexes.Length; i++)
			{
				if (TreePrototypeIndexes[i] == managerPrototypeIndex)
				{
					terrainPrototypeIndexes.Add(i);
				}
			}
		}

		public int GetFirstTerrainDetailPrototypeIndex(int managerPrototypeIndex)
		{
			if (DetailPrototypeIndexes == null)
			{
				return -1;
			}
			for (int i = 0; i < DetailPrototypeIndexes.Length; i++)
			{
				if (DetailPrototypeIndexes[i] % 1000 == managerPrototypeIndex)
				{
					return i;
				}
			}
			return -1;
		}

		public void GetTerrainDetailPrototypeIndexes(int managerPrototypeIndex, ref List<int> terrainPrototypeIndexes)
		{
			if (terrainPrototypeIndexes == null)
			{
				if (terrainPrototypeIndexes == null)
				{
					terrainPrototypeIndexes = new List<int>();
				}
			}
			else
			{
				terrainPrototypeIndexes.Clear();
			}
			if (DetailPrototypeIndexes == null)
			{
				return;
			}
			for (int i = 0; i < DetailPrototypeIndexes.Length; i++)
			{
				if (DetailPrototypeIndexes[i] % 1000 == managerPrototypeIndex)
				{
					terrainPrototypeIndexes.Add(i);
				}
			}
		}

		protected bool IsUnorderedTreePrototypeIndexes(GPUITreeManager treeManager)
		{
			if (TreePrototypeIndexes == null)
			{
				DetermineTreePrototypeIndexes(treeManager);
			}
			for (int i = 0; i < TreePrototypeIndexes.Length; i++)
			{
				if (i != TreePrototypeIndexes[i])
				{
					return true;
				}
			}
			return false;
		}

		public string GetTreePrototypeIndexesToString()
		{
			if (TreePrototypeIndexes == null)
			{
				return null;
			}
			string text = "";
			for (int i = 0; i < TreePrototypeIndexes.Length; i++)
			{
				if (i > 0)
				{
					text += ", ";
				}
				text += TreePrototypeIndexes[i];
			}
			return text;
		}

		public string GetDetailPrototypeIndexesToString()
		{
			if (DetailPrototypeIndexes == null)
			{
				return null;
			}
			string text = "";
			for (int i = 0; i < DetailPrototypeIndexes.Length; i++)
			{
				if (i > 0)
				{
					text += ", ";
				}
				text = text + DetailPrototypeIndexes[i] % 1000 + "[" + DetailPrototypeIndexes[i] / 1000 + "]";
			}
			return text;
		}

		public virtual void AddTreePrototypeToTerrain(GameObject pickerGameObject, int overwriteIndex)
		{
			LoadTerrainData();
			if (_treePrototypes == null)
			{
				return;
			}
			if (overwriteIndex >= 0)
			{
				List<int> terrainPrototypeIndexes = new List<int>();
				GetTerrainTreePrototypeIndexes(overwriteIndex, ref terrainPrototypeIndexes);
				foreach (int item in terrainPrototypeIndexes)
				{
					if (item >= 0 && item < _treePrototypes.Length)
					{
						_treePrototypes[item].prefab = pickerGameObject;
					}
				}
			}
			else
			{
				_treePrototypes = _treePrototypes.AddAndReturn(new TreePrototype
				{
					prefab = pickerGameObject
				});
			}
			DetermineTreePrototypeIndexes(TreeManager);
		}

		public virtual void AddDetailPrototypeToTerrain(UnityEngine.Object pickerObject, int overwriteIndex)
		{
			LoadTerrainData();
			if (_detailPrototypes == null)
			{
				return;
			}
			if (pickerObject is Texture2D)
			{
				if (overwriteIndex >= 0)
				{
					List<int> terrainPrototypeIndexes = new List<int>();
					GetTerrainDetailPrototypeIndexes(overwriteIndex, ref terrainPrototypeIndexes);
					foreach (int item in terrainPrototypeIndexes)
					{
						if (item >= 0 && item < _detailPrototypes.Length)
						{
							_detailPrototypes[item].prototype = null;
							_detailPrototypes[item].prototypeTexture = (Texture2D)pickerObject;
							_detailPrototypes[item].renderMode = DetailRenderMode.GrassBillboard;
							_detailPrototypes[item].usePrototypeMesh = false;
						}
					}
				}
				else
				{
					_detailPrototypes = _detailPrototypes.AddAndReturn(new DetailPrototype
					{
						usePrototypeMesh = false,
						prototypeTexture = (Texture2D)pickerObject,
						renderMode = DetailRenderMode.GrassBillboard,
						noiseSeed = UnityEngine.Random.Range(100, 100000)
					});
				}
			}
			else if (pickerObject is GameObject gameObject)
			{
				if (gameObject.GetComponentInChildren<MeshRenderer>() == null)
				{
					return;
				}
				if (overwriteIndex >= 0)
				{
					List<int> terrainPrototypeIndexes2 = new List<int>();
					GetTerrainDetailPrototypeIndexes(overwriteIndex, ref terrainPrototypeIndexes2);
					foreach (int item2 in terrainPrototypeIndexes2)
					{
						if (item2 >= 0 && item2 < _detailPrototypes.Length)
						{
							_detailPrototypes[item2].prototype = gameObject;
							_detailPrototypes[item2].prototypeTexture = null;
							_detailPrototypes[item2].renderMode = DetailRenderMode.VertexLit;
							_detailPrototypes[item2].usePrototypeMesh = true;
						}
					}
				}
				else
				{
					_detailPrototypes = _detailPrototypes.AddAndReturn(new DetailPrototype
					{
						usePrototypeMesh = true,
						prototype = gameObject.GetComponentInChildren<MeshRenderer>().gameObject,
						renderMode = DetailRenderMode.VertexLit,
						noiseSeed = UnityEngine.Random.Range(100, 100000),
						healthyColor = Color.white,
						dryColor = Color.white,
						useInstancing = true
					});
				}
			}
			DetermineDetailPrototypeIndexes(DetailManager);
		}

		public void RemoveTreePrototypeAtIndex(int index)
		{
			LoadTerrainData();
			if (_treePrototypes == null || _treePrototypes.Length == 0)
			{
				return;
			}
			List<int> terrainPrototypeIndexes = new List<int>();
			GetTerrainTreePrototypeIndexes(index, ref terrainPrototypeIndexes);
			LoadTreeInstances();
			foreach (int item in terrainPrototypeIndexes)
			{
				RemoveTerrainTreePrototypeAtIndex(item);
			}
			OnRemoveTreePrototypesAtIndexes(terrainPrototypeIndexes);
			DetermineTreePrototypeIndexes(TreeManager);
		}

		private void RemoveTerrainTreePrototypeAtIndex(int terrainPrototypeIndex)
		{
			_treePrototypes = _treePrototypes.RemoveAtAndReturn(terrainPrototypeIndex);
			if (_treeInstances == null || _treeInstances.Length == 0)
			{
				return;
			}
			List<TreeInstance> list = new List<TreeInstance>(_treeInstances);
			for (int i = 0; i < list.Count; i++)
			{
				TreeInstance value = list[i];
				if (value.prototypeIndex >= terrainPrototypeIndex)
				{
					if (value.prototypeIndex == terrainPrototypeIndex)
					{
						list.RemoveAt(i);
						i--;
					}
					else if (value.prototypeIndex > terrainPrototypeIndex)
					{
						value.prototypeIndex--;
						list[i] = value;
					}
				}
			}
			_treeInstances = list.ToArray();
		}

		protected abstract void OnRemoveTreePrototypesAtIndexes(List<int> terrainPrototypeIndexes);

		public void RemoveDetailPrototypeAtIndex(int index)
		{
			DisposeDetailDensityTextures();
			List<int> terrainPrototypeIndexes = new List<int>();
			GetTerrainDetailPrototypeIndexes(index, ref terrainPrototypeIndexes);
			foreach (int item in terrainPrototypeIndexes)
			{
				_detailPrototypes = _detailPrototypes.RemoveAtAndReturn(item);
			}
			OnRemoveDetailPrototypesAtIndexes(terrainPrototypeIndexes);
			DetermineDetailPrototypeIndexes(DetailManager);
		}

		protected abstract void OnRemoveDetailPrototypesAtIndexes(List<int> terrainPrototypeIndexes);

		internal void SetTreeManager(GPUITreeManager treeManager)
		{
			if (TreeManager != null && TreeManager != treeManager)
			{
				TreeManager.RemoveTerrain(this);
			}
			TreeManager = treeManager;
			SetTerrainTreeDistance(0f);
			DetermineTreePrototypeIndexes(treeManager);
			LoadTreeInstances();
		}

		internal void SetDetailManager(GPUIDetailManager detailManager)
		{
			if (DetailManager != null && DetailManager != detailManager)
			{
				DetailManager.RemoveTerrain(this);
			}
			DetailManager = detailManager;
			SetTerrainDetailObjectDistance(0f);
			DetermineDetailPrototypeIndexes(detailManager);
		}

		internal void RemoveTreeManager()
		{
			if (TreeManager != null && (!Application.isPlaying || TreeManager.isEnableDefaultRenderingWhenDisabled))
			{
				SetTerrainTreeDistance(GetTerrainTreeDistance());
			}
			TreeManager = null;
			_treeInstances = null;
		}

		internal void RemoveDetailManager()
		{
			if (DetailManager != null && (!Application.isPlaying || DetailManager.isEnableDefaultRenderingWhenDisabled))
			{
				SetTerrainDetailObjectDistance(DetailManager.detailObjectDistance);
			}
			DetailManager = null;
		}

		public virtual float GetTerrainTreeDistance()
		{
			return 5000f;
		}

		public RenderTexture GetHeightmapTexture()
		{
			if (_heightmapTexture == null)
			{
				CreateHeightmapTexture();
			}
			return _heightmapTexture;
		}

		public void SetHeightmapTexture(RenderTexture heightmapTexture)
		{
			_heightmapTexture = heightmapTexture;
		}

		public abstract int GetHeightmapResolution();

		public virtual bool SetTerrainBounds(bool forceNew = false)
		{
			if (forceNew || _bounds == default(Bounds))
			{
				_bounds = _cachedTransform.gameObject.GetBounds(isVertexBased: true);
				_bounds.center -= _cachedTransform.position;
				if (HasScalingSupport())
				{
					Vector3 b = _cachedTransform.lossyScale.Reciprocal();
					_bounds.extents = Vector3.Scale(_bounds.extents, b);
					_bounds.center = Vector3.Scale(_bounds.center, b);
					if (_bounds.extents == Vector3.zero)
					{
						_bounds.extents = Vector3.one;
					}
				}
				RequireTreeUpdate();
				RequireDetailUpdate();
				return true;
			}
			return false;
		}

		public virtual Vector3 GetPosition()
		{
			Vector3 vector = _bounds.min;
			if (HasScalingSupport())
			{
				vector = Vector3.Scale(vector, GetTerrainSale());
			}
			if (HasRotationSupport())
			{
				vector = GetTerrainRotation() * vector;
			}
			return _cachedPosition + vector;
		}

		public virtual Bounds GetTerrainWorldBounds()
		{
			Bounds bounds = _bounds;
			if (HasRotationSupport())
			{
				bounds = bounds.GetRotationAppliedBounds(GetTerrainRotation());
			}
			if (HasScalingSupport())
			{
				Vector3 terrainSale = GetTerrainSale();
				bounds.center = Vector3.Scale(bounds.center, terrainSale);
				bounds.extents = Vector3.Scale(bounds.extents, terrainSale);
			}
			bounds.center += _cachedPosition;
			return bounds;
		}

		public virtual bool IsBakedDetailTextures()
		{
			return true;
		}

		public virtual Vector3 GetSize()
		{
			Vector3 vector = _bounds.size;
			if (HasScalingSupport())
			{
				vector = Vector3.Scale(vector, GetTerrainSale());
			}
			return vector;
		}

		public virtual float GetDetailDensity(int prototypeIndex)
		{
			return 255f;
		}

		public int GetDetailTextureCount()
		{
			if (_detailDensityTextures == null)
			{
				return 0;
			}
			return _detailDensityTextures.Length;
		}

		public RenderTexture GetDetailDensityTexture(int index)
		{
			if (_detailDensityTextures == null || index < 0 || _detailDensityTextures.Length <= index)
			{
				return null;
			}
			return _detailDensityTextures[index];
		}

		public virtual int GetBakedDetailTextureCount()
		{
			if (_bakedDetailTextures == null)
			{
				return 0;
			}
			return _bakedDetailTextures.Length;
		}

		public virtual Texture2D GetBakedDetailTexture(int index)
		{
			if (_bakedDetailTextures == null || index < 0 || _bakedDetailTextures.Length <= index)
			{
				return null;
			}
			return _bakedDetailTextures[index];
		}

		public virtual void SetBakedDetailTexture(int index, Texture2D texture)
		{
			if (DetailPrototypes == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Detail prototypes are not set.");
				return;
			}
			if (_bakedDetailTextures == null)
			{
				_bakedDetailTextures = new Texture2D[DetailPrototypes.Length];
			}
			if (index < 0 || index > _bakedDetailTextures.Length)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "SetBakedDetailTexture error: given index [" + index + "] is out of bounds. Detail prototype count: " + _bakedDetailTextures.Length);
			}
			else
			{
				_bakedDetailTextures[index] = texture;
				if (IsDetailDensityTexturesLoaded)
				{
					CreateDetailTextures();
				}
			}
		}

		public virtual void SetDetailDensityTexture(int index, RenderTexture renderTexture)
		{
			if (DetailPrototypes == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Detail prototypes are not set.");
				return;
			}
			if (!IsDetailDensityTexturesLoaded)
			{
				CreateDetailTextures();
			}
			if (_detailDensityTextures[index] != null)
			{
				_detailDensityTextures[index].Release();
			}
			_detailDensityTextures[index] = renderTexture;
		}

		public TreeInstance[] GetTreeInstances(bool reloadTreeInstances = false)
		{
			if (reloadTreeInstances)
			{
				LoadTreeInstances();
			}
			if (_treeInstances == null)
			{
				return EMPTY_TREE_INSTANCES;
			}
			return _treeInstances;
		}

		public virtual void SetTreeInstances(TreeInstance[] treeInstances, bool applyToTerrainData = false)
		{
			_treeInstances = treeInstances;
			if (TreeManager != null)
			{
				ConvertToGPUITreeData(TreeManager);
				TreeManager.RequireUpdate();
			}
		}

		public virtual Color GetWavingGrassTint()
		{
			return Color.white;
		}

		public bool Equals(GPUITerrain other)
		{
			if (other == null)
			{
				return false;
			}
			return GetInstanceID() == other.GetInstanceID();
		}

		public override bool Equals(object obj)
		{
			if (obj is GPUITerrain other)
			{
				return Equals(other);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return GetInstanceID();
		}

		public virtual Texture GetHolesTexture()
		{
			if (DUMMY_HOLES_TEXTURE == null)
			{
				DUMMY_HOLES_TEXTURE = new RenderTexture(1, 1, 0, GPUITerrainConstants.R8_RenderTextureFormat, RenderTextureReadWrite.Linear)
				{
					isPowerOfTwo = false,
					enableRandomWrite = true,
					filterMode = FilterMode.Point,
					useMipMap = false,
					autoGenerateMips = false
				};
				DUMMY_HOLES_TEXTURE.Create();
				Texture2D texture2D = new Texture2D(1, 1);
				texture2D.SetPixel(0, 0, Color.white);
				GPUITextureUtility.CopyTextureSamplerWithComputeShader(texture2D, DUMMY_HOLES_TEXTURE);
				texture2D.DestroyGeneric();
			}
			return DUMMY_HOLES_TEXTURE;
		}

		public virtual int GetAlphamapTextureCount()
		{
			return 0;
		}

		public virtual Texture2D[] GetAlphamapTextures()
		{
			return null;
		}

		public virtual TerrainLayer[] GetTerrainLayers()
		{
			return null;
		}

		internal Matrix4x4 GetMatrixOffset()
		{
			return _matrixOffset;
		}

		public virtual bool HasMatrixOffset()
		{
			return false;
		}

		protected virtual bool HasScalingSupport()
		{
			return false;
		}

		protected virtual bool HasRotationSupport()
		{
			return false;
		}

		protected virtual Vector3 GetTerrainSale()
		{
			Vector3 vector = Vector3.one;
			if (HasScalingSupport())
			{
				vector = _cachedTransform.lossyScale;
			}
			if (HasRotationSupport())
			{
				vector = GPUIUtility.RotateSize(vector, GetSavedTerrainRotation());
			}
			return vector;
		}

		protected virtual Quaternion GetTerrainRotation()
		{
			return Quaternion.identity;
		}

		protected virtual Quaternion GetSavedTerrainRotation()
		{
			return Quaternion.identity;
		}

		public virtual bool HasTwoChannelHeightmap()
		{
			return !GPUIRuntimeSettings.Instance.API_HAS_GUARANTEED_R8_SUPPORT;
		}

		public void SetProceduralDetailModifier(IGPUIProceduralDetailModifier detailModifier)
		{
			_proceduralDetailModifier = detailModifier;
			RequireDetailUpdate(forceImmediateUpdate: false, reloadTerrainDetailTextures: true);
		}

		protected bool IsReadTerrainDetails(int terrainDetailPrototypeIndex)
		{
			if (_proceduralDetailModifier != null && !_proceduralDetailModifier.IsReadTerrainDetails(terrainDetailPrototypeIndex))
			{
				return false;
			}
			if (DetailManager != null && DetailPrototypeIndexes != null && DetailPrototypeIndexes.Length > terrainDetailPrototypeIndex && !DetailManager.IsReadTerrainDetails(DetailPrototypeIndexes[terrainDetailPrototypeIndex] % 1000))
			{
				return false;
			}
			return true;
		}
	}
}
