using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMDebugMenuCommands : MonoBehaviour
	{
		[MMDebugLogCommand]
		public static void Now()
		{
		}

		[MMDebugLogCommand]
		public static void Clear()
		{
		}

		[MMDebugLogCommand]
		public static void Restart()
		{
		}

		[MMDebugLogCommand]
		public static void Reload()
		{
		}

		[MMDebugLogCommand]
		public static void Sysinfo()
		{
		}

		[MMDebugLogCommand]
		public static void Quit()
		{
		}

		[MMDebugLogCommand]
		public static void Exit()
		{
		}

		[MMDebugLogCommand]
		public static void Help()
		{
		}

		private static void InternalQuit()
		{
		}

		[MMDebugLogCommand]
		[MMDebugLogCommandArgumentCount(1)]
		public static void Vsync(string[] args)
		{
		}

		[MMDebugLogCommand]
		[MMDebugLogCommandArgumentCount(1)]
		public static void Framerate(string[] args)
		{
		}

		[MMDebugLogCommand]
		[MMDebugLogCommandArgumentCount(1)]
		public static void Timescale(string[] args)
		{
		}

		[MMDebugLogCommand]
		[MMDebugLogCommandArgumentCount(2)]
		public static void Biggest(string[] args)
		{
		}
	}
}
