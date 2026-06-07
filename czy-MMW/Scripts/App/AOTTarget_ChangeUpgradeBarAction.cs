using Factory;

public static class AOTTarget_ChangeUpgradeBarAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ChangeUpgradeBarAction, IScope>();
	}
}
