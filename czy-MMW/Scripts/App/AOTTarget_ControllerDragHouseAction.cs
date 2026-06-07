using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragHouseAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragHouseAction, IScope>();
	}
}
