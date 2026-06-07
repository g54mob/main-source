using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using ModApi.Design.PartProperties;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Wheel")]
	public class ResizableWheelData : PartModifierData<ResizableWheelScript>
	{
		private const float DefaultDamper = 1f;

		private const string DefaultDirection = "Normal";

		private const float DefaultSize = 1.5f;

		private const float DefaultSpring = 1f;

		private const float DefaultWidth = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 10000f, 21, Label = "Brake Torque", Order = 10, Header = "Wheel Settings", HeaderCollapsed = true, Tooltip = "Changes the torque applied to the wheel when brake is applied.", TechTreeIdForMaxValue = "Wheel.Brake")]
		private float _brakeTorque = 5000f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Damper", Order = 22, Tooltip = "Higher damper settings can help to reduce oscillation. Lower damper settings allow more oscillation.")]
		private float _damper = 1f;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Normal", "Reversed" }, Label = "Direction", Order = 0, Tooltip = "Changes the direction the wheel rotates when motor input is applied.")]
		private string _direction = "Normal";

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Reversed", Order = 0, Tooltip = "Changes the direction the wheel rotates when motor input is applied.")]
		private bool _directionReverse;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Disabled", "Enabled" }, Label = "Suspension", Order = 20)]
		private bool _enableSuspension;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 3f, 26, Label = "Gear Ratio", Order = 5, Tooltip = "Higher values result in more torque for the wheel, but lower RPM. Lower values result in less torque, but higher max RPM.")]
		private float _gearRatio = 1.5f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxAngularVelocity = 300f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxRpm = 1000f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 1, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways, Tooltip = "Changes the overall size of the wheel.", TechTreeIdForMaxValue = "MaxSize.Wheel")]
		private float _size = 1.5f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _slipForwardAsymptote;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _slipForwardExtremum;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _slipSidewaysAsymptote;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _slipSidewaysExtremum;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 100, Order = 29, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by the motor built into the wheel.")]
		private float _soundVolume = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Suspension Strength", Order = 21, Tooltip = "Changes the strength of the spring force in the suspension.")]
		private float _spring = 1f;

		private float _styleFrictionConcrete = 1f;

		private float _styleFrictionOffroad = 1f;

		private float _styleGearScalar = 1f;

		private float _styleRimDensity = 50f;

		private float _styleRimlScale = 1f;

		private float _styleTireDensity = 25f;

		private float _styleTorqueScalar = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 5000f, 50, Label = "Torque", Order = 4, Tooltip = "Increase the power of the wheel at the cost of higher electricity usage. The value shown is already scaled by the Gear Ratio.", TechTreeIdForMaxValue = "Wheel.Torque")]
		private float _torque = 1000f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 1.5f, 11, Label = "Forward Traction", Order = 11, Tooltip = "Changes the forward grip of the wheel.")]
		private float _tractionForward = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 1.5f, 11, Label = "Sideways Traction", Order = 12, Tooltip = "Changes the sideways grip of the wheel.")]
		private float _tractionSideways = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 30f, 31, Label = "Turning Angle", Order = 3, Tooltip = "Changes the maximum turning angle of the wheel.")]
		private float _turningAngle;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _turningRate = 150f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2f, 11, Label = "Width", Order = 2, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways, Tooltip = "Changes the width of the wheel.")]
		private float _width = 1f;

		public float BaseGearRatio
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

		public float BrakeTorque
		{
			get
			{
				return _brakeTorque * ((base.Version == 1) ? 1f : ((base.Version == 2) ? Scale : (0.1f * Scale * Scale)));
			}
			set
			{
				_brakeTorque = value / ((base.Version == 1) ? 1f : ((base.Version == 2) ? Scale : (0.1f * Scale * Scale)));
			}
		}

		public float Damper => _damper;

		public bool Direction
		{
			get
			{
				if (base.Version < 3)
				{
					_directionReverse = _direction == "Reversed";
				}
				return _directionReverse;
			}
			set
			{
				_directionReverse = value;
				_direction = (value ? "Reversed" : "Normal");
			}
		}

		public bool EnableSuspension
		{
			get
			{
				return _enableSuspension;
			}
			set
			{
				_enableSuspension = value;
			}
		}

		public float FrictionConcrete => _styleFrictionConcrete;

		public float FrictionOffroad => _styleFrictionOffroad;

		public float FrictionScale => Mathf.Max(1f, Mathf.Sqrt(_size) * Mathf.Sqrt(_width));

		public float GearRatio => _gearRatio * _styleGearScalar;

		public override float MassDry
		{
			get
			{
				if (base.Version >= 3)
				{
					return 0f + CalculateMass(Radius, ThicknessScale * 0.25f, _styleRimlScale, _styleRimDensity, _styleTireDensity, (base.Version < 3) ? 0f : TorqueScaled, _turningAngle);
				}
				return 0.19999999f;
			}
		}

		public float MaxAngularVelocity
		{
			get
			{
				return _maxAngularVelocity;
			}
			set
			{
				_maxAngularVelocity = value;
			}
		}

		public float MaxRpm => _maxRpm / Mathf.Max(0.001f, GearRatio);

		public float MotorTorque
		{
			get
			{
				return _torque;
			}
			set
			{
				_torque = value;
			}
		}

		public override long Price => CalculatePrice(Radius, ThicknessScale * 0.25f, _styleRimlScale, _styleRimDensity, _styleTireDensity, Torque, GearRatio, _turningAngle);

		public bool PropertiesOpen { get; set; }

		public float Radius => _size * 0.492f;

		public float RimScale => _styleRimlScale;

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

		public override string ScaleCareerID => "MaxSize.Wheel";

		public float SlipForwardAsymptote
		{
			get
			{
				return _slipForwardAsymptote;
			}
			set
			{
				_slipForwardAsymptote = value;
			}
		}

		public float SlipForwardExtremum
		{
			get
			{
				return _slipForwardExtremum;
			}
			set
			{
				_slipForwardExtremum = value;
			}
		}

		public float SlipSidewaysAsymptote
		{
			get
			{
				return _slipSidewaysAsymptote;
			}
			set
			{
				_slipSidewaysAsymptote = value;
			}
		}

		public float SlipSidewaysExtremum
		{
			get
			{
				return _slipSidewaysExtremum;
			}
			set
			{
				_slipSidewaysExtremum = value;
			}
		}

		public float SoundVolume => _soundVolume;

		public float Spring => _spring;

		public float SuspensionDistance => Mathf.Clamp(Radius * 0.35f, 0.05f, 0.25f);

		public float SuspensionStiffness { get; set; }

		public float ThicknessScale => _width * _size;

		public float Torque => ComputeTorque(MotorTorque);

		public float TorqueScaled => Torque * GearRatio;

		public float TractionForward => _tractionForward;

		public float TractionSideways => _tractionSideways;

		public float TurningAngle
		{
			get
			{
				return _turningAngle;
			}
			set
			{
				_turningAngle = value;
			}
		}

		public float TurningRate
		{
			get
			{
				return _turningRate;
			}
			set
			{
				_turningRate = value;
			}
		}

		public float WheelMass => CalculateMass(Radius, ThicknessScale * 0.25f, _styleRimlScale, _styleRimDensity, _styleTireDensity, 0f, 0f);

		public event EventHandler<EventArgs> WheelParametersChanged;

		public float ComputeTorque(float motorTorque)
		{
			return motorTorque * _styleTorqueScalar * ((base.Version == 1) ? 1f : ((base.Version == 2) ? Scale : (0.05f * Scale * Scale)));
		}

		public override void OnPartLoaded()
		{
			base.OnPartLoaded();
			InvokeWheelParametersChangedOnSymmetricPartModifiers(synchronizePartModifiersFirst: false, justStyles: true);
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			if (SlipForwardExtremum <= 0.1f)
			{
				SlipForwardExtremum = 8f;
			}
			if (SlipForwardAsymptote <= 0.1f)
			{
				SlipForwardAsymptote = 10f;
			}
			if (SlipSidewaysExtremum <= 0.1f)
			{
				SlipSidewaysExtremum = 15f;
			}
			if (SlipSidewaysAsymptote <= 0.1f)
			{
				SlipSidewaysAsymptote = 20f;
			}
			if (_tractionForward < 0f)
			{
				_tractionForward = 0f;
			}
			if (_tractionSideways < 0f)
			{
				_tractionSideways = 0f;
			}
			if (_spring < 0f)
			{
				_spring = 0.01f;
			}
			if (_damper < 0f)
			{
				_damper = 0f;
			}
			if (_turningAngle < 0f)
			{
				_turningAngle = 0f;
			}
			if (_size < 0.1f)
			{
				_size = 0.1f;
			}
			if (_width < 0.1f)
			{
				_width = 0.1f;
			}
		}

		protected override void OnCreated(XElement partModifierXml)
		{
			base.OnCreated(partModifierXml);
			SuspensionStiffness = 0.65f;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _width, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _damper, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _spring, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _tractionForward, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _tractionSideways, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _torque, (float x) => Math.Round(TorqueScaled, 1).ToString());
			d.OnValueLabelRequested(() => _gearRatio, (float x) => Math.Round(GearRatio, 2).ToString());
			d.OnValueLabelRequested(() => _brakeTorque, (float x) => Mathf.Round(BrakeTorque).ToString());
			d.OnValueLabelRequested(() => _soundVolume, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _turningAngle, delegate(float x)
			{
				int num = (int)x;
				return (num == 0) ? "None" : (num + "°");
			});
			d.OnValueLabelRequested(() => _size, (float x) => Utilities.FormatPercentage(x));
			d.OnVisibilityRequested(() => _direction, (bool x) => base.Version < 3);
			d.OnVisibilityRequested(() => _directionReverse, (bool x) => base.Version >= 3);
			d.OnVisibilityRequested(() => _gearRatio, (bool x) => _torque > 0f);
			d.OnPropertyChanged(() => _direction, delegate
			{
				if (base.Version >= 3)
				{
					_directionReverse = _direction == "Reversed";
				}
			});
			d.OnPropertyChanged(() => _directionReverse, delegate
			{
				InvokeWheelParametersChangedOnSymmetricPartModifiers();
			});
			d.OnPropertyChanged(() => _size, delegate
			{
				InvokeWheelParametersChangedOnSymmetricPartModifiers();
			});
			d.OnPropertyChanged(() => _width, delegate
			{
				InvokeWheelParametersChangedOnSymmetricPartModifiers();
			});
			d.OnPropertyChanged(() => _gearRatio, delegate
			{
				SyncProperties(d);
			});
			d.OnPropertyChanged(() => _torque, delegate
			{
				base.Script.VisibilityRPM(_torque > 0f);
				SyncProperties(d);
			});
			d.OnPropertyChanged(() => _turningAngle, delegate
			{
				base.Script.VisibilityTurn(_turningAngle > 0f);
				SyncProperties(d);
			});
			d.OnPartStyleChanged(delegate
			{
				InvokeWheelParametersChangedOnSymmetricPartModifiers(synchronizePartModifiersFirst: false);
			});
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (validator.IsCareerMode)
			{
				d.OnVisibilityRequested(() => _enableSuspension, (bool x) => validator.IsItemAvailable("Wheel.Suspension"));
			}
			d.OnVisibilityRequested(() => _spring, (bool x) => EnableSuspension);
			d.OnVisibilityRequested(() => _damper, (bool x) => EnableSuspension);
			d.OnActivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ResizableWheelData x)
				{
					x.PropertiesOpen = true;
				});
			});
			d.OnDeactivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ResizableWheelData x)
				{
					x.PropertiesOpen = false;
				});
			});
			d.OnDeactivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ResizableWheelData x)
				{
					x.Script?.ResetWheelRotation();
				});
			});
			d.OnPropertyChanged(() => _turningAngle, delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: false, _turningAngle, delegate(ResizableWheelData x, float y)
				{
					x._turningAngle = y;
				});
			});
		}

		private static float CalculateMass(float radius, float width, float rimRadius, float rimDensity, float tireDensity, float motorPower, float turningAngle)
		{
			float num = MathF.PI * radius * radius * width;
			rimRadius *= radius * 0.75f;
			float num2 = MathF.PI * rimRadius * rimRadius * width;
			float num3 = num - num2;
			return 0.01f * Mathf.Max(1f, num3 * tireDensity + num2 * rimDensity + motorPower / Mathf.Max(0.001f, 100f * radius) + Mathf.Sqrt(turningAngle * (motorPower + 1f)));
		}

		private static long CalculatePrice(float radius, float width, float rimRadius, float rimDensity, float tireDensity, float motorPower, float gearReduction, float turningAngle)
		{
			float num = MathF.PI * radius * radius * width;
			rimRadius *= radius * 0.75f;
			float num2 = MathF.PI * rimRadius * rimRadius * width;
			float num3 = num2 * rimDensity;
			float num4 = (num - num2) * tireDensity;
			gearReduction = ((gearReduction > 1f) ? gearReduction : (1f / gearReduction));
			return (long)Mathf.Max(1f, 10f * num4 + 100000f * num2 / Mathf.Sqrt(Mathf.Max(0.001f, rimDensity)) + 50f * motorPower / Mathf.Max(0.001f, radius) + 100f * gearReduction * Mathf.Sqrt(Mathf.Max(0f, motorPower)) + (num3 + num4) * Mathf.Sqrt(turningAngle * Mathf.Pow(motorPower + 1f, 1.5f)));
		}

		private void InvokeWheelParametersChangedOnSymmetricPartModifiers(bool synchronizePartModifiersFirst = true, bool justStyles = false)
		{
			if (synchronizePartModifiersFirst)
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			}
			IPartStyle style = base.Part.Styles[1].Style;
			IPartStyle style2 = base.Part.Styles[2].Style;
			_styleGearScalar = ((base.Version < 3) ? 1f : style.GetData("GearScalar", 1f));
			_styleTorqueScalar = ((base.Version < 3) ? 1f : style.GetData("TorqueScalar", 1f));
			_styleTireDensity = ((base.Version < 3) ? 25f : style2.GetData("TireDensity", 25f));
			_styleRimDensity = ((base.Version < 3) ? 50f : style.GetData("RimDensity", 50f));
			_styleRimlScale = style2.GetData("WheelScale", 1f);
			_styleFrictionConcrete = style2.GetData((base.Version < 3) ? "FrictionNormalV1" : "FrictionNormal", 1f);
			_styleFrictionOffroad = style2.GetData((base.Version < 3) ? "FrictionOffroadV1" : "FrictionOffroad", 1f);
			base.Part.Config.MaxTemperature = style2.GetData("MaxTemperature", 500f);
			if (!justStyles)
			{
				this.WheelParametersChanged(this, EventArgs.Empty);
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ResizableWheelData modifier)
				{
					modifier.WheelParametersChanged(modifier, EventArgs.Empty);
				});
				base.Part.PartScript.CraftScript.SetStructureChanged();
			}
		}

		private void SyncProperties(IDesignerPartPropertiesModifierInterface d)
		{
			d.Manager.Flyout.RefreshUI();
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
