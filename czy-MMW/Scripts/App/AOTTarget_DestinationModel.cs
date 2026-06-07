using System.Collections.Generic;
using Factory;
using Motorways.Models;
using Server;

public static class AOTTarget_DestinationModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DestinationModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DestinationModel, List<TileModel>>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DestinationModel, CarparkModel>();
	}
}
