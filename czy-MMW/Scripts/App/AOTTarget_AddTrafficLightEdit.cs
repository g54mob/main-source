using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_AddTrafficLightEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AddTrafficLightEdit, Vector2Int>();
	}
}
