using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragMotorwayHandleAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragMotorwayHandleAction, IScope>();
	}
}
