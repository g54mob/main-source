using Factory;
using FixMath;
using Motorways.Models;

public static class AOTTarget_CityPlanModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<CityPlanModel, Fix64>();
	}
}
