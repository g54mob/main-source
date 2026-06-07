using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDragEditMotorwayAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDragEditMotorwayAction, IScope>();
	}
}
