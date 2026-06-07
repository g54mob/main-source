using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class SpatialHash
	{
		private const int INITIAL_CAPACITY = 256;

		private const int MIN_USE_SPATIAL_HASH = 32;

		private const int MAX_DIMENSION = 16;

		private const int MIN_DIMENSION = 4;

		private static readonly float3[] Bounds = new float3[4];

		private readonly Dictionary<int, ISpatialHash> m_Instances = new Dictionary<int, ISpatialHash>();

		private NativeHashSet<int> m_DynamicInstances = new NativeHashSet<int>(256, Allocator.Persistent);

		private NativeHashMap<int, Record> m_Records = new NativeHashMap<int, Record>(256, Allocator.Persistent);

		private NativeHashMap<HashKey, int> m_HashCensus = new NativeHashMap<HashKey, int>(256, Allocator.Persistent);

		private NativeParallelMultiHashMap<HashKey, int> m_HashData = new NativeParallelMultiHashMap<HashKey, int>(256, Allocator.Persistent);

		private NativeList<Candidate> m_Candidates = new NativeList<Candidate>(256, Allocator.Persistent);

		private int m_UpdateFrame = -1;

		public SpatialHash()
		{
			ApplicationManager.EventExit -= OnExit;
			ApplicationManager.EventExit += OnExit;
		}

		private void OnExit()
		{
			ApplicationManager.EventExit -= OnExit;
			m_Instances.Clear();
			m_DynamicInstances.Dispose();
			m_Records.Dispose();
			m_HashCensus.Dispose();
			m_HashData.Dispose();
			m_Candidates.Dispose();
		}

		public void Insert(ISpatialHash item)
		{
			if (item == null || ApplicationManager.IsExiting || m_Instances.ContainsKey(item.UniqueCode))
			{
				return;
			}
			int uniqueCode = item.UniqueCode;
			float3 float5 = item.Position;
			bool flag = !((Component)item).gameObject.isStatic;
			m_Instances.Add(uniqueCode, item);
			m_Records.Add(uniqueCode, new Record(uniqueCode, float5, flag));
			if (flag)
			{
				m_DynamicInstances.Add(uniqueCode);
			}
			for (int num = 16; num >= 4; num >>= 1)
			{
				int3 position = HashKey.Hash(num, float5);
				HashKey key = new HashKey(num, position);
				m_HashData.Add(key, uniqueCode);
				if (m_HashCensus.ContainsKey(key))
				{
					m_HashCensus[key]++;
				}
				else
				{
					m_HashCensus.Add(key, 1);
				}
			}
		}

		public void Remove(ISpatialHash item)
		{
			if (item == null || ApplicationManager.IsExiting)
			{
				return;
			}
			int uniqueCode = item.UniqueCode;
			if (m_Records.TryGetValue(uniqueCode, out var item2))
			{
				for (int num = 16; num >= 4; num >>= 1)
				{
					int3 position = HashKey.Hash(num, item2.Position);
					HashKey key = new HashKey(num, position);
					m_HashData.Remove(key, uniqueCode);
					m_HashCensus[key]--;
				}
				if (m_Records[uniqueCode].IsDynamic)
				{
					m_DynamicInstances.Remove(uniqueCode);
				}
				m_Instances.Remove(uniqueCode);
				m_Records.Remove(uniqueCode);
			}
		}

		public bool Contains(ISpatialHash item)
		{
			if (ApplicationManager.IsExiting)
			{
				return false;
			}
			int uniqueCode = item.UniqueCode;
			return m_Records.ContainsKey(uniqueCode);
		}

		public void Find(Vector3 point, float radius, List<ISpatialHash> results, ISpatialHash except = null)
		{
			if (ApplicationManager.IsExiting)
			{
				return;
			}
			m_Candidates.Clear();
			results.Clear();
			if (m_Records.Count < 32)
			{
				foreach (KeyValuePair<int, ISpatialHash> instance in m_Instances)
				{
					if (instance.Value != null && instance.Value != except)
					{
						float num = math.distance(point, instance.Value.Position);
						if (!(num > radius))
						{
							m_Candidates.Add(new Candidate(instance.Key, num));
						}
					}
				}
			}
			else
			{
				UpdateRecords();
				Bounds[0] = new float3(point.x - radius, point.y + radius, point.z - radius);
				Bounds[1] = new float3(point.x + radius, point.y + radius, point.z - radius);
				Bounds[2] = new float3(point.x - radius, point.y - radius, point.z - radius);
				Bounds[3] = new float3(point.x - radius, point.y - radius, point.z + radius);
				GetCandidates(16, point, radius, except?.UniqueCode ?? 0);
			}
			m_Candidates.Sort();
			if (results.Capacity < m_Candidates.Length)
			{
				results.Capacity = m_Candidates.Length;
			}
			foreach (Candidate candidate in m_Candidates)
			{
				int uniqueCode = candidate.UniqueCode;
				results.Add(m_Instances[uniqueCode]);
			}
		}

		private void GetCandidates(int dimension, float3 point, float radius, int exceptUniqueCode)
		{
			int3 int5 = HashKey.Hash(dimension, Bounds[0]);
			int3 int6 = HashKey.Hash(dimension, Bounds[1]);
			int3 int7 = HashKey.Hash(dimension, Bounds[2]);
			int3 int8 = HashKey.Hash(dimension, Bounds[3]);
			for (int i = int5.x; i <= int6.x; i++)
			{
				for (int j = int7.y; j <= int5.y; j++)
				{
					for (int k = int7.z; k <= int8.z; k++)
					{
						int3 position = new int3(i, j, k);
						HashKey key = new HashKey(dimension, position);
						if (!m_HashCensus.TryGetValue(key, out var item) || item == 0)
						{
							continue;
						}
						if (item < 32 || dimension <= 4)
						{
							foreach (int item2 in m_HashData.GetValuesForKey(key))
							{
								if (item2 != exceptUniqueCode)
								{
									float num = math.distance(m_Records[item2].Position, point);
									if (!(num > radius))
									{
										m_Candidates.Add(new Candidate(item2, num));
									}
								}
							}
						}
						else
						{
							GetCandidates(dimension >> 1, point, radius, exceptUniqueCode);
						}
					}
				}
			}
		}

		private void UpdateRecords()
		{
			if (m_UpdateFrame == Time.frameCount)
			{
				return;
			}
			foreach (int dynamicInstance in m_DynamicInstances)
			{
				float3 position = m_Records[dynamicInstance].Position;
				float3 float5 = ((Component)m_Instances[dynamicInstance]).transform.position;
				if (position.Equals(float5))
				{
					continue;
				}
				for (int num = 16; num >= 4; num >>= 1)
				{
					int3 position2 = HashKey.Hash(num, position);
					int3 position3 = HashKey.Hash(num, float5);
					if (position2.x != position3.x || position2.y != position3.y || position2.z != position3.z)
					{
						HashKey key = new HashKey(num, position2);
						HashKey key2 = new HashKey(num, position3);
						m_HashData.Remove(key, dynamicInstance);
						m_HashCensus[key]--;
						m_HashData.Add(key2, dynamicInstance);
						if (m_HashCensus.ContainsKey(key2))
						{
							m_HashCensus[key2]++;
						}
						else
						{
							m_HashCensus.Add(key2, 1);
						}
					}
				}
				bool isDynamic = m_Records[dynamicInstance].IsDynamic;
				m_Records[dynamicInstance] = new Record(dynamicInstance, float5, isDynamic);
			}
			m_UpdateFrame = Time.frameCount;
		}
	}
}
