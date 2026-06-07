using Factory;
using Motorways.Actions;

public static class AOTTarget_DragClearTileAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragClearTileAction, IScope>();
	}
}
