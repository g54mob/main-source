using System.Runtime.CompilerServices;
using PugTilemap;
using Unity.Collections;
using Unity.Mathematics;

public static class UpdateSubMapCommon
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void FilterUpdates(in NativeArray<TileUpdateBuffer> tileUpdates, ref NativeList<TileUpdateBuffer> clearList, ref NativeList<TileUpdateBuffer> removeList, ref NativeList<TileUpdateBuffer> addList)
	{
		if (tileUpdates.Length == 0)
		{
			return;
		}
		NativeParallelHashSet<int2> nativeParallelHashSet = new NativeParallelHashSet<int2>(tileUpdates.Length * 2, Allocator.Temp);
		NativeParallelMultiHashMap<int2, TileCD> nativeParallelMultiHashMap = new NativeParallelMultiHashMap<int2, TileCD>(tileUpdates.Length * 2, Allocator.Temp);
		for (int num = tileUpdates.Length - 1; num >= 0; num--)
		{
			TileUpdateBuffer value = tileUpdates[num];
			if (value.command == TileUpdateBuffer.Command.Clear)
			{
				nativeParallelHashSet.Add(value.position);
				clearList.Add(in value);
			}
			else
			{
				if ((value.command != TileUpdateBuffer.Command.Remove && value.command != TileUpdateBuffer.Command.Add) || (!value.tile.tileType.IsIgnoreClear() && nativeParallelHashSet.Contains(value.position)))
				{
					continue;
				}
				if (nativeParallelMultiHashMap.ContainsKey(value.position))
				{
					using NativeParallelMultiHashMap<int2, TileCD>.Enumerator enumerator = nativeParallelMultiHashMap.GetValuesForKey(value.position);
					bool flag = false;
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.tileType == value.tile.tileType)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				nativeParallelMultiHashMap.Add(value.position, value.tile);
				removeList.Add(in value);
				if (value.command == TileUpdateBuffer.Command.Add)
				{
					addList.Add(in value);
				}
			}
		}
		nativeParallelHashSet.Dispose();
		nativeParallelMultiHashMap.Dispose();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void EnvironmentalDecorationUpdates(in NativeArray<TileUpdateBuffer> tileUpdates, ref NativeList<TileUpdateBuffer> removeList, ref NativeList<TileUpdateBuffer> addList)
	{
		for (int num = tileUpdates.Length - 1; num >= 0; num--)
		{
			TileUpdateBuffer tileUpdateBuffer = tileUpdates[num];
			if (tileUpdateBuffer.tile.tileType != TileType.none && tileUpdateBuffer.tile.tileType != TileType.roofHole)
			{
				if (tileUpdateBuffer.tile.tileType != TileType.smallStones)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.smallStones
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType != TileType.debris)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.debris
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType != TileType.debris2)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.debris2
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType != TileType.smallGrass)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.smallGrass
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType != TileType.wallGrass)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.wallGrass
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType == TileType.wall && tileUpdateBuffer.command == TileUpdateBuffer.Command.Add)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.roofHole
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType == TileType.ground && tileUpdateBuffer.command == TileUpdateBuffer.Command.Remove)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.dugUpGround
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
					value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.wateredGround
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
				if (tileUpdateBuffer.tile.tileType == TileType.dugUpGround && tileUpdateBuffer.command == TileUpdateBuffer.Command.Remove)
				{
					TileUpdateBuffer value = new TileUpdateBuffer
					{
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.wateredGround
						},
						command = TileUpdateBuffer.Command.Remove,
						position = tileUpdateBuffer.position
					};
					removeList.Add(in value);
				}
			}
		}
	}
}
