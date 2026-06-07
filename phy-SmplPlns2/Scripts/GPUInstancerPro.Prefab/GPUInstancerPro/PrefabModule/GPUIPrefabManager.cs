using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace GPUInstancerPro.PrefabModule
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(100)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#The_Prefab_Manager")]
	public class GPUIPrefabManager : GPUIManagerWithPrototypeData<GPUIPrefabPrototypeData>, IGPUIInstanceTransformProvider
	{
		[SerializeField]
		public bool isFindInstancesAtInitialization = true;

		private const int BUFFER_SIZE_INCREMENT = 128;

		private const int TRANSFORM_UPDATE_JOB_BATCH_SIZE = 32;

		private static List<GPUIPrefab> _instancesToAdd;

		private Predicate<GPUIPrefab> _isNullOrInstancedPredicate;

		private NativeArray<JobHandle> _jobHandles;

		private List<int> _prefabIDCheckList;

		private static readonly List<string> MATERIAL_VARIATION_SHADER_KEYWORDS = new List<string> { GPUIPrefabConstants.Kw_GPUI_MATERIAL_VARIATION };

		private static readonly Matrix4x4 ZERO_MATRIX = Matrix4x4.zero;

		[NonSerialized]
		private bool _requireTransformUpdate;

		protected override void OnEnable()
		{
			_isNullOrInstancedPredicate = IsPrefabNullOrInstanced;
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (GPUIRenderingSystem.IsActive && base.IsInitialized)
			{
				AddRemoveInstances();
				StartAutoUpdateTransformJobs();
			}
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
					Debug.LogError(GPUIConstants.LOG_PREFIX + "There are multiple prototypes with the same prefab ID: " + prefabID, this);
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
						component._isBeingAddedToThePrefabManager = true;
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
						if (prefabID2 != 0 && dictionary.TryGetValue(prefabID2, out var value) && !gPUIPrefab._isBeingAddedToThePrefabManager)
						{
							value.Add(gPUIPrefab);
							gPUIPrefab._isBeingAddedToThePrefabManager = true;
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
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Prefab object reference is not set on the prototype: " + gPUIPrototype, this);
					continue;
				}
				List<GPUIPrefab> list2 = dictionary[GetPrefabID(k)];
				if (list2.Count > 0)
				{
					AddPrefabInstances(list2, k);
				}
			}
			GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
			instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(ApplyTransformBufferChanges));
			GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
			instance2.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance2.OnPreCull, new Action<GPUICameraData>(GPUIMaterialVariationDataProvider.Instance.UpdateVariationBuffers));
			GPUIRenderingSystem instance3 = GPUIRenderingSystem.Instance;
			instance3.OnPreCull = (Action<GPUICameraData>)Delegate.Combine(instance3.OnPreCull, new Action<GPUICameraData>(ApplyTransformBufferChanges));
			GPUIRenderingSystem instance4 = GPUIRenderingSystem.Instance;
			instance4.OnPreCull = (Action<GPUICameraData>)Delegate.Combine(instance4.OnPreCull, new Action<GPUICameraData>(GPUIMaterialVariationDataProvider.Instance.UpdateVariationBuffers));
		}

		public override void Dispose()
		{
			base.Dispose();
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
				instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(ApplyTransformBufferChanges));
				GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
				instance2.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance2.OnPreCull, new Action<GPUICameraData>(GPUIMaterialVariationDataProvider.Instance.UpdateVariationBuffers));
			}
			if (_jobHandles.IsCreated)
			{
				_jobHandles.Dispose();
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
						component._isBeingAddedToThePrefabManager = true;
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
						gPUIPrefab._isBeingAddedToThePrefabManager = true;
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

		private unsafe void StartAutoUpdateTransformJobs()
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
				if (gPUIPrefabPrototypeData.IsInitialized && (_requireTransformUpdate || gPUIPrefabPrototypeData.isAutoUpdateTransformData) && gPUIPrefabPrototypeData.HasMatrixArray() && gPUIPrefabPrototypeData.instanceTransforms != null && gPUIPrefabPrototypeData.instanceCount > 0)
				{
					gPUIPrefabPrototypeData.UpdateTransformAccessArray();
					gPUIPrefabPrototypeData.autoUpdateTransformsJob.instanceCount = gPUIPrefabPrototypeData.instanceCount;
					gPUIPrefabPrototypeData.autoUpdateTransformsJob.zeroMatrix = ZERO_MATRIX;
					gPUIPrefabPrototypeData.autoUpdateTransformsJob.p_matrixArray = gPUIPrefabPrototypeData.GetMatrixArrayUnsafePtr();
					gPUIPrefabPrototypeData.autoUpdateTransformsJob.p_isModifiedArray = gPUIPrefabPrototypeData.isModifiedArray.GetUnsafePtr();
					_jobHandles[i] = gPUIPrefabPrototypeData.autoUpdateTransformsJob.ScheduleReadOnly(gPUIPrefabPrototypeData.transformAccessArray, 32);
					gPUIPrefabPrototypeData.isMatrixArrayModified = true;
					if (gPUIPrefabPrototypeData._isAutoUpdateTransformJobsStarted)
					{
						gPUIPrefabPrototypeData.SetAllMatricesModified();
					}
					else
					{
						gPUIPrefabPrototypeData._isAutoUpdateTransformJobsStarted = true;
					}
				}
			}
			_requireTransformUpdate = false;
			_dependentJob = JobHandle.CombineDependencies(_jobHandles);
		}

		private unsafe void ApplyTransformBufferChanges()
		{
			_dependentJob.Complete();
			for (int i = 0; i < _prototypeDataArray.Length; i++)
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[i];
				gPUIPrefabPrototypeData._isAutoUpdateTransformJobsStarted = false;
				if (!gPUIPrefabPrototypeData.IsInitialized)
				{
					continue;
				}
				if (gPUIPrefabPrototypeData.isMatrixArrayModified && gPUIPrefabPrototypeData.HasMatrixArray())
				{
					int num = gPUIPrefabPrototypeData.minModifiedIndex;
					int num2 = gPUIPrefabPrototypeData.maxModifiedIndex;
					bool flag = num == 0 && num2 >= gPUIPrefabPrototypeData.instanceCount - 1;
					if (gPUIPrefabPrototypeData.isAutoUpdateTransformData && gPUIPrefabPrototypeData.instanceCount > 0 && !flag)
					{
						void* unsafePtr = gPUIPrefabPrototypeData.isModifiedArray.GetUnsafePtr();
						for (int j = 0; j < gPUIPrefabPrototypeData.instanceCount; j++)
						{
							if (UnsafeUtility.ReadArrayElementWithStride<int>(unsafePtr, j, 4) != 0)
							{
								if (num > j)
								{
									num = j;
								}
								if (num2 < j)
								{
									num2 = j;
								}
							}
						}
					}
					num = Mathf.Max(0, num);
					num2 = Mathf.Min(gPUIPrefabPrototypeData.instanceCount - 1, num2);
					flag = num == 0 && num2 == gPUIPrefabPrototypeData.instanceCount - 1;
					int renderKey = _runtimeRenderKeys[i];
					GPUIRenderingSystem.SetBufferSize(renderKey, gPUIPrefabPrototypeData.GetMatrixLength(), !flag || num > num2);
					if (num <= num2)
					{
						GPUIRenderingSystem.SetTransformBufferData(renderKey, gPUIPrefabPrototypeData.GetTransformationMatrixArray(), num, num, num2 - num + 1, isOverwritePreviousFrameBuffer: false);
					}
					GPUIRenderingSystem.SetInstanceCount(renderKey, gPUIPrefabPrototypeData.instanceCount);
					gPUIPrefabPrototypeData.isMatrixArrayModified = false;
					gPUIPrefabPrototypeData.minModifiedIndex = int.MaxValue;
					gPUIPrefabPrototypeData.maxModifiedIndex = -1;
				}
				if (gPUIPrefabPrototypeData.hasOptionalRenderers && gPUIPrefabPrototypeData.isOptionalRendererStatusModified && gPUIPrefabPrototypeData.optionalRendererStatusData.IsCreated)
				{
					GPUIRenderingSystem.Instance.SetOptionalRendererStatusData(_runtimeRenderKeys[i], gPUIPrefabPrototypeData.optionalRendererStatusData);
					gPUIPrefabPrototypeData.isOptionalRendererStatusModified = false;
				}
			}
		}

		private void ApplyTransformBufferChanges(GPUICameraData cameraData)
		{
			ApplyTransformBufferChanges();
		}

		private void AddRemoveInstances()
		{
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
							gPUIPrefabPrototypeData.SetMatrix(item, gPUIPrefabPrototypeData.GetMatrix(num3));
							Transform transform2 = gPUIPrefabPrototypeData.instanceTransforms[num3];
							if ((bool)transform2)
							{
								GPUIPrefab component2 = transform2.GetComponent<GPUIPrefab>();
								gPUIPrefabPrototypeData.instanceTransforms[item] = transform2;
								component2.SetBufferIndex(item);
								if (gPUIPrefabPrototypeData.hasOptionalRenderers)
								{
									gPUIPrefabPrototypeData.optionalRendererStatusData[item] = component2.optionalRendererStatus;
								}
							}
						}
						gPUIPrefabPrototypeData.SetMatrix(num3, ZERO_MATRIX);
						num3--;
					}
					gPUIPrefabPrototypeData.indexesToRemove.Clear();
					gPUIPrefabPrototypeData.instanceCount = num3 + 1;
					gPUIPrefabPrototypeData.isMatrixArrayModified = true;
					gPUIPrefabPrototypeData.isTransformReferencesModified = true;
					gPUIPrefabPrototypeData.isOptionalRendererStatusModified = true;
					if (count2 == 0 && gPUIPrefabPrototypeData.instanceCount < gPUIPrefabPrototypeData.GetMatrixLength() - 256)
					{
						ResizeArrays(i, (gPUIPrefabPrototypeData.instanceCount / 128 + 1) * 128);
					}
				}
				if (count2 <= 0)
				{
					continue;
				}
				int num4 = gPUIPrefabPrototypeData.instanceCount + count2;
				if (num4 > gPUIPrefabPrototypeData.GetMatrixLength())
				{
					ResizeArrays(i, (num4 / 128 + 1) * 128);
				}
				for (int j = 0; j < count2; j++)
				{
					GPUIPrefab gPUIPrefab2 = gPUIPrefabPrototypeData.instancesToAdd[j];
					if (!gPUIPrefab2.IsInstanced && gPUIPrefab2.enabled)
					{
						num3++;
						SetupPrefabInstanceForInstancing(gPUIPrefab2, i, num3);
					}
				}
				gPUIPrefabPrototypeData.instancesToAdd.Clear();
				gPUIPrefabPrototypeData.instanceCount = num3 + 1;
				gPUIPrefabPrototypeData.isMatrixArrayModified = true;
				gPUIPrefabPrototypeData.isTransformReferencesModified = true;
				gPUIPrefabPrototypeData.isOptionalRendererStatusModified = true;
			}
		}

		public void UpdateTransformData()
		{
			for (int i = 0; i < _prototypeDataArray.Length; i++)
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[i];
				if (gPUIPrefabPrototypeData.IsInitialized)
				{
					gPUIPrefabPrototypeData.SetAllMatricesModified();
				}
			}
		}

		public void UpdateTransformData(int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex >= _prototypeDataArray.Length)
			{
				Debug.Log(GPUIConstants.LOG_PREFIX + "Invalid prototype index: " + prototypeIndex + ". Current number of prototypes: " + _prototypeDataArray.Length, this);
			}
			else
			{
				GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
				if (gPUIPrefabPrototypeData.IsInitialized)
				{
					gPUIPrefabPrototypeData.SetAllMatricesModified();
				}
			}
		}

		protected virtual void ClearInstancingData(GPUIPrefab gpuiPrefab, bool enableRenderers)
		{
			gpuiPrefab.ClearInstancingData(enableRenderers);
		}

		public int GetPrototypeIndex(GPUIPrefab gpuiPrefab)
		{
			return GetPrototypeIndexWithPrefabID(gpuiPrefab.GetPrefabID());
		}

		public int GetPrototypeIndexWithPrefabID(int prefabID)
		{
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not add prefab instance! Given prefab is null.");
			}
			else
			{
				if (gpuiPrefab.IsInstanced || gpuiPrefab._isBeingAddedToThePrefabManager)
				{
					return;
				}
				if (gpuiPrefab.GetPrefabID() == 0)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not add prefab instance. Unknown prefab ID! Make sure the prefab ID is not overridden or use the AddPrefabInstance(GPUIPrefab gpuiPrefab, int prototypeIndex) method with the prototypeIndex parameter.", gpuiPrefab.gameObject);
					return;
				}
				if (_instancesToAdd == null)
				{
					_instancesToAdd = new List<GPUIPrefab>();
				}
				_instancesToAdd.Add(gpuiPrefab);
				gpuiPrefab._isBeingAddedToThePrefabManager = true;
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Invalid prototype index: " + prototypeIndex, base.gameObject);
				return false;
			}
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			if (gPUIPrefabPrototypeData == null || !gPUIPrefabPrototypeData.IsInitialized)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find runtime data at index: " + prototypeIndex, base.gameObject);
				return false;
			}
			gPUIPrefabPrototypeData.instancesToAdd.AddRange(instances);
			return true;
		}

		public bool AddPrefabInstance(GameObject go, int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find prototype at index " + prototypeIndex + " for: " + go, go);
				return false;
			}
			return AddPrefabInstance(go.AddOrGetComponent<GPUIPrefab>(), prototypeIndex);
		}

		public void AddPrefabInstances(IEnumerable<GameObject> instances, int prototypeIndex)
		{
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find prototype at index " + prototypeIndex + ".");
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not add prefab instance! Given prefab is null.");
				return false;
			}
			if (gpuiPrefab.IsInstanced || gpuiPrefab._isBeingAddedToThePrefabManager)
			{
				return true;
			}
			if (prototypeIndex < 0 || prototypeIndex > _prototypeDataArray.Length)
			{
				prototypeIndex = GetPrototypeIndex(gpuiPrefab);
				if (prototypeIndex < 0)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
					return false;
				}
			}
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			if (gPUIPrefabPrototypeData == null || !gPUIPrefabPrototypeData.IsInitialized)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find runtime data for: " + gpuiPrefab, gpuiPrefab);
				return false;
			}
			gPUIPrefabPrototypeData.instancesToAdd.Add(gpuiPrefab);
			gpuiPrefab._isBeingAddedToThePrefabManager = true;
			return true;
		}

		public int AddPrefabInstanceImmediate(GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			if (gpuiPrefab == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not add prefab instance! Given prefab is null.");
				return -1;
			}
			if (gpuiPrefab.IsInstanced)
			{
				return gpuiPrefab.bufferIndex;
			}
			if (prototypeIndex < 0)
			{
				prototypeIndex = GetPrototypeIndex(gpuiPrefab);
				if (prototypeIndex < 0)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
					return -1;
				}
			}
			_dependentJob.Complete();
			GPUIPrefabPrototypeData obj = _prototypeDataArray[prototypeIndex];
			int matrixLength = obj.GetMatrixLength();
			ResizeArrays(prototypeIndex, matrixLength + 1);
			SetupPrefabInstanceForInstancing(gpuiPrefab, prototypeIndex, matrixLength);
			obj.isTransformReferencesModified = true;
			obj.isOptionalRendererStatusModified = true;
			obj.isMatrixArrayModified = true;
			obj.instanceCount++;
			return matrixLength;
		}

		public bool RemovePrefabInstance(GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData;
			if (!gpuiPrefab.IsInstanced)
			{
				if (gpuiPrefab._isBeingAddedToThePrefabManager)
				{
					if (prototypeIndex < 0)
					{
						prototypeIndex = GetPrototypeIndex(gpuiPrefab);
					}
					gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
					int num = gPUIPrefabPrototypeData.instancesToAdd.IndexOf(gpuiPrefab);
					if (num >= 0)
					{
						gPUIPrefabPrototypeData.instancesToAdd.RemoveAt(num);
						gpuiPrefab._isBeingAddedToThePrefabManager = false;
						return true;
					}
					if (_instancesToAdd != null)
					{
						num = _instancesToAdd.IndexOf(gpuiPrefab);
						if (num >= 0)
						{
							_instancesToAdd.RemoveAt(num);
							gpuiPrefab._isBeingAddedToThePrefabManager = false;
							return true;
						}
					}
				}
				return true;
			}
			if (prototypeIndex < 0)
			{
				prototypeIndex = GetPrototypeIndex(gpuiPrefab);
				if (prototypeIndex < 0)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
					return false;
				}
			}
			if (_prototypeDataArray == null || _prototypeDataArray.Length <= prototypeIndex)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find runtime data at index: " + prototypeIndex, gpuiPrefab);
				return false;
			}
			gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			gPUIPrefabPrototypeData.indexesToRemove.Add(gpuiPrefab.bufferIndex);
			return true;
		}

		public void UpdateTransformData(GPUIPrefab gpuiPrefab)
		{
			int num = ((!gpuiPrefab.IsInstanced) ? GetPrototypeIndex(gpuiPrefab) : GetPrototypeIndex(gpuiPrefab.renderKey));
			if (num < 0)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find prototype for: " + gpuiPrefab, gpuiPrefab);
				return;
			}
			if (_prototypeDataArray == null || _prototypeDataArray.Length <= num)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find runtime data at index: " + num, gpuiPrefab);
				return;
			}
			_dependentJob.Complete();
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[num];
			if (!gPUIPrefabPrototypeData.isAutoUpdateTransformData && gPUIPrefabPrototypeData.HasMatrixArray() && gPUIPrefabPrototypeData.GetMatrixLength() > gpuiPrefab.bufferIndex)
			{
				gPUIPrefabPrototypeData.isMatrixArrayModified = true;
				Transform cachedTransform = gpuiPrefab.CachedTransform;
				gPUIPrefabPrototypeData.SetMatrix(gpuiPrefab.bufferIndex, cachedTransform.localToWorldMatrix);
				cachedTransform.hasChanged = false;
			}
		}

		public virtual void SetupPrefabInstanceForInstancing(GPUIPrefab gpuiPrefab, int prototypeIndex, int bufferIndex)
		{
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			Transform cachedTransform = gpuiPrefab.CachedTransform;
			if (!gPUIPrefabPrototypeData.isAutoUpdateTransformData)
			{
				gPUIPrefabPrototypeData.SetMatrix(bufferIndex, cachedTransform.localToWorldMatrix);
			}
			gPUIPrefabPrototypeData.instanceTransforms[bufferIndex] = cachedTransform;
			if (gPUIPrefabPrototypeData.hasOptionalRenderers)
			{
				gPUIPrefabPrototypeData.optionalRendererStatusData[bufferIndex] = gpuiPrefab.optionalRendererStatus;
			}
			cachedTransform.hasChanged = false;
			gpuiPrefab.SetInstancingData(this, gPUIPrefabPrototypeData.prefabID, _runtimeRenderKeys[prototypeIndex], bufferIndex);
		}

		protected virtual void ResizeArrays(int prototypeIndex, int newSize)
		{
			GPUIPrefabPrototypeData gPUIPrefabPrototypeData = _prototypeDataArray[prototypeIndex];
			gPUIPrefabPrototypeData.ResizeMatrixArray(newSize);
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
			if (gPUIPrefabPrototypeData.hasOptionalRenderers)
			{
				GPUIUtility.ResizeNativeArray(ref gPUIPrefabPrototypeData.optionalRendererStatusData, newSize, Allocator.Persistent);
			}
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

		public virtual void SetPrefabInstanceRenderersEnabled(GPUIPrefab prefabInstance, bool enabled)
		{
			prefabInstance.SetRenderersEnabled(enabled);
		}

		protected override void OnUpdatePerInstanceLightProbes(int prototypeIndex)
		{
			_prototypeDataArray[prototypeIndex].SetAllMatricesModified();
		}

		public override List<string> GetShaderKeywords(int prototypeIndex)
		{
			if (_prototypes[prototypeIndex].prefabObject.HasComponent<GPUIMaterialVariationInstance>())
			{
				return MATERIAL_VARIATION_SHADER_KEYWORDS;
			}
			return base.GetShaderKeywords(prototypeIndex);
		}

		public int GetPrefabID(GameObject prefabObject)
		{
			return prefabObject.GetComponent<GPUIPrefab>().GetPrefabID();
		}

		public NativeArray<Matrix4x4> GetTransformMatrix(int prefabID)
		{
			_dependentJob.Complete();
			int prototypeIndexWithPrefabID = GetPrototypeIndexWithPrefabID(prefabID);
			if (prototypeIndexWithPrefabID < 0)
			{
				return default(NativeArray<Matrix4x4>);
			}
			return GetPrototypeData(prototypeIndexWithPrefabID).GetTransformationMatrixArray();
		}

		public void SetTransformMatrixModified(int prefabID)
		{
			int prototypeIndexWithPrefabID = GetPrototypeIndexWithPrefabID(prefabID);
			if (prototypeIndexWithPrefabID >= 0)
			{
				GetPrototypeData(prototypeIndexWithPrefabID).SetAllMatricesModified();
			}
		}

		public TransformAccessArray GetTransformAccessArray(int prefabID)
		{
			int prototypeIndexWithPrefabID = GetPrototypeIndexWithPrefabID(prefabID);
			if (prototypeIndexWithPrefabID < 0)
			{
				return default(TransformAccessArray);
			}
			GPUIPrefabPrototypeData prototypeData = GetPrototypeData(prototypeIndexWithPrefabID);
			prototypeData.UpdateTransformAccessArray();
			return prototypeData.transformAccessArray;
		}

		public Transform[] GetInstanceTransforms(int prefabID)
		{
			int prototypeIndexWithPrefabID = GetPrototypeIndexWithPrefabID(prefabID);
			if (prototypeIndexWithPrefabID < 0)
			{
				return null;
			}
			return GetPrototypeData(prototypeIndexWithPrefabID).instanceTransforms;
		}

		public Transform GetInstanceTransform(int prefabID, int bufferIndex)
		{
			int prototypeIndexWithPrefabID = GetPrototypeIndexWithPrefabID(prefabID);
			if (prototypeIndexWithPrefabID < 0)
			{
				return null;
			}
			GPUIPrefabPrototypeData prototypeData = GetPrototypeData(prototypeIndexWithPrefabID);
			if (prototypeData.instanceTransforms.Length <= bufferIndex)
			{
				return null;
			}
			return prototypeData.instanceTransforms[bufferIndex];
		}

		public Transform GetInstanceTransformWithRenderKey(int renderKey, int bufferIndex)
		{
			int prototypeIndex = GetPrototypeIndex(renderKey);
			if (prototypeIndex < 0)
			{
				return null;
			}
			GPUIPrefabPrototypeData prototypeData = GetPrototypeData(prototypeIndex);
			if (prototypeData.instanceTransforms.Length <= bufferIndex)
			{
				return null;
			}
			return prototypeData.instanceTransforms[bufferIndex];
		}

		public int GetInstanceCount(int prefabID)
		{
			int prototypeIndexWithPrefabID = GetPrototypeIndexWithPrefabID(prefabID);
			if (prototypeIndexWithPrefabID < 0)
			{
				return 0;
			}
			return GetPrototypeData(prototypeIndexWithPrefabID).instanceCount;
		}

		public void RequireTransformUpdate()
		{
			_requireTransformUpdate = true;
		}
	}
}
