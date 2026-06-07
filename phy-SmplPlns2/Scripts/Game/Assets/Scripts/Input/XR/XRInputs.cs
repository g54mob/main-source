using System.Collections.Generic;
using Assets.Scripts.Settings;
using Assets.Scripts.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;

namespace Assets.Scripts.Input.XR
{
	public static class XRInputs
	{
		public static class Flight
		{
			public static InputActionMap ActionMap { get; private set; }

			public static InputAction CycleTargetingMode { get; private set; }

			public static InputAction FireGuns { get; private set; }

			public static InputAction FireWeapons { get; private set; }

			public static InputAction GripPressedLeft { get; private set; }

			public static InputAction GripPressedRight { get; private set; }

			public static InputAction GripReleasedLeft { get; private set; }

			public static InputAction GripReleasedRight { get; private set; }

			public static InputAction InteractLeft { get; private set; }

			public static InputAction InteractRight { get; private set; }

			public static InputAction LandingGear { get; private set; }

			public static InputAction LaunchCountermeasures { get; private set; }

			public static InputAction MenuLeft { get; private set; }

			public static InputAction MenuRight { get; private set; }

			public static InputAction NextTarget { get; private set; }

			public static InputAction NextView { get; private set; }

			public static InputAction NextWeapon { get; private set; }

			public static InputAction Pause { get; private set; }

			public static InputAction Pitch { get; private set; }

			public static InputAction RecenterView { get; private set; }

			public static InputAction Roll { get; private set; }

			public static InputAction Throttle { get; private set; }

			public static InputAction ThrottleVtolToggle { get; private set; }

			public static InputAction UIClickLeft { get; private set; }

			public static InputAction UIClickRight { get; private set; }

			public static InputAction Vtol { get; private set; }

			public static InputAction Yaw { get; private set; }

			public static List<InputAction> GetInputActions(XRHandType handType, XRControlGripType gripType, string controlId)
			{
				List<InputAction> list = new List<InputAction>(1);
				XRVirtualInputDevice current = XRVirtualInputDevice.Current;
				TrackedDevice xRController = Game.Instance.InputManagerXR.GetXRController(handType);
				if (xRController == null)
				{
					if (DebugSettings.XRControllerLogs)
					{
						Debug.LogError($"Unable to find paired XR Controller for {handType} hand while looking up input action for control '{controlId}' ({handType}Hand / {gripType}).");
					}
					return list;
				}
				ButtonControl control = current.GetControl(handType, gripType);
				InputControl childControl = xRController.GetChildControl(controlId);
				if (childControl == null)
				{
					Debug.LogError($"Unable to find control '{controlId}' on device '{xRController}' while looking up input action for control '{controlId}' ({handType}Hand / {gripType}).");
					return list;
				}
				InputBinding inputBinding = InputBinding.MaskByGroup(Game.Instance.InputManagerXR.PlayerInput.currentControlScheme);
				ReadOnlyArray<InputBinding> bindings = ActionMap.bindings;
				int count = bindings.Count;
				for (int i = 0; i < count; i++)
				{
					InputBinding binding = bindings[i];
					if (binding.isComposite)
					{
						if (i + 2 >= count)
						{
							continue;
						}
						InputBinding binding2 = bindings[i + 1];
						InputBinding binding3 = bindings[i + 2];
						if (binding2.isPartOfComposite && binding3.isPartOfComposite)
						{
							if (binding2.name == "modifier")
							{
								if (string.IsNullOrWhiteSpace(binding3.groups) || inputBinding.Matches(binding3))
								{
									InputControl inputControl = InputControlPath.TryFindControl(current, binding2.effectivePath);
									InputControl inputControl2 = InputControlPath.TryFindControl(xRController, binding3.effectivePath);
									if (inputControl == control && inputControl2 == childControl)
									{
										list.Add(ActionMap.FindAction(binding.action));
									}
								}
							}
							else if (binding3.name == "modifier" && (string.IsNullOrWhiteSpace(binding2.groups) || inputBinding.Matches(binding2)))
							{
								InputControl inputControl3 = InputControlPath.TryFindControl(current, binding3.effectivePath);
								InputControl inputControl4 = InputControlPath.TryFindControl(xRController, binding2.effectivePath);
								if (inputControl3 == control && inputControl4 == childControl)
								{
									list.Add(ActionMap.FindAction(binding.action));
								}
							}
						}
						i += 2;
					}
					else if ((string.IsNullOrWhiteSpace(binding.groups) || inputBinding.Matches(binding)) && InputControlPath.TryFindControl(xRController, binding.effectivePath) == childControl)
					{
						list.Add(ActionMap.FindAction(binding.action));
					}
				}
				return list;
			}

