using System.Collections.Generic;
using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_CarparkModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<CarparkModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<CarparkModel, List<TileModel>>();
	}
}
