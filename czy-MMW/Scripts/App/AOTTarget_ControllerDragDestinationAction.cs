using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragDestinationAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragDestinationAction, IScope>();
	}
}
