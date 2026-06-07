using Factory;
using Motorways.Actions;

public static class AOTTarget_DragMoveInGameFocusAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragMoveInGameFocusAction, IScope>();
	}
}
