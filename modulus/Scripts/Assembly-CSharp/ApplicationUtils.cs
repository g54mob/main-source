using System.Threading;
using UnityEngine;

public class ApplicationUtils
{
	private static bool s_IsApplicationPlaying;

	private static bool s_IsApplicationQuitting;

	private static Thread s_MainThread;

	public static bool IsApplicationPlaying => s_IsApplicationPlaying;

	public static bool IsApplicationQuitting => s_IsApplicationQuitting;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void RunOnStart()
	{
		s_IsApplicationPlaying = true;
		s_IsApplicationQuitting = false;
		Application.quitting += Quit;
		s_MainThread = Thread.CurrentThread;
	}

	private static void Quit()
	{
		s_IsApplicationPlaying = false;
		s_IsApplicationQuitting = true;
		Application.quitting -= Quit;
	}

	public static void QuitApplication()
	{
		Application.Quit();
	}

	public static bool IsMainThread()
	{
		if (!IsApplicationPlaying)
		{
			return true;
		}
		return s_MainThread.Equals(Thread.CurrentThread);
	}
}
