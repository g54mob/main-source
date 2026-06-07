using Factory;
using Motorways.Actions;

public static class AOTTarget_DragRoundaboutAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragRoundaboutAction, IScope>();
	}
}
