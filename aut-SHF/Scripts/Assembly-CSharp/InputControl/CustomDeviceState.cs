using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace InputControl
{
	public struct CustomDeviceState : IInputStateTypeInfo
	{
		[InputControl(layout = "Vector2", displayName = "Position", usage = "Point", dontReset = true)]
		public Vector2 position;

		public FourCC format => default(FourCC);
	}
}
