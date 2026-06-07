#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Data.FeatureFlags.Validators;
using Data.Variables;
using Events;
using Events.Islands;
using Presentation.FactoryFloor.Culling.Jobs;
using Presentation.Locators;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using Utils;

namespace JobSystem
{
	public class CullingJobManager : MonoBehaviour
	{
		private const int MaxIslands = 128;

		private const int FrustrumPlanes = 6;

		private const int InnerloopBatchCount = 64;

		private readonly CullableJobItem InvalidJobItem = new CullableJobItem
		{
			IsValid = false
		};

		public static CullingJobManager Instance;

		[SerializeField]
		private QualityLevelSO _qualityLevel;

		[SerializeField]
		private EnableCullingJobManager _validator;

		[SerializeField]
		private CameraLocator _mainCameraLocator;

		[SerializeField]
		private IslandCullStateChangedEventSO _islandCullStateChangedEvent;

		[SerializeField]
		[Range(0f, 5f)]
		private float _frustumCullingAdditionalMarginExpansionPercentage = 0.25f;

		[SerializeField]
		private int _chunkSize = 4096;

		[SerializeField]
		private BaseEvent _cullingJobsScheduledEvent;

		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		[SerializeField]
		private float _maxZoomModifierCullingMultiplier = 1.5f;

		private readonly Dictionary<ICullable, int> _cullableToIndex = new Dictionary<ICullable, int>();

		private readonly Dictionary<IslandObject, int> _islandLookup = new Dictionary<IslandObject, int>();

		private readonly List<int> _freeIndexes = new List<int>();

		private ICullable[] _cullables;

		private NativeArray<float4> _frustumPlanes;

		private NativeArray<CullableJobItem> _cullableBurstItems;

		private NativeArray<CullableObjectState> _cullResults;

		private NativeArray<CullableObjectState> _prevCullResults;

		private NativeQueue<int> _cullingChangesToApply;

		private NativeArray<IslandCullState> _islandCullStates;

		private int _chunksAllocated;

		private IslandCullingBurstJob _islandCullingJob;

		private QualityLevelCullingBurstJob _qualityLevelCullingJob;

		private DistanceCullingBurstJob _distanceCullingBurstJob;

		private FrustumCullingBurstJob _frustumCullingBurstJob;

		private CullingDiffJob _cullingDiffJob;

		private JobHandle _cullingJobsHandle;

		private bool _areJobsRunning;

		private readonly List<ICullable> _registerCullables = new List<ICullable>();

		private readonly List<ICullable> _unRegisterCullables = new List<ICullable>();

		private static bool _featureFlagDisabled;

		public void Awake()
		{
			if (_validator == null || !_validator.IsEnabledFeatureFlag())
			{
				this.Log("CullingJobManager disabled by FeatureFlag.", "Awake", 71);
				_featureFlagDisabled = true;
				base.enabled = false;
				return;
			}
			Instance = this;
			_featureFlagDisabled = false;
			_islandCullStateChangedEvent.Register(IslandCullStateChanged);
			_preLoadingSaveEvent.Register(HandlePreLoadingSave);
			_chunksAllocated = 1;
			InitializeNativeCollections();
			_maxZoomLevelModifier.ValueChanged += OnMaxZoomLevelChanged;
		}

		public void OnDestroy()
		{
			DestroyNativeCollections();
			Instance = null;
			_islandCullStateChangedEvent.UnRegister(IslandCullStateChanged);
			_maxZoomLevelModifier.ValueChanged -= OnMaxZoomLevelChanged;
		}

		private void HandlePreLoadingSave()
		{
			DestroyNativeCollections();
			_chunksAllocated = 1;
			InitializeNativeCollections();
		}

		public void Update()
		{
			UpdateCameraInfo();
			_qualityLevelCullingJob.CurrentQualityLevel = GetQualityLevel();
			_distanceCullingBurstJob.CurrentQualityLevel = GetQualityLevel();
			_distanceCullingBurstJob.CameraPosition = _mainCameraLocator.Camera.transform.position;
			_frustumCullingBurstJob.FrustumPlanes = _frustumPlanes;
			int arrayLength = _chunkSize * _chunksAllocated;
			_cullingJobsHandle = IJobParallelForExtensions.Schedule(_islandCullingJob, arrayLength, 64);
			_cullingJobsHandle = IJobParallelForExtensions.Schedule(_qualityLevelCullingJob, arrayLength, 64, _cullingJobsHandle);
			_cullingJobsHandle = IJobParallelForExtensions.Schedule(_distanceCullingBurstJob, arrayLength, 64, _cullingJobsHandle);
			_cullingJobsHandle = IJobParallelForExtensions.Schedule(_frustumCullingBurstJob, arrayLength, 64, _cullingJobsHandle);
			_cullingJobsHandle = IJobParallelForExtensions.Schedule(_cullingDiffJob, arrayLength, 64, _cullingJobsHandle);
			_areJobsRunning = true;
			_cullingJobsScheduledEvent.Fire();
		}

