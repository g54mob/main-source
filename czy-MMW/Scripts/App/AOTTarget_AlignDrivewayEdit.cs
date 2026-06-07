using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_AlignDrivewayEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AlignDrivewayEdit, Vector2Int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AlignDrivewayEdit, TileDirection>();
	}
}
