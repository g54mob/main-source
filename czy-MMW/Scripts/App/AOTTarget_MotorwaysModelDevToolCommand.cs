using Factory;

public static class AOTTarget_MotorwaysModelDevToolCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysModelDevToolCommand, IScope>();
	}
}
