using Factory;
using Motorways;

public static class AOTTarget_MotorwaysGame
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGame, IScope>();
	}
}
