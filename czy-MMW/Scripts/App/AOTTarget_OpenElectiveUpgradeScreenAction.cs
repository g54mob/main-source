using Factory;
using Motorways.Actions;

public static class AOTTarget_OpenElectiveUpgradeScreenAction
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<OpenElectiveUpgradeScreenAction, IScope>();
	}
}
