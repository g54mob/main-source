using Factory;

public static class AOTTarget_MenuNavigationAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MenuNavigationAction, IScope>();
	}
}
