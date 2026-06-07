using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;
using UnityEngine;

namespace ModApi.Craft
{
	public class CraftControls
	{
		public delegate void TargetHeadingChangedHandler(Quaterniond? newHeading, Quaterniond? oldHeading);

		private ICommandPod _commandPod;

		private Quaterniond? _targetHeading;

		private bool _translationModeEnabled;

		public float Brake { get; set; }

		public float EvaAnalogJump { get; set; }

		public float EvaMoveFwdAft { get; set; }

		public float EvaMoveUpDown { get; set; }

		public float EvaPitch { get; set; }

		public float EvaRoll { get; set; }

		public bool EvaShootTether { get; set; }

		public float EvaStrafe { get; set; }

		public float EvaTetherLength { get; set; }

		public float EvaTetherLengthOffset { get; set; }

		public float EvaTurn { get; set; }

		public bool EvaWalk { get; set; }

		public float OffsetBrake { get; set; }

		public float OffsetPitch { get; set; }

		public float OffsetRoll { get; set; }

		public float OffsetSlider1 { get; set; }

		public float OffsetSlider2 { get; set; }

		public float OffsetSlider3 { get; set; }

		public float OffsetSlider4 { get; set; }

		public float OffsetTranslateForward { get; set; }

		public float OffsetTranslateRight { get; set; }

		public float OffsetTranslateUp { get; set; }

		public float OffsetYaw { get; set; }

		public float Pitch { get; set; }

		public bool PitchInputReceived { get; set; }

		public float Roll { get; set; }

		public bool RollInputReceived { get; set; }

		public float Slider1 { get; set; }

		public float Slider2 { get; set; }

		public float Slider3 { get; set; }

		public float Slider4 { get; set; }

		public Vector3d? TargetDirection
		{
			get
			{
				if (TargetHeading.HasValue)
				{
					return TargetHeading.Value * Vector3d.up;
				}
				return null;
			}
		}

		public Quaterniond? TargetHeading
		{
			get
			{
				return _targetHeading;
			}
			set
			{
				Quaterniond? targetHeading = _targetHeading;
				_targetHeading = value;
				if (targetHeading != value)
				{
					this.TargetHeadingChanged?.Invoke(value, targetHeading);
				}
			}
		}

		public float Throttle { get; set; }

		public float TranslateForward { get; set; }

		public float TranslateRight { get; set; }

		public float TranslateUp { get; set; }

		public bool TranslationModeEnabled
		{
			get
			{
				return _translationModeEnabled;
			}
			set
			{
				if (_translationModeEnabled != value)
				{
					_translationModeEnabled = value;
					Roll = 0f;
					Yaw = 0f;
					Pitch = 0f;
					OffsetRoll = 0f;
					OffsetYaw = 0f;
					OffsetPitch = 0f;
					TranslateForward = 0f;
					TranslateUp = 0f;
					TranslateRight = 0f;
					OffsetTranslateForward = 0f;
					OffsetTranslateRight = 0f;
					OffsetTranslateUp = 0f;
				}
			}
		}

		public float Yaw { get; set; }

		public bool YawInputReceived { get; set; }

		public event TargetHeadingChangedHandler TargetHeadingChanged;

		public CraftControls(ICommandPod commandPod, XElement stateXml)
		{
			_commandPod = commandPod;
			if (stateXml != null)
			{
				Brake = (OffsetBrake = stateXml.GetFloatAttribute("brake"));
				Pitch = (OffsetPitch = stateXml.GetFloatAttribute("pitch"));
				Roll = (OffsetRoll = stateXml.GetFloatAttribute("roll"));
				Slider1 = (OffsetSlider1 = stateXml.GetFloatAttribute("slider1"));
				Slider2 = (OffsetSlider2 = stateXml.GetFloatAttribute("slider2"));
				Slider3 = (OffsetSlider3 = stateXml.GetFloatAttribute("slider3"));
				Slider4 = (OffsetSlider4 = stateXml.GetFloatAttribute("slider4"));
				Yaw = (OffsetYaw = stateXml.GetFloatAttribute("yaw"));
				Throttle = stateXml.GetFloatAttribute("throttle");
				TranslateForward = (OffsetTranslateForward = stateXml.GetFloatAttribute("forward"));
				TranslateRight = (OffsetTranslateRight = stateXml.GetFloatAttribute("right"));
				TranslateUp = (OffsetTranslateUp = stateXml.GetFloatAttribute("up"));
				EvaMoveFwdAft = stateXml.GetFloatAttribute("evaMoveFwdAft");
				EvaPitch = stateXml.GetFloatAttribute("evaPitch");
				EvaRoll = stateXml.GetFloatAttribute("evaRoll");
				EvaStrafe = stateXml.GetFloatAttribute("evaStrafe");
				EvaTurn = stateXml.GetFloatAttribute("evaTurn");
			}
		}

