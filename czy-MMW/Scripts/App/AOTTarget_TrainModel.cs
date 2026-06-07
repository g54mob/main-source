using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TrainModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TrainModel, Clock>();
	}
}
