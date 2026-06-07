using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TrainLineModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TrainLineModel, Clock>();
	}
}
