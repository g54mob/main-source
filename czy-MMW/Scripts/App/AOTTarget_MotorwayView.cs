using Factory;
using Motorways;
using Motorways.Views;

public static class AOTTarget_MotorwayView
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwayView, City>();
	}
}