			public static void Initialize(PlayerInput playerInput)
			{
				ActionMap = (Game.Instance.Device.IsVRBuild ? playerInput.actions.FindActionMap("Flight", throwIfNotFound: true) : new InputActionMap());
				InteractLeft = FindAction("InteractLeft");
				InteractRight = FindAction("InteractRight");
				GripPressedLeft = FindAction("GripPressedLeft");
				GripReleasedLeft = FindAction("GripReleasedLeft");
				GripPressedRight = FindAction("GripPressedRight");
				GripReleasedRight = FindAction("GripReleasedRight");
				MenuLeft = FindAction("MenuLeft");
				MenuRight = FindAction("MenuRight");
				Pitch = FindAction("Pitch");
				Roll = FindAction("Roll");
				Yaw = FindAction("Yaw");
				Throttle = FindAction("Throttle");
				ThrottleVtolToggle = FindAction("ThrottleVtolToggle");
				Vtol = ActionMap.FindAction("Vtol");
				LandingGear = ActionMap.FindAction("LandingGear");
				FireGuns = FindAction("FireGuns");
				FireWeapons = FindAction("FireWeapons");
				LaunchCountermeasures = FindAction("LaunchCountermeasures");
				CycleTargetingMode = FindAction("CycleTargetingMode");
				NextTarget = FindAction("NextTarget");
				NextWeapon = FindAction("NextWeapon");
				Pause = FindAction("Pause");
				NextView = FindAction("NextView");
				RecenterView = FindAction("RecenterView");
				UIClickLeft = FindAction("UIClickLeft");
				UIClickRight = FindAction("UIClickRight");
				if (Game.Instance.Device.IsVRBuild)
				{
					GameInputs inputs = Game.Inputs;
					((GameInput)inputs.Pitch).AddInputAction(Pitch);
					((GameInput)inputs.Roll).AddInputAction(Roll);
					((GameInput)inputs.Yaw).AddInputAction(Yaw);
					((GameInput)inputs.Throttle).AddInputAction(Throttle);
					((GameInput)inputs.Vtol).AddInputAction(Vtol);
					((GameInput)inputs.LandingGear).AddInputAction(LandingGear);
					((GameInput)inputs.Pause).AddInputAction(Pause);
					((GameInput)inputs.NextView).AddInputAction(NextView);
					((GameInput)inputs.FireGuns).AddInputAction(FireGuns);
					((GameInput)inputs.FireWeapons).AddInputAction(FireWeapons);
					((GameInput)inputs.LaunchCountermeasures).AddInputAction(LaunchCountermeasures);
					((GameInput)inputs.CycleTargetingMode).AddInputAction(CycleTargetingMode);
					((GameInput)inputs.NextTarget).AddInputAction(NextTarget);
					((GameInput)inputs.NextWeapon).AddInputAction(NextWeapon);
				}
			}

			private static InputAction FindAction(string actionName)
			{
				if (!Game.Instance.Device.IsVRBuild)
				{
					return _dummyInput;
				}
				return ActionMap.FindAction(actionName, throwIfNotFound: true);
			}
		}

		public static class Menu
		{
			public static InputActionMap ActionMap { get; private set; }

			public static InputAction GripLeft { get; private set; }

			public static InputAction GripRight { get; private set; }

			public static InputAction RecenterView { get; private set; }

			public static InputAction UIClickLeft { get; private set; }

			public static InputAction UIClickRight { get; private set; }

