using System.Runtime.InteropServices;

public static class GfnRuntimeSdk
{
	private const string DLLName = "GfnRuntimeSdk";

	[DllImport("GfnRuntimeSdk", CallingConvention = CallingConvention.Cdecl)]
	private static extern int gfnInitializeRuntimeSdk(int language);

	[DllImport("GfnRuntimeSdk", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool gfnIsRunningInCloud();

	[DllImport("GfnRuntimeSdk", CallingConvention = CallingConvention.Cdecl)]
	private static extern int gfnShutdownRuntimeSdk();

	public static int InitializeRuntimeSdk()
	{
		return gfnInitializeRuntimeSdk(0);
	}

	public static bool IsRunningInCloud()
	{
		return gfnIsRunningInCloud();
	}

	public static void ShutdownRuntimeSdk()
	{
		gfnShutdownRuntimeSdk();
	}

	public static bool IsError(int code)
	{
		return code < 0;
	}
}
