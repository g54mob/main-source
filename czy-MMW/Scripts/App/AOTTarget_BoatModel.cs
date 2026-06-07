using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_BoatModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<BoatModel, Clock>();
	}
}
