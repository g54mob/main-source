using Factory;
using Motorways.Actions;

public static class AOTTarget_DragMotorwayHandleAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragMotorwayHandleAction, IScope>();
	}
}
