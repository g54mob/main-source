using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TileCornerModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TileCornerModel, Clock>();
	}
}
