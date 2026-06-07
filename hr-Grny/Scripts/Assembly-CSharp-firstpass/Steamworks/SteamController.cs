namespace Steamworks
{
	public static class SteamController
	{
		public static bool Init()
		{
			return false;
		}

		public static bool Shutdown()
		{
			return false;
		}

		public static void RunFrame()
		{
		}

		public static int GetConnectedControllers(ControllerHandle_t[] handlesOut)
		{
			return 0;
		}

		public static bool ShowBindingPanel(ControllerHandle_t controllerHandle)
		{
			return false;
		}

		public static ControllerActionSetHandle_t GetActionSetHandle(string pszActionSetName)
		{
			return default(ControllerActionSetHandle_t);
		}

		public static void ActivateActionSet(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle)
		{
		}

		public static ControllerActionSetHandle_t GetCurrentActionSet(ControllerHandle_t controllerHandle)
		{
			return default(ControllerActionSetHandle_t);
		}

		public static ControllerDigitalActionHandle_t GetDigitalActionHandle(string pszActionName)
		{
			return default(ControllerDigitalActionHandle_t);
		}

		public static ControllerDigitalActionData_t GetDigitalActionData(ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle)
		{
			return default(ControllerDigitalActionData_t);
		}

		public static int GetDigitalActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, EControllerActionOrigin[] originsOut)
		{
			return 0;
		}

		public static ControllerAnalogActionHandle_t GetAnalogActionHandle(string pszActionName)
		{
			return default(ControllerAnalogActionHandle_t);
		}

		public static ControllerAnalogActionData_t GetAnalogActionData(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle)
		{
			return default(ControllerAnalogActionData_t);
		}

		public static int GetAnalogActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, EControllerActionOrigin[] originsOut)
		{
			return 0;
		}

		public static void StopAnalogActionMomentum(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction)
		{
		}

		public static void TriggerHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec)
		{
		}

		public static void TriggerRepeatedHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags)
		{
		}

		public static void TriggerVibration(ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed)
		{
		}

		public static void SetLEDColor(ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags)
		{
		}

		public static int GetGamepadIndexForController(ControllerHandle_t ulControllerHandle)
		{
			return 0;
		}

		public static ControllerHandle_t GetControllerForGamepadIndex(int nIndex)
		{
			return default(ControllerHandle_t);
		}

		public static ControllerMotionData_t GetMotionData(ControllerHandle_t controllerHandle)
		{
			return default(ControllerMotionData_t);
		}

		public static bool ShowDigitalActionOrigins(ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle, float flScale, float flXPosition, float flYPosition)
		{
			return false;
		}

		public static bool ShowAnalogActionOrigins(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle, float flScale, float flXPosition, float flYPosition)
		{
			return false;
		}

		public static string GetStringForActionOrigin(EControllerActionOrigin eOrigin)
		{
			return null;
		}

		public static string GetGlyphForActionOrigin(EControllerActionOrigin eOrigin)
		{
			return null;
		}
	}
}
