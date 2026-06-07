using Factory;
using Motorways.Actions;

public static class AOTTarget_ToggleDragClearTileAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ToggleDragClearTileAction, IScope>();
	}
}
