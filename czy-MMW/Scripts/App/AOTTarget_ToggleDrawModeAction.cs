using Factory;
using Motorways.Actions;

public static class AOTTarget_ToggleDrawModeAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ToggleDrawModeAction, IScope>();
	}
}
