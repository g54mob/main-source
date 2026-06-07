using Factory;
using Motorways.Actions;

public static class AOTTarget_DragEditMotorwayAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragEditMotorwayAction, IScope>();
	}
}
