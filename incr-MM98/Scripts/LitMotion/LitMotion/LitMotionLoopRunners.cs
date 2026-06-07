using System.Runtime.InteropServices;

namespace LitMotion
{
	public static class LitMotionLoopRunners
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionInitialization
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionEarlyUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionFixedUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionPreUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionPreLateUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionPostLateUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct LitMotionTimeUpdate
		{
		}
	}
}
