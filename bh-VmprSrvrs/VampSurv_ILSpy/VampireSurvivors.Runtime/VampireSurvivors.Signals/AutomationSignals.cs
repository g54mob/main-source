using System.Runtime.InteropServices;

namespace VampireSurvivors.Signals;

public static class AutomationSignals
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RedDamageSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct BlueDamageSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CancelAutomationSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct AutomationGameSessionInitializedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct AutomationSplashScreenInitializedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct AutomationIntroWarningScreenInitializedSignal
	{
	}

	public struct TestFinished
	{
		public string TestName;
	}
}
