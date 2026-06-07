using Factory;
using Motorways.Actions;

public static class AOTTarget_ToggleCreativeModeEditMenuAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ToggleCreativeModeEditMenuAction, IScope>();
	}
}
