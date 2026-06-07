using Factory;

public static class AOTTarget_InitRandomCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<InitRandomCommand, float>();
	}
}
