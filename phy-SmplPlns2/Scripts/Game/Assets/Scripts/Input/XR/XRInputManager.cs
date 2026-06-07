using System;
using System.Linq;
using Assets.Scripts.Settings;
using Assets.Scripts.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;

namespace Assets.Scripts.Input.XR
{
	public class XRInputManager : MonoBehaviour
	{
		public PlayerInput PlayerInput { get; private set; }

		public TrackedDevice GetXRController(XRHandType handType)
		{
			InternedString value = ((handType == XRHandType.Left) ? CommonUsages.LeftHand : CommonUsages.RightHand);
			foreach (InputDevice device in PlayerInput.devices)
			{
				if (device is TrackedDevice trackedDevice && Enumerable.Contains(trackedDevice.usages, value))
				{
					return trackedDevice;
				}
			}
			return null;
		}

		protected virtual void Awake()
		{
			PlayerInput = GetComponent<PlayerInput>();
			XRInputs.Initialize(PlayerInput);
			if (Game.Instance.Device.IsVRBuild)
			{
				InputDevice[] array = UnityEngine.InputSystem.InputSystem.devices.Where((InputDevice x) => Enumerable.Contains(x.usages, CommonUsages.LeftHand) || Enumerable.Contains(x.usages, CommonUsages.RightHand)).ToArray();
				UnityEngine.InputSystem.InputSystem.onDeviceChange += OnDeviceChange;
				InputDevice[] array2 = array;
				foreach (InputDevice device in array2)
				{
					OnDeviceChange(device, InputDeviceChange.Added);
				}
			}
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			InputWrapper.Player.controllers.Mouse.enabled = focus;
			InputWrapper.Player.controllers.Keyboard.enabled = focus;
		}

		protected virtual void OnDestroy()
		{
			if (Game.Instance.Device.IsVRBuild)
			{
				UnityEngine.InputSystem.InputSystem.onDeviceChange -= OnDeviceChange;
			}
		}

		private void OnDeviceChange(InputDevice device, InputDeviceChange change)
		{
			if (change != InputDeviceChange.Added)
			{
				return;
			}
			ReadOnlyArray<InputControlScheme> controlSchemes = PlayerInput.actions.controlSchemes;
			InputUser user = PlayerInput.user;
			if (!controlSchemes.Any((InputControlScheme x) => x.SupportsDevice(device)))
			{
				return;
			}
			InputUser.PerformPairingWithDevice(device, user);
			if (DebugSettings.XRControllerLogs)
			{
				Debug.Log($"Pairing Device: {device} {System.Environment.NewLine}" + "Paired Devices: " + string.Join(", ", PlayerInput.devices.Select((InputDevice x) => x.ToString())));
			}
			InputControlScheme? inputControlScheme = InputControlScheme.FindControlSchemeForDevices(user.pairedDevices, controlSchemes);
			if (XRDeviceManager.IsMockRuntime)
			{
				inputControlScheme = controlSchemes.Where((InputControlScheme x) => x.name == "Unity Mock Runtime").First();
				Mouse current = Mouse.current;
				if (current != null && !Enumerable.Contains(PlayerInput.devices, current))
				{
					InputUser.PerformPairingWithDevice(current, user);
				}
			}
			if (inputControlScheme.HasValue && inputControlScheme.Value.name != PlayerInput.currentControlScheme)
			{
				PlayerInput.SwitchCurrentControlScheme(inputControlScheme.Value.name, user.pairedDevices.ToArray());
				if (DebugSettings.XRControllerLogs)
				{
					Debug.Log("Control Scheme Changed: " + PlayerInput.currentControlScheme);
				}
			}
		}
	}
}
