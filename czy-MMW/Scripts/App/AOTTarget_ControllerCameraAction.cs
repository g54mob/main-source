using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerCameraAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerCameraAction, IScope>();
	}
}
