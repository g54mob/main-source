using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragMotorwayAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragMotorwayAction, IScope>();
	}
}
