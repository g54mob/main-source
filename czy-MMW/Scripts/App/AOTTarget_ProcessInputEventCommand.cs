using Factory;

public static class AOTTarget_ProcessInputEventCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ProcessInputEventCommand, float>();
	}
}
