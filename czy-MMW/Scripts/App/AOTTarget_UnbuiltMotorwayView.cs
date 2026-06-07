using Factory;
using Motorways;
using Motorways.Views;

public static class AOTTarget_UnbuiltMotorwayView
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<UnbuiltMotorwayView, City>();
	}
}
