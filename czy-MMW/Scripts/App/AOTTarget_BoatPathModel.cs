using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_BoatPathModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<BoatPathModel, Clock>();
	}
}
