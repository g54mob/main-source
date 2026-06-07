using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	public abstract class QueryBase : IQueryable
	{
		private static class ShaderIDs
		{
			public static readonly int s_QueryPositions_MinimumGridSizes = Shader.PropertyToID("_Crest_QueryPositions_MinimumGridSizes");
		}

		private sealed class SegmentRegistrar
		{
			public Dictionary<int, Vector3Int> _Segments = new Dictionary<int, Vector3Int>();

			public int _QueryCount;
		}

		private sealed class SegmentRegistrarRingBuffer
		{
			private static readonly int s_PoolSize = 10;

			private readonly SegmentRegistrar[] _Segments = new SegmentRegistrar[s_PoolSize];

			public int _SegmentRelease;

			public int _SegmentAcquire;

			public SegmentRegistrar Current => _Segments[_SegmentAcquire];

			public SegmentRegistrarRingBuffer()
			{
				for (int i = 0; i < _Segments.Length; i++)
				{
					_Segments[i] = new SegmentRegistrar();
				}
			}

			public void AcquireNew()
			{
				int segmentAcquire = _SegmentAcquire;
				int num = (_SegmentAcquire + 1) % _Segments.Length;
				if (num == _SegmentRelease)
				{
					Debug.LogError("Crest: Query ring buffer exhausted. Please report this to developers.");
					return;
				}
				_SegmentAcquire = num;
				SegmentRegistrar segmentRegistrar = _Segments[_SegmentAcquire];
				segmentRegistrar._QueryCount = 0;
				segmentRegistrar._Segments.Clear();
				foreach (KeyValuePair<int, Vector3Int> segment in _Segments[segmentAcquire]._Segments)
				{
					if (Time.frameCount - segment.Value.z < 10)
					{
						Vector3Int value = segment.Value;
						value.x = segmentRegistrar._QueryCount;
						value.y = value.x + (segment.Value.y - segment.Value.x);
						segmentRegistrar._QueryCount = value.y + 1;
						segmentRegistrar._Segments.Add(segment.Key, value);
					}
				}
			}

			public void ReleaseLast()
			{
				_SegmentRelease = (_SegmentRelease + 1) % _Segments.Length;
			}

			public void RemoveRegistrations(int key)
			{
				int num = _SegmentAcquire;
				do
				{
					if (_Segments[num]._Segments.ContainsKey(key))
					{
						_Segments[num]._Segments.Remove(key);
					}
					num = (num + 1) % _Segments.Length;
				}
				while (num != _SegmentRelease);
			}

			public void ClearAvailable()
			{
				int num = _SegmentAcquire;
				do
				{
					_Segments[num]._Segments.Clear();
					_Segments[num]._QueryCount = 0;
					num = (num + 1) % _Segments.Length;
				}
				while (num != _SegmentRelease);
			}

			public void ClearAll()
			{
				for (int i = 0; i < _Segments.Length; i++)
				{
					_Segments[i]._QueryCount = 0;
					_Segments[i]._Segments.Clear();
				}
			}
		}

		private struct ReadbackRequest
		{
			public AsyncGPUReadbackRequest _Request;

			public float _DataTimestamp;

			public Dictionary<int, Vector3Int> _Segments;
		}

		public enum QueryStatus
		{
			OK = 0,
			RetrieveFailed = 1,
			PostFailed = 2,
			NotEnoughDataForVels = 4,
			VelocityDataInvalidated = 8,
			InvalidDtForVelocity = 0x10
		}

		private const int k_MaximumRequests = 7;

		private const int k_MaximumGuids = 2048;

		private const int k_NormalAdditionalQueryCount = 2;

		private readonly WaterRenderer _Water;

		private readonly IQueryableLod<IQueryProvider> _Lod;

		private readonly PropertyWrapperCompute _Wrapper;

		private readonly Action<AsyncGPUReadbackRequest> _DataArrivedAction;

		private const int k_ComputeGroupSize = 64;

		private const float k_FiniteDifferenceDx = 0.1f;

		private readonly ComputeBuffer _ComputeBufferQueries;

		private readonly ComputeBuffer _ComputeBufferResults;

		internal const int k_DefaultMaximumQueryCount = 4096;

		private readonly int _MaximumQueryCount;

		private readonly Vector3[] _QueryPositionXZ_MinimumGridSize;

		private readonly SegmentRegistrarRingBuffer _SegmentRegistrarRingBuffer = new SegmentRegistrarRingBuffer();

		private NativeArray<Vector3> _QueryResults;

		private float _QueryResultsTime = -1f;

		private Dictionary<int, Vector3Int> _ResultSegments;

		private NativeArray<Vector3> _QueryResultsLast;

		private float _QueryResultsTimeLast = -1f;

		private Dictionary<int, Vector3Int> _ResultSegmentsLast;

		private readonly List<ReadbackRequest> _Requests = new List<ReadbackRequest>();

		protected abstract int Kernel { get; }

		public int ResultGuidCount
		{
			get
			{
				if (_ResultSegments == null)
				{
					return 0;
				}
				return _ResultSegments.Count;
			}
		}

		public int RequestCount
		{
			get
			{
				if (_Requests == null)
				{
					return 0;
				}
				return _Requests.Count;
			}
		}

		public int QueryCount
		{
			get
			{
				if (_SegmentRegistrarRingBuffer == null)
				{
					return 0;
				}
				return _SegmentRegistrarRingBuffer.Current._QueryCount;
			}
		}

		public QueryBase(IQueryableLod<IQueryProvider> lod)
		{
			_Water = lod.Water;
			_Lod = lod;
			_DataArrivedAction = DataArrived;
			_MaximumQueryCount = lod.MaximumQueryCount;
			_QueryPositionXZ_MinimumGridSize = new Vector3[_MaximumQueryCount];
			_ComputeBufferQueries = new ComputeBuffer(_MaximumQueryCount, 12, ComputeBufferType.Default);
			_ComputeBufferResults = new ComputeBuffer(_MaximumQueryCount, 12, ComputeBufferType.Default);
			_QueryResults = new NativeArray<Vector3>(_MaximumQueryCount, Allocator.Persistent);
			_QueryResultsLast = new NativeArray<Vector3>(_MaximumQueryCount, Allocator.Persistent);
			ComputeShader query = ScriptableSingleton<WaterResources>.Instance.Compute._Query;
			if (query == null)
			{
				Debug.LogError("Crest: Could not load Query compute shader");
			}
			else
			{
				_Wrapper = new PropertyWrapperCompute(_Water.SimulationBuffer, query, Kernel);
			}
		}

		private void LogMaximumQueryCountExceededError()
		{
			Debug.LogError(string.Format("Crest: Maximum query count ({0}) exceeded, increase the <i>{1} > Simulations > {2} > {3}</i> to support a higher number of queries.", _MaximumQueryCount, "WaterRenderer", _Lod.Name, "MaximumQueryCount"), _Water);
		}

		protected bool UpdateQueryPoints(int ownerHash, float minSpatialLength, Vector3[] queryPoints, Vector3[] queryNormals)
		{
			SegmentRegistrar current = _SegmentRegistrarRingBuffer.Current;
			if (queryPoints.Length + current._QueryCount > _MaximumQueryCount)
			{
				LogMaximumQueryCountExceededError();
				return false;
			}
			bool flag = false;
			int num = ((queryPoints != null) ? queryPoints.Length : 0);
			int num2 = ((queryNormals != null) ? queryNormals.Length : 0);
			int num3 = num + num2 * 2;
			if (current._Segments.TryGetValue(ownerHash, out var value))
			{
				if (value.y - value.x + 1 == num3)
				{
					value.z = Time.frameCount;
					current._Segments[ownerHash] = value;
					flag = true;
				}
				else
				{
					current._Segments.Remove(ownerHash);
				}
			}
			if (num3 == 0)
			{
				return false;
			}
			if (!flag)
			{
				if (current._Segments.Count >= 2048)
				{
					Debug.LogError("Crest: Too many guids registered with CollProviderCompute. Increase s_maxGuids.");
					return false;
				}
				value.x = current._QueryCount;
				value.y = value.x + num3 - 1;
				value.z = Time.frameCount;
				current._Segments.Add(ownerHash, value);
				current._QueryCount += num3;
			}
			float num4 = minSpatialLength / 2f;
			float num5 = 2f;
			int num6 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Log(Mathf.Max(num4 / num5 / _Lod.Texel, 1f), 2f)), 0, _Water.LodLevels - 2);
			if (num + value.x > _QueryPositionXZ_MinimumGridSize.Length)
			{
				LogMaximumQueryCountExceededError();
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				_QueryPositionXZ_MinimumGridSize[i + value.x].x = queryPoints[i].x;
				_QueryPositionXZ_MinimumGridSize[i + value.x].y = queryPoints[i].z;
				_QueryPositionXZ_MinimumGridSize[i + value.x].z = num6;
			}
			for (int j = 0; j < num2; j++)
			{
				int num7 = value.x + num + 2 * j;
				_QueryPositionXZ_MinimumGridSize[num7].x = queryNormals[j].x + 0.1f;
				_QueryPositionXZ_MinimumGridSize[num7].y = queryNormals[j].z;
				_QueryPositionXZ_MinimumGridSize[num7].z = num6;
				num7++;
				_QueryPositionXZ_MinimumGridSize[num7].x = queryNormals[j].x;
				_QueryPositionXZ_MinimumGridSize[num7].y = queryNormals[j].z + 0.1f;
				_QueryPositionXZ_MinimumGridSize[num7].z = num6;
			}
			return true;
		}

		private void RemoveQueryPoints(int guid)
		{
			_SegmentRegistrarRingBuffer.RemoveRegistrations(guid);
		}

		private void CompactQueryStorage()
		{
			_SegmentRegistrarRingBuffer.ClearAvailable();
		}

		protected bool RetrieveResults(int guid, Vector3[] displacements, float[] heights, Vector3[] normals)
		{
			if (_ResultSegments == null)
			{
				return false;
			}
			if (!_ResultSegments.TryGetValue(guid, out var value))
			{
				return false;
			}
			int num = 0;
			if (displacements != null)
			{
				num = displacements.Length;
			}
			if (heights != null)
			{
				num = heights.Length;
			}
			if (displacements != null)
			{
			}
			int num2 = ((normals != null) ? normals.Length : 0);
			if (num > 0)
			{
				if (displacements != null)
				{
					_QueryResults.Slice(value.x, num).CopyTo(displacements);
				}
				if (heights != null)
				{
					float seaLevel = _Water.SeaLevel;
					for (int i = 0; i < num; i++)
					{
						heights[i] = seaLevel + _QueryResults[i + value.x].y;
					}
				}
			}
			if (num2 > 0)
			{
				int num3 = value.x + num;
				Vector3 vector = -Vector3.right * 0.1f;
				Vector3 vector2 = -Vector3.forward * 0.1f;
				for (int j = 0; j < num2; j++)
				{
					Vector3 vector3 = _QueryResults[j + value.x];
					Vector3 vector4 = vector + _QueryResults[num3 + 2 * j];
					Vector3 vector5 = vector2 + _QueryResults[num3 + 2 * j + 1];
					normals[j] = Vector3.Cross(vector3 - vector4, vector3 - vector5).normalized;
					normals[j].y *= -1f;
				}
			}
			return true;
		}

		protected int CalculateVelocities(int ownerHash, Vector3[] results)
		{
			if (_QueryResultsTime < 0f || _QueryResultsTimeLast < 0f)
			{
				return 1;
			}
			if (!_ResultSegments.TryGetValue(ownerHash, out var value))
			{
				return 1;
			}
			if (!_ResultSegmentsLast.TryGetValue(ownerHash, out var value2))
			{
				return 4;
			}
			if (value.y - value.x != value2.y - value2.x)
			{
				return 8;
			}
			float num = _QueryResultsTime - _QueryResultsTimeLast;
			if (num < 0.0001f)
			{
				return 16;
			}
			int num2 = results.Length;
			for (int i = 0; i < num2; i++)
			{
				results[i] = (_QueryResults[i + value.x] - _QueryResultsLast[i + value2.x]) / num;
			}
			return 0;
		}

		public void UpdateQueries(WaterRenderer water)
		{
			if (_SegmentRegistrarRingBuffer.Current._QueryCount > 0)
			{
				ExecuteQueries();
			}
		}

		public void SendReadBack(WaterRenderer water)
		{
			if (_SegmentRegistrarRingBuffer.Current._QueryCount > 0)
			{
				while (_Requests.Count >= 7)
				{
					_Requests.RemoveAt(0);
				}
				ReadbackRequest item = default(ReadbackRequest);
				item._DataTimestamp = Time.time - Time.deltaTime;
				item._Request = AsyncGPUReadback.Request(_ComputeBufferResults, _DataArrivedAction);
				item._Segments = _SegmentRegistrarRingBuffer.Current._Segments;
				_Requests.Add(item);
				_SegmentRegistrarRingBuffer.AcquireNew();
			}
		}

		private void ExecuteQueries()
		{
			_ComputeBufferQueries.SetData(_QueryPositionXZ_MinimumGridSize, 0, 0, _SegmentRegistrarRingBuffer.Current._QueryCount);
			_Wrapper.SetBuffer(ShaderIDs.s_QueryPositions_MinimumGridSizes, _ComputeBufferQueries);
			_Wrapper.SetBuffer(WaveHarmonic.Crest.ShaderIDs.s_Target, _ComputeBufferResults);
			int x = (_SegmentRegistrarRingBuffer.Current._QueryCount + 64 - 1) / 64;
			_Wrapper.Dispatch(x, 1, 1);
		}

		private void DataArrived(AsyncGPUReadbackRequest req)
		{
			if (!_QueryResults.IsCreated)
			{
				_Requests.Clear();
				return;
			}
			for (int num = _Requests.Count - 1; num >= 0; num--)
			{
				if (_Requests[num]._Request.hasError)
				{
					_Requests.RemoveAt(num);
					_SegmentRegistrarRingBuffer.ReleaseLast();
				}
			}
			int num2 = _Requests.Count - 1;
			while (num2 >= 0 && !_Requests[num2]._Request.done)
			{
				num2--;
			}
			if (num2 >= 0)
			{
				NativeArray<Vector3> queryResultsLast = _QueryResultsLast;
				NativeArray<Vector3> queryResults = _QueryResults;
				_QueryResults = queryResultsLast;
				_QueryResultsLast = queryResults;
				_QueryResultsTimeLast = _QueryResultsTime;
				_ResultSegmentsLast = _ResultSegments;
				ReadbackRequest readbackRequest = _Requests[num2];
				readbackRequest._Request.GetData<Vector3>().CopyTo(_QueryResults);
				_QueryResultsTime = readbackRequest._DataTimestamp;
				_ResultSegments = readbackRequest._Segments;
			}
			for (int num3 = num2; num3 >= 0; num3--)
			{
				_Requests.RemoveAt(num3);
				_SegmentRegistrarRingBuffer.ReleaseLast();
			}
		}

		public void CleanUp()
		{
			_ComputeBufferQueries.Dispose();
			_ComputeBufferResults.Dispose();
			if (_QueryResults.IsCreated)
			{
				_QueryResults.Dispose();
			}
			if (_QueryResultsLast.IsCreated)
			{
				_QueryResultsLast.Dispose();
			}
			_SegmentRegistrarRingBuffer.ClearAll();
		}

		public virtual void Initialize(WaterRenderer water)
		{
		}

		public int JCalculateVelocities(int ownerHash, Vector3[] results)
		{
			return CalculateVelocities(ownerHash, results);
		}

		public bool JRetrieveResults(int guid, Vector3[] displacements, float[] heights, Vector3[] normals)
		{
			return RetrieveResults(guid, displacements, heights, normals);
		}

		public bool UpdateQueryPoints(int ownerHash, float minSpatialLength, Span<Vector3> queryPoints, Span<Vector3> queryNormals, bool once)
		{
			SegmentRegistrar current = _SegmentRegistrarRingBuffer.Current;
			if (queryPoints.Length + current._QueryCount > _MaximumQueryCount)
			{
				LogMaximumQueryCountExceededError();
				return false;
			}
			bool flag = false;
			int num = ((queryPoints != null) ? queryPoints.Length : 0);
			int num2 = ((queryNormals != null) ? queryNormals.Length : 0);
			int num3 = num + num2 * 2;
			if (current._Segments.TryGetValue(ownerHash, out var value))
			{
				if (value.y - value.x + 1 == num3)
				{
					value.z = (once ? (Time.frameCount - 20) : Time.frameCount);
					current._Segments[ownerHash] = value;
					flag = true;
				}
				else
				{
					current._Segments.Remove(ownerHash);
				}
			}
			if (num3 == 0)
			{
				return false;
			}
			if (!flag)
			{
				if (current._Segments.Count >= 2048)
				{
					Debug.LogError("Crest: Too many guids registered with CollProviderCompute. Increase s_maxGuids.");
					return false;
				}
				value.x = current._QueryCount;
				value.y = value.x + num3 - 1;
				value.z = (once ? (Time.frameCount - 20) : Time.frameCount);
				current._Segments.Add(ownerHash, value);
				current._QueryCount += num3;
			}
			float num4 = minSpatialLength / 2f;
			float num5 = 2f;
			int num6 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Log(Mathf.Max(num4 / num5 / _Lod.Texel, 1f), 2f)), 0, _Water.LodLevels - 2);
			if (num + value.x > _QueryPositionXZ_MinimumGridSize.Length)
			{
				LogMaximumQueryCountExceededError();
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				_QueryPositionXZ_MinimumGridSize[i + value.x].x = queryPoints[i].x;
				_QueryPositionXZ_MinimumGridSize[i + value.x].y = queryPoints[i].z;
				_QueryPositionXZ_MinimumGridSize[i + value.x].z = num6;
			}
			for (int j = 0; j < num2; j++)
			{
				int num7 = value.x + num + 2 * j;
				_QueryPositionXZ_MinimumGridSize[num7].x = queryNormals[j].x + 0.1f;
				_QueryPositionXZ_MinimumGridSize[num7].y = queryNormals[j].z;
				_QueryPositionXZ_MinimumGridSize[num7].z = num6;
				num7++;
				_QueryPositionXZ_MinimumGridSize[num7].x = queryNormals[j].x;
				_QueryPositionXZ_MinimumGridSize[num7].y = queryNormals[j].z + 0.1f;
				_QueryPositionXZ_MinimumGridSize[num7].z = num6;
			}
			return true;
		}
	}
}
