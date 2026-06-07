using System.Runtime.InteropServices;

namespace R3
{
	public static class R3LoopRunners
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3Initialization
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3EarlyUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3FixedUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3PreUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3Update
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3PreLateUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3PostLateUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3TimeUpdate
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct R3PostFixedUpdate
		{
		}
	}
}
