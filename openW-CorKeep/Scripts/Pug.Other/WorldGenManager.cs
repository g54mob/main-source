using System;
using System.Collections.Generic;
using PugWorldGen;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

public class WorldGenManager : ManagerBase
{
	public struct AreaRequestResult
	{
		public int Index;

		public int RequesterId;

		public Vector2 ViewPortBase;

		public Vector2 ViewPortSize;

		public NativeArray<Color32> Data;
	}

	public struct PointsRequestResult
	{
		public int Index;

		public int RequesterId;

		public NativeArray<Color32> Data;

		public int DataSize;
	}

	public struct ProceduralDataRequester : IDisposable
	{
		private readonly int _areaRequesterId;

		private readonly int _maxSize;

		private readonly NativeArray<Color32>[] _pool;

		private int _poolIndex;

		private int _poolLength;

		public bool IsCreated => _pool != null;

		internal ProceduralDataRequester(int areaRequesterId, int maxSize, int poolSize = 1)
		{
			_areaRequesterId = areaRequesterId;
			_maxSize = maxSize;
			_pool = new NativeArray<Color32>[poolSize];
			_poolIndex = 0;
			_poolLength = 0;
			for (int i = 0; i < _pool.Length; i++)
			{
				_pool[i] = new NativeArray<Color32>(maxSize, Allocator.Persistent);
			}
		}

		public int RequestArea(Vector2 position, Vector2 size, byte downscale = 1)
		{
			if (size.x / (float)(int)downscale * (size.y / (float)(int)downscale) > (float)_maxSize)
			{
				Debug.LogError($"Requested area size {size} is greater than max size {_maxSize}");
				return -1;
			}
			if (_poolLength == _pool.Length)
			{
				return -1;
			}
			int result = Manager.worldGen.RequestArea(_areaRequesterId, position, size, _pool[_poolIndex], downscale);
			_poolIndex = (_poolIndex + 1) % _pool.Length;
			_poolLength++;
			return result;
		}

		public bool TryGetAreaRequestResult(out AreaRequestResult result)
		{
			if (Manager.worldGen.TryGetAreaRequestResult(_areaRequesterId, out result))
			{
				_poolLength--;
				return true;
			}
			result = default(AreaRequestResult);
			return false;
		}

		public int RequestPoints(NativeArray<Vector2> points)
		{
			return RequestPoints(points, points.Length);
		}

		public int RequestPoints(NativeArray<Vector2> points, int pointCount)
		{
			if (pointCount > _maxSize)
			{
				Debug.LogError($"Requested point count {pointCount} is greater than max size {_maxSize}");
				return -1;
			}
			if (_poolLength == _pool.Length)
			{
				return -1;
			}
			int result = Manager.worldGen.RequestPoints(_areaRequesterId, points, pointCount, _pool[_poolIndex]);
			_poolIndex = (_poolIndex + 1) % _pool.Length;
			_poolLength++;
			return result;
		}

		public bool TryGetPointsRequestResult(out PointsRequestResult result)
		{
			if (Manager.worldGen.TryGetPointsRequestResult(_areaRequesterId, out result))
			{
				_poolLength--;
				return true;
			}
			result = default(PointsRequestResult);
			return false;
		}

		public void Dispose()
		{
			NativeArray<Color32>[] pool = _pool;
			foreach (NativeArray<Color32> nativeArray in pool)
			{
				nativeArray.Dispose();
			}
		}
	}

	public PugWorld world;

	public CoreKeeperWorldParameters defaultWorldParameters;

	public CoreKeeperWorldGenerationSettings defaultWorldGenerationSettings;

	public CoreKeeperGenerationSettings coreKeeperGenerationSettings;

	private Dictionary<int, AreaRequestResult> _requestIdToAreaRequest = new Dictionary<int, AreaRequestResult>();

	private List<Queue<AreaRequestResult>> _areaRequestResults = new List<Queue<AreaRequestResult>>();

	private Dictionary<int, PointsRequestResult> _requestIdToPointRequest = new Dictionary<int, PointsRequestResult>();

	private List<Queue<PointsRequestResult>> _pointRequestResults = new List<Queue<PointsRequestResult>>();

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("WorldGenManager.Init");

