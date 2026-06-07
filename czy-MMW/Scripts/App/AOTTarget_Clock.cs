using Factory;
using FixMath;
using Server;

public static class AOTTarget_Clock
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Clock, int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Clock, Fix64>();
	}
}
