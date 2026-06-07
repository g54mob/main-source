using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TileModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TileModel, Clock>();
	}
}
