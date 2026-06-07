using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using ModApi.Design.PartProperties;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	[Serializable]
	[DesignerPartModifier("Landing Gear", PanelOrder = 2000)]
	public class LandingGearData : PartModifierData<LandingGearScript>
	{
		public delegate void PropertyChanged();

		public const float BayMassCostPremium = 1.2f;

		private const int StyleBayIndex = 2;

		private const int StyleDoorIndex = 3;

		private const int StyleWheelIndex = 1;

		private bool _active;

		[SerializeField]
		[DesignerPropertySlider(1f, 2f, 21, Label = "Bay Length", Order = 2, Tooltip = "Changes the length of the landing gear bay")]
		private float _bayLength = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.6f, 1f, 17, Label = "Bay Width", Order = 2, Tooltip = "Changes the width of the landing gear bay")]
		private float _bayWidth = 1f;

		private bool _bayPresent;

		[SerializeField]
		[DesignerPropertySlider(0f, 10000f, 21, Label = "Brake Torque", Order = 20, Header = "Wheel Settings", HeaderCollapsed = true, Tooltip = "Changes the torque applied to the wheel when brake is applied.", TechTreeIdForMaxValue = "Wheel.Brake")]
		private float _brakeTorque = 5000f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Suspension Damper", Order = 25, Tooltip = "Higher damper settings can help to reduce oscillation. Lower damper settings allow more oscillation.")]
		private float _damperScale = 1f;

		private bool _doubleWheel;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool? _extended;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _extensionPercent = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Mirror Offsets", Order = 0, Tooltip = "Mirrors the offsets of the landing gear")]
		private bool _flipped;

		[SerializeField]
		[DesignerPropertySlider(Label = "Forward Offset", Order = 12, Tooltip = "Changes the forward offset of the wheel's position")]
		private float _forwardOffset;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 3f, 26, Label = "Gear Ratio", Order = 4, Tooltip = "Higher values result in more torque for the wheel, but lower RPM. Lower values result in less torque, but higher max RPM.")]
		private float _gearRatio = 1.5f;

		[SerializeField]
		[DesignerPropertySlider(Label = "Height Offset", Order = 11, Tooltip = "Changes the height offset of the wheel's position")]
		private float _heightOffset;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.5f, MaxValue = 2f, NumberOfSteps = 31, Label = "Gear Length", Header = "Leg Shape", HeaderCollapsed = true, Order = 10, Tooltip = "Changes the length of the wheel's support rod (does not affect suspension travel).")]
		private float _lengthScale = 1f;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 45f, NumberOfSteps = 10, Label = "Turning Angle", Order = 3, Tooltip = "Changes max the turning angle of the wheel.")]
		private float _maxTurningAngle;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 2f, NumberOfSteps = 20, Label = "Retraction Speed", Order = 8, Tooltip = "Allows speeding up/slowing down of the wheel's retraction.")]
		private float _retractionSpeed = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Upper Braces", Order = 16, Tooltip = "Determines whether the upper braces inside the bay should be hidden.")]
		private bool _showUpperBraces = true;

		[SerializeField]
		[DesignerPropertySlider(Label = "Side Offset", Order = 13, Tooltip = "Changes the side offset of the wheel's position")]
		private float _sideOffset;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.25f, MaxValue = 4f, NumberOfSteps = 76, Label = "Size", Order = 1, Tooltip = "Changes the overall size of the landing gear.", TechTreeIdForMaxValue = "MaxSize.LandingGear")]
		private float _size = 1f;

		[SerializeField]
		[DesignerPropertySlider(MinValue = -45f, MaxValue = 45f, NumberOfSteps = 91, Label = "Slant Angle", Order = 14, Tooltip = "Changes the angle that the lower support attatches to the wheel.")]
		private float _slantAngle;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 100, Order = 29, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by the motor built into the wheel.")]
		private float _soundVolume = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Suspension Strength", Order = 24, Tooltip = "Changes the strength of the spring force in the suspension.")]
		private float _springForceScale = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Start Extended", Order = 9, Tooltip = "Determines whether the gear should start out extended, or retracted.")]
		private bool _startExtended = true;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Support Arm", Order = 17, Tooltip = "Enables/disables the support arm for the landing gear.")]
		private bool _supportArmEnabled = true;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.05f, MaxValue = 1f, NumberOfSteps = 20, Label = "Suspension Travel", Order = 23, Tooltip = "Changes the length (meters) of available suspension travel.")]
		private float _suspensionTravel = 0.25f;

		[SerializeField]
		[DesignerPropertySlider(0f, 5000f, 51, Label = "Torque", Order = 5, Tooltip = "Changes the power of the wheel, which impacts electricity usage. The value shown is already scaled by the Gear Ratio.", TechTreeIdForMaxValue = "Wheel.Torque")]
		private float _torque;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 41, Label = "Forward Traction", Order = 21, Tooltip = "Changes the forward grip of the wheel.")]
		private float _tractionForward = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 41, Label = "Sideways Traction", Order = 22, Tooltip = "Changes the sideways grip of the wheel.")]
		private float _tractionSideways = 1f;

		[SerializeField]
		[DesignerPropertySlider(MinValue = -90f, MaxValue = 90f, NumberOfSteps = 181, Label = "Vertical Offset Angle", Order = 15, Tooltip = "Changes the vertical angle of the wheel.")]
		private float _verticalAngleOffset;

		public float BayLength => _bayLength;

		public float BayWidth
		{
			get
			{
				if (!_doubleWheel)
				{
					return _bayWidth;
				}
				return 1f;
			}
		}

		public float BrakeTorque => _brakeTorque * ((base.Version == 1) ? 1f : Scale) * ((base.Version > 2 && _doubleWheel) ? 2f : 1f);

		public float BrakeTorqueUnscaled => _brakeTorque;

		public float DamperScale
		{
			get
			{
				return _damperScale;
			}
			set
			{
				_damperScale = value;
			}
		}

		public bool? Extended
		{
			get
			{
				return _extended;
			}
			set
			{
				_extended = value;
			}
		}

		public float ExtensionPercent
		{
			get
			{
				return _extensionPercent;
			}
			set
			{
				_extensionPercent = value;
			}
		}

		public bool Flipped
		{
			get
			{
				return _flipped;
			}
			set
			{
				_flipped = value;
			}
		}

		public float ForwardOffset
		{
			get
			{
				return _forwardOffset;
			}
			set
			{
				_forwardOffset = value;
			}
		}

		public float GearRatio
		{
			get
			{
				return _gearRatio;
			}
			set
			{
				_gearRatio = value;
			}
		}

		public bool HasBay { get; set; }

		public bool HasDoor { get; set; }

		public float HeightOffset => _heightOffset;

		public float LengthScale => _lengthScale;

		public override float MassDry
		{
			get
			{
				if (base.Version < 3)
				{
					return 2.5f * (HasBay ? 1.2f : 1f) * Mathf.Pow(Scale, 2f);
				}
				float num = (HasBay ? (Scale * 0.05f * 0.75f * (1.5f + (HasDoor ? 4f : 3f) * BayWidth * (BayLength + Mathf.Max(0f, 0.5f * _forwardOffset)))) : 0f);
				float num2 = 0.005f * (SuspensionTravel + Mathf.Sqrt(Vector3.SqrMagnitude(_lengthScale * new Vector3(_sideOffset, _forwardOffset, 1f - _heightOffset))));
				float num3 = (_doubleWheel ? 2f : 1f) * 0.0023f;
				float num4 = ((base.Version < 4) ? (Torque * 0.025f) : (Torque / (100f * Scale * Scale)));
				return 0.01f * (Scale * 2700f * (num + num2 + num3) + num4 - 20f);
			}
		}

		public float MaxTurningAngle => _maxTurningAngle;

		public override long Price => (long)(base.Part.Mass * 10000f + 1000f * SuspensionTravel * Scale + 25f * _torque * Scale * (1f + ((_gearRatio > 1f) ? (0.5f * _gearRatio) : (0.5f / _gearRatio))) + Mathf.Sqrt(100f * _maxTurningAngle * (Torque + 1f)));

		public bool RestrictLegToBayBoundaries { get; private set; }

		public float RetractionSpeed => _retractionSpeed;

		public override float Scale
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public override string ScaleCareerID => string.Empty;

		public bool ShowUpperBraces
		{
			get
			{
				if (!_showUpperBraces)
				{
					return !HasBay;
				}
				return true;
			}
		}

		public float SideOffset => _sideOffset;

		public float SlantAngle
		{
			get
			{
				if (!_doubleWheel)
				{
					return _slantAngle;
				}
				return 0f;
			}
		}

		public float SoundVolume => _soundVolume;

		public float SpringForceScale
		{
			get
			{
				return _springForceScale;
			}
			set
			{
				_springForceScale = value;
			}
		}

		public bool StartExtended
		{
			get
			{
				return _startExtended;
			}
			set
			{
				_startExtended = value;
			}
		}

		public bool SupportArmEnabled
		{
			get
			{
				return _supportArmEnabled;
			}
			set
			{
				_supportArmEnabled = value;
			}
		}

		public float SuspensionTravel => _suspensionTravel;

		public float Torque => _torque * _gearRatio * ((base.Version == 1) ? 1f : ((base.Version < 4) ? Scale : (0.018f * Scale * Scale)));

		public float TorqueUnscaled => _torque;

		public float TractionForward
		{
			get
			{
				return _tractionForward;
			}
			set
			{
				_tractionForward = value;
			}
		}

		public float TractionSideways
		{
			get
			{
				return _tractionSideways;
			}
			set
			{
				_tractionSideways = value;
			}
		}

		public float VerticalAngleOffset => _verticalAngleOffset;

		public event EventHandler<EventArgs> GearParametersChanged;

		public void LoadFlagsInFlight()
		{
			SetBayStyle(base.Part.Styles[2].Style);
			SetWheelStyle(base.Part.Styles[1].Style);
		}

		public void SetLandingLegRestrictionsEnabled(bool enabled)
		{
			RestrictLegToBayBoundaries = enabled;
			if (_active)
			{
				UpdateLandingLegRestrictionsEnabled(enabled);
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			SetBayStyle(base.Part.Styles[2].Style);
			SetWheelStyle(base.Part.Styles[1].Style);
			d.OnValueLabelRequested(() => _retractionSpeed, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _size, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _forwardOffset, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _heightOffset, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _bayLength, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _bayWidth, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _sideOffset, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _lengthScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _springForceScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _damperScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _slantAngle, (float x) => Units.GetAngleString(x, 1));
			d.OnValueLabelRequested(() => _maxTurningAngle, (float x) => Units.GetAngleString(x, 1));
			d.OnValueLabelRequested(() => _verticalAngleOffset, (float x) => Units.GetAngleString(x, 1));
			d.OnValueLabelRequested(() => _tractionForward, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _tractionSideways, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _suspensionTravel, (float x) => Units.GetDistanceString(x * Scale));
			d.OnValueLabelRequested(() => _torque, (float x) => Units.GetTorqueString(Torque));
			d.OnValueLabelRequested(() => _brakeTorque, (float x) => Units.GetTorqueString(BrakeTorque));
			d.OnValueLabelRequested(() => _soundVolume, (float x) => Utilities.FormatPercentage(x));
			d.OnPartStyleChanged(delegate(IPartStyle p, IPartStyle n)
			{
				InvokeGearParametersChangedOnSymmetricPartModifiers(p, n);
			});
			d.OnPropertyChanged(() => _flipped, delegate
			{
				InvokeGearParametersChangedOnSymmetricPartModifiers(null, null);
			});
			d.OnPropertyChanged(() => _maxTurningAngle, delegate
			{
				base.Script.VisibilityTurn(_maxTurningAngle > 0f);
				SyncProperties(d);
			});
			d.OnPropertyChanged(() => _torque, delegate
			{
				base.Script.VisibilityMotor(_torque > 0f);
				SyncProperties(d);
			});
			d.OnPropertyChanged(() => _gearRatio, delegate
			{
				SyncProperties(d);
			});
			d.OnPropertyChanged(() => _size, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _bayLength, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _bayWidth, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _sideOffset, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _slantAngle, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _lengthScale, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _heightOffset, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _forwardOffset, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _showUpperBraces, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _suspensionTravel, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _supportArmEnabled, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _retractionSpeed, delegate
			{
				base.Script.UpdateRetractionSpeed();
			});
			d.OnPropertyChanged(() => _verticalAngleOffset, delegate
			{
				base.Script.UpdateShapeAndSync();
			});
			d.OnPropertyChanged(() => _startExtended, delegate(bool newVal, bool oldVal)
			{
				Extended = newVal;
				ExtensionPercent = (newVal ? 1f : 0f);
				base.Script.UpdateStartExtended(newVal);
			});
			d.OnVisibilityRequested(() => _gearRatio, (bool x) => _torque > 0f);
			d.OnVisibilityRequested(() => _slantAngle, (bool x) => !_doubleWheel);
			d.OnVisibilityRequested(() => _bayLength, (bool x) => _bayPresent);
			d.OnVisibilityRequested(() => _bayWidth, (bool x) => _bayPresent && !_doubleWheel);
			d.OnVisibilityRequested(() => _showUpperBraces, (bool x) => HasBay);
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (validator.IsCareerMode)
			{
				d.OnVisibilityRequested(() => _startExtended, (bool x) => validator.IsItemAvailable("LandingGear.Retraction"));
				d.OnVisibilityRequested(() => _suspensionTravel, (bool x) => validator.IsItemAvailable("Wheel.Suspension"));
				d.OnVisibilityRequested(() => _springForceScale, (bool x) => validator.IsItemAvailable("Wheel.Suspension"));
				d.OnVisibilityRequested(() => _damperScale, (bool x) => validator.IsItemAvailable("Wheel.Suspension"));
			}
			base.DesignerPartProperties.OnActivated(delegate
			{
				_active = true;
				UpdateLandingLegRestrictionsEnabled(RestrictLegToBayBoundaries);
			});
			base.DesignerPartProperties.OnDeactivated(delegate
			{
				_active = false;
			});
		}

		private void InvokeGearParametersChangedOnSymmetricPartModifiers(IPartStyle oldStyle, IPartStyle newStyle, bool synchronizePartModifiersFirst = true)
		{
			if (newStyle != null)
			{
				if (newStyle.SubpartIndex == 2)
				{
					SetBayStyle(newStyle);
				}
				else if (newStyle.SubpartIndex == 1)
				{
					SetWheelStyle(newStyle);
				}
			}
			if (synchronizePartModifiersFirst)
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			}
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LandingGearData modifier)
			{
				modifier.GearParametersChanged(modifier, EventArgs.Empty);
			});
		}

		private void SetBayStyle(IPartStyle newStyle)
		{
			_bayPresent = newStyle.DisplayName != "None";
		}

		private void SetWheelStyle(IPartStyle newStyle)
		{
			_doubleWheel = newStyle.DisplayName == "Double";
		}

		private void SyncProperties(IDesignerPartPropertiesModifierInterface d)
		{
			d.Manager.Flyout.RefreshUI();
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}

		private void UpdateLandingLegRestrictionsEnabled(bool restricted)
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (restricted || validator.IsCareerMode)
			{
				base.DesignerPartProperties.GetSliderProperty(() => _forwardOffset).UpdateSliderSettings(-1f, 1f, 201, refreshUI: true);
				base.DesignerPartProperties.GetSliderProperty(() => _heightOffset).UpdateSliderSettings(0f, 0.5f, 201, refreshUI: true);
				base.DesignerPartProperties.GetSliderProperty(() => _sideOffset).UpdateSliderSettings(-0.5f, 0.5f, 201, refreshUI: true);
			}
			else
			{
				base.DesignerPartProperties.GetSliderProperty(() => _forwardOffset).UpdateSliderSettings(-5f, 5f, 201, refreshUI: true);
				base.DesignerPartProperties.GetSliderProperty(() => _heightOffset).UpdateSliderSettings(-5f, 5f, 201, refreshUI: true);
				base.DesignerPartProperties.GetSliderProperty(() => _sideOffset).UpdateSliderSettings(-5f, 5f, 201, refreshUI: true);
			}
		}
	}
}
