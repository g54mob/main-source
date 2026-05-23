#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using Data.GameState;
using Events;
using Presentation.FactoryFloor;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Rendering;
using Utils;

namespace JobSystem
{
	public class TransformJobManager : MonoBehaviour
	{
		private const int InnerloopBatchCount = 64;

		public static TransformJobManager Instance;

		public static bool InstanceExists;

		[SerializeField]
		private int _chunkSize = 4096;

		[SerializeField]
		protected PauseStateData _pauseState;

		[SerializeField]
		private BaseEvent _transformJobsScheduledEvent;

		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		private JobHandle _animationJobHandle;

		private JobHandle _movementJobHandle;

		private int _chunksAllocated;

		private TransformAnimationDeltaJob _deltaJob;

		private TransformMovementJob _movementJob;

		[ReadOnly]
		private NativeArray<float3> _startPositions;

		[ReadOnly]
		private NativeArray<float3> _endPositions;

		[ReadOnly]
		private NativeArray<float> _startScales;

		[ReadOnly]
		private NativeArray<float> _endScales;

		[ReadOnly]
		private NativeArray<float> _progresses01;

		[ReadOnly]
		private NativeArray<bool> _animPlaying;

		[ReadOnly]
		private NativeArray<float> _timeAnimating;

		[ReadOnly]
		private NativeArray<float> _totalAnimTimes;

		[ReadOnly]
		private NativeArray<bool> _animationsFinishedThisFrame;

		private TransformAccessArray _transformAccess;

		private readonly Dictionary<Transform, int> _transformToIndex = new Dictionary<Transform, int>();

		private readonly List<int> _freeIndexes = new List<int>();

		private ITransformJobAble[] _animationSources;

		private Transform _dummyTransform;

		private bool _areJobsRunning;

		private readonly Queue<RequestTransformJobContext> _transformRequests = new Queue<RequestTransformJobContext>();

		private void Awake()
		{
			if (InstanceExists)
			{
				this.LogWarning("Multiple instances attempted to call Awake(). Aborting.", "Awake", 57);
				Object.Destroy(base.gameObject);
				return;
			}
			Instance = this;
			InstanceExists = true;
			_preLoadingSaveEvent.Register(HandlePreLoadingSave);
			_dummyTransform = new GameObject("TransformJobManager.DummyTransform").transform;
			_chunksAllocated = 1;
			InitializeNativeCollections();
		}

		private void OnDestroy()
		{
			_preLoadingSaveEvent.UnRegister(HandlePreLoadingSave);
			DestroyNativeCollections();
			Instance = null;
			InstanceExists = false;
		}

		private void HandlePreLoadingSave()
		{
			DestroyNativeCollections();
			_chunksAllocated = 1;
			InitializeNativeCollections();
		}

		private void Update()
		{
			if (!_pauseState.IsPaused)
			{
				ProceedJobs();
			}
			_transformJobsScheduledEvent.Fire();
		}

		private void LateUpdate()
		{
			CompleteJobsAndQueues();
		}

		private void InitializeNativeCollections()
		{
			int num = _chunkSize * _chunksAllocated;
			this.Log($"Allocating space for {num} transforms in TransformJobManager.", "InitializeNativeCollections", 105);
			_startPositions = new NativeArray<float3>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_endPositions = new NativeArray<float3>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_startScales = new NativeArray<float>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_endScales = new NativeArray<float>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_progresses01 = new NativeArray<float>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_timeAnimating = new NativeArray<float>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_totalAnimTimes = new NativeArray<float>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_animPlaying = new NativeArray<bool>(num, Allocator.Persistent);
			_animationsFinishedThisFrame = new NativeArray<bool>(num, Allocator.Persistent);
			_transformAccess = new TransformAccessArray(num);
			CreateJobs();
			_animationSources = new ITransformJobAble[num];
			_transformToIndex.Clear();
			_freeIndexes.Clear();
			_freeIndexes.Capacity = num;
			for (int i = 0; i < num; i++)
			{
				_transformAccess.Add(_dummyTransform);
				_freeIndexes.Add(i);
			}
			this.Log("Initialized Native Collections.", "InitializeNativeCollections", 132);
		}

		private void AddChunkNativeCollections()
		{
			CompleteJobs();
			_chunksAllocated++;
			int num = _chunkSize * _chunksAllocated;
			int num2 = num - _chunkSize;
			ArrayExtensions.ResizeArray(ref _startPositions, num);
			ArrayExtensions.ResizeArray(ref _endPositions, num);
			ArrayExtensions.ResizeArray(ref _startScales, num);
			ArrayExtensions.ResizeArray(ref _endScales, num);
			ArrayExtensions.ResizeArray(ref _progresses01, num);
			ArrayExtensions.ResizeArray(ref _timeAnimating, num);
			ArrayExtensions.ResizeArray(ref _totalAnimTimes, num);
			ArrayExtensions.ResizeArray(ref _animPlaying, num);
			ArrayExtensions.ResizeArray(ref _animationsFinishedThisFrame, num);
			_transformAccess.ResizeArray(num);
			ITransformJobAble[] array = new ITransformJobAble[num];
			for (int i = 0; i < _animationSources.Length; i++)
			{
				array[i] = _animationSources[i];
			}
			_animationSources = array;
			for (int j = num2; j < num; j++)
			{
				_transformAccess.Add(_dummyTransform);
				_freeIndexes.Add(j);
				_animPlaying[j] = false;
				_animationsFinishedThisFrame[j] = false;
			}
			CreateJobs();
			this.Log($"Resized Native Collections from {num2} to {num}", "AddChunkNativeCollections", 173);
		}

