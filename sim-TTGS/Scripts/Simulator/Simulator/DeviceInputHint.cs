using System;

namespace Simulator
{
	public class DeviceInputHint : InputHintStateManagement<DeviceInputHint.EActionStates>
	{
		[Flags]
		public enum EActionStates
		{
			KEYBOARD = 1,
			GAMEPAD = 2
		}
	}
}
