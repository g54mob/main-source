using Factory;

public static class AOTTarget_InGameInputStateChangeAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<InGameInputStateChangeAction, IScope>();
	}
}
