using Factory;
using Motorways.Actions;

public static class AOTTarget_AdvanceTutorialAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<AdvanceTutorialAction, IScope>();
	}
}
