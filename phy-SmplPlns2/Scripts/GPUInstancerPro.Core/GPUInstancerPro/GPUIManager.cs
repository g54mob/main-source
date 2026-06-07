using System;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro
{
	public abstract class GPUIManager : MonoBehaviour, IGPUIDisposable, IDisposable, IGPUILightProbeDataProvider
	{
		[SerializeField]
		public bool isDontDestroyOnLoad;

		[SerializeField]
		protected GPUIPrototype[] _prototypes;

		[SerializeField]
		public GPUIProfile defaultProfile;

		[SerializeField]
		public bool isEnableDefaultRenderingWhenDisabled = true;

		[SerializeField]
		private bool _disablePlayModeRendering;

		[NonSerialized]
		protected int[] _runtimeRenderKeys;

		[NonSerialized]
		protected JobHandle _dependentJob;

		[NonSerialized]
		private bool _loggedPrototypeValidationError;

		[NonSerialized]
		public int errorCode;

		[NonSerialized]
		public UnityAction errorFixAction;

		[NonSerialized]
		private static readonly Type[] _prefabRendererTypes = new Type[2]
		{
			typeof(MeshRenderer),
			typeof(BillboardRenderer)
		};

		private const int ERROR_CODE_ADDITION = 200;

		public bool IsInitialized { get; private set; }

		protected virtual void Awake()
		{
			if (Application.isPlaying && _disablePlayModeRendering)
			{
				UnityEngine.Object.Destroy(this);
			}
			else if (!GPUIRuntimeSettings.Instance.IsSupportedPlatform())
			{
				base.enabled = false;
			}
		}

		protected virtual void Start()
		{
			CheckPrototypeChanges();
			if (Application.isPlaying && isDontDestroyOnLoad)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		protected virtual void OnEnable()
		{
			if (Application.isPlaying && _disablePlayModeRendering)
			{
				UnityEngine.Object.Destroy(this);
				Dispose();
			}
			else if (!IsInitialized)
			{
				Initialize();
			}
		}

		protected virtual void OnDisable()
		{
			Dispose();
		}

		protected virtual void Update()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		public virtual bool IsValid(bool logError)
		{
			errorCode = 0;
			errorFixAction = null;
			if (_disablePlayModeRendering)
			{
				errorCode = -106;
				errorFixAction = delegate
				{
					_disablePlayModeRendering = false;
				};
			}
			return true;
		}

		public virtual void Initialize()
		{
			Dispose();
			CheckPrototypeChanges();
			IsValid(Application.isPlaying);
			GPUIRenderingSystem.AddActiveManager(this);
			for (int i = 0; i < _prototypes.Length; i++)
			{
				RegisterRenderer(i);
			}
			IsInitialized = true;
		}

		public virtual void ReleaseBuffers()
		{
		}

		public virtual void Dispose()
		{
			_dependentJob.Complete();
			if (!IsInitialized)
			{
				return;
			}
			IsInitialized = false;
			ReleaseBuffers();
			GPUIRenderingSystem.RemoveActiveManager(this);
			if (_runtimeRenderKeys != null)
			{
				for (int i = 0; i < _runtimeRenderKeys.Length; i++)
				{
					DisposeRenderer(i);
				}
				_runtimeRenderKeys = null;
			}
		}

		public virtual void OnPrototypeEnabledStatusChanged(int prototypeIndex, bool isEnabled)
		{
			if (IsInitialized)
			{
				if (isEnabled && _runtimeRenderKeys[prototypeIndex] == 0)
				{
					OnPrototypeEnabled(prototypeIndex);
				}
				else if (!isEnabled && _runtimeRenderKeys[prototypeIndex] != 0)
				{
					OnPrototypeDisabled(prototypeIndex);
				}
			}
		}

		protected virtual void OnPrototypeEnabled(int prototypeIndex)
		{
			RegisterRenderer(prototypeIndex);
		}

		protected virtual void OnPrototypeDisabled(int prototypeIndex)
		{
			DisposeRenderer(prototypeIndex);
		}

		protected virtual bool RegisterRenderer(int prototypeIndex)
		{
			GPUIPrototype gPUIPrototype = _prototypes[prototypeIndex];
			if (gPUIPrototype == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Prototype at index: " + prototypeIndex + " is null.", this);
				return false;
			}
			if (!gPUIPrototype.IsValid(logError: true) || !gPUIPrototype.isEnabled)
			{
				return false;
			}
			if (GPUIRenderingSystem.RegisterRenderer(this, gPUIPrototype, out var rendererKey, GetRendererGroupID(prototypeIndex), GetTransformBufferType(prototypeIndex), GetShaderKeywords(prototypeIndex)))
			{
				_runtimeRenderKeys[prototypeIndex] = rendererKey;
				return true;
			}
			return false;
		}

		protected virtual void DisposeRenderer(int prototypeIndex)
		{
			if (_runtimeRenderKeys != null && _runtimeRenderKeys.Length > prototypeIndex)
			{
				int num = _runtimeRenderKeys[prototypeIndex];
				if (num != 0)
				{
					GPUIRenderingSystem.DisposeRenderer(num);
				}
				_runtimeRenderKeys[prototypeIndex] = 0;
			}
		}

		internal void OnRenderSourceDisposed(int runtimeRenderKey)
		{
			int prototypeIndex = GetPrototypeIndex(runtimeRenderKey);
			if (prototypeIndex >= 0 && _runtimeRenderKeys[prototypeIndex] != 0)
			{
				_runtimeRenderKeys[prototypeIndex] = 0;
				DisposeRenderer(prototypeIndex);
			}
		}

		protected virtual void DisposeAllRenderers()
		{
			if (_runtimeRenderKeys == null)
			{
				return;
			}
			for (int i = 0; i < _runtimeRenderKeys.Length; i++)
			{
				int num = _runtimeRenderKeys[i];
				if (num != 0)
				{
					GPUIRenderingSystem.DisposeRenderer(num);
				}
				_runtimeRenderKeys[i] = 0;
			}
		}

		public int GetRenderKey(int prototypeIndex)
		{
			if (!IsInitialized || _runtimeRenderKeys == null || _runtimeRenderKeys.Length < prototypeIndex || prototypeIndex < 0)
			{
				return 0;
			}
			return _runtimeRenderKeys[prototypeIndex];
		}

		public int GetPrototypeIndex(int renderKey)
		{
			if (_runtimeRenderKeys != null)
			{
				for (int i = 0; i < _runtimeRenderKeys.Length; i++)
				{
					if (_runtimeRenderKeys[i] == renderKey)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public int GetPrototypeIndex(GameObject prefabObject)
		{
			if (prefabObject == null)
			{
				return -1;
			}
			if (_prototypes != null)
			{
				for (int i = 0; i < _prototypes.Length; i++)
				{
					if (_prototypes[i].prototypeType == GPUIPrototypeType.Prefab && _prototypes[i].prefabObject == prefabObject)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public int GetPrototypeIndex(GPUILODGroupData lgd)
		{
			if (lgd == null)
			{
				return -1;
			}
			if (_prototypes != null)
			{
				for (int i = 0; i < _prototypes.Length; i++)
				{
					if (_prototypes[i].prototypeType == GPUIPrototypeType.LODGroupData && _prototypes[i].gpuiLODGroupData == lgd)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public virtual GPUIProfile GetDefaultProfile()
		{
			if (defaultProfile != null)
			{
				return defaultProfile;
			}
			return GPUIProfile.DefaultProfile;
		}

		public virtual GPUIProfile GetDefaultProfile(GameObject prefab)
		{
			return GetDefaultProfile();
		}

		public virtual int GetRendererGroupID(int prototypeIndex)
		{
			return 0;
		}

		public virtual GPUITransformBufferType GetTransformBufferType(int prototypeIndex)
		{
			return GPUITransformBufferType.Default;
		}

		public virtual List<string> GetShaderKeywords(int prototypeIndex)
		{
			return null;
		}

		public void OnLightProbesUpdated()
		{
			if (GPUIRenderingSystem.WillUpdateLightProbes() || _runtimeRenderKeys == null)
			{
				return;
			}
			for (int i = 0; i < _runtimeRenderKeys.Length; i++)
			{
				if (GPUIRenderingSystem.TryGetTransformBufferData(_runtimeRenderKeys[i], out var transformBufferData, out var _, out var _, resetCrossFade: false) && transformBufferData.IsGeneratePerInstanceLightProbes)
				{
					OnUpdatePerInstanceLightProbes(i);
				}
			}
		}

		protected virtual void OnUpdatePerInstanceLightProbes(int prototypeIndex)
		{
		}

		public virtual void CheckPrototypeChanges()
		{
			ClearNullPrototypes();
			SynchronizeData();
		}

		protected virtual bool ValidatePrototype(int prototypeIndex)
		{
			GPUIPrototype gPUIPrototype = _prototypes[prototypeIndex];
			if (!gPUIPrototype.IsValid(Application.isPlaying))
			{
				return false;
			}
			if (gPUIPrototype.prototypeType == GPUIPrototypeType.Prefab && !ValidatePrefabPrototype(gPUIPrototype))
			{
				return false;
			}
			return true;
		}

		public static bool ValidatePrefabPrototype(GPUIPrototype prototype)
		{
			if (prototype.prefabObject.TryGetComponent<LODGroup>(out var component))
			{
				LOD[] lODs = component.GetLODs();
				for (int i = 0; i < lODs.Length; i++)
				{
					bool flag = false;
					if (lODs[i].renderers != null)
					{
						Renderer[] renderers = lODs[i].renderers;
						foreach (Renderer renderer in renderers)
						{
							if (!(renderer != null))
							{
								continue;
							}
							if (renderer is BillboardRenderer)
							{
								flag = true;
								continue;
							}
							if (renderer is MeshRenderer meshRenderer)
							{
								flag = true;
								if (!meshRenderer.TryGetComponent<MeshFilter>(out var component2) || component2.sharedMesh == null)
								{
									prototype.errorCode = 2005;
									return false;
								}
							}
							else
							{
								if (!(renderer is SkinnedMeshRenderer skinnedMeshRenderer))
								{
									continue;
								}
								flag = true;
								if (skinnedMeshRenderer.sharedMesh == null)
								{
									prototype.errorCode = 2005;
									return false;
								}
							}
							Material[] sharedMaterials = renderer.sharedMaterials;
							if (sharedMaterials.Contains(null))
							{
								flag = true;
								prototype.errorCode = 2004;
								return false;
							}
							Material[] array = sharedMaterials;
							for (int k = 0; k < array.Length; k++)
							{
								if (array[k].shader == null)
								{
									prototype.errorCode = 2006;
									return false;
								}
							}
						}
					}
					if (!flag)
					{
						prototype.errorCode = 2002;
						return false;
					}
				}
			}
			else
			{
				if (prototype.prefabObject.GetComponentInChildren<LODGroup>(includeInactive: true) != null)
				{
					prototype.errorCode = 2001;
					return false;
				}
				MeshRenderer[] componentsInChildren = prototype.prefabObject.GetComponentsInChildren<MeshRenderer>();
				SkinnedMeshRenderer[] componentsInChildren2 = prototype.prefabObject.GetComponentsInChildren<SkinnedMeshRenderer>();
				if ((componentsInChildren == null || componentsInChildren.Length == 0) && (componentsInChildren2 == null || componentsInChildren2.Length == 0))
				{
					prototype.errorCode = 2003;
					return false;
				}
				MeshRenderer[] array2 = componentsInChildren;
				foreach (MeshRenderer meshRenderer2 in array2)
				{
					if (meshRenderer2.sharedMaterials == null || meshRenderer2.sharedMaterials.Contains(null))
					{
						prototype.errorCode = 2004;
						return false;
					}
					if (!meshRenderer2.TryGetComponent<MeshFilter>(out var component3) || component3.sharedMesh == null)
					{
						prototype.errorCode = 2005;
						return false;
					}
					Material[] array = meshRenderer2.sharedMaterials;
					for (int k = 0; k < array.Length; k++)
					{
						if (array[k].shader == null)
						{
							prototype.errorCode = 2006;
							return false;
						}
					}
				}
				SkinnedMeshRenderer[] array3 = componentsInChildren2;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in array3)
				{
					if (skinnedMeshRenderer2.sharedMaterials == null || skinnedMeshRenderer2.sharedMaterials.Contains(null))
					{
						prototype.errorCode = 2004;
						return false;
					}
					if (skinnedMeshRenderer2.sharedMesh == null)
					{
						prototype.errorCode = 2005;
						return false;
					}
					Material[] array = skinnedMeshRenderer2.sharedMaterials;
					for (int k = 0; k < array.Length; k++)
					{
						if (array[k].shader == null)
						{
							prototype.errorCode = 2006;
							return false;
						}
					}
				}
			}
			return true;
		}

		protected virtual void SynchronizeData()
		{
			int num = _prototypes.Length;
			if (_runtimeRenderKeys == null)
			{
				_runtimeRenderKeys = new int[num];
			}
			else if (_runtimeRenderKeys.Length != num)
			{
				Array.Resize(ref _runtimeRenderKeys, num);
			}
		}

		protected virtual void ClearNullPrototypes()
		{
			if (_prototypes == null)
			{
				_prototypes = new GPUIPrototype[0];
			}
			int num = _prototypes.Length;
			for (int i = 0; i < num; i++)
			{
				GPUIPrototype gPUIPrototype = _prototypes[i];
				if (gPUIPrototype.prototypeType == GPUIPrototypeType.Prefab && gPUIPrototype.prefabObject == null)
				{
					RemovePrototypeAtIndex(i);
					return;
				}
			}
			if (_runtimeRenderKeys == null)
			{
				_runtimeRenderKeys = new int[num];
			}
			bool flag = true;
			for (int j = 0; j < _prototypes.Length; j++)
			{
				if (_prototypes[j] == null)
				{
					RemovePrototypeAtIndex(j);
					return;
				}
				flag &= ValidatePrototype(j);
			}
			if (!flag && Application.isPlaying && !_loggedPrototypeValidationError)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "There are errors with the prototype setup, please check the prototypes on " + GPUIUtility.CamelToTitleCase(GetType().Name) + " for further information.", base.gameObject);
				_loggedPrototypeValidationError = true;
			}
		}

		public virtual int AddPrototype(GPUIPrototype prototype)
		{
			if (!prototype.IsValid(logError: true))
			{
				return -1;
			}
			if (_prototypes != null && _prototypes.Contains(prototype))
			{
				return -1;
			}
			int num = _prototypes.Length;
			Array.Resize(ref _prototypes, num + 1);
			_prototypes[num] = prototype;
			CheckPrototypeChanges();
			prototype.GenerateBillboard(forceNew: false);
			if (IsInitialized)
			{
				RegisterRenderer(num);
			}
			return num;
		}

		public int AddPrototype(GameObject prefab)
		{
			return AddPrototype(new GPUIPrototype(prefab, GetDefaultProfile(prefab)));
		}

		public virtual void RemovePrototypeAtIndex(int index)
		{
			if (IsInitialized)
			{
				DisposeRenderer(index);
				_runtimeRenderKeys = _runtimeRenderKeys.RemoveAtAndReturn(index);
			}
			_prototypes = _prototypes.RemoveAtAndReturn(index);
			CheckPrototypeChanges();
		}

		public virtual void RemoveAllPrototypes()
		{
			if (IsInitialized)
			{
				DisposeAllRenderers();
				_runtimeRenderKeys = new int[0];
			}
			_prototypes = new GPUIPrototype[0];
			CheckPrototypeChanges();
		}

		public virtual bool CanAddObjectAsPrototype(UnityEngine.Object obj)
		{
			if (obj is GameObject gameObject)
			{
				for (int i = 0; i < _prototypes.Length; i++)
				{
					if (_prototypes[i].prefabObject == gameObject)
					{
						return false;
					}
				}
				return true;
			}
			if (obj is GPUILODGroupData gPUILODGroupData)
			{
				for (int j = 0; j < _prototypes.Length; j++)
				{
					if (_prototypes[j].gpuiLODGroupData == gPUILODGroupData)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public int GetPrototypeCount()
		{
			if (_prototypes == null)
			{
				return 0;
			}
			return _prototypes.Length;
		}

		public GPUIPrototype GetPrototype(int index)
		{
			if (_prototypes == null || _prototypes.Length <= index)
			{
				return null;
			}
			return _prototypes[index];
		}

		public virtual GPUIPrototypeData GetPrototypeDataGeneric(int prototypeIndex)
		{
			return null;
		}

		public virtual void OnPrototypePropertiesModified()
		{
		}

		public virtual int GetRegisteredInstanceCount(int prototypeIndex)
		{
			if (!IsInitialized || prototypeIndex < 0 || _runtimeRenderKeys == null || prototypeIndex >= _runtimeRenderKeys.Length)
			{
				return 0;
			}
			if (GPUIRenderingSystem.TryGetRenderSource(_runtimeRenderKeys[prototypeIndex], out var renderSource))
			{
				return renderSource.instanceCount;
			}
			return 0;
		}

		public virtual void AddDependentJob(JobHandle jobHandle)
		{
			_dependentJob = JobHandle.CombineDependencies(_dependentJob, jobHandle);
		}
	}
}
