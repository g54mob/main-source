using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_AnchoredMessageModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AnchoredMessageModel, Clock>();
	}
}