		public void LateUpdate()
		{
			CompleteJobsAndQueues();
		}

		public void InitializeNativeCollections()
		{
			int num = _chunkSize * _chunksAllocated;
			this.Log($"Allocating space for {num} conveyor belts in CullingJobManager.", "InitializeNativeCollections", 134);
			_cullableBurstItems = new NativeArray<CullableJobItem>(num, Allocator.Persistent);
			_cullResults = new NativeArray<CullableObjectState>(num, Allocator.Persistent);
			_prevCullResults = new NativeArray<CullableObjectState>(num, Allocator.Persistent);
			_cullingChangesToApply = new NativeQueue<int>(Allocator.Persistent);
			_islandCullStates = new NativeArray<IslandCullState>(128, Allocator.Persistent);
			_frustumPlanes = new NativeArray<float4>(6, Allocator.Persistent);
			_islandLookup.Clear();
			_cullables = new ICullable[num];
			_cullableToIndex.Clear();
			_freeIndexes.Clear();
			_freeIndexes.Capacity = num;
			for (int i = 0; i < num; i++)
			{
				_freeIndexes.Add(i);
				_cullableBurstItems[i] = InvalidJobItem;
			}
			CreateJobs();
		}

		public void AddChunkNativeCollections()
		{
			_chunksAllocated++;
			int num = _chunkSize * _chunksAllocated;
			int num2 = num - _chunkSize;
			this.Log($"Resizing Native Collections from {num2} to {num}", "AddChunkNativeCollections", 163);
			ArrayExtensions.ResizeArray(ref _cullableBurstItems, num);
			ArrayExtensions.ResizeArray(ref _cullResults, num);
			ArrayExtensions.ResizeArray(ref _prevCullResults, num);
			for (int i = num2; i < num; i++)
			{
				_freeIndexes.Add(i);
				_cullableBurstItems[i] = InvalidJobItem;
			}
			ICullable[] array = new ICullable[num];
			for (int j = 0; j < _cullables.Length; j++)
			{
				array[j] = _cullables[j];
			}
			_cullables = array;
			CreateJobs();
		}

		private void CreateJobs()
		{
			_islandCullingJob = new IslandCullingBurstJob
			{
				Input = _cullableBurstItems,
				IslandCullStates = _islandCullStates,
				Output = _cullResults
			};
			_qualityLevelCullingJob = new QualityLevelCullingBurstJob
			{
				Input = _cullableBurstItems,
				Output = _cullResults
			};
			_distanceCullingBurstJob = new DistanceCullingBurstJob
			{
				Input = _cullableBurstItems,
				Output = _cullResults,
				MaxZoomAdjustment = Mathf.RoundToInt((float)_maxZoomLevelModifier.Value * _maxZoomModifierCullingMultiplier)
			};
			_frustumCullingBurstJob = new FrustumCullingBurstJob
			{
				Input = _cullableBurstItems,
				FrustumPlanes = _frustumPlanes,
				FrustumPlaneDistanceForCulling = _frustumCullingAdditionalMarginExpansionPercentage * 2f,
				FrustumPlaneDistanceForShadowsOnly = _frustumCullingAdditionalMarginExpansionPercentage,
				Output = _cullResults
			};
			_cullingDiffJob = new CullingDiffJob
			{
				Input = _cullableBurstItems,
				PrevState = _prevCullResults,
				NewState = _cullResults,
				Output = _cullingChangesToApply.AsParallelWriter()
			};
		}

		private void DestroyNativeCollections()
		{
			if (_areJobsRunning)
			{
				_cullingJobsHandle.Complete();
				_areJobsRunning = false;
			}
			if (_cullableBurstItems.IsCreated)
			{
				_cullableBurstItems.Dispose();
			}
			if (_cullResults.IsCreated)
			{
				_cullResults.Dispose();
			}
			if (_prevCullResults.IsCreated)
			{
				_prevCullResults.Dispose();
			}
			if (_cullingChangesToApply.IsCreated)
			{
				_cullingChangesToApply.Dispose();
			}
			if (_frustumPlanes.IsCreated)
			{
				_frustumPlanes.Dispose();
			}
			_cullableToIndex.Clear();
			_registerCullables.Clear();
			_unRegisterCullables.Clear();
		}

		private void CompleteJobsAndQueues()
		{
			_cullingJobsHandle.Complete();
			_areJobsRunning = false;
			while (!_cullingChangesToApply.IsEmpty())
			{
				int num = _cullingChangesToApply.Dequeue();
				ICullable cullable = _cullables[num];
				if (!_unRegisterCullables.Contains(cullable))
				{
					cullable.UpdateCullState(_cullResults[num]);
				}
			}
			foreach (ICullable unRegisterCullable in _unRegisterCullables)
			{
				UnRegisterCullableInternal(unRegisterCullable);
			}
			_unRegisterCullables.Clear();
			foreach (ICullable registerCullable in _registerCullables)
			{
				RegisterCullableInternal(registerCullable);
			}
			_registerCullables.Clear();
		}

