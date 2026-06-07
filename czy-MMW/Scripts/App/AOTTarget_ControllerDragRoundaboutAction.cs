using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragRoundaboutAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragRoundaboutAction, IScope>();
	}
}
