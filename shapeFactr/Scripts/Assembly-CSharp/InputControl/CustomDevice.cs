using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace InputControl
{
	[InputControlLayout(displayName = "Custom Pointer Device", stateType = typeof(CustomDeviceState))]
	public class CustomDevice : Pointer, IInputUpdateCallbackReceiver
	{
		private static CustomDevice s_Instance;

		private CustomDeviceState m_PreviousState;

		private bool m_IsInitialized;

		public new static CustomDevice current => null;

		static CustomDevice()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
		}

		public void OnUpdate()
		{
		}

		private bool StateEquals(CustomDeviceState a, CustomDeviceState b)
		{
			return false;
		}

		protected override void OnRemoved()
		{
		}

		public override void MakeCurrent()
		{
		}
	}
}
