using Factory;
using Motorways.Actions;

public static class AOTTarget_DrawRoadAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DrawRoadAction, IScope>();
	}
}
