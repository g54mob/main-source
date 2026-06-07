using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_RemoveMotorwaysEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RemoveMotorwaysEdit, Vector2Int>();
	}
}
