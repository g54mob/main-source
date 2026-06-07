using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_VehicleModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<VehicleModel, Clock>();
	}
}
