using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_RoadChunkModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RoadChunkModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RoadChunkModel, TrainCrossingModel>();
	}
}
