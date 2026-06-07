using Factory;
using Motorways.Actions;

public static class AOTTarget_MouseCameraAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MouseCameraAction, IScope>();
	}
}
