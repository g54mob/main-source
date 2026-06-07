using Factory;
using Motorways.Actions;

public static class AOTTarget_ToggleZoomAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ToggleZoomAction, IScope>();
	}
}
