using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class TileTypeColorLookupSystem : SystemBase
{
	public struct LookupHelper
	{
		[ReadOnly]
		public NativeParallelHashMap<TileTypeAndTileset, PugColor32> TileTypeAndSetToColor;

		[ReadOnly]
		public NativeParallelHashMap<PugColor32, TileTypeAndTileset> ColorToTileTypeAndSet;

		public Color32 GetColorByTileType(int pugMapTileset, TileType tileType)
		{
			if (TileTypeAndSetToColor.TryGetValue(new TileTypeAndTileset(tileType, (Tileset)pugMapTileset), out var item))
			{
				return item;
			}
			if (TileTypeAndSetToColor.TryGetValue(new TileTypeAndTileset(tileType, Tileset.Dirt), out item))
			{
				return item;
			}
			return Color.black;
		}

		public Color GetTrueColorByTileType(int pugMapTileset, TileType tileType)
		{
			return GetColorByTileType(pugMapTileset, tileType);
		}
	}

	private NativeParallelHashMap<TileTypeAndTileset, PugColor32> _tileTypeAndSetToColor;

	private NativeParallelHashMap<PugColor32, TileTypeAndTileset> _colorToTileTypeAndSet;

	[Preserve]
	protected override void OnCreate()
	{
		TileTypeColorTable tileTypeColorTable = Resources.Load<TileTypeColorTable>("TileTypeColorTable");
		_tileTypeAndSetToColor = new NativeParallelHashMap<TileTypeAndTileset, PugColor32>(512, Allocator.Persistent);
		_colorToTileTypeAndSet = new NativeParallelHashMap<PugColor32, TileTypeAndTileset>(512, Allocator.Persistent);
		foreach (TileTypeColorTable.TileSetColors tileSetColor in tileTypeColorTable.tileSetColors)
		{
			foreach (TileTypeColorTable.TileColor tileColor in tileSetColor.tileColors)
			{
				TileTypeAndTileset tileTypeAndTileset = new TileTypeAndTileset
				{
					TileType = tileColor.tileType,
					Tileset = tileSetColor.pugMapTileset
				};
				_tileTypeAndSetToColor.Add(tileTypeAndTileset, tileColor.color);
				_colorToTileTypeAndSet.TryAdd(tileColor.color, tileTypeAndTileset);
			}
		}
		base.Enabled = false;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		_tileTypeAndSetToColor.Dispose();
		_colorToTileTypeAndSet.Dispose();
		base.OnDestroy();
	}

	public LookupHelper CreateLookupHelper()
	{
		return new LookupHelper
		{
			TileTypeAndSetToColor = _tileTypeAndSetToColor,
			ColorToTileTypeAndSet = _colorToTileTypeAndSet
		};
	}

	[Preserve]
	protected override void OnUpdate()
	{
		base.Enabled = false;
	}

	[Preserve]
	public TileTypeColorLookupSystem()
	{
	}
}
