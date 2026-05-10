using System;
using System.Runtime.CompilerServices;

[Obsolete("Use SettingsEntry.Set instead", true)]
public static class CameraSettingsInvoker
{
	public static event Action<int> AAChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static void SetAA(int index)
	{
	}
}
