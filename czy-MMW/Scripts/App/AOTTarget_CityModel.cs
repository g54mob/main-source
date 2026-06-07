using Factory;
using Motorways;
using Motorways.Models;
using Server;

public static class AOTTarget_CityModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<CityModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<CityModel, GameMode>();
	}
}
