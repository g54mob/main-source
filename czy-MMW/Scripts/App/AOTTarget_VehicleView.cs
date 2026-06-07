using Factory;
using Motorways;
using Motorways.Views;

public static class AOTTarget_VehicleView
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<VehicleView, City>();
	}
}
