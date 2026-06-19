using System.Collections.Generic;
using System.Text;
using Pug.UnityExtensions;
using PugMod;
using PugTilemap;
using QFSW.QC;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class TilesDebugSystem : SystemBase
{
	private static List<int2> positions = new List<int2>();

	private TileAccessor _tileAccessor;

	[CommandWithModSupport("printTilesAtPlayerPosition", "Prints the tile at the current player's position (host only)", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PrintTilesAtPlayerPosition()
	{
		PrintTilesAtPosition(Manager.main.player.WorldPosition.XZ());
	}

	[CommandWithModSupport("printTilesAtPosition", "Prints the tile at the given position (host only)", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PrintTilesAtPosition(Vector2 position)
	{
		positions.Add(position.ToFloat2().RoundToInt2());
	}

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<SubMapRegistry>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		_tileAccessor = new TileAccessor(ref base.CheckedStateRef);
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (positions.Count == 0)
		{
			return;
		}
		_tileAccessor.Update(ref base.CheckedStateRef);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int2 position in positions)
		{
			stringBuilder.Append($"Tiles at position {position}:");
			using NativeArray<TileCD> nativeArray = _tileAccessor.Get(position, Allocator.Temp);
			foreach (TileCD item in nativeArray)
			{
				stringBuilder.Append($" {item.tileType} {(Tileset)item.tileset},");
			}
			Debug.Log(stringBuilder.ToString());
			stringBuilder.Clear();
		}
		positions.Clear();
	}

	[Preserve]
	public TilesDebugSystem()
	{
	}
}
