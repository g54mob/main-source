using Factory;
using Motorways.Actions;

public static class AOTTarget_PressUIFocusAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<PressUIFocusAction, IScope>();
	}
}
