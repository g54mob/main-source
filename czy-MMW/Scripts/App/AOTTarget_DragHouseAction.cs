using Factory;
using Motorways.Actions;

public static class AOTTarget_DragHouseAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragHouseAction, IScope>();
	}
}
