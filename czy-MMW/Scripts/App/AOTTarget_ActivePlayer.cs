using Factory;
using Motorways;

public static class AOTTarget_ActivePlayer
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ActivePlayer, IScope>();
	}
}
