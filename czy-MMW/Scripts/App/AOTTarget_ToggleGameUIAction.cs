using Factory;

public static class AOTTarget_ToggleGameUIAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ToggleGameUIAction, IScope>();
	}
}
