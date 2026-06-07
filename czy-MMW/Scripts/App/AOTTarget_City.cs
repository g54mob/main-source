using Factory;
using Motorways;

public static class AOTTarget_City
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<City, IScope>();
	}
}
