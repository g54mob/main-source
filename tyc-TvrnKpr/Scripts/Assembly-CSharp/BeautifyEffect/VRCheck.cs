using System.Collections.Generic;
using UnityEngine.XR;

namespace BeautifyEffect
{
	internal static class VRCheck
	{
		public static bool isActive;

		public static bool isVrRunning;

		private static readonly List<XRDisplaySubsystemDescriptor> displaysDescs;

		private static readonly List<XRDisplaySubsystem> displays;

		private static bool IsActive()
		{
			return false;
		}

		private static bool IsVrRunning()
		{
			return false;
		}

		public static void Init()
		{
		}
	}
}