		private void CreateJobs()
		{
			_deltaJob = new TransformAnimationDeltaJob
			{
				Progresses01 = _progresses01,
				TimeAnimating = _timeAnimating,
				TotalAnimationTime = _totalAnimTimes,
				AnimationsFinishedThisFrame = _animationsFinishedThisFrame,
				AnimationPlaying = _animPlaying
			};
			_movementJob = new TransformMovementJob
			{
				StartPositions = _startPositions,
				EndPositions = _endPositions,
				StartScales = _startScales,
				EndScales = _endScales,
				Progresses01 = _progresses01,
				AnimationPlaying = _animPlaying
			};
		}

		private void DestroyNativeCollections()
		{
			if (_areJobsRunning)
			{
				_animationJobHandle.Complete();
				_movementJobHandle.Complete();
				_areJobsRunning = false;
			}
			if (_startPositions.IsCreated)
			{
				_startPositions.Dispose();
			}
			if (_endPositions.IsCreated)
			{
				_endPositions.Dispose();
			}
			if (_startScales.IsCreated)
			{
				_startScales.Dispose();
			}
			if (_endScales.IsCreated)
			{
				_endScales.Dispose();
			}
			if (_progresses01.IsCreated)
			{
				_progresses01.Dispose();
			}
			if (_timeAnimating.IsCreated)
			{
				_timeAnimating.Dispose();
			}
			if (_totalAnimTimes.IsCreated)
			{
				_totalAnimTimes.Dispose();
			}
			if (_animationsFinishedThisFrame.IsCreated)
			{
				_animationsFinishedThisFrame.Dispose();
			}
			if (_transformAccess.isCreated)
			{
				_transformAccess.Dispose();
			}
			_transformToIndex.Clear();
			_freeIndexes.Clear();
			_animationSources = null;
			this.Log("Destroyed Native Collections.", "DestroyNativeCollections", 221);
		}

		private void AddTransformInternal(RequestTransformJobContext context)
		{
			if (_areJobsRunning)
			{
				_transformRequests.Enqueue(context);
				return;
			}
			if (_transformToIndex.TryGetValue(context.Transform, out var value))
			{
				if (_animPlaying[value])
				{
					_animationSources[value].AnimationEnd();
				}
				SetValuesAtIndex(value, context);
				return;
			}
			if (_freeIndexes.Count == 0)
			{
				AddChunkNativeCollections();
			}
			int num = _freeIndexes[0];
			_freeIndexes.RemoveAtSwapBack(0);
			_transformAccess[num] = context.Transform;
			_transformToIndex.Add(context.Transform, num);
			SetValuesAtIndex(num, context);
		}

		internal static void AddTransform(RequestTransformJobContext context)
		{
			if (InstanceExists)
			{
				Instance.AddTransformInternal(context);
			}
		}

		public static void AddTransform(Transform transform, ITransformJobAble source, Vector3 startPosition, Vector3 endPosition, float startScale, float endScale, float totalTime, float startTime = 0f)
		{
			AddTransform(new RequestTransformJobContext(transform, source, startPosition, endPosition, startScale, endScale, totalTime, startTime, add: true));
		}

		private void RemoveTransformInternal(RequestTransformJobContext context)
		{
			int value;
			if (_areJobsRunning)
			{
				_transformRequests.Enqueue(context);
			}
			else if (_transformToIndex.TryGetValue(context.Transform, out value) && context.Source == _animationSources[value])
			{
				_transformAccess[value] = null;
				_animationSources[value] = null;
				_animPlaying[value] = false;
				_animationsFinishedThisFrame[value] = false;
				_transformToIndex.Remove(context.Transform);
				_freeIndexes.Add(value);
			}
		}

		internal static void RemoveTransform(RequestTransformJobContext context)
		{
			if (InstanceExists)
			{
				Instance.RemoveTransformInternal(context);
			}
		}

		public static void RemoveTransform(Transform transform, ITransformJobAble source)
		{
			RemoveTransform(new RequestTransformJobContext(transform, source, default(Vector3), default(Vector3), 0f, 0f, 0f, 0f, add: false));
		}

		private void SetValuesAtIndex(int index, RequestTransformJobContext context)
		{
			_startPositions[index] = context.StartPosition;
			_endPositions[index] = context.EndPosition;
			_startScales[index] = context.StartScale;
			_endScales[index] = context.EndScale;
			_totalAnimTimes[index] = context.TotalTime;
			_timeAnimating[index] = context.StartTime;
			_animPlaying[index] = true;
			_animationsFinishedThisFrame[index] = false;
			_animationSources[index] = context.Source;
		}

		private void ProceedJobs()
		{
			if (_transformToIndex.Count != 0)
			{
				_deltaJob.DeltaTime = Time.deltaTime;
				_animationJobHandle = IJobParallelForExtensions.Schedule(_deltaJob, _progresses01.Length, 64);
				_movementJobHandle = _movementJob.Schedule(_transformAccess, _animationJobHandle);
				_areJobsRunning = true;
			}
		}

		private void CompleteJobsAndQueues()
		{
			CompleteJobs();
			while (_transformRequests.Count > 0)
			{
				_transformRequests.Dequeue().Execute();
			}
			for (int i = 0; i < _animationsFinishedThisFrame.Length; i++)
			{
				if (_animationsFinishedThisFrame[i])
				{
					_animationsFinishedThisFrame[i] = false;
					_animationSources[i].AnimationEnd();
					RemoveTransform(_transformAccess[i], _animationSources[i]);
				}
			}
		}

		private void CompleteJobs()
		{
			_animationJobHandle.Complete();
			_movementJobHandle.Complete();
			_areJobsRunning = false;
		}
	}
}
