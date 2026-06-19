using System;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct TileAccessor : IReadTileAccessor
{
	public static readonly TileCD DefaultTile = new TileCD
	{
		tileset = 2,
		tileType = TileType.wall
	};

	[ReadOnly]
	private NativeParallelHashMap<int2, Entity> _subMapIndexToEntity;

	private BufferLookup<SubMapLayerBuffer> _subMapLayerBufferLookup;

	private Entity _lastSubMapEntity;

	private int2 _lastSubMapIndex;

	public TileAccessor(ref SystemState state, bool isReadOnly = true)
	{
		_subMapIndexToEntity = state.GetSingleton<SubMapRegistry>().IndexToEntity;
		_subMapLayerBufferLookup = state.GetBufferLookup<SubMapLayerBuffer>(isReadOnly);
		_lastSubMapEntity = Entity.Null;
		_lastSubMapIndex = int.MinValue;
	}

	public TileAccessor(SystemBase systemBase)
		: this(ref systemBase.CheckedStateRef)
	{
	}

	public void Update(ref SystemState state)
	{
		_subMapLayerBufferLookup.Update(ref state);
		_lastSubMapEntity = Entity.Null;
		_lastSubMapIndex = int.MinValue;
	}

	public void Update(SystemBase systemBase)
	{
		Update(ref systemBase.CheckedStateRef);
	}

	public bool IsInitialized(int2 worldPosition)
	{
		int2 key = (worldPosition & -64) >> 6;
		return _subMapIndexToEntity.ContainsKey(key);
	}

	public Entity GetSubMapEntity(int2 worldPosition)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var _, out var subMapEntity))
		{
			return Entity.Null;
		}
		return subMapEntity;
	}

	public unsafe bool IsSet(int2 worldPosition)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return false;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			flag |= unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
		}
		return flag;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe bool HasType(int2 worldPosition, TileType tileType)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return tileType == DefaultTile.tileType;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (unsafeReadOnlyPtr[i].layer.tileType == tileType && byRef)
			{
				return true;
			}
		}
		if (!flag)
		{
			return tileType == DefaultTile.tileType;
		}
		return false;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe bool HasTypeAndTileset(int2 worldPosition, TileType tileType, int tileset)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			if (tileType == DefaultTile.tileType)
			{
				return tileset == DefaultTile.tileset;
			}
			return false;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (unsafeReadOnlyPtr[i].layer.tileset == tileset && unsafeReadOnlyPtr[i].layer.tileType == tileType && byRef)
			{
				return true;
			}
		}
		if (!flag && tileType == DefaultTile.tileType)
		{
			return tileset == DefaultTile.tileset;
		}
		return false;
	}

	[Obsolete("Deprecated in 1.1.2.2 in favor of TryGetBlockingTile. Will get removed in a future update.")]
	[GenerateTestsForBurstCompatibility]
	public unsafe bool HasBlockingType(int2 worldPosition, bool includeLowColliders)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return DefaultTile.tileType.IsBlockingTile(includeLowColliders);
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		bool flag = false;
		bool flag2 = false;
		int2 int5 = subMapIndex * 64;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			flag2 |= byRef && unsafeReadOnlyPtr[i].layer.tileType.IsBlockingTile(includeLowColliders);
		}
		if (!flag2)
		{
			if (!flag)
			{
				return DefaultTile.tileType.IsBlockingTile(includeLowColliders);
			}
			return false;
		}
		return true;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe bool GetType(int2 worldPosition, TileType tileType, out TileCD tileCD)
	{
		tileCD = DefaultTile;
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return DefaultTile.tileType == tileType;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (unsafeReadOnlyPtr[i].layer.tileType == tileType && byRef)
			{
				tileCD = new TileCD
				{
					tileset = unsafeReadOnlyPtr[i].layer.tileset,
					tileType = unsafeReadOnlyPtr[i].layer.tileType
				};
				return true;
			}
		}
		if (!flag)
		{
			return DefaultTile.tileType == tileType;
		}
		return false;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe TileCD GetTopDamageableTile(int2 worldPosition)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return DefaultTile;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		TileCD result = default(TileCD);
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (byRef && unsafeReadOnlyPtr[i].layer.tileType.IsDamageableTile() && GetSurfacePriority(result.tileType) < GetSurfacePriority(unsafeReadOnlyPtr[i].layer.tileType))
			{
				result = unsafeReadOnlyPtr[i].layer;
			}
		}
		if (!flag)
		{
			return DefaultTile;
		}
		return result;
	}

	[Obsolete("Deprecated in 1.1.2.2 in favor of TryGetBlockingTile. Will get removed in a future update.")]
	[GenerateTestsForBurstCompatibility]
	public unsafe TileCD GetBlockingTile(int2 worldPosition, bool includeLowColliders = true)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return DefaultTile;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		TileCD result = default(TileCD);
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			TileType tileType = unsafeReadOnlyPtr[i].layer.tileType;
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (byRef)
			{
				flag2 = flag2 || tileType == TileType.bridge;
				if (GetSurfacePriority(tileType) > GetSurfacePriority(result.tileType) && tileType.IsBlockingTile(includeLowColliders))
				{
					result = unsafeReadOnlyPtr[i].layer;
				}
			}
		}
		if ((result.tileType == TileType.water || result.tileType == TileType.pit) && flag2)
		{
			result = default(TileCD);
		}
		if (!flag)
		{
			return DefaultTile;
		}
		return result;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe bool TryGetBlockingTile(int2 worldPosition, out TileCD tile, bool includeLowColliders = true)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			tile = DefaultTile;
			return true;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		tile = default(TileCD);
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			TileType tileType = unsafeReadOnlyPtr[i].layer.tileType;
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (byRef)
			{
				flag2 = flag2 || tileType == TileType.bridge;
				if (GetSurfacePriority(tileType) > GetSurfacePriority(tile.tileType) && tileType.IsBlockingTile(includeLowColliders))
				{
					tile = unsafeReadOnlyPtr[i].layer;
				}
			}
		}
		TileType tileType2 = tile.tileType;
		if ((tileType2 == TileType.water || tileType2 == TileType.pit) && flag2)
		{
			tile = default(TileCD);
		}
		if (!flag)
		{
			tile = DefaultTile;
		}
		return tile.tileType != TileType.none;
	}

	public bool HasAdjacentWater(int2 worldPosition)
	{
		for (int i = 0; i < Direction.allFourClockwise.Length; i++)
		{
			int2 i2 = Direction.allFourClockwise[i].i2;
			if (HasType(worldPosition + i2, TileType.water))
			{
				return true;
			}
		}
		return false;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe NativeArray<TileCD> Get(int2 worldPosition, Allocator allocator)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			NativeArray<TileCD> result = new NativeArray<TileCD>(1, allocator);
			result[0] = DefaultTile;
			return result;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		int num = 0;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			if (unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5))
			{
				num++;
			}
		}
		if (num == 0)
		{
			NativeArray<TileCD> result2 = new NativeArray<TileCD>(1, allocator);
			result2[0] = DefaultTile;
			return result2;
		}
		NativeArray<TileCD> result3 = new NativeArray<TileCD>(num, allocator);
		num = 0;
		for (int j = 0; j < dynamicBuffer.Length; j++)
		{
			if (unsafeReadOnlyPtr[j].GetByRef(worldPosition - int5))
			{
				result3[num++] = unsafeReadOnlyPtr[j].layer;
			}
		}
		return result3;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe int Count(int2 worldPosition)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return 0;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		int num = 0;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			if (unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5))
			{
				num++;
			}
		}
		return num;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe TileCD GetTop(int2 worldPosition)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return DefaultTile;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		TileCD result = default(TileCD);
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
			flag = flag || byRef;
			if (byRef && GetSurfacePriority(result.tileType) < GetSurfacePriority(unsafeReadOnlyPtr[i].layer.tileType))
			{
				result = unsafeReadOnlyPtr[i].layer;
			}
		}
		if (!flag)
		{
			return DefaultTile;
		}
		return result;
	}

	[GenerateTestsForBurstCompatibility]
	public TileType GetTopType(int2 worldPosition)
	{
		return GetTop(worldPosition).tileType;
	}

	[GenerateTestsForBurstCompatibility]
	public unsafe TileCD GetTopFromSelection(int2 worldPosition, NativeParallelHashSet<TileCD> selection)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return DefaultTile;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		SubMapLayer* unsafeReadOnlyPtr = (SubMapLayer*)dynamicBuffer.GetUnsafeReadOnlyPtr();
		int2 int5 = subMapIndex * 64;
		TileCD result = default(TileCD);
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			if (selection.Contains(unsafeReadOnlyPtr[i].layer))
			{
				bool byRef = unsafeReadOnlyPtr[i].GetByRef(worldPosition - int5);
				flag = flag || byRef;
				if (byRef && GetSurfacePriority(result.tileType) < GetSurfacePriority(unsafeReadOnlyPtr[i].layer.tileType))
				{
					result = unsafeReadOnlyPtr[i].layer;
				}
			}
		}
		if (!flag)
		{
			return DefaultTile;
		}
		return result;
	}

	public bool Set(int2 worldPosition, TileCD tile)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			Debug.LogError("trying to set non-existing submap");
			return false;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		int2 int5 = subMapIndex * 64;
		int2 pos = worldPosition - int5;
		int i;
		for (i = 0; i < dynamicBuffer.Length; i++)
		{
			if (dynamicBuffer.ElementAt(i).layer.Equals(tile))
			{
				dynamicBuffer.ElementAt(i).Set(pos);
				break;
			}
		}
		if (i == dynamicBuffer.Length)
		{
			SubMapLayerBuffer subMapLayerBuffer = new SubMapLayerBuffer
			{
				data = new SubMapLayer
				{
					layer = tile
				}
			};
			subMapLayerBuffer.data.Set(pos);
			dynamicBuffer.Add(subMapLayerBuffer);
		}
		return true;
	}

	public void Remove(int2 worldPosition, TileCD tile)
	{
		if (!GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			return;
		}
		DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
		int2 int5 = subMapIndex * 64;
		int2 pos = worldPosition - int5;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			if (dynamicBuffer.ElementAt(i).layer.Equals(tile))
			{
				dynamicBuffer.ElementAt(i).Unset(pos);
				break;
			}
		}
	}

	public void Clear(int2 worldPosition)
	{
		if (GetSubMapEntityIfAvailable(worldPosition, out var subMapIndex, out var subMapEntity))
		{
			DynamicBuffer<SubMapLayer> dynamicBuffer = _subMapLayerBufferLookup[subMapEntity].Reinterpret<SubMapLayer>();
			int2 int5 = subMapIndex * 64;
			int2 pos = worldPosition - int5;
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				dynamicBuffer.ElementAt(i).Unset(pos);
			}
		}
	}

	public int GetSurfacePriority(TileType tileType)
	{
		return tileType.GetSurfacePriority();
	}

	private bool GetSubMapEntityIfAvailable(int2 worldPosition, out int2 subMapIndex, out Entity subMapEntity)
	{
		subMapIndex = (worldPosition & -64) >> 6;
		if (math.all(subMapIndex == _lastSubMapIndex))
		{
			subMapEntity = _lastSubMapEntity;
			return true;
		}
		if (!_subMapIndexToEntity.TryGetValue(subMapIndex, out subMapEntity))
		{
			return false;
		}
		_lastSubMapEntity = subMapEntity;
		_lastSubMapIndex = subMapIndex;
		return true;
	}
}