		public static void CopyControls(CraftControls sourceControls, CraftControls destControls)
		{
			destControls.Brake = sourceControls.Brake;
			destControls.OffsetBrake = sourceControls.OffsetBrake;
			destControls.OffsetPitch = sourceControls.OffsetPitch;
			destControls.OffsetRoll = sourceControls.OffsetRoll;
			destControls.OffsetSlider1 = sourceControls.OffsetSlider1;
			destControls.OffsetSlider2 = sourceControls.OffsetSlider2;
			destControls.OffsetSlider3 = sourceControls.OffsetSlider3;
			destControls.OffsetSlider4 = sourceControls.OffsetSlider4;
			destControls.OffsetTranslateForward = sourceControls.OffsetTranslateForward;
			destControls.OffsetTranslateRight = sourceControls.OffsetTranslateRight;
			destControls.OffsetTranslateUp = sourceControls.OffsetTranslateUp;
			destControls.OffsetYaw = sourceControls.OffsetYaw;
			destControls.Pitch = sourceControls.Pitch;
			destControls.Roll = sourceControls.Roll;
			destControls.Slider1 = sourceControls.Slider1;
			destControls.Slider2 = sourceControls.Slider2;
			destControls.Slider3 = sourceControls.Slider3;
			destControls.Slider4 = sourceControls.Slider4;
			destControls.Throttle = sourceControls.Throttle;
			destControls.TranslateForward = sourceControls.TranslateForward;
			destControls.TranslateRight = sourceControls.TranslateRight;
			destControls.TranslateUp = sourceControls.TranslateUp;
			destControls.Yaw = sourceControls.Yaw;
		}

		public static void ZeroControls(CraftControls controls, bool zeroOffsets = true)
		{
			controls.Pitch = 0f;
			controls.Roll = 0f;
			controls.Slider1 = 0f;
			controls.Slider2 = 0f;
			controls.Slider3 = 0f;
			controls.Slider4 = 0f;
			controls.TranslateForward = 0f;
			controls.TranslateRight = 0f;
			controls.TranslateUp = 0f;
			controls.Yaw = 0f;
			if (zeroOffsets)
			{
				controls.OffsetBrake = 0f;
				controls.OffsetPitch = 0f;
				controls.OffsetRoll = 0f;
				controls.OffsetSlider1 = 0f;
				controls.OffsetSlider2 = 0f;
				controls.OffsetSlider3 = 0f;
				controls.OffsetSlider4 = 0f;
				controls.OffsetTranslateForward = 0f;
				controls.OffsetTranslateRight = 0f;
				controls.OffsetTranslateUp = 0f;
				controls.OffsetYaw = 0f;
				controls.Brake = 0f;
				controls.Throttle = 0f;
			}
		}

		public XElement GenerateStateXml()
		{
			XElement xElement = new XElement("Controls");
			SetAttributeIfNonZero(xElement, "brake", OffsetBrake);
			SetAttributeIfNonZero(xElement, "pitch", OffsetPitch);
			SetAttributeIfNonZero(xElement, "roll", OffsetRoll);
			SetAttributeIfNonZero(xElement, "slider1", OffsetSlider1);
			SetAttributeIfNonZero(xElement, "slider2", OffsetSlider2);
			SetAttributeIfNonZero(xElement, "slider3", OffsetSlider3);
			SetAttributeIfNonZero(xElement, "slider4", OffsetSlider4);
			SetAttributeIfNonZero(xElement, "yaw", OffsetYaw);
			SetAttributeIfNonZero(xElement, "forward", OffsetTranslateForward);
			SetAttributeIfNonZero(xElement, "right", OffsetTranslateRight);
			SetAttributeIfNonZero(xElement, "up", OffsetTranslateUp);
			SetAttributeIfNonZero(xElement, "evaMoveFwdAft", EvaMoveFwdAft);
			SetAttributeIfNonZero(xElement, "evaPitch", EvaPitch);
			SetAttributeIfNonZero(xElement, "evaRoll", EvaRoll);
			SetAttributeIfNonZero(xElement, "evaStrafe", EvaStrafe);
			SetAttributeIfNonZero(xElement, "evaTurn", EvaTurn);
			SetAttributeIfNonZero(xElement, "throttle", Throttle);
			return xElement;
		}

		public bool GetActivationGroup(int activationGroup)
		{
			if (_commandPod != null)
			{
				return _commandPod.GetActivationGroupState(activationGroup);
			}
			return false;
		}

		public string GetActivationGroupName(int activationGroup)
		{
			string text = null;
			if (_commandPod != null)
			{
				ICommandPod commandPod = _commandPod;
				if (commandPod.IsEva && commandPod.EvaScript.CrewCompartmentCommandPod != null)
				{
					commandPod = commandPod.EvaScript.CrewCompartmentCommandPod;
				}
				int num = activationGroup - 1;
				if (num < commandPod.ActivationGroupNames.Count)
				{
					text = commandPod.ActivationGroupNames[num];
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "Activation Group";
			}
			return text;
		}

		public void SetActivationGroup(int activationGroup, bool state)
		{
			if (_commandPod != null)
			{
				_commandPod.SetActivationGroupState(activationGroup, state);
			}
		}

		public void ToggleActivationGroup(int activationGroup)
		{
			if (_commandPod != null)
			{
				bool activationGroupState = _commandPod.GetActivationGroupState(activationGroup);
				_commandPod.SetActivationGroupState(activationGroup, !activationGroupState);
			}
		}

		public void ToggleTranslationMode()
		{
			TranslationModeEnabled = !TranslationModeEnabled;
			IFlightSceneUI flightSceneUI = Game.Instance.FlightScene?.FlightSceneUI;
			if (flightSceneUI != null)
			{
				if (TranslationModeEnabled)
				{
					flightSceneUI.ShowMessage("Translation Mode Enabled");
				}
				else
				{
					flightSceneUI.ShowMessage("Translation Mode Disabled");
				}
			}
		}

		private static void SetAttributeIfNonZero(XElement stateXml, string attributeName, float attributeValue)
		{
			if (attributeValue != 0f)
			{
				stateXml.SetAttributeValue(attributeName, attributeValue);
			}
		}
	}
}
