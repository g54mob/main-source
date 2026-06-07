using Factory;
using Motorways.Actions;

public static class AOTTarget_DoubleTapToggleDrawModeAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DoubleTapToggleDrawModeAction, IScope>();
	}
}
