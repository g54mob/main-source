using Factory;
using Motorways.Actions;

public static class AOTTarget_ChangeGameSpeedAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ChangeGameSpeedAction, IScope>();
	}
}
