using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

public struct ObjectLookup
{
	internal struct SubAreaCell
	{
		internal UnsafeParallelMultiHashMap<int2, ObjectLookupEntry> subAreaMap;
	}

	private NativeParallelHashMap<int2, SubAreaCell> _map;

	private int2 _cachedCurrentCellIndex;

	private SubAreaCell _cachedSubAreaCell;

	private NativeParallelMultiHashMapIterator<int2> _cachedIter;

	internal ObjectLookup(NativeParallelHashMap<int2, SubAreaCell> map)
	{
		_map = map;
		_cachedCurrentCellIndex = int2.zero;
		_cachedSubAreaCell = default(SubAreaCell);
		_cachedIter = default(NativeParallelMultiHashMapIterator<int2>);
	}

	public bool Has(int2 tilePosition, ObjectID objectId)
	{
		if (!TryGetFirstEntry(tilePosition, out var entry))
		{
			return false;
		}
		do
		{
			if (objectId == entry.objectId)
			{
				return true;
			}
		}
		while (TryGetNextEntry(out entry));
		return false;
	}

	public bool HasAny(int2 tilePosition, NativeArray<ObjectID> objectIds)
	{
		if (!TryGetFirstEntry(tilePosition, out var entry))
		{
			return false;
		}
		do
		{
			for (int i = 0; i < objectIds.Length; i++)
			{
				if (objectIds[i] == entry.objectId)
				{
					return true;
				}
			}
		}
		while (TryGetNextEntry(out entry));
		return false;
	}

	public bool HasAny(int2 tilePosition, NativeHashSet<int> objectIds)
	{
		if (!TryGetFirstEntry(tilePosition, out var entry))
		{
			return false;
		}
		do
		{
			foreach (int item in objectIds)
			{
				if (item == (int)entry.objectId)
				{
					return true;
				}
			}
		}
		while (TryGetNextEntry(out entry));
		return false;
	}

	private bool TryGetFirstEntry(int2 tilePosition, out ObjectLookupEntry entry)
	{
		entry = default(ObjectLookupEntry);
		int2 subAreaCellIndex = ObjectLookupUtility.ToSubAreaCellIndex(tilePosition);
		if (!TryGetSubArea(subAreaCellIndex))
		{
			return false;
		}
		if (_cachedSubAreaCell.subAreaMap.ContainsKey(tilePosition))
		{
			return _cachedSubAreaCell.subAreaMap.TryGetFirstValue(tilePosition, out entry, out _cachedIter);
		}
		return false;
	}

	private bool TryGetSubArea(int2 subAreaCellIndex)
	{
		if (!_cachedSubAreaCell.subAreaMap.IsCreated || math.any(_cachedCurrentCellIndex != subAreaCellIndex))
		{
			if (!_map.ContainsKey(subAreaCellIndex))
			{
				return false;
			}
			_cachedSubAreaCell = _map[subAreaCellIndex];
			_cachedCurrentCellIndex = subAreaCellIndex;
		}
		return true;
	}

	private bool TryGetNextEntry(out ObjectLookupEntry entry)
	{
		return _cachedSubAreaCell.subAreaMap.TryGetNextValue(out entry, ref _cachedIter);
	}

	public NativeList<ObjectLookupEntry> GetNearby(int2 tilePosition, Allocator allocator, int distance)
	{
		int num = distance * distance;
		int2 int5 = new int2(distance, distance);
		int2 int6 = ObjectLookupUtility.ToSubAreaCellIndex(tilePosition - int5);
		int2 int7 = ObjectLookupUtility.ToSubAreaCellIndex(tilePosition + int5);
		NativeList<ObjectLookupEntry> result = new NativeList<ObjectLookupEntry>(32, allocator);
		for (int i = int6.x; i <= int7.x; i++)
		{
			for (int j = int6.y; j <= int7.y; j++)
			{
				int2 subAreaCellIndex = new int2(i, j);
				if (!TryGetSubArea(subAreaCellIndex))
				{
					continue;
				}
				using UnsafeParallelMultiHashMap<int2, ObjectLookupEntry>.KeyValueEnumerator keyValueEnumerator = _cachedSubAreaCell.subAreaMap.GetEnumerator();
				do
				{
					if (math.distancesq(keyValueEnumerator.Current.Key, tilePosition) <= (float)num)
					{
						result.Add(in keyValueEnumerator.Current.Value);
					}
				}
				while (keyValueEnumerator.MoveNext());
			}
		}
		return result;
	}

	public NativeList<ObjectLookupEntry> GetObjects(int2 worldPosition, Allocator allocator)
	{
		NativeList<ObjectLookupEntry> result = new NativeList<ObjectLookupEntry>(1, allocator);
		if (!TryGetFirstEntry(worldPosition, out var entry))
		{
			return result;
		}
		result.Add(in entry);
		while (TryGetNextEntry(out entry))
		{
			result.Add(in entry);
		}
		return result;
	}
}
