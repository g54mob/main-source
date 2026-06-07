using Rewired.Platforms.Custom;
using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	public sealed class CustomPlatformManager : MonoBehaviour, ICustomPlatformInitializer
	{
		public CustomPlatformHardwareJoystickMapProvider mapProvider;

		public CustomPlatformInitOptions GetCustomPlatformInitOptions()
		{
			return null;
		}
	}
}
