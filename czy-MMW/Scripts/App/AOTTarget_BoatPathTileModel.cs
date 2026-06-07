using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_BoatPathTileModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<BoatPathTileModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<BoatPathTileModel, TileModel>();
	}
}
