using Factory;
using Motorways;
using Motorways.Models;

public static class AOTTarget_UpgradeDatabaseModel
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<UpgradeDatabaseModel, int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<UpgradeDatabaseModel, UpgradeType>();
	}
}
