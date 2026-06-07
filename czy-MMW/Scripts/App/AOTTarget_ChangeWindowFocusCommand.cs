using Factory;

public static class AOTTarget_ChangeWindowFocusCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ChangeWindowFocusCommand, float>();
	}
}
