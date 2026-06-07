using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_RemoveRoundaboutEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RemoveRoundaboutEdit, Vector2Int>();
	}
}
