using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_RemoveTrafficLightEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RemoveTrafficLightEdit, Vector2Int>();
	}
}
