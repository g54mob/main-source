using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_ClearTileEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ClearTileEdit, Vector2Int>();
	}
}
