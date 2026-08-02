using System;
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

		[SerializeField]
		protected Bounds _bounds;

		[SerializeField]
		internal Texture2D[] _bakedDetailTextures;

		[SerializeField]
		public bool isAutoFindTreeManager = true;

		[SerializeField]
		public bool isAutoFindDetailManager = true;

		[SerializeField]
		public GPUITerrainHolesSampleMode terrainHolesSampleMode;

		[NonSerialized]
		private Transform _cachedTransform;

		[NonSerialized]
		private Vector3 _cachedPosition;

		[NonSerialized]
		private RenderTexture _heightmapTexture;

		[NonSerialized]
		protected TreeInstance[] _treeInstances;

		[NonSerialized]
		protected RenderTexture[] _detailDensityTextures;

		protected static readonly TreeInstance[] _emptyTreeInstances = new TreeInstance[0];

		protected static RenderTexture dummyHolesTexture;

		private static readonly Vector4 _kDecodeDot = new Vector4(1f, 0.003921569f, 1.53787E-05f, 6.030863E-08f);

		public GPUITreeManager TreeManager { get; private set; }

		public TreePrototype[] TreePrototypes { get; protected set; }

		internal int[] TreePrototypeIndexes { get; private set; }

		public GPUIDetailManager DetailManager { get; private set; }

		public DetailPrototype[] DetailPrototypes { get; protected set; }

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
			NotifyTransformChanges();
		}

		public virtual void LoadTerrainData()
		{
			LoadTerrain();
		}

		protected void Initialize()
		{
			Dispose();
			LoadTerrainData();
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
				TreeManager = UnityEngine.Object.FindFirstObjectByType<GPUITreeManager>();
				if (TreeManager != null && !TreeManager.AddTerrain(this))
				{
					SetTreeManager(TreeManager);
				}
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
				DetailManager = UnityEngine.Object.FindFirstObjectByType<GPUIDetailManager>();
				if (DetailManager != null && !DetailManager.AddTerrain(this))
				{
					SetDetailManager(DetailManager);
				}
			}
		}

		internal void Dispose()
		{
			IsInitialized = false;
			DisposeDetailDensityTextures();
			_treeInstances = null;
			if (TreeManager != null)
			{
				TreeManager.RemoveTerrain(this);
			}
			if (DetailManager != null)
			{
				DetailManager.RemoveTerrain(this);
			}
			if (dummyHolesTexture != null)
			{
				dummyHolesTexture.DestroyRenderTexture();
			}
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

		protected void ResizeDetailDensityTexturesArray(int detailCount)
		{
			if (_detailDensityTextures == null)
			{
				_detailDensityTextures = new RenderTexture[detailCount];
			}
			else if (detailCount > _detailDensityTextures.Length)
			{
				Array.Resize(ref _detailDensityTextures, detailCount);
			}
			else if (detailCount < _detailDensityTextures.Length)
			{
				for (int i = detailCount; i < _detailDensityTextures.Length; i++)
				{
					DisposeDetailDensityTexture(i);
				}
				Array.Resize(ref _detailDensityTextures, detailCount);
			}
		}

		protected void DisposeDetailDensityTexture(int index)
		{
			RenderTexture renderTexture = _detailDensityTextures[index];
			if (renderTexture != null && renderTexture.name.EndsWith("_GPUIDL"))
			{
				renderTexture.DestroyRenderTexture();
			}
		}

		internal virtual void SetTerrainDetailObjectDistance(float value)
		{
		}

		internal virtual void SetTerrainTreeDistance(float value)
		{
		}

		protected void CreateHeightmapTexture()
		{
			_heightmapTexture = LoadHeightmapTexture();
		}

		protected abstract RenderTexture LoadHeightmapTexture();

		public void CreateDetailTextures(bool forceUpdate = false)
		{
			LoadDetailDensityTextures(forceUpdate);
			IsDetailDensityTexturesLoaded = true;
		}

		protected virtual void LoadDetailDensityTextures(bool forceUpdate = false)
		{
			DisposeDetailDensityTextures();
			int num = ((DetailPrototypes != null) ? DetailPrototypes.Length : 0);
			if (num == 0)
			{
				return;
			}
			int detailResolution = GetDetailResolution();
			_detailDensityTextures = new RenderTexture[num];
			if (_bakedDetailTextures == null)
			{
				_bakedDetailTextures = new Texture2D[num];
			}
			else if (_bakedDetailTextures.Length != num)
			{
				Array.Resize(ref _bakedDetailTextures, num);
			}
			string text = base.name;
			for (int i = 0; i < num; i++)
			{
				_detailDensityTextures[i] = GPUITerrainUtility.CreateDetailRenderTexture(detailResolution, text + "_GPUIDL" + i);
				if (_bakedDetailTextures[i] != null)
				{
					Graphics.Blit(_bakedDetailTextures[i], _detailDensityTextures[i]);
				}
			}
			if (DetailManager != null)
			{
				DetailManager.RequireUpdate();
			}
		}

		protected abstract int GetDetailResolution();

		public virtual void RemoveTreePrototypeAtIndex(int index)
		{
		}

		public virtual void RemoveDetailPrototypeAtIndex(int index)
		{
		}

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
			if (!IsTerrainWithinViewDistance(position, cameraPos, detailObjectDistance))
			{
				return;
			}
			if (DetailPrototypeIndexes == null)
			{
				DetermineDetailPrototypeIndexes(DetailManager);
			}
			int num = sizeAndIndexes[1];
			int subSettingCount = detailPrototypeData.GetSubSettingCount();
			ComputeShader cS_VegetationGenerator = GPUITerrainConstants.CS_VegetationGenerator;
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
					Debug.LogError("Can not find Detail Prototype Sub Setting parameter buffer index.");
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
					if (terrainHolesSampleMode == GPUITerrainHolesSampleMode.Runtime)
					{
						cS_VegetationGenerator.EnableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
						cS_VegetationGenerator.SetTexture(0, GPUITerrainConstants.PROP_terrainHoleTexture, GetHolesTexture());
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
					cS_VegetationGenerator.DispatchXZ(0, width, width);
				}
			}
		}

		private bool IsTerrainWithinViewDistance(Vector3 terrainPos, Vector3 cameraPos, float detailObjectDistance)
		{
			Bounds bounds = _bounds;
			bounds.center += terrainPos;
			if (!bounds.Contains(cameraPos) && Mathf.Sqrt(bounds.SqrDistance(cameraPos)) > detailObjectDistance)
			{
				return false;
			}
			return true;
		}

		public bool IsTerrainWithinViewDistance(Vector3 cameraPos, float viewDistance)
		{
			return IsTerrainWithinViewDistance(GetPosition(), cameraPos, viewDistance);
		}

		public void NotifyTransformChanges()
		{
			if (_cachedPosition != _cachedTransform.position)
			{
				_cachedPosition = _cachedTransform.position;
				if (TreeManager != null)
				{
					TreeManager.RequireUpdate();
				}
				if (DetailManager != null)
				{
					DetailManager.RequireUpdate();
				}
			}
		}

		protected virtual void LoadTreeInstances()
		{
		}

		private void ConvertToGPUITreeData(GPUITreeManager treeManager)
		{
			TreeInstance[] treeInstances = GetTreeInstances();
			if (IsUnorderedTreePrototypeIndexes(treeManager))
			{
				for (int i = 0; i < treeInstances.Length; i++)
				{
					TreeInstance treeInstance = treeInstances[i];
					treeInstance.prototypeIndex = TreePrototypeIndexes[treeInstance.prototypeIndex];
					treeInstances[i] = treeInstance;
				}
			}
			if (treeManager._enableTreeInstanceColors)
			{
				for (int j = 0; j < treeInstances.Length; j++)
				{
					TreeInstance treeInstance2 = treeInstances[j];
					Color color = treeInstance2.color;
					treeInstance2.color = DecodeFloatRGBA(color);
					treeInstances[j] = treeInstance2;
				}
			}
		}

		private static Color32 DecodeFloatRGBA(Vector4 enc)
		{
			byte[] bytes = BitConverter.GetBytes(Vector4.Dot(enc, _kDecodeDot));
			return new Color32(bytes[0], bytes[1], bytes[2], bytes[3]);
		}

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
			ConvertToGPUITreeData(treeManager);
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

		internal void DetermineTreePrototypeIndexes(GPUITreeManager treeManager)
		{
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
			if (!(treeManager == null))
			{
				for (int i = 0; i < TreePrototypes.Length; i++)
				{
					TreePrototypeIndexes[i] = treeManager.DetermineTreePrototypeIndex(TreePrototypes[i]);
				}
			}
		}

		internal void DetermineDetailPrototypeIndexes(GPUIDetailManager detailManager)
		{
			if (DetailPrototypes == null)
			{
				DetailPrototypeIndexes = new int[0];
				return;
			}
			if (DetailPrototypeIndexes == null || DetailPrototypeIndexes.Length != DetailPrototypes.Length)
			{
				DetailPrototypeIndexes = new int[DetailPrototypes.Length];
			}
			if (!(detailManager == null))
			{
				for (int i = 0; i < DetailPrototypes.Length; i++)
				{
					DetailPrototypeIndexes[i] = detailManager.DetermineDetailPrototypeIndex(DetailPrototypes[i]);
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

		public Bounds GetBounds()
		{
			Bounds bounds = _bounds;
			bounds.center += GetPosition();
			return bounds;
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

		public virtual Vector3 GetPosition()
		{
			return _cachedPosition;
		}

		public virtual bool IsBakedDetailTextures()
		{
			return true;
		}

		public int GetTerrainTreePrototypeIndex(int managerPrototypeIndex)
		{
			if (TreePrototypeIndexes == null)
			{
				DetermineTreePrototypeIndexes(TreeManager);
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

		public int GetTerrainDetailPrototypeIndex(int managerPrototypeIndex)
		{
			if (DetailPrototypeIndexes == null)
			{
				DetermineDetailPrototypeIndexes(DetailManager);
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

		public virtual Vector3 GetSize()
		{
			return _bounds.size;
		}

		public virtual float GetDetailDensity(int prototypeIndex)
		{
			return Mathf.Pow(2f, 16f) / Mathf.Pow(GetDetailResolution(), 2f);
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

		public Texture2D GetBakedDetailTexture(int index)
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
				Debug.LogError("Detail prototypes are not set.");
				return;
			}
			if (_bakedDetailTextures == null)
			{
				_bakedDetailTextures = new Texture2D[DetailPrototypes.Length];
			}
			if (index < 0 || index > _bakedDetailTextures.Length)
			{
				Debug.LogError("SetBakedDetailTexture error: given index [" + index + "] is out of bounds. Detail prototype count: " + _bakedDetailTextures.Length);
				return;
			}
			_bakedDetailTextures[index] = texture;
			if (IsDetailDensityTexturesLoaded)
			{
				CreateDetailTextures();
			}
		}

		public virtual void SetDetailDensityTexture(int index, RenderTexture renderTexture)
		{
			if (DetailPrototypes == null)
			{
				Debug.LogError("Detail prototypes are not set.");
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
				return _emptyTreeInstances;
			}
			return _treeInstances;
		}

		public void SetTreeInstances(TreeInstance[] treeInstances)
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

		public virtual void AddTreePrototypeToTerrain(GameObject pickerGameObject, int overwriteIndex)
		{
		}

		public virtual void AddDetailPrototypeToTerrain(UnityEngine.Object pickerObject, int overwriteIndex)
		{
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
			if (dummyHolesTexture == null)
			{
				dummyHolesTexture = new RenderTexture(1, 1, 0, GPUIRuntimeSettings.Instance.API_HAS_GUARANTEED_R8_SUPPORT ? RenderTextureFormat.R8 : RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear)
				{
					isPowerOfTwo = false,
					enableRandomWrite = true,
					filterMode = FilterMode.Point,
					useMipMap = false,
					autoGenerateMips = false
				};
				dummyHolesTexture.Create();
				Texture2D texture2D = new Texture2D(1, 1);
				texture2D.SetPixel(0, 0, Color.white);
				Graphics.Blit(texture2D, dummyHolesTexture);
				texture2D.DestroyGeneric();
			}
			return dummyHolesTexture;
		}
	}
}
