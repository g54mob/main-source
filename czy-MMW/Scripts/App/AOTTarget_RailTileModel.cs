using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_RailTileModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RailTileModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<RailTileModel, TileModel>();
	}
}
