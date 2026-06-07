using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TilemapModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TilemapModel, Clock>();
	}
}
