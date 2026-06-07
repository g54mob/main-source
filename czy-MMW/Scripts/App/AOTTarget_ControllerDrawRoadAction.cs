using Factory;
using Motorways.Actions;

public static class AOTTarget_ControllerDrawRoadAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ControllerDrawRoadAction, IScope>();
	}
}
