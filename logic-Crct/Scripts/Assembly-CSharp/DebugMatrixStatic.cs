using Simulation;

public static class DebugMatrixStatic
{
	[MonoPInvokeCallback(typeof(Circuit.DebugCallback))]
	public static void ValueInserted()
	{
	}
}
