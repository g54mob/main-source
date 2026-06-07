using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_TreeModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TreeModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TreeModel, int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TreeModel, TileModel>();
	}
}
