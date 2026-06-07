using Factory;
using Motorways;
using Server;
using UnityEngine;

public static class AOTTarget_Tile
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Tile, ITilemap>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Tile, Vector2Int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Tile, TileContentType>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Tile, IModel>();
	}
}
