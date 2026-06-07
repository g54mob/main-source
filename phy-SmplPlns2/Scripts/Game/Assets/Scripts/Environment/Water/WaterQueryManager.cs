using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using WaveHarmonic.Crest;
using WaveHarmonic.Crest.Internal;

namespace Assets.Scripts.Environment.Water
{
	[BurstCompile]
	public class WaterQueryManager : MonoBehaviour
	{
		[Flags]
		protected enum DebugLogFlags
		{
			None = 0,
			QuerySubmit = 1,
			QueryUpdate = 2,
			QueryComplete = 4,
			QuerySuperseded = 8,
			GridResizeEvents = 0x10,
			TooManyQueries = 0x20,
			QueryApiChanged = 0x40,
			QueryEvents = 0xF
		}

		private static class Profile
		{
			public static readonly ProfilerMarker QueryHeightDisplacement = new ProfilerMarker("WaterQueryManager.QueryHeightDisplacement");

			public static readonly ProfilerMarker Update = new ProfilerMarker("WaterQueryManager.Update");
		}

		[BurstCompile]
		private class WaterHeightQueryFrame
		{
			private static class Profile
			{
				public static readonly ProfilerMarker ApplyQueryResults = new ProfilerMarker("WaterHeightQueryFrame.ApplyQueryResults");

				public static readonly ProfilerMarker Create = new ProfilerMarker("WaterHeightQueryFrame.Create");

				public static readonly ProfilerMarker GetQueryResults = new ProfilerMarker("WaterHeightQueryFrame.GetQueryResults");

				public static readonly ProfilerMarker PrepareQueryForSubmit = new ProfilerMarker("WaterHeightQueryFrame.PrepareQueryForSubmit");

				public static readonly ProfilerMarker QueryHeightDisplacement = new ProfilerMarker("WaterHeightQueryFrame.QueryHeightDisplacement");

				public static readonly ProfilerMarker Reset = new ProfilerMarker("WaterHeightQueryFrame.Reset");

				public static readonly ProfilerMarker SubmitQuery = new ProfilerMarker("WaterHeightQueryFrame.SubmitQuery");

				public static readonly ProfilerMarker UpdateQuery = new ProfilerMarker("WaterHeightQueryFrame.UpdateQuery");
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void GetGridPositions_00004038_0024PostfixBurstDelegate(int count, float3* positions, int* positionIds, float3* gridPositions, float gridSize);

