using Factory;

public static class AOTTarget_App
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<App, IScope>();
	}
}
