using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragTrafficLightAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragTrafficLightAction, IScope>();
	}
}
