using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerEditMenuNavigateAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerEditMenuNavigateAction, IScope>();
	}
}
