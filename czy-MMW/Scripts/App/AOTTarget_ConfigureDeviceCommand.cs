using Factory;

public static class AOTTarget_ConfigureDeviceCommand
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<ConfigureDeviceCommand, float>();
	}
}