	public override bool Setup()
	{
		PugWorld.activeWorld = world;
		PugWorld.activeWorldParameters = defaultWorldParameters;
		PugWorld.onAreaRequestComplete += OnAreaRequestComplete;
		PugWorld.onPointsRequestComplete += OnPointsRequestComplete;
		return true;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			return true;
		}
	}

	public override void Deinit()
	{
		PugWorld.onAreaRequestComplete -= OnAreaRequestComplete;
		PugWorld.onPointsRequestComplete -= OnPointsRequestComplete;
	}

	private void Update()
	{
		if (Manager.main.currentSceneHandler.isInGame)
		{
			PugWorld.ProcessAreaRequests();
		}
	}

	public void PreparePugWorld()
	{
		PugWorld.activeWorld = world;
		PugWorld.activeWorldParameters = Manager.saves.GetWorldGenerationParametersReference();
	}

	public int GetScaledPassageRadiusBound()
	{
		CoreKeeperWorldParameters worldGenerationParametersReference = Manager.saves.GetWorldGenerationParametersReference();
		return (int)math.ceil((worldGenerationParametersReference.ring4Size + worldGenerationParametersReference.ring4Chaos) * worldGenerationParametersReference.worldScale) + 32;
	}

	public int GetScaledWorldRadiusBound()
	{
		CoreKeeperWorldParameters worldGenerationParametersReference = Manager.saves.GetWorldGenerationParametersReference();
		float x = worldGenerationParametersReference.ring4Size + worldGenerationParametersReference.ring4Chaos;
		float y = worldGenerationParametersReference.ring4Size + worldGenerationParametersReference.northBlobRadius * 3f;
		return (int)math.ceil(math.max(x, y) * worldGenerationParametersReference.worldScale) + 32;
	}

	public int CreateNewRequesterId()
	{
		int count = _areaRequestResults.Count;
		_areaRequestResults.Add(new Queue<AreaRequestResult>());
		_pointRequestResults.Add(new Queue<PointsRequestResult>());
		return count;
	}

	public int RequestArea(int requesterId, Vector2 position, Vector2 size, NativeArray<Color32> data, byte downscale = 1)
	{
		int num = PugWorld.RequestArea(position, size, OutputType.Data, 0, downscale);
		_requestIdToAreaRequest.Add(num, new AreaRequestResult
		{
			Index = num,
			RequesterId = requesterId,
			ViewPortBase = position,
			ViewPortSize = size,
			Data = data
		});
		return num;
	}

	public bool TryGetAreaRequestResult(int requesterId, out AreaRequestResult result)
	{
		if (_areaRequestResults.Count <= requesterId)
		{
			Debug.LogError($"Requester ID {requesterId} does not exist");
			result = default(AreaRequestResult);
			return false;
		}
		return _areaRequestResults[requesterId].TryDequeue(out result);
	}

	private unsafe void OnAreaRequestComplete(byte channel, int index, Vector2 position, Vector2 size, NativeArray<Color32> data, Vector2Int dataSize)
	{
		if (!_requestIdToAreaRequest.Remove(index, out var value))
		{
			Debug.LogError($"Got request index without requester ID {index}");
			return;
		}
		if (data.Length > value.Data.Length)
		{
			Debug.LogError($"Data length {data.Length} is greater than requester data length {value.Data.Length}");
			return;
		}
		UnsafeUtility.MemCpy(value.Data.GetUnsafePtr(), data.GetUnsafeReadOnlyPtr(), data.Length * UnsafeUtility.SizeOf<Color32>());
		if (Vector2.Distance(value.ViewPortBase, position) > 1f || Vector2.Distance(value.ViewPortSize, size) > 1f)
		{
			Debug.LogWarning($"got request at {value.ViewPortBase}, size {value.ViewPortSize} for request at {position}, size {size}");
		}
		if (value.RequesterId >= _areaRequestResults.Count)
		{
			Debug.LogError($"Requester ID {value.RequesterId} does not exist");
		}
		else
		{
			_areaRequestResults[value.RequesterId].Enqueue(value);
		}
	}

	public int RequestPoints(int requesterId, NativeArray<Vector2> points, int pointCount, NativeArray<Color32> data)
	{
		int num = PugWorld.RequestPoints(points, pointCount);
		_requestIdToPointRequest.Add(num, new PointsRequestResult
		{
			Index = num,
			RequesterId = requesterId,
			Data = data
		});
		return num;
	}

	public bool TryGetPointsRequestResult(int requesterId, out PointsRequestResult result)
	{
		if (_pointRequestResults.Count <= requesterId)
		{
			Debug.LogError($"Requester ID {requesterId} does not exist");
			result = default(PointsRequestResult);
			return false;
		}
		return _pointRequestResults[requesterId].TryDequeue(out result);
	}

	private unsafe void OnPointsRequestComplete(int index, NativeArray<Color32> data, int dataLength)
	{
		if (!_requestIdToPointRequest.Remove(index, out var value))
		{
			Debug.LogError($"Got request index without requester ID {index}");
			return;
		}
		if (dataLength > value.Data.Length)
		{
			Debug.LogError($"Data length {dataLength} is greater than requester data length {value.Data.Length}");
			return;
		}
		UnsafeUtility.MemCpy(value.Data.GetUnsafePtr(), data.GetUnsafeReadOnlyPtr(), dataLength * UnsafeUtility.SizeOf<Color32>());
		if (value.RequesterId >= _pointRequestResults.Count)
		{
			Debug.LogError($"Requester ID {value.RequesterId} does not exist");
		}
		else
		{
			_pointRequestResults[value.RequesterId].Enqueue(value);
		}
	}

	public ProceduralDataRequester CreateProceduralDataRequester(int maxSize, int poolSize = 1)
	{
		return new ProceduralDataRequester(CreateNewRequesterId(), maxSize, poolSize);
	}
}
