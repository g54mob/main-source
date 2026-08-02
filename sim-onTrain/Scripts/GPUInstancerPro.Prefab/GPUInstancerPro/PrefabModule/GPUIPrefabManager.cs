using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace GPUInstancerPro.PrefabModule
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(100)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#The_Prefab_Manager")]
	public class GPUIPrefabManager : GPUIManagerWithPrototypeData<GPUIPrefabPrototypeData>
	{
		[SerializeField]
		public bool isFindInstancesAtInitialization = true;

		private static readonly Type[] _rendererTypes = new Type[2]
		{
			typeof(MeshRenderer),
			typeof(BillboardRenderer)
		};

		private const int BUFFER_SIZE_INCREMENT = 128;

		private const int TRANSFORM_UPDATE_JOB_BATCH_SIZE = 32;

		private static List<GPUIPrefab> _instancesToAdd;

		private Predicate<GPUIPrefab> _isNullOrInstancedPredicate;

		private NativeArray<JobHandle> _jobHandles;

		private List<int> _prefabIDCheckList;

		private static readonly List<string> MATERIAL_VARIATION_SHADER_KEYWORDS = new List<string> { GPUIPrefabConstants.Kw_GPUI_MATERIAL_VARIATION };

		private static readonly Matrix4x4 ZERO_MATRIX = Matrix4x4.zero;

		protected override void OnEnable()
		{
			_isNullOrInstancedPredicate = IsPrefabNullOrInstanced;
			base.OnEnable();
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (!GPUIRenderingSystem.IsActive || !base.IsInitialized)
			{
				return;
			}
			_dependentJob.Complete();
			int num = 0;
			if (_instancesToAdd != null && _instancesToAdd.Count > 0)
			{
				_instancesToAdd.RemoveAll(_isNullOrInstancedPredicate);
				num = _instancesToAdd.Count;
			}
			for (int i = 0; i < _prototypeDataArray.Length; i++)
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[i];
				if (!gPUIPrefabPrototypeData.IsInitialized)
				{
					continue;
				}
				gPUIPrefabPrototypeData.instancesToAdd.RemoveAll(_isNullOrInstancedPredicate);
				if (num > 0)
				{
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						GPUIPrefab gPUIPrefab = _instancesToAdd[num2];
						if (gPUIPrefab.GetPrefabID() == gPUIPrefabPrototypeData.prefabID)
						{
							gPUIPrefabPrototypeData.instancesToAdd.Add(gPUIPrefab);
							_instancesToAdd.RemoveAtSwapBack(num2);
							num--;
						}
					}
				}
				int count = gPUIPrefabPrototypeData.indexesToRemove.Count;
				int count2 = gPUIPrefabPrototypeData.instancesToAdd.Count;
				int num3 = gPUIPrefabPrototypeData.instanceCount - 1;
				if (count > 0)
				{
					foreach (int item in gPUIPrefabPrototypeData.indexesToRemove)
					{
						Transform transform = gPUIPrefabPrototypeData.instanceTransforms[item];
						if (transform != null && transform.TryGetComponent<GPUIPrefab>(out var component))
						{
							ClearInstancingData(component, enableRenderers: false);
						}
						if (num3 != item)
						{
							gPUIPrefabPrototypeData.matrixArray[item] = gPUIPrefabPrototypeData.matrixArray[num3];
							Transform transform2 = gPUIPrefabPrototypeData.instanceTransforms[num3];
							if ((bool)transform2)
							{
								GPUIPrefab component2 = transform2.GetComponent<GPUIPrefab>();
								gPUIPrefabPrototypeData.instanceTransforms[item] = transform2;
								component2.SetBufferIndex(item);
							}
						}
						gPUIPrefabPrototypeData.matrixArray[num3] = ZERO_MATRIX;
						num3--;
					}
					gPUIPrefabPrototypeData.indexesToRemove.Clear();
					gPUIPrefabPrototypeData.instanceCount = num3 + 1;
					gPUIPrefabPrototypeData.isMatrixArrayModified = true;
					gPUIPrefabPrototypeData.isTransformReferencesModified = true;
					if (count2 == 0 && gPUIPrefabPrototypeData.instanceCount < gPUIPrefabPrototypeData.matrixArray.Length - 256)
					{
						ResizeArrays(i, (gPUIPrefabPrototypeData.instanceCount / 128 + 1) * 128);
					}
				}
				if (count2 <= 0)
				{
					continue;
				}
				int num4 = gPUIPrefabPrototypeData.instanceCount + count2;
				if (num4 > gPUIPrefabPrototypeData.matrixArray.Length)
				{
					ResizeArrays(i, (num4 / 128 + 1) * 128);
				}
				for (int j = 0; j < count2; j++)
				{
					GPUIPrefab gPUIPrefab2 = gPUIPrefabPrototypeData.instancesToAdd[j];
					if (!gPUIPrefab2.IsInstanced)
					{
						num3++;
						SetupPrefabInstanceForInstancing(gPUIPrefab2, i, num3);
					}
				}
				gPUIPrefabPrototypeData.instancesToAdd.Clear();
				gPUIPrefabPrototypeData.instanceCount = num3 + 1;
				gPUIPrefabPrototypeData.isMatrixArrayModified = true;
				gPUIPrefabPrototypeData.isTransformReferencesModified = true;
			}
			StartAutoUpdateTransformJobs();
		}

		public override void Initialize()
		{
			base.Initialize();
			if (!GPUIRenderingSystem.IsActive || !base.IsInitialized)
			{
				return;
			}
			Dictionary<int, List<GPUIPrefab>> dictionary = new Dictionary<int, List<GPUIPrefab>>();
			for (int i = 0; i < _prototypes.Length; i++)
			{
				List<GPUIPrefab> list = new List<GPUIPrefab>();
				int prefabID = GetPrefabID(i);
				if (dictionary.ContainsKey(prefabID))
				{
					Debug.LogError("There are multiple prototypes with the same prefab ID: " + prefabID, this);
					continue;
				}
				dictionary.Add(prefabID, list);
				if (isFindInstancesAtInitialization || _prototypeDataArray[i].GetRegisteredInstanceCount() <= 0)
				{
					continue;
				}
				GameObject[] prefabInstances = _prototypeDataArray[i].registeredInstances.prefabInstances;
				foreach (GameObject gameObject in prefabInstances)
				{
					if (gameObject != null && gameObject.TryGetComponent<GPUIPrefab>(out var component) && !component.IsInstanced)
					{
						list.Add(component);
					}
				}
			}
			if (isFindInstancesAtInitialization)
			{
				GPUIPrefab[] array = UnityEngine.Object.FindObjectsByType<GPUIPrefab>(FindObjectsSortMode.None);
				foreach (GPUIPrefab gPUIPrefab in array)
				{
					if (!gPUIPrefab.IsInstanced)
					{
						int prefabID2 = gPUIPrefab.GetPrefabID();
						if (prefabID2 != 0 && dictionary.TryGetValue(prefabID2, out var value))
						{
							value.Add(gPUIPrefab);
						}
					}
				}
			}
			for (int k = 0; k < _prototypes.Length; k++)
			{
				GPUIPrototype gPUIPrototype = _prototypes[k];
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[k];
				if (!gPUIPrototype.isEnabled || !gPUIPrefabPrototypeData.IsInitialized)
				{
					continue;
				}
				if (gPUIPrototype.prefabObject == null)
				{
					Debug.LogError("Prefab object reference is not set on the prototype: " + gPUIPrototype, this);
					continue;
				}
				List<GPUIPrefab> list2 = dictionary[GetPrefabID(k)];
				if (list2.Count > 0)
				{
					AddPrefabInstances(list2, k);
				}
			}
			GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(ApplyTransformBufferChanges);
			GPUIRenderingSystem.Instance.OnPreCull.AddListener(ApplyTransformBufferChanges);
			GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(GPUIMaterialVariationDataProvider.Instance.UpdateVariationBuffers);
			GPUIRenderingSystem.Instance.OnPreCull.AddListener(GPUIMaterialVariationDataProvider.Instance.UpdateVariationBuffers);
		}

		public override void Dispose()
		{
			base.Dispose();
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(ApplyTransformBufferChanges);
				GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(GPUIMaterialVariationDataProvider.Instance.UpdateVariationBuffers);
			}
			if (_jobHandles.IsCreated)
			{
				_jobHandles.Dispose();
			}
		}

		private void StartAutoUpdateTransformJobs()
		{
			if (!_jobHandles.IsCreated)
			{
				_jobHandles = new NativeArray<JobHandle>(_prototypes.Length, Allocator.Persistent);
			}
			else if (_jobHandles.Length != _prototypes.Length)
			{
				_jobHandles.Dispose();
				_jobHandles = new NativeArray<JobHandle>(_prototypes.Length, Allocator.Persistent);
			}
			for (int i = 0; i < _prototypeDataArray.Length; i++)
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[i];
				if (!gPUIPrefabPrototypeData.IsInitialized || !gPUIPrefabPrototypeData.isAutoUpdateTransformData || !gPUIPrefabPrototypeData.matrixArray.IsCreated || gPUIPrefabPrototypeData.instanceTransforms == null || gPUIPrefabPrototypeData.instanceCount <= 0)
				{
					continue;
				}
				if (gPUIPrefabPrototypeData.isTransformReferencesModified)
				{
					if (gPUIPrefabPrototypeData.transformAccessArray.isCreated)
					{
						if (gPUIPrefabPrototypeData.instanceTransforms.Length != gPUIPrefabPrototypeData.transformAccessArray.length)
						{
							gPUIPrefabPrototypeData.transformAccessArray.Dispose();
							TransformAccessArray.Allocate(gPUIPrefabPrototypeData.instanceTransforms.Length, -1, out gPUIPrefabPrototypeData.transformAccessArray);
						}
					}
					else
					{
						TransformAccessArray.Allocate(gPUIPrefabPrototypeData.instanceTransforms.Length, -1, out gPUIPrefabPrototypeData.transformAccessArray);
					}
					gPUIPrefabPrototypeData.transformAccessArray.SetTransforms(gPUIPrefabPrototypeData.instanceTransforms);
					gPUIPrefabPrototypeData.isTransformReferencesModified = false;
				}
				_jobHandles[i] = new GPUIAutoUpdateTransformsJob
				{
					instanceCount = gPUIPrefabPrototypeData.instanceCount,
					zeroMatrix = ZERO_MATRIX,
					instanceDataNativeArray = gPUIPrefabPrototypeData.matrixArray
				}.ScheduleReadOnly(gPUIPrefabPrototypeData.transformAccessArray, 32);
				gPUIPrefabPrototypeData.isMatrixArrayModified = true;
			}
			_dependentJob = JobHandle.CombineDependencies(_jobHandles);
		}

		private void ApplyTransformBufferChanges(GPUICameraData cameraData)
		{
			_dependentJob.Complete();
			for (int i = 0; i < _prototypeDataArray.Length; i++)
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[i];
				if (gPUIPrefabPrototypeData.IsInitialized && gPUIPrefabPrototypeData.isMatrixArrayModified && gPUIPrefabPrototypeData.matrixArray.IsCreated)
				{
					int renderKey = _runtimeRenderKeys[i];
					GPUIRenderingSystem.SetBufferSize(renderKey, gPUIPrefabPrototypeData.matrixArray.Length, isCopyPreviousData: false);
					GPUIRenderingSystem.SetTransformBufferData(renderKey, gPUIPrefabPrototypeData.matrixArray, 0, 0, gPUIPrefabPrototypeData.instanceCount, isOverwritePreviousFrameBuffer: false);
					GPUIRenderingSystem.SetInstanceCount(renderKey, gPUIPrefabPrototypeData.instanceCount);
					gPUIPrefabPrototypeData.isMatrixArrayModified = false;
				}
			}
		}

		private bool IsPrefabNullOrInstanced(GPUIPrefab p)
		{
			if (!(p == null))
			{
				return p.IsInstanced;
			}
			return true;
		}

		protected override void OnPrototypeEnabled(int prototypeIndex)
		{
			base.OnPrototypeEnabled(prototypeIndex);
			List<GPUIPrefab> list = new List<GPUIPrefab>();
			if (!isFindInstancesAtInitialization && _prototypeDataArray[prototypeIndex].GetRegisteredInstanceCount() > 0)
			{
				GameObject[] prefabInstances = _prototypeDataArray[prototypeIndex].registeredInstances.prefabInstances;
				foreach (GameObject gameObject in prefabInstances)
				{
					if (gameObject != null && gameObject.TryGetComponent<GPUIPrefab>(out var component) && !component.IsInstanced)
					{
						list.Add(component);
					}
				}
			}
			else
			{
				GPUIPrefab[] array = UnityEngine.Object.FindObjectsByType<GPUIPrefab>(FindObjectsSortMode.None);
				int prefabID = GetPrefabID(prototypeIndex);
				GPUIPrefab[] array2 = array;
				foreach (GPUIPrefab gPUIPrefab in array2)
				{
					if (!gPUIPrefab.IsInstanced && prefabID == gPUIPrefab.GetPrefabID())
					{
						list.Add(gPUIPrefab);
					}
				}
			}
			if (list.Count > 0)
			{
				AddPrefabInstances(list, prototypeIndex);
			}
		}

		protected override void DisposeRenderer(int prototypeIndex)
		{
			if (_prototypeDataArray == null)
			{
				return;
			}
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			if (gPUIPrefabPrototypeData == null || !gPUIPrefabPrototypeData.IsInitialized)
			{
				return;
			}
			if (_prototypes[prototypeIndex].prefabObject != null && gPUIPrefabPrototypeData.instanceTransforms != null)
			{
				if (!isFindInstancesAtInitialization)
				{
					gPUIPrefabPrototypeData.registeredInstances = new GPUIPrefabPrototypeData.GPUIPrefabInstances
					{
						prefabInstances = new GameObject[gPUIPrefabPrototypeData.instanceTransforms.Length]
					};
				}
				for (int i = 0; i < gPUIPrefabPrototypeData.instanceTransforms.Length; i++)
				{
					Transform transform = gPUIPrefabPrototypeData.instanceTransforms[i];
					if (transform != null && transform.TryGetComponent<GPUIPrefab>(out var component))
					{
						ClearInstancingData(component, isEnableDefaultRenderingWhenDisabled);
						if (!isFindInstancesAtInitialization)
						{
							gPUIPrefabPrototypeData.registeredInstances.prefabInstances[i] = component.gameObject;
						}
					}
				}
			}
			base.DisposeRenderer(prototypeIndex);
		}

		protected override void ClearNullPrototypes()
		{
			base.ClearNullPrototypes();
		}

		public override void RemovePrototypeAtIndex(int index)
		{
			base.RemovePrototypeAtIndex(index);
		}

		public override bool CanAddObjectAsPrototype(UnityEngine.Object obj)
		{
			if (base.CanAddObjectAsPrototype(obj))
			{
				return true;
			}
			return false;
		}

		public override Type[] GetPrefabRendererTypes()
		{
			return _rendererTypes;
		}

		public void UpdateTransformData()
		{
			for (int i = 0; i < _prototypeDataArray.Length; i++)
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[i];
				if (gPUIPrefabPrototypeData.IsInitialized)
				{
					gPUIPrefabPrototypeData.isMatrixArrayModified = true;
				}
			}
		}

		public void UpdateTransformData(int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex >= _prototypeDataArray.Length)
			{
				Debug.Log("Invalid prototype index: " + prototypeIndex + ". Current number of prototypes: " + _prototypeDataArray.Length, this);
				return;
			}
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			if (gPUIPrefabPrototypeData.IsInitialized)
			{
				gPUIPrefabPrototypeData.isMatrixArrayModified = true;
			}
		}

		protected virtual void ClearInstancingData(GPUIPrefab gpuiPrefab, bool enableRenderers)
		{
			gpuiPrefab.ClearInstancingData(enableRenderers, GetPrefabRendererTypes());
		}

		public int GetPrototypeIndex(GPUIPrefab gpuiPrefab)
		{
			int prefabID = gpuiPrefab.GetPrefabID();
			if (prefabID != 0)
			{
				if (base.IsInitialized)
				{
					for (int i = 0; i < _prototypes.Length; i++)
					{
						if (_prototypeDataArray[i].prefabID == prefabID)
						{
							return i;
						}
					}
				}
				else
				{
					for (int j = 0; j < _prototypes.Length; j++)
					{
						if (_prototypes[j].prefabObject.GetComponent<GPUIPrefab>().GetPrefabID() == prefabID)
						{
							return j;
						}
					}
				}
			}
			return -1;
		}

		public static void AddPrefabInstance(GPUIPrefab gpuiPrefab)
		{
			if (gpuiPrefab == null)
			{
				Debug.LogError("Can not add prefab instance! Given prefab is null.");
			}
			else
			{
				if (gpuiPrefab.IsInstanced)
				{
					return;
				}
				if (gpuiPrefab.GetPrefabID() == 0)
				{
					Debug.LogError("Can not add prefab instance. Unknown prefab ID! Make sure the prefab ID is not overridden or use the AddPrefabInstance(GPUIPrefab gpuiPrefab, int prototypeIndex) method with the prototypeIndex parameter.", gpuiPrefab.gameObject);
					return;
				}
				if (_instancesToAdd == null)
				{
					_instancesToAdd = new List<GPUIPrefab>();
				}
				_instancesToAdd.Add(gpuiPrefab);
			}
		}

		public static void AddPrefabInstances(IEnumerable<GPUIPrefab> gpuiPrefabs)
		{
			if (gpuiPrefabs != null)
			{
				if (_instancesToAdd == null)
				{
					_instancesToAdd = new List<GPUIPrefab>();
				}
				_instancesToAdd.AddRange(gpuiPrefabs);
			}
		}

		public bool AddPrefabInstances(IEnumerable<GPUIPrefab> instances, int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				Debug.LogError("Invalid prototype index: " + prototypeIndex, base.gameObject);
				return false;
			}
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			if (gPUIPrefabPrototypeData == null || !gPUIPrefabPrototypeData.IsInitialized)
			{
				Debug.LogError("Can not find runtime data at index: " + prototypeIndex, base.gameObject);
				return false;
			}
			gPUIPrefabPrototypeData.instancesToAdd.AddRange(instances);
			return true;
		}

		public bool AddPrefabInstance(GameObject go, int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				Debug.LogError("Can not find prototype at index " + prototypeIndex + " for: " + go, go);
				return false;
			}
			return AddPrefabInstance(go.AddOrGetComponent<GPUIPrefab>(), prototypeIndex);
		}

		public void AddPrefabInstances(IEnumerable<GameObject> instances, int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				Debug.LogError("Can not find prototype at index " + prototypeIndex + ".");
				return;
			}
			foreach (GameObject instance in instances)
			{
				AddPrefabInstance(instance.AddOrGetComponent<GPUIPrefab>(), prototypeIndex);
			}
		}

		public bool AddPrefabInstance(GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			if (gpuiPrefab == null)
			{
				Debug.LogError("Can not add prefab instance! Given prefab is null.");
				return false;
			}
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				prototypeIndex = GetPrototypeIndex(gpuiPrefab);
				if (prototypeIndex < 0)
				{
					Debug.LogError("Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
					return false;
				}
			}
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			if (gPUIPrefabPrototypeData == null || !gPUIPrefabPrototypeData.IsInitialized)
			{
				Debug.LogError("Can not find runtime data for: " + gpuiPrefab, gpuiPrefab);
				return false;
			}
			if (!gpuiPrefab.IsInstanced)
			{
				gPUIPrefabPrototypeData.instancesToAdd.Add(gpuiPrefab);
			}
			return true;
		}

		public int AddPrefabInstanceImmediate(GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			if (prototypeIndex < 0)
			{
				prototypeIndex = GetPrototypeIndex(gpuiPrefab);
				if (prototypeIndex < 0)
				{
					Debug.LogError("Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
					return -1;
				}
			}
			_dependentJob.Complete();
			GPUIPrefabPrototypeData obj = _prototypeDataArray[prototypeIndex];
			int length = obj.matrixArray.Length;
			ResizeArrays(prototypeIndex, length + 1);
			SetupPrefabInstanceForInstancing(gpuiPrefab, prototypeIndex, length);
			obj.isTransformReferencesModified = true;
			obj.isMatrixArrayModified = true;
			obj.instanceCount++;
			return length;
		}

		public bool RemovePrefabInstance(GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			if (!gpuiPrefab.IsInstanced)
			{
				return true;
			}
			if (prototypeIndex < 0)
			{
				prototypeIndex = GetPrototypeIndex(gpuiPrefab);
				if (prototypeIndex < 0)
				{
					Debug.LogError("Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
					return false;
				}
			}
			if (_prototypeDataArray == null || _prototypeDataArray.Length <= prototypeIndex)
			{
				Debug.LogError("Can not find runtime data at index: " + prototypeIndex, gpuiPrefab);
				return false;
			}
			_prototypeDataArray[prototypeIndex].indexesToRemove.Add(gpuiPrefab.bufferIndex);
			return true;
		}

		public void UpdateTransformData(GPUIPrefab gpuiPrefab)
		{
			int num = ((!gpuiPrefab.IsInstanced) ? GetPrototypeIndex(gpuiPrefab) : GetPrototypeIndex(gpuiPrefab.renderKey));
			if (num < 0)
			{
				Debug.LogError("Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
				return;
			}
			if (_prototypeDataArray == null || _prototypeDataArray.Length <= num)
			{
				Debug.LogError("Can not find runtime data at index: " + num, gpuiPrefab);
				return;
			}
			_dependentJob.Complete();
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[num];
			if (!gPUIPrefabPrototypeData.isAutoUpdateTransformData && gPUIPrefabPrototypeData.matrixArray.IsCreated && gPUIPrefabPrototypeData.matrixArray.Length > gpuiPrefab.bufferIndex)
			{
				gPUIPrefabPrototypeData.isMatrixArrayModified = true;
				Transform cachedTransform = gpuiPrefab.CachedTransform;
				gPUIPrefabPrototypeData.matrixArray[gpuiPrefab.bufferIndex] = cachedTransform.localToWorldMatrix;
				cachedTransform.hasChanged = false;
			}
		}

		public virtual void SetupPrefabInstanceForInstancing(GPUIPrefab gpuiPrefab, int prototypeIndex, int bufferIndex)
		{
			gpuiPrefab.Initialize();
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			Transform cachedTransform = gpuiPrefab.CachedTransform;
			if (!gPUIPrefabPrototypeData.isAutoUpdateTransformData)
			{
				gPUIPrefabPrototypeData.matrixArray[bufferIndex] = cachedTransform.localToWorldMatrix;
			}
			gPUIPrefabPrototypeData.instanceTransforms[bufferIndex] = cachedTransform;
			cachedTransform.hasChanged = false;
			gpuiPrefab.SetInstancingData(this, gPUIPrefabPrototypeData.prefabID, _runtimeRenderKeys[prototypeIndex], bufferIndex, GetPrefabRendererTypes());
		}

		protected virtual void ResizeArrays(int prototypeIndex, int newSize)
		{
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			GPUIUtility.ResizeNativeArray(ref gPUIPrefabPrototypeData.matrixArray, newSize, Allocator.Persistent);
			gPUIPrefabPrototypeData.isMatrixArrayModified = true;
			if (gPUIPrefabPrototypeData.instanceTransforms == null)
			{
				gPUIPrefabPrototypeData.instanceTransforms = new Transform[newSize];
			}
			else
			{
				Array.Resize(ref gPUIPrefabPrototypeData.instanceTransforms, newSize);
			}
			gPUIPrefabPrototypeData.isTransformReferencesModified = true;
		}

		public int GetPrefabID(int prototypeIndex)
		{
			return GetPrefabID(_prototypes[prototypeIndex]);
		}

		internal static int GetPrefabID(GPUIPrototype prototype)
		{
			if (prototype.prefabObject.TryGetComponent<GPUIPrefab>(out var component))
			{
				return component.GetPrefabID();
			}
			return prototype.GetKey();
		}

		public override int GetRegisteredInstanceCount(int prototypeIndex)
		{
			if (!Application.isPlaying && !isFindInstancesAtInitialization && _prototypeDataArray != null && _prototypeDataArray.Length > prototypeIndex && _prototypeDataArray[prototypeIndex] != null && _prototypeDataArray[prototypeIndex].registeredInstances != null && _prototypeDataArray[prototypeIndex].registeredInstances.prefabInstances != null)
			{
				return _prototypeDataArray[prototypeIndex].registeredInstances.prefabInstances.Length;
			}
			return base.GetRegisteredInstanceCount(prototypeIndex);
		}

		public override List<string> GetShaderKeywords(int prototypeIndex)
		{
			if (_prototypes[prototypeIndex].prefabObject.HasComponent<GPUIMaterialVariationInstance>())
			{
				return MATERIAL_VARIATION_SHADER_KEYWORDS;
			}
			return base.GetShaderKeywords(prototypeIndex);
		}
	}
}
