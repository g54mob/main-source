using Factory;

public static class AOTTarget_MotorwaysDevToolCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysDevToolCommand, IScope>();
	}
}
