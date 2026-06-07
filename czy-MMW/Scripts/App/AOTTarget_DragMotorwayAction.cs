using Factory;
using Motorways.Actions;

public static class AOTTarget_DragMotorwayAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragMotorwayAction, IScope>();
	}
}