			public static InputAction UIScrollLeft { get; private set; }

			public static InputAction UIScrollRight { get; private set; }

			public static void Initialize(PlayerInput playerInput)
			{
				ActionMap = (Game.Instance.Device.IsVRBuild ? playerInput.actions.FindActionMap("Menu", throwIfNotFound: true) : new InputActionMap());
				UIClickLeft = FindAction("UIClickLeft");
				UIClickRight = FindAction("UIClickRight");
				UIScrollLeft = FindAction("UIScrollLeft");
				UIScrollRight = FindAction("UIScrollRight");
				RecenterView = FindAction("RecenterView");
				GripLeft = FindAction("GripLeft");
				GripRight = FindAction("GripRight");
			}

			private static InputAction FindAction(string actionName)
			{
				if (!Game.Instance.Device.IsVRBuild)
				{
					return _dummyInput;
				}
				return ActionMap.FindAction(actionName, throwIfNotFound: true);
			}
		}

		public static class PoseLeftHand
		{
			public static InputActionMap ActionMap { get; private set; }

			public static InputAction DevicePose { get; private set; }

			public static InputAction DevicePosition { get; private set; }

			public static InputAction DeviceRotation { get; private set; }

			public static InputAction Grip { get; private set; }

			public static InputAction PointerPose { get; private set; }

			public static InputAction ThumbTouched { get; private set; }

			public static InputAction Trigger { get; private set; }

			public static InputAction TriggerTouched { get; private set; }

			public static void Initialize(PlayerInput playerInput)
			{
				ActionMap = (Game.Instance.Device.IsVRBuild ? playerInput.actions.FindActionMap("Pose_Left", throwIfNotFound: true) : new InputActionMap());
				DevicePose = FindAction("DevicePose");
				DevicePosition = FindAction("DevicePosition");
				DeviceRotation = FindAction("DeviceRotation");
				PointerPose = FindAction("PointerPose");
				Trigger = FindAction("Trigger");
				Grip = FindAction("Grip");
				TriggerTouched = FindAction("TriggerTouched");
				ThumbTouched = FindAction("ThumbTouched");
			}

			private static InputAction FindAction(string actionName)
			{
				if (!Game.Instance.Device.IsVRBuild)
				{
					return _dummyInput;
				}
				return ActionMap.FindAction(actionName, throwIfNotFound: true);
			}
		}

		public static class PoseRightHand
		{
			public static InputActionMap ActionMap { get; private set; }

			public static InputAction DevicePose { get; private set; }

			public static InputAction DevicePosition { get; private set; }

			public static InputAction DeviceRotation { get; private set; }

			public static InputAction Grip { get; private set; }

			public static InputAction PointerPose { get; private set; }

			public static InputAction ThumbTouched { get; private set; }

			public static InputAction Trigger { get; private set; }

			public static InputAction TriggerTouched { get; private set; }

			public static void Initialize(PlayerInput playerInput)
			{
				ActionMap = (Game.Instance.Device.IsVRBuild ? playerInput.actions.FindActionMap("Pose_Right", throwIfNotFound: true) : new InputActionMap());
				DevicePose = FindAction("DevicePose");
				DevicePosition = FindAction("DevicePosition");
				DeviceRotation = FindAction("DeviceRotation");
				PointerPose = FindAction("PointerPose");
				Trigger = FindAction("Trigger");
				Grip = FindAction("Grip");
				TriggerTouched = FindAction("TriggerTouched");
				ThumbTouched = FindAction("ThumbTouched");
			}

			private static InputAction FindAction(string actionName)
			{
				if (!Game.Instance.Device.IsVRBuild)
				{
					return _dummyInput;
				}
				return ActionMap.FindAction(actionName, throwIfNotFound: true);
			}
		}

		private static InputAction _dummyInput = new InputAction();

		public static void Initialize(PlayerInput playerInput)
		{
			Flight.Initialize(playerInput);
			Menu.Initialize(playerInput);
			PoseLeftHand.Initialize(playerInput);
			PoseRightHand.Initialize(playerInput);
		}
	}
}
