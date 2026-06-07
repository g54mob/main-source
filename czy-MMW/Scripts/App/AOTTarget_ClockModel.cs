using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_ClockModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ClockModel, Clock>();
	}
}
