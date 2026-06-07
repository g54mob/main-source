using Factory;
using Motorways.Actions;

public static class AOTTarget_MoveInGameFocusAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MoveInGameFocusAction, IScope>();
	}
}
