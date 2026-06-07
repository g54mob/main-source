using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TrainCrossingModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TrainCrossingModel, Clock>();
	}
}
