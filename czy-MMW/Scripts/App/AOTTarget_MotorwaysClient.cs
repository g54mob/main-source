using Factory;
using Motorways;

public static class AOTTarget_MotorwaysClient
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysClient, Scope>();
	}
}
