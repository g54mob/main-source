using Factory;
using Motorways;
using UnityEngine;

public static class AOTTarget_RemoveUnbuiltMotorwaysEdit
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RemoveUnbuiltMotorwaysEdit, Vector2Int>();
	}
}
