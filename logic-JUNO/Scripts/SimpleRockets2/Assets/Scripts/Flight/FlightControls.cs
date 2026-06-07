using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Input;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;
using ModApi.Input;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class FlightControls
	{
		private CraftNode _craftNode;

		private FlightSceneScript _flightScene;

		private MouseInputSettingsFlight _mouseInputSettings;

		private int _lastActivationFrame = -1;

		private INavSphere _navSphere;

		private CraftControls _nullControls;

		private float _throttleIncrement;

		public float AnalogBrake { get; set; }

		public float AnalogEvaMoveFwdAft { get; set; }

		public float AnalogEvaStrafe { get; set; }

		public float AnalogEvaUpDown { get; set; }

		public float AnalogPitch { get; set; }

		public float AnalogRoll { get; set; }

		public float AnalogThrottle { get; set; }

		public float AnalogYaw { get; set; }

		public CraftControls Controls
		{
			get
			{
				if (_craftNode != null && _craftNode.Controls != null)
				{
					return _craftNode.Controls;
				}
				return _nullControls;
			}
		}

		public bool EnableMouseJoystick { get; set; }

		public float EvaJumpUI { get; set; }

		public bool EvaShootTetherUI { get; set; }

		public INavSphere NavSphere => _navSphere;

		public bool SwapEvaStrafeTurn { get; private set; }

		public bool SwapRollYaw { get; private set; }

		private ICommandPod CommandPod => _craftNode?.CraftScript?.ActiveCommandPod;

		public FlightControls(INavSphere navSphere)
		{
			_nullControls = new CraftControls(null, null);
			_navSphere = navSphere;
			_flightScene = FlightSceneScript.Instance;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputFlight;
		}

		public void ActivateStage()
		{
			if (CommandPod == null)
			{
				return;
			}
			if (!_flightScene.TimeManager.CurrentMode.WarpMode)
			{
				if (_lastActivationFrame != _flightScene.FixedUpdateFrameCount)
				{
					_lastActivationFrame = _flightScene.FixedUpdateFrameCount;
					CommandPod.ActivateStage();
				}
				else
				{
					Debug.Log("Prevented an attempt to activate more than one stage in a single fixed update frame.");
				}
			}
			else
			{
				_flightScene.FlightSceneUI.ShowMessage("Cannot activate stage during time warp");
			}
		}

		public bool GetActivationGroupStatus(int activationGroup)
		{
			if (Controls != null)
			{
				return Controls.GetActivationGroup(activationGroup);
			}
			return false;
		}

		public void ResetAnalogControls()
		{
			AnalogBrake = 0f;
			AnalogEvaMoveFwdAft = 0f;
			AnalogEvaStrafe = 0f;
			AnalogEvaUpDown = 0f;
			AnalogPitch = 0f;
			AnalogRoll = 0f;
			AnalogThrottle = 0f;
			AnalogYaw = 0f;
		}

		public void SetCraftNode(CraftNode craftNode)
		{
			_craftNode = craftNode;
		}

		public void ToggleActivationGroup(int activationGroup)
		{
			if (Controls != null)
			{
				Controls.ToggleActivationGroup(activationGroup);
			}
		}

		public void Update(float timeStep)
		{
			if (_craftNode == null || Game.Instance.UserInterface.AnyDialogsOpen || Game.Instance.UserInterface.IsTextInputFocused)
			{
				return;
			}
			IGameInputs inputs = Game.Instance.Inputs;
			if (inputs.SwapRollYaw.GetButtonDownIfEnabled())
			{
				SwapRollYaw = !SwapRollYaw;
				if (Game.InFlightScene)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Roll and Yaw inputs swapped.");
				}
			}
			if (inputs.SwapEvaStrafeTurn.GetButtonDownIfEnabled())
			{
				SwapEvaStrafeTurn = !SwapEvaStrafeTurn;
				if (Game.InFlightScene)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("EVA Strafe and EVA Turn inputs swapped.");
				}
			}
			if (inputs.ToggleMouseJoystick.GetButtonDownIfEnabled())
			{
				EnableMouseJoystick = !EnableMouseJoystick;
				if (Game.InFlightScene)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage(EnableMouseJoystick ? "Mouse as Joystick Enabled" : "Mouse as Joystick Disabled");
				}
			}
			InputWrapper.UpdateLastInput(inputs.Throttle);
			bool flag = InputWrapper.LastInputWasNormalAxis(inputs.Throttle);
			if (inputs.Throttle.Enabled && !flag)
			{
				_throttleIncrement = Mathf.Clamp(inputs.Throttle.GetAxis(), -1f, 1f);
			}
			float? num = GetControlInput(inputs.Pitch);
			float? num2 = GetControlInput(inputs.Roll);
			float? num3 = GetControlInput(inputs.Yaw);
			float? controlInput = GetControlInput(inputs.Brake);
			if (EnableMouseJoystick)
			{
				Vector2 vector = UnityEngine.Input.mousePosition;
				vector.x /= (float)Screen.width * 0.5f;
				vector.y /= (float)Screen.height * 0.5f;
				vector -= Vector2.one;
				ProcessDeadzone(ref vector.x, _mouseInputSettings.MouseJoystickDeadzoneRoll.Value);
				ProcessDeadzone(ref vector.y, _mouseInputSettings.MouseJoystickDeadzonePitch.Value);
				vector.y = (_mouseInputSettings.MouseJoystickInvertPitch.Value ? (0f - vector.y) : vector.y);
				num = num.GetValueOrDefault() + vector.y;
				num2 = num2.GetValueOrDefault() + vector.x;
			}
			if (SwapRollYaw)
			{
				float? num4 = num3;
				float? num5 = num2;
				num2 = num4;
				num3 = num5;
			}
			float num6 = GetControlInput(inputs.EvaMoveUpDownNoModifier).GetValueOrDefault();
			float num7 = GetControlInput(inputs.EvaPitchNoModifier).GetValueOrDefault();
			float num8 = GetControlInput(inputs.EvaRollNoModifier).GetValueOrDefault();
			float num9 = GetControlInput(inputs.EvaMoveFwdAft).GetValueOrDefault();
			float num10 = GetControlInput(SwapEvaStrafeTurn ? inputs.EvaTurn : inputs.EvaStrafe).GetValueOrDefault();
			float num11 = GetControlInput(SwapEvaStrafeTurn ? inputs.EvaStrafe : inputs.EvaTurn).GetValueOrDefault();
			IGameInput evaEnableJetpackMovement = inputs.EvaEnableJetpackMovement;
			if (!evaEnableJetpackMovement.IsBound || evaEnableJetpackMovement.GetButton())
			{
				if (evaEnableJetpackMovement.IsBound)
				{
					num9 = 0f;
					num10 = 0f;
					num11 = 0f;
				}
				num6 += GetControlInput(inputs.EvaMoveUpDown).GetValueOrDefault();
				num7 += GetControlInput(inputs.EvaPitch).GetValueOrDefault();
				num8 += GetControlInput(inputs.EvaRoll).GetValueOrDefault();
			}
			Controls.PitchInputReceived = false;
			Controls.RollInputReceived = false;
			Controls.YawInputReceived = false;
			Controls.TranslateUp = 0f;
			Controls.TranslateRight = 0f;
			Controls.TranslateForward = 0f;
			if (!_craftNode.Controls.TranslationModeEnabled)
			{
				if (num2.HasValue && (!_navSphere.HeadingLocked || num2.Value + AnalogRoll != 0f))
				{
					Controls.Roll = Mathf.Clamp(num2.Value + AnalogRoll + Controls.OffsetRoll, -1f, 1f);
					Controls.RollInputReceived = num2.Value + AnalogRoll != 0f;
				}
				if (num.HasValue && (!_navSphere.HeadingLocked || num.Value + AnalogPitch != 0f))
				{
					Controls.Pitch = Mathf.Clamp(num.Value + AnalogPitch + Controls.OffsetPitch, -1f, 1f);
					Controls.PitchInputReceived = num.Value + AnalogPitch != 0f;
				}
				if (num3.HasValue && (!_navSphere.HeadingLocked || num3.Value + AnalogYaw != 0f))
				{
					Controls.Yaw = Mathf.Clamp(num3.Value + AnalogYaw + Controls.OffsetYaw, -1f, 1f);
					Controls.YawInputReceived = num3.Value + AnalogYaw != 0f;
				}
				if (_navSphere.HeadingLocked)
				{
					_navSphere.LockHeading(_navSphere.Pitch, _navSphere.Heading);
				}
				Controls.TranslateUp = Mathf.Clamp(Controls.OffsetTranslateUp, -1f, 1f);
				Controls.TranslateForward = Mathf.Clamp(Controls.OffsetTranslateForward, -1f, 1f);
				Controls.TranslateRight = Mathf.Clamp(Controls.OffsetTranslateRight, -1f, 1f);
			}
			else
			{
				if (num2.HasValue)
				{
					Controls.TranslateUp = Mathf.Clamp(num.Value + AnalogPitch + Controls.OffsetTranslateUp, -1f, 1f);
				}
				if (num.HasValue)
				{
					Controls.TranslateForward = Mathf.Clamp(num2.Value + AnalogThrottle + Controls.OffsetTranslateForward, -1f, 1f);
				}
				if (num3.HasValue)
				{
					Controls.TranslateRight = Mathf.Clamp(num3.Value + AnalogRoll + Controls.OffsetTranslateRight, -1f, 1f);
				}
			}
			Controls.TranslateUp = Mathf.Clamp((Controls.TranslateUp + GetControlInput(inputs.TranslateUpDown)).GetValueOrDefault(), -1f, 1f);
			Controls.TranslateRight = Mathf.Clamp((Controls.TranslateRight + GetControlInput(inputs.TranslateLeftRight)).GetValueOrDefault(), -1f, 1f);
			Controls.TranslateForward = Mathf.Clamp((Controls.TranslateForward + GetControlInput(inputs.TranslateForwardBackward)).GetValueOrDefault(), -1f, 1f);
			Controls.EvaAnalogJump = EvaJumpUI;
			Controls.EvaMoveFwdAft = Mathf.Clamp(num9 + AnalogEvaMoveFwdAft, -1f, 1f);
			Controls.EvaStrafe = Mathf.Clamp(num10 + AnalogEvaStrafe, -1f, 1f);
			Controls.EvaTurn = Mathf.Clamp(num11 + AnalogYaw, -1f, 1f);
			Controls.EvaMoveUpDown = Mathf.Clamp(num6 + AnalogEvaUpDown, -1f, 1f);
			Controls.EvaPitch = Mathf.Clamp(num7 + AnalogPitch, -1f, 1f);
			Controls.EvaRoll = Mathf.Clamp(num8 + AnalogRoll, -1f, 1f);
			Controls.EvaShootTether = inputs.EvaShootTether.GetButtonDownIfEnabled() || EvaShootTetherUI;
			Controls.EvaTetherLength = Mathf.Clamp(inputs.EvaTetherLength.GetAxis() + Controls.EvaTetherLengthOffset, -1f, 1f);
			if (controlInput.HasValue)
			{
				Controls.Brake = Mathf.Clamp(controlInput.Value + AnalogBrake + Controls.OffsetBrake, -1f, 1f);
			}
			if (inputs.Throttle.Enabled)
			{
				if (flag)
				{
					Controls.Throttle = inputs.Throttle.GetAxis();
				}
				else
				{
					Controls.Throttle += timeStep * (_throttleIncrement + (Controls.TranslationModeEnabled ? 0f : AnalogThrottle));
				}
				Controls.Throttle = Mathf.Clamp01(Controls.Throttle);
			}
			if (inputs.KillThrottle.GetButtonDownIfEnabled())
			{
				Controls.Throttle = 0f;
			}
			else if (inputs.FullThrottle.GetButtonDownIfEnabled())
			{
				Controls.Throttle = 1f;
			}
			if (inputs.Slider1.Enabled)
			{
				Controls.Slider1 = Mathf.Clamp(inputs.Slider1.GetAxis() + Controls.OffsetSlider1, -1f, 1f);
			}
			if (inputs.Slider2.Enabled)
			{
				Controls.Slider2 = Mathf.Clamp(inputs.Slider2.GetAxis() + Controls.OffsetSlider2, -1f, 1f);
			}
			if (inputs.Slider3.Enabled)
			{
				Controls.Slider3 = Mathf.Clamp(inputs.Slider3.GetAxis() + Controls.OffsetSlider3, -1f, 1f);
			}
			if (inputs.Slider4.Enabled)
			{
				Controls.Slider4 = Mathf.Clamp(inputs.Slider4.GetAxis() + Controls.OffsetSlider4, -1f, 1f);
			}
			if (inputs.ActivateStage.GetButtonDownIfEnabled())
			{
				ActivateStage();
			}
			if (!_flightScene.TimeManager.Paused && inputs.EvaToggleWalk.GetButtonUpIfEnabled())
			{
				Controls.EvaWalk = !Controls.EvaWalk;
				_flightScene.FlightSceneUI.ShowMessage((Controls.EvaWalk ? "Walking" : "Running") ?? "");
			}
			if (inputs.ActivationGroup1.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(1);
			}
			if (inputs.ActivationGroup2.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(2);
			}
			if (inputs.ActivationGroup3.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(3);
			}
			if (inputs.ActivationGroup4.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(4);
			}
			if (inputs.ActivationGroup5.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(5);
			}
			if (inputs.ActivationGroup6.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(6);
			}
			if (inputs.ActivationGroup7.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(7);
			}
			if (inputs.ActivationGroup8.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(8);
			}
			if (inputs.ActivationGroup9.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(9);
			}
			if (inputs.ActivationGroup10.GetButtonDownIfEnabled())
			{
				Controls.ToggleActivationGroup(10);
			}
			if (inputs.LockHeading.GetButtonDownIfEnabled())
			{
				if (!_navSphere.HeadingLocked)
				{
					_navSphere.LockCurrentHeading();
				}
				else
				{
					_navSphere.UnlockHeading();
				}
			}
			if (inputs.LockPrograde.GetButtonDownIfEnabled())
			{
				_navSphere.ToggleProgradeLock();
			}
			if (inputs.LockRetrograde.GetButtonDownIfEnabled())
			{
				_navSphere.ToggleRetrogradeLock();
			}
			if (inputs.LockTarget.GetButtonDownIfEnabled())
			{
				_navSphere.ToggleTargetLock();
			}
			if (inputs.ToggleTranslationMode.GetButtonDownIfEnabled())
			{
				Controls.ToggleTranslationMode();
			}
			if (inputs.ActivateCameraLook.GetButtonDown())
			{
				inputs.ActivateCameraLook.Enabled = !inputs.ActivateCameraLook.Enabled;
			}
			static void ProcessDeadzone(ref float value, float deadzone)
			{
				if (deadzone > 0.9f)
				{
					deadzone = 0.9f;
				}
				if (value > deadzone)
				{
					value = (value - deadzone) / (1f - deadzone);
				}
				else if (value < 0f - deadzone)
				{
					value = (value + deadzone) / (1f - deadzone);
				}
				else
				{
					value = 0f;
				}
			}
		}

		private float? GetControlInput(IGameInput input)
		{
			float? result = null;
			if (input.Enabled)
			{
				result = Mathf.Clamp(input.GetAxis(), -1f, 1f);
			}
			return result;
		}
	}
}
