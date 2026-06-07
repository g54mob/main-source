using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_LaneModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<LaneModel, Clock>();
	}
}
