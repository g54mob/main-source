using Factory;
using Motorways.Actions;

public static class AOTTarget_DragTrafficLightAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragTrafficLightAction, IScope>();
	}
}
