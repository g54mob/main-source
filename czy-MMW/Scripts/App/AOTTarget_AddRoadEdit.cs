using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_AddRoadEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AddRoadEdit, Vector2Int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AddRoadEdit, TileDirection>();
	}
}