			internal static class GetGridPositions_00004038_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<GetGridPositions_00004038_0024PostfixBurstDelegate>(GetGridPositions).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(int count, float3* positions, int* positionIds, float3* gridPositions, float gridSize)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<int, float3*, int*, float3*, float, void>)functionPointer)(count, positions, positionIds, gridPositions, gridSize);
							return;
						}
					}
					GetGridPositions_0024BurstManaged(count, positions, positionIds, gridPositions, gridSize);
				}
			}

			private const int MaxLifespanFrames = 6;

			private static byte _nextQueryId = 1;

			private List<Action<float>> _invalidQueries;

			private List<(int Index, Action<float> Callback)> _queries;

			private CollisionQueryJundroo _queryApi;

			private Dictionary<int, int> _queryPointIndexMap;

			private Vector3[] _queryPoints;

			private float[] _queryResults;

			private int? _querySubmitFrame;

			private List<Action<float>> _requestedQueryCallbacks;

			private List<float3> _requestedQueryPositions;

			private bool _tooManyQueriesLogged;

			public float GridSize { get; private set; }

			public int MaxQueries { get; }

			public float MinSpatialLength { get; private set; }

			public int QueryCount { get; private set; }

			public int QueryCountExceeded { get; private set; }

			public int QueryId { get; }

			public bool QuerySubmitted => _querySubmitFrame.HasValue;

			public int RequestedQueryCount => _requestedQueryPositions.Count;

			public int ReservedQueryCount { get; }

			public WaterQueryManager WaterQueryManager { get; }

			protected WaterHeightQueryFrame(WaterQueryManager waterQueryManager, int reservedQueryCount)
			{
				WaterQueryManager = waterQueryManager;
				ReservedQueryCount = reservedQueryCount;
				MaxQueries = ManagerBehaviour<WaterRenderer>.Instance.AnimatedWavesLod.MaximumQueryCount - reservedQueryCount;
				_queryPoints = new Vector3[MaxQueries];
				_queryResults = new float[MaxQueries];
				_queries = new List<(int, Action<float>)>(MaxQueries);
				_invalidQueries = new List<Action<float>>();
				_requestedQueryPositions = new List<float3>(MaxQueries);
				_requestedQueryCallbacks = new List<Action<float>>(MaxQueries);
				_queryPointIndexMap = new Dictionary<int, int>();
				QueryId = _nextQueryId++;
			}

			public static WaterHeightQueryFrame Create(WaterQueryManager waterQueryManager, int reservedQueryCount)
			{
				using (Profile.Create.Auto())
				{
					return new WaterHeightQueryFrame(waterQueryManager, reservedQueryCount);
				}
			}

			public static void DebugDrawCross(Vector3 pos, float r, Color col, float duration = 0f)
			{
				Debug.DrawLine(pos - Vector3.up * r, pos + Vector3.up * r, col, duration);
				Debug.DrawLine(pos - Vector3.right * r, pos + Vector3.right * r, col, duration);
				Debug.DrawLine(pos - Vector3.forward * r, pos + Vector3.forward * r, col, duration);
			}

			public void Initialize(float gridSize, float minSpatialLength, CollisionQueryJundroo queryApi)
			{
				GridSize = gridSize;
				MinSpatialLength = minSpatialLength;
				_queryApi = queryApi;
			}

			public void QueryHeightDisplacement(Vector3 position, Action<float> callback)
			{
				using (Profile.QueryHeightDisplacement.Auto())
				{
					_requestedQueryPositions.Add(position);
					_requestedQueryCallbacks.Add(callback);
				}
			}

			public void Reset()
			{
				using (Profile.Reset.Auto())
				{
					QueryCount = 0;
					QueryCountExceeded = 0;
					_querySubmitFrame = null;
					_queries.Clear();
					_queryPointIndexMap.Clear();
					_requestedQueryPositions.Clear();
					_requestedQueryCallbacks.Clear();
					_invalidQueries.Clear();
					_tooManyQueriesLogged = false;
				}
			}

			public void ShowDebugVisualizations()
			{
				foreach (int value in _queryPointIndexMap.Values)
				{
					Vector3 pos = _queryPoints[value];
					pos.y = _queryResults[value];
					DebugDrawCross(pos, 1f, Color.magenta);
				}
			}

			public bool UpdateQuery()
			{
				using (Profile.UpdateQuery.Auto())
				{
					return QuerySubmitted ? GetQueryResults() : SubmitQuery();
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(GetGridPositions_00004038_0024PostfixBurstDelegate))]
			private unsafe static void GetGridPositions(int count, float3* positions, int* positionIds, float3* gridPositions, float gridSize)
			{
				GetGridPositions_00004038_0024BurstDirectCall.Invoke(count, positions, positionIds, gridPositions, gridSize);
			}

			private void ApplyQueryResults()
			{
				using (Profile.ApplyQueryResults.Auto())
				{
					if (WaterQueryManager._debugLoggingFlags.HasFlag(DebugLogFlags.QueryComplete))
					{
						Debug.Log($"{Time.frameCount}: Completed Query '{QueryId}'  ({Time.frameCount - _querySubmitFrame.Value} Frames)");
					}
					float seaLevel = ManagerBehaviour<WaterRenderer>.Instance.SeaLevel;
					foreach (var query in _queries)
					{
						float obj = _queryResults[query.Index] - seaLevel;
						query.Callback(obj);
					}
					if (_invalidQueries.Count <= 0)
					{
						return;
					}
					foreach (Action<float> invalidQuery in _invalidQueries)
					{
						invalidQuery(0f);
					}
				}
			}

			private bool GetQueryResults()
			{
				using (Profile.GetQueryResults.Auto())
				{
					if (WaterQueryManager._debugLoggingFlags.HasFlag(DebugLogFlags.QueryUpdate))
					{
						Debug.Log($"{Time.frameCount}: Updating Query '{QueryId}'");
					}
					int queryResults = _queryApi.GetQueryResults(QueryId, _queryResults, null, null);
					if (((IQueryProvider)_queryApi).RetrieveSucceeded(queryResults))
					{
						ApplyQueryResults();
						return true;
					}
					if (Time.frameCount >= _querySubmitFrame.Value + 6)
					{
						Debug.LogError($"{Time.frameCount}: Water height query '{QueryId}' was active for {6} frames without completing. The query will be abandoned.");
						return true;
					}
					return false;
				}
			}

			private unsafe void PrepareQueryForSubmit()
			{
				using (Profile.PrepareQueryForSubmit.Auto())
				{
					int count = _requestedQueryPositions.Count;
					NativeArray<float3> nativeArray = new NativeArray<float3>(_requestedQueryPositions.GetInternalArray(), Allocator.Temp);
					NativeArray<int> nativeArray2 = new NativeArray<int>(count, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<float3> nativeArray3 = new NativeArray<float3>(count, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					GetGridPositions(count, (float3*)nativeArray.GetUnsafePtr(), (int*)nativeArray2.GetUnsafePtr(), (float3*)nativeArray3.GetUnsafePtr(), GridSize);
					for (int i = 0; i < count; i++)
					{
						if (!_queryPointIndexMap.TryGetValue(nativeArray2[i], out var value))
						{
							if (QueryCount >= MaxQueries)
							{
								QueryCountExceeded++;
								_invalidQueries.Add(_requestedQueryCallbacks[i]);
								if (WaterQueryManager._debugLoggingFlags.HasFlag(DebugLogFlags.TooManyQueries) && !_tooManyQueriesLogged)
								{
									Debug.Log($"Too many water height queries this frame: {QueryCount}");
									_tooManyQueriesLogged = true;
								}
								continue;
							}
							value = QueryCount++;
							_queryPointIndexMap[nativeArray2[i]] = value;
							_queryPoints[value] = nativeArray3[i];
						}
						_queries.Add((value, _requestedQueryCallbacks[i]));
					}
					nativeArray3.Dispose();
					nativeArray2.Dispose();
					nativeArray.Dispose();
				}
			}

			private bool SubmitQuery()
			{
				using (Profile.SubmitQuery.Auto())
				{
					PrepareQueryForSubmit();
					if (WaterQueryManager._debugLoggingFlags.HasFlag(DebugLogFlags.QuerySubmit))
					{
						Debug.Log($"{Time.frameCount}: Submitting Query '{QueryId}'  ({_queries.Count} Requests --> {QueryCount} Queries)" + ((QueryCountExceeded > 0) ? $" Exceeded Budget: {QueryCountExceeded}" : string.Empty));
					}
					Span<Vector3> i_queryPoints = _queryPoints.AsSpan(0, QueryCount);
					int num = _queryApi.QueryOnce(QueryId, MinSpatialLength, i_queryPoints, includeNormals: false);
					_querySubmitFrame = Time.frameCount;
					return num != 0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal unsafe static void GetGridPositions_0024BurstManaged(int count, float3* positions, int* positionIds, float3* gridPositions, float gridSize)
			{
				float num = gridSize / 2f;
				for (int i = 0; i < count; i++)
				{
					int2 int5 = math.clamp((int2)(positions[i].xz / gridSize - -32768f), new int2(0, 0), new int2(65535, 65535));
					float2 float5 = ((float2)int5 + -32768f) * gridSize + num;
					positionIds[i] = (int5.x << 16) | int5.y;
					gridPositions[i] = new float3(float5.x, positions[i].y, float5.y);
				}
			}
		}

		private const float MinGridSize = 0.5f;

		private Queue<WaterHeightQueryFrame> _activeQueries;

		private Queue<WaterHeightQueryFrame> _activeQueriesSwap;

		[SerializeField]
		[Tooltip("The debug log flags used to specify what events get logged. These are typically only used in debugging.")]
		private DebugLogFlags _debugLoggingFlags;

		[SerializeField]
		[Tooltip("A value indicating whether debug visualizations are enabled for this manager.")]
		private bool _debugVisualizationsEnabled;

		private int _gridShrinkFrameCount;

		[SerializeField]
		private float _gridSize = 1f;

		private Queue<WaterHeightQueryFrame> _inactiveQueries;

		[SerializeField]
		private float _minSpatialLength = 0.5f;

		private WaterHeightQueryFrame _pendingQuery;

		private CollisionQueryJundroo _queryApi;

		[SerializeField]
		[Tooltip("The number of queries reserved for use external to this query manager. In other words, this manager considers the max queries to be the Crest setting for max queries minus this reserved query count number.")]
		private int _reservedQueryCount = 128;

		private bool _tooManyActiveQueriesLogged;

		public void QueryHeightDisplacement(Vector3 position, Action<float> callback)
		{
			using (Profile.QueryHeightDisplacement.Auto())
			{
				if (_queryApi == null)
				{
					callback(0f);
				}
				else
				{
					_pendingQuery?.QueryHeightDisplacement(position, callback);
				}
			}
		}

		protected virtual void Awake()
		{
			_activeQueries = new Queue<WaterHeightQueryFrame>();
			_activeQueriesSwap = new Queue<WaterHeightQueryFrame>();
			_inactiveQueries = new Queue<WaterHeightQueryFrame>();
		}

		protected virtual void Update()
		{
			using (Profile.Update.Auto())
			{
				CollisionQueryJundroo queryApi = GetQueryApi();
				if (queryApi != _queryApi)
				{
					_queryApi = queryApi;
					if (_debugLoggingFlags.HasFlag(DebugLogFlags.QueryApiChanged))
					{
						Debug.Log("The water query API has changed. Existing water queries will be abandoned.");
					}
					while (_activeQueries.Count > 0)
					{
						WaterHeightQueryFrame waterHeightQueryFrame = _activeQueries.Dequeue();
						waterHeightQueryFrame.Reset();
						_inactiveQueries.Enqueue(waterHeightQueryFrame);
					}
				}
				if (queryApi == null)
				{
					return;
				}
				WaterHeightQueryFrame pendingQuery = _pendingQuery;
				if (pendingQuery != null && pendingQuery.RequestedQueryCount > 0)
				{
					_pendingQuery.Initialize(_gridSize, _minSpatialLength, _queryApi);
					_activeQueries.Enqueue(_pendingQuery);
					_pendingQuery = null;
				}
				while (_activeQueries.Count > 0)
				{
					WaterHeightQueryFrame waterHeightQueryFrame2 = _activeQueries.Dequeue();
					bool num = !waterHeightQueryFrame2.QuerySubmitted;
					bool flag = waterHeightQueryFrame2.UpdateQuery();
					if (num)
					{
						AdjustGridSizeIfNecessary(waterHeightQueryFrame2);
					}
					if (flag)
					{
						if (_debugVisualizationsEnabled)
						{
							waterHeightQueryFrame2.ShowDebugVisualizations();
						}
						waterHeightQueryFrame2.Reset();
						_inactiveQueries.Enqueue(waterHeightQueryFrame2);
						while (_activeQueriesSwap.Count > 0)
						{
							WaterHeightQueryFrame waterHeightQueryFrame3 = _activeQueriesSwap.Dequeue();
							waterHeightQueryFrame3.Reset();
							_inactiveQueries.Enqueue(waterHeightQueryFrame3);
							if (_debugLoggingFlags.HasFlag(DebugLogFlags.QuerySuperseded))
							{
								Debug.Log($"{Time.frameCount}: Query '{waterHeightQueryFrame3.QueryId}' superseded by query '{waterHeightQueryFrame2.QueryId}'");
							}
						}
					}
					else
					{
						_activeQueriesSwap.Enqueue(waterHeightQueryFrame2);
					}
				}
				Queue<WaterHeightQueryFrame> activeQueriesSwap = _activeQueriesSwap;
				Queue<WaterHeightQueryFrame> activeQueries = _activeQueries;
				_activeQueries = activeQueriesSwap;
				_activeQueriesSwap = activeQueries;
				_activeQueriesSwap.Clear();
				_tooManyActiveQueriesLogged = false;
				if (_pendingQuery == null)
				{
					PrepareNewPendingQuery();
				}
			}
		}

		private static CollisionQueryJundroo GetQueryApi()
		{
			ICollisionProvider collisionProvider = ManagerBehaviour<WaterRenderer>.Instance?.CollisionProvider;
			if (collisionProvider == null)
			{
				WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
				if ((object)instance != null && instance.isActiveAndEnabled)
				{
					Debug.LogError("Unable to get the collision query API for water queries. The collision provider was null.");
					return null;
				}
				collisionProvider = ICollisionProvider.None;
			}
			if (!(collisionProvider is CollisionQueryJundroo result))
			{
				if (!(collisionProvider is ICollisionProvider.NoneProvider))
				{
					Debug.LogError("Unable to get the collision query API for water queries. The collision provider did not match the expected type." + System.Environment.NewLine + "Expected: " + typeof(CollisionQueryJundroo).FullName + System.Environment.NewLine + "Actual: " + collisionProvider.GetType().FullName);
				}
				return null;
			}
			return result;
		}

		private void AdjustGridSizeIfNecessary(WaterHeightQueryFrame query)
		{
			if (query.QueryCountExceeded > 0)
			{
				_gridSize *= 2f;
				_gridShrinkFrameCount = 0;
				if (_debugLoggingFlags.HasFlag(DebugLogFlags.GridResizeEvents))
				{
					Debug.Log($"{Time.frameCount}: Increasing query grid size: {_gridSize}");
				}
			}
			else if (_gridSize > 0.5f && (float)query.QueryCount < (float)query.MaxQueries / 2.25f)
			{
				_gridShrinkFrameCount++;
				if (_gridShrinkFrameCount >= 10)
				{
					_gridSize = Mathf.Max(0.5f, _gridSize / 2f);
					_gridShrinkFrameCount = 0;
					if (_debugLoggingFlags.HasFlag(DebugLogFlags.GridResizeEvents))
					{
						Debug.Log($"{Time.frameCount}: Decreasing query grid size: {_gridSize}");
					}
				}
			}
			else
			{
				_gridShrinkFrameCount = 0;
			}
		}

		private void PrepareNewPendingQuery()
		{
			_pendingQuery = null;
			while (_pendingQuery == null)
			{
				if (_inactiveQueries.Count > 0)
				{
					WaterHeightQueryFrame waterHeightQueryFrame = _inactiveQueries.Dequeue();
					if (waterHeightQueryFrame.ReservedQueryCount == _reservedQueryCount)
					{
						_pendingQuery = waterHeightQueryFrame;
					}
					continue;
				}
				if (_activeQueries.Count > 10)
				{
					if (!_tooManyActiveQueriesLogged)
					{
						Debug.LogError($"Too many active water height queries: {_activeQueries.Count}");
						_tooManyActiveQueriesLogged = true;
					}
					break;
				}
				_pendingQuery = WaterHeightQueryFrame.Create(this, _reservedQueryCount);
			}
		}
	}
}
