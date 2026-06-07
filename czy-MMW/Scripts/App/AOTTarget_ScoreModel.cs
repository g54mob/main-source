using Factory;
using FixMath;
using Motorways.Models;
using Server;

public static class AOTTarget_ScoreModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ScoreModel, Clock>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ScoreModel, int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ScoreModel, Fix64>();
	}
}
