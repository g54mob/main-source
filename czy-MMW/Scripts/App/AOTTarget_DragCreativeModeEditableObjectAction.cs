using Factory;
using Motorways.Actions;

public static class AOTTarget_DragCreativeModeEditableObjectAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DragCreativeModeEditableObjectAction, IScope>();
	}
}
