using Factory;

public static class AOTTarget_TickAppCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TickAppCommand, float>();
	}
}
