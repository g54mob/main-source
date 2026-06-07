using Factory;
using Motorways.Actions;

public static class AOTTarget_TouchCameraAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TouchCameraAction, IScope>();
	}
}
