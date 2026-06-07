using Factory;
using Motorways;
using Motorways.Views;

public static class AOTTarget_TrafficLightView
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<TrafficLightView, City>();
	}
}
