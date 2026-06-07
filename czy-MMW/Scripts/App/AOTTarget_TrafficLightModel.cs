using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TrafficLightModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TrafficLightModel, Clock>();
	}
}
