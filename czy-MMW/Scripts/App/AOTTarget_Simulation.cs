using Factory;
using FixMath;
using Server;

public static class AOTTarget_Simulation
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Simulation, IScope>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Simulation, Fix64>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<Simulation, bool>();
	}
}
