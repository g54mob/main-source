using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	public class ExternalTools : IExternalTools
	{
		private static Func<object> _getPlatformInitializerDelegate;

		private bool _isEditorPaused;

		private Action<bool> _EditorPausedStateChangedEvent;

		public static Func<object> getPlatformInitializerDelegate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool isEditorPaused => false;

		public bool UnityInput_IsTouchPressureSupported => false;

		public event Action<bool> EditorPausedStateChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<uint, bool> XboxOneInput_OnGamepadStateChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Destroy()
		{
		}

		public object GetPlatformInitializer()
		{
			return null;
		}

		public string GetFocusedEditorWindowTitle()
		{
			return null;
		}

		public bool IsEditorSceneViewFocused()
		{
			return false;
		}

		public bool LinuxInput_IsJoystickPreconfigured(string name)
		{
			return false;
		}

		public int XboxOneInput_GetUserIdForGamepad(uint id)
		{
			return 0;
		}

		public ulong XboxOneInput_GetControllerId(uint unityJoystickId)
		{
			return 0uL;
		}

		public bool XboxOneInput_IsGamepadActive(uint unityJoystickId)
		{
			return false;
		}

		public string XboxOneInput_GetControllerType(ulong xboxControllerId)
		{
			return null;
		}

		public uint XboxOneInput_GetJoystickId(ulong xboxControllerId)
		{
			return 0u;
		}

		public void XboxOne_Gamepad_UpdatePlugin()
		{
		}

		public bool XboxOne_Gamepad_SetGamepadVibration(ulong xboxOneJoystickId, float leftMotor, float rightMotor, float leftTriggerLevel, float rightTriggerLevel)
		{
			return false;
		}

		public void XboxOne_Gamepad_PulseVibrateMotor(ulong xboxOneJoystickId, int motorInt, float startLevel, float endLevel, ulong durationMS)
		{
		}

		public Vector3 PS4Input_GetLastAcceleration(int id)
		{
			return default(Vector3);
		}

		public Vector3 PS4Input_GetLastGyro(int id)
		{
			return default(Vector3);
		}

		public Vector4 PS4Input_GetLastOrientation(int id)
		{
			return default(Vector4);
		}

		public void PS4Input_GetLastTouchData(int id, out int touchNum, out int touch0x, out int touch0y, out int touch0id, out int touch1x, out int touch1y, out int touch1id)
		{
			touchNum = default(int);
			touch0x = default(int);
			touch0y = default(int);
			touch0id = default(int);
			touch1x = default(int);
			touch1y = default(int);
			touch1id = default(int);
		}

		public void PS4Input_GetPadControllerInformation(int id, out float touchpixelDensity, out int touchResolutionX, out int touchResolutionY, out int analogDeadZoneLeft, out int analogDeadZoneright, out int connectionType)
		{
			touchpixelDensity = default(float);
			touchResolutionX = default(int);
			touchResolutionY = default(int);
			analogDeadZoneLeft = default(int);
			analogDeadZoneright = default(int);
			connectionType = default(int);
		}

		public void PS4Input_PadSetMotionSensorState(int id, bool bEnable)
		{
		}

		public void PS4Input_PadSetTiltCorrectionState(int id, bool bEnable)
		{
		}

		public void PS4Input_PadSetAngularVelocityDeadbandState(int id, bool bEnable)
		{
		}

		public void PS4Input_PadSetLightBar(int id, int red, int green, int blue)
		{
		}

		public void PS4Input_PadResetLightBar(int id)
		{
		}

		public void PS4Input_PadSetVibration(int id, int largeMotor, int smallMotor)
		{
		}

		public void PS4Input_PadResetOrientation(int id)
		{
		}

		public bool PS4Input_PadIsConnected(int id)
		{
			return false;
		}

		public void PS4Input_GetUsersDetails(int slot, object loggedInUser)
		{
		}

		public int PS4Input_GetDeviceClassForHandle(int handle)
		{
			return 0;
		}

		public string PS4Input_GetDeviceClassString(int intValue)
		{
			return null;
		}

		public int PS4Input_PadGetUsersHandles2(int maxControllers, int[] handles)
		{
			return 0;
		}

		public void PS4Input_GetSpecialControllerInformation(int id, int padIndex, object controllerInformation)
		{
		}

		public Vector3 PS4Input_SpecialGetLastAcceleration(int id)
		{
			return default(Vector3);
		}

		public Vector3 PS4Input_SpecialGetLastGyro(int id)
		{
			return default(Vector3);
		}

		public Vector4 PS4Input_SpecialGetLastOrientation(int id)
		{
			return default(Vector4);
		}

		public int PS4Input_SpecialGetUsersHandles(int maxNumberControllers, int[] handles)
		{
			return 0;
		}

		public int PS4Input_SpecialGetUsersHandles2(int maxNumberControllers, int[] handles)
		{
			return 0;
		}

		public bool PS4Input_SpecialIsConnected(int id)
		{
			return false;
		}

		public void PS4Input_SpecialResetLightSphere(int id)
		{
		}

		public void PS4Input_SpecialResetOrientation(int id)
		{
		}

		public void PS4Input_SpecialSetAngularVelocityDeadbandState(int id, bool bEnable)
		{
		}

		public void PS4Input_SpecialSetLightSphere(int id, int red, int green, int blue)
		{
		}

		public void PS4Input_SpecialSetMotionSensorState(int id, bool bEnable)
		{
		}

		public void PS4Input_SpecialSetTiltCorrectionState(int id, bool bEnable)
		{
		}

		public void PS4Input_SpecialSetVibration(int id, int largeMotor, int smallMotor)
		{
		}

		public Vector3 PS4Input_AimGetLastAcceleration(int id)
		{
			return default(Vector3);
		}

		public Vector3 PS4Input_AimGetLastGyro(int id)
		{
			return default(Vector3);
		}

		public Vector4 PS4Input_AimGetLastOrientation(int id)
		{
			return default(Vector4);
		}

		public int PS4Input_AimGetUsersHandles(int maxNumberControllers, int[] handles)
		{
			return 0;
		}

		public int PS4Input_AimGetUsersHandles2(int maxNumberControllers, int[] handles)
		{
			return 0;
		}

		public bool PS4Input_AimIsConnected(int id)
		{
			return false;
		}

		public void PS4Input_AimResetLightSphere(int id)
		{
		}

		public void PS4Input_AimResetOrientation(int id)
		{
		}

		public void PS4Input_AimSetAngularVelocityDeadbandState(int id, bool bEnable)
		{
		}

		public void PS4Input_AimSetLightSphere(int id, int red, int green, int blue)
		{
		}

		public void PS4Input_AimSetMotionSensorState(int id, bool bEnable)
		{
		}

		public void PS4Input_AimSetTiltCorrectionState(int id, bool bEnable)
		{
		}

		public void PS4Input_AimSetVibration(int id, int largeMotor, int smallMotor)
		{
		}

		public Vector3 PS4Input_GetLastMoveAcceleration(int id, int index)
		{
			return default(Vector3);
		}

		public Vector3 PS4Input_GetLastMoveGyro(int id, int index)
		{
			return default(Vector3);
		}

		public int PS4Input_MoveGetButtons(int id, int index)
		{
			return 0;
		}

		public int PS4Input_MoveGetAnalogButton(int id, int index)
		{
			return 0;
		}

		public bool PS4Input_MoveIsConnected(int id, int index)
		{
			return false;
		}

		public int PS4Input_MoveGetUsersMoveHandles(int maxNumberControllers, int[] primaryHandles, int[] secondaryHandles)
		{
			return 0;
		}

		public int PS4Input_MoveGetUsersMoveHandles(int maxNumberControllers, int[] primaryHandles)
		{
			return 0;
		}

		public int PS4Input_MoveGetUsersMoveHandles(int maxNumberControllers)
		{
			return 0;
		}

		public IntPtr PS4Input_MoveGetControllerInputForTracking()
		{
			return (IntPtr)0;
		}

		public int PS4Input_MoveSetLightSphere(int id, int index, int red, int green, int blue)
		{
			return 0;
		}

		public int PS4Input_MoveSetVibration(int id, int index, int motor)
		{
			return 0;
		}

		public void GetDeviceVIDPIDs(out List<int> vids, out List<int> pids)
		{
			vids = null;
			pids = null;
		}

		public int GetAndroidAPILevel()
		{
			return 0;
		}

		public bool UnityUI_Graphic_GetRaycastTarget(object graphic)
		{
			return false;
		}

		public void UnityUI_Graphic_SetRaycastTarget(object graphic, bool value)
		{
		}

		public float UnityInput_GetTouchPressure(ref Touch touch)
		{
			return 0f;
		}

		public float UnityInput_GetTouchMaximumPossiblePressure(ref Touch touch)
		{
			return 0f;
		}

		public IControllerTemplate CreateControllerTemplate(Guid typeGuid, object payload)
		{
			return null;
		}

		public Type[] GetControllerTemplateTypes()
		{
			return null;
		}

		public Type[] GetControllerTemplateInterfaceTypes()
		{
			return null;
		}
	}
}