		private void RegisterCullableInternal(ICullable toRegister)
		{
			if (_areJobsRunning)
			{
				_registerCullables.Add(toRegister);
				_unRegisterCullables.Remove(toRegister);
				return;
			}
			if (_freeIndexes.Count == 0)
			{
				AddChunkNativeCollections();
			}
			int num = _freeIndexes[0];
			_freeIndexes.RemoveAtSwapBack(0);
			_prevCullResults[num] = toRegister.CurrentState;
			_cullResults[num] = CullableObjectState.Unknown;
			_cullableBurstItems[num] = new CullableJobItem
			{
				IsValid = true,
				Settings = toRegister.GetSettings(),
				WorldPosition = toRegister.GetPosition().Position,
				IslandID = GetIslandIDForCullable(toRegister),
				Bounds = toRegister.GetPosition().Bounds.GetValueOrDefault(Vector3.one)
			};
			_cullables[num] = toRegister;
			_cullableToIndex[toRegister] = num;
		}

		private void UnRegisterCullableInternal(ICullable toUnregister)
		{
			int value;
			if (_areJobsRunning)
			{
				_registerCullables.Remove(toUnregister);
				_unRegisterCullables.Add(toUnregister);
			}
			else if (_cullableToIndex.TryGetValue(toUnregister, out value))
			{
				_freeIndexes.Add(value);
				_cullableBurstItems[value] = InvalidJobItem;
				_cullables[value] = null;
				_cullableToIndex.Remove(toUnregister);
			}
		}

		private void RefreshCullablePositionInternal(ICullable cullable)
		{
			if (_cullableToIndex.TryGetValue(cullable, out var value))
			{
				_cullingJobsHandle.Complete();
				_cullableBurstItems[value] = new CullableJobItem
				{
					IsValid = true,
					Settings = cullable.GetSettings(),
					WorldPosition = cullable.GetPosition().Position,
					IslandID = GetIslandIDForCullable(cullable),
					Bounds = cullable.GetPosition().Bounds.GetValueOrDefault(Vector3.one)
				};
			}
		}

		public static void RegisterCullable(ICullable toRegister)
		{
			if (!_featureFlagDisabled && !ApplicationUtils.IsApplicationQuitting)
			{
				if (Instance == null)
				{
					toRegister.LogError("Tried to register an ICullable, but there is no CullingJobManager in the scene.", "RegisterCullable", 351);
				}
				else
				{
					Instance.RegisterCullableInternal(toRegister);
				}
			}
		}

		public static void UnRegisterCullable(ICullable toUnregister)
		{
			if (!_featureFlagDisabled && !ApplicationUtils.IsApplicationQuitting)
			{
				if (Instance == null)
				{
					toUnregister.LogError("Tried to unregister an ICullable, but there is no CullingJobManager in the scene.", "UnRegisterCullable", 363);
				}
				else
				{
					Instance.UnRegisterCullableInternal(toUnregister);
				}
			}
		}

		public static void RefreshCullablePosition(ICullable cullable)
		{
			if (!_featureFlagDisabled)
			{
				if (Instance == null)
				{
					cullable.LogError("Tried to refresh position of an ICullable, but there is no CullingJobManager in the scene.", "RefreshCullablePosition", 375);
				}
				else
				{
					Instance.RefreshCullablePositionInternal(cullable);
				}
			}
		}

		private void UpdateCameraInfo()
		{
			Plane[] array = GeometryUtility.CalculateFrustumPlanes(_mainCameraLocator.Camera);
			for (int i = 0; i < 6; i++)
			{
				float4 value = _frustumPlanes[i];
				value.x = array[i].normal.x;
				value.y = array[i].normal.y;
				value.z = array[i].normal.z;
				value.w = array[i].distance;
				_frustumPlanes[i] = value;
			}
		}

		private int GetIslandIDForCullable(ICullable cullable)
		{
			IslandObject island = cullable.GetPosition().Island;
			if (island == null)
			{
				return -1;
			}
			if (!_islandLookup.ContainsKey(island))
			{
				_islandLookup.Add(island, _islandLookup.Count);
			}
			return _islandLookup[island];
		}

		private CullingGraphicsQualityLevel GetQualityLevel()
		{
			return (CullingGraphicsQualityLevel)(_qualityLevel.Value + 1);
		}

		private void IslandCullStateChanged(IslandObject islandObject)
		{
			_cullingJobsHandle.Complete();
			if (!_islandLookup.TryGetValue(islandObject, out var value))
			{
				value = _islandLookup.Count;
				_islandLookup[islandObject] = value;
			}
			_islandCullStates[value] = islandObject.GetCullState();
		}

		private void OnMaxZoomLevelChanged(int _)
		{
			_distanceCullingBurstJob.MaxZoomAdjustment = Mathf.RoundToInt((float)_maxZoomLevelModifier.Value * _maxZoomModifierCullingMultiplier);
		}
	}
}
