using Factory;
using Motorways.Actions;

public static class AOTTarget_DragDestinationAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragDestinationAction, IScope>();
	}
}
