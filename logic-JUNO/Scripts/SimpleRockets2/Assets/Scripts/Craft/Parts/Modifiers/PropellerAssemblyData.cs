using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using ModApi.Design.PartProperties;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Propeller Assembly")]
	[PartModifierTypeId("PropellerAssembly")]
	public class PropellerAssemblyData : PartModifierData<PropellerAssemblyScript>
	{
		public enum PitchControl
		{
			Manual = 0,
			Fixed = 1
		}

		public const float MaxPitchDegrees = 40f;

		private const int HubPricePerKg = 20;

		private const int MaxDesignerUIPitch = 90;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _basePrice = 3000;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _bladeBlurCount = 30;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _bladeBlurSpread = 30f;

		[SerializeField]
		[DesignerPropertySlider(2f, 8f, 7, Label = "Blade Count", Order = 0, Tooltip = "The number of propeller blades. More blades means more thrust given the same RPM, but also more drag and mass for the motor to spin.", TechTreeIdForMaxValue = "Prop.BladeCount")]
		private int _bladeCount = 3;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _chordRadiusRatio = 0.15f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Blade Width", Order = 2, Tooltip = "The width (chord-length) of the propeller blades")]
		private float _chordScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _defaultDiameter = 2f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _density = 2000f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _dragScalar = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Hub Scale", Order = 3, Tooltip = "The scale of the propeller hub/cone")]
		private float _hubScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _isWaterProp;

		[SerializeField]
		[DesignerPropertySlider(-90f, 90f, 181, Label = "Pitch", Order = 6, Tooltip = "The propeller blade's pitch setting, which is either used to determine the fixed pitch of the blades, or maximum pitch, depending on blade control type.")]
		private float _maxPitch;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Manual", "Fixed" }, Label = "Blade Control", Order = 5, Tooltip = "The pitch of the blades can either be fixed, or controlled via an input controller during flight.")]
		private PitchControl _pitchControlType;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Reverse Blades", Order = 7, Tooltip = "Reverses the direction the propellers are facing as well as inverting an attached motor's input controller, if \"Sync with motor\" is enabled.")]
		private bool _reverseBladeDirection;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 4f, 151, Label = "Size", Order = 1, Tooltip = "Changes the overall size/scale of the propeller assembly", TechTreeIdForMaxValue = "MaxSize.Prop")]
		private float _size = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _spinTolerance = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _spinToleranceMultiplier = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _styleId = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _styleIdHub = string.Empty;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Auto-Reverse Motor", Order = 8, Tooltip = "Synchronizes changes between blade direction and motor rotation.")]
		private bool _syncWithMotor = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thrustScalar = 1f;

		public int BladeBlurCount => _bladeBlurCount;

		public float BladeBlurSpread
		{
			get
			{
				return _bladeBlurSpread;
			}
			set
			{
				_bladeBlurSpread = value;
			}
		}

		public int BladeCount => _bladeCount;

		public float ChordScale
		{
			get
			{
				return _chordScale;
			}
			set
			{
				_chordScale = value;
			}
		}

		public float Diameter
		{
			get
			{
				return _defaultDiameter * _size;
			}
			set
			{
				_size = value / _defaultDiameter;
			}
		}

		public float DragScalar
		{
			get
			{
				return _dragScalar;
			}
			set
			{
				_dragScalar = value;
			}
		}

		public float HubMass => Mathf.Pow(HubScale * 0.1f * Radius, 2f) * _density * (float)((!IsManual) ? 1 : BladeCount);

		public float HubScale => _hubScale;

		public bool IsManual => _pitchControlType == PitchControl.Manual;

		public bool IsWaterProp => _isWaterProp;

		public override float MassDry => (CalculateSingleBladeMass() * (float)BladeCount + HubMass) * 0.01f;

		public float MaxPitch
		{
			get
			{
				return _maxPitch;
			}
			set
			{
				_maxPitch = value;
			}
		}

		public PitchControl PitchControlType
		{
			get
			{
				return _pitchControlType;
			}
			set
			{
				_pitchControlType = value;
			}
		}

		public override long Price => (long)(CalculateSingleBladePrice() * (float)BladeCount + HubMass * 20f * (float)((!IsManual) ? 1 : 3));

		public float PropellerPitchScale { get; internal set; } = 1f;

		public bool PropertiesOpen { get; private set; }

		public float Radius => Diameter * 0.5f;

		public bool ReverseBladeDirection
		{
			get
			{
				return _reverseBladeDirection;
			}
			set
			{
				_reverseBladeDirection = value;
			}
		}

		public override float Scale => _size;

		public override string ScaleCareerID => "MaxSize.Prop";

		public float SpinTolerance => _spinTolerance * _spinToleranceMultiplier;

		public string StyleBlade => _styleId;

		public string StyleHub => _styleIdHub;

		public bool SyncWithMotor
		{
			get
			{
				return _syncWithMotor;
			}
			set
			{
				_syncWithMotor = value;
			}
		}

		public float ThrustScalar
		{
			get
			{
				return _thrustScalar;
			}
			set
			{
				_thrustScalar = value;
			}
		}

		public float CalculateSingleBladeMass()
		{
			float radius = Radius;
			return Radius * _chordRadiusRatio * ChordScale * radius * 0.00635f * _density;
		}

		public float CalculateSingleBladePrice()
		{
			return (float)_basePrice * _size * _size * ChordScale;
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
		}

		public void UpdateStyleProperties()
		{
			IPartStyle style = base.Part.Styles[1].Style;
			_styleId = style.Id;
			_defaultDiameter = style.GetData("DefaultDiameter", 2f);
			_chordRadiusRatio = style.GetData("ChordToRadiusRatio", 0.15f);
			_isWaterProp = style.GetData("IsWaterProp", defaultValue: false);
			_density = style.GetData("Density", 2000f);
			_basePrice = style.GetData("BasePrice", 3000);
			_spinTolerance = style.GetData("SpinTolerance", 1f);
			_styleIdHub = base.Part.Styles[2].Style.Id;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			base.OnDesignerInitialization(d);
			d.OnAnyPropertyChanged(delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
				d.Manager.RefreshUI();
			});
			d.OnPropertyChanged(() => _bladeCount, delegate
			{
				base.Script.UpdateBladeCount();
			});
			d.OnPropertyChanged(() => _maxPitch, delegate
			{
				base.Script.UpdatePitchRepresentation();
			});
			d.OnPropertyChanged(() => _size, delegate
			{
				base.Script.UpdateScale(repositionConnectedParts: true);
			});
			d.OnPropertyChanged(() => _hubScale, delegate
			{
				base.Script.UpdateScale(repositionConnectedParts: true);
			});
			d.OnPropertyChanged(() => _chordScale, delegate
			{
				base.Script.UpdateScale(repositionConnectedParts: false);
			});
			d.OnPropertyChanged(() => _pitchControlType, delegate
			{
				if (!validator.IsItemAvailable("Prop.VariablePitch") && IsManual)
				{
					_pitchControlType = PitchControl.Fixed;
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the manual variable pitch yet. You can unlock it in the Tech Tree.";
				}
				base.Script.SetPitchInputControllerVisibility(IsManual);
				base.DesignerPartProperties.GetSliderProperty(() => _maxPitch).LabelValue = (IsManual ? "Max Positive Pitch" : "Fixed Pitch");
				UpdatePitchSlider();
				base.Script.UpdatePitchRepresentation();
				d?.Manager?.Flyout.RefreshUI();
			});
			d.OnPropertyChanged(() => _reverseBladeDirection, delegate
			{
				base.Script.UpdatePropDirection(SyncWithMotor);
			});
			d.OnPropertyChanged(() => _syncWithMotor, delegate
			{
				base.Script.UpdatePropDirection(SyncWithMotor);
			});
			d.OnValueLabelRequested(() => _maxPitch, (float x) => Units.GetAngleString(x, 0));
			d.OnValueLabelRequested(() => _size, (float x) => Utilities.FormatPercentage(x) + " (" + Units.GetDistanceString(Diameter) + " diameter)");
			d.OnValueLabelRequested(() => _chordScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _hubScale, (float x) => Utilities.FormatPercentage(x));
			d.OnPartStyleChanged(delegate
			{
				UpdateStyleProperties();
				base.Script.RebuildPropellerAssembly(repositionConnectedParts: true);
				base.Script.PartScript.CraftScript.SetStructureChanged();
				d?.Manager?.RefreshUI();
			});
			d.OnActivated(delegate
			{
				UpdatePitchSlider();
			});
			d.OnActivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(PropellerAssemblyData x)
				{
					x.PropertiesOpen = true;
				});
			});
			d.OnDeactivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(PropellerAssemblyData x)
				{
					x.PropertiesOpen = false;
				});
			});
			d.OnDeactivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(PropellerAssemblyData x)
				{
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
					{
						if (!x.PropertiesOpen && x.Script != null)
						{
							x.Script.ResetDesignerRotation();
						}
					});
				});
			});
		}

		private void UpdatePitchSlider()
		{
			ISliderProperty sliderProperty = base.DesignerPartProperties.GetSliderProperty(() => _maxPitch);
			int num = ((_pitchControlType != PitchControl.Manual) ? (-90) : 0);
			int num2 = 90;
			float maxPitch = _maxPitch;
			sliderProperty.UpdateSliderSettings(num, num2, num2 - num + 1);
			_maxPitch = ((_pitchControlType == PitchControl.Fixed) ? maxPitch : Mathf.Abs(maxPitch));
		}
	}
}
