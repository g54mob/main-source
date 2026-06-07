using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_HouseModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<HouseModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<HouseModel, TileModel>();
	}
}
