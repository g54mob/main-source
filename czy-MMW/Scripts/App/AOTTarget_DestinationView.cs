using Factory;
using Motorways;
using Motorways.Views;

public static class AOTTarget_DestinationView
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<DestinationView, City>();
	}
}
