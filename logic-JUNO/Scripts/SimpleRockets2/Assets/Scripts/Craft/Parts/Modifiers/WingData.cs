using System;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using ModApi.Data;
using ModApi.Design.PartProperties;
using ModApi.Scripts.State.Validation;
using ModApi.Services.Purchasing;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Wing", PanelOrder = 500)]
	[DesignerPartModifier(null, typeof(WingPartProperties), PanelOrder = 2000)]
	public class WingData : PartModifierData<WingScript>
	{
		public delegate void PropertyChangedHandler(bool newVal, bool oldVal);

		public enum CraftSideType
		{
			Auto = 0,
			Right = 1,
			Left = 2
		}

		public static class Airfoils
		{
			public const string Fin = "Fin";

			public const string FlatBottom = "Flat Bottom";

			public const string FlatPlate = "Flat Plate";

			public const string SemiSymmetric = "Semi-Symmetric";

			public const string Symmetric = "Symmetric";
		}

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Symmetric", "Semi-Symmetric", "Flat Bottom" }, Label = "Airfoil", Order = 0)]
		private string _airfoil = "Symmetric";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _allowAirfoilSelection = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _allowControlSurfaces = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _angleOfAttack;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Auto Resize", Order = 1, Tooltip = "Determines if the part should automatically attempt to resize itself when connecting to a similar part to match its dimensions.")]
		private bool _autoResize = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _cDragOverride = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _cLiftOverride = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _controlSurfacePriceMultiplier = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _curveLength = 0.3f;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Craft Side", Tooltip = "The side of the craft the wing is connected to. If connected to the right side of the craft then the airfoil and pitch input will be inverted, which is important for airplanes.")]
		private CraftSideType _craftSide;

		private float _density;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _densityOverride = -1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 21, Label = "Fuel", Order = 4, Tooltip = "The amount of fuel to put in this fuel tank.")]
		private float _fuelPercentage = 1f;

		private FuelTankData _fuelTank;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _hingeDistanceFromTrailingEdge = 0.3f;

		[SerializeField]
		[DesignerPropertyToggleButton]
		private bool _invertAirfoil;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Visual Curve", Order = 3, Tooltip = "A visual enhancement of the wing, curving its leading edge.")]
		private bool _isFancy;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Visual Airfoil", Order = 2, Tooltip = "A visual enhancement of the wing, affecting its overal shape to match its airfoil.")]
		private bool _isStylish;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxFuelCapacity;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _minSectionLength;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _rootLeadingOffset;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _rootTrailingOffset;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _thickness = 0.1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thicknessDelta = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thicknessDeltaStyle = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thicknessOffset = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thicknessOffsetStyle = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thicknessTip = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thicknessTipAuto = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _leadingBulge = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _leadingBulgeStyle = -1f;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _tipLeadingOffset;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private Vector3 _tipPosition;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _tipTrailingOffset;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Physics Enabled")]
		private bool _wingPhysicsEnabled;

		private float _wingStrength = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _wingStrengthOverride = -1f;

		public string Airfoil
		{
			get
			{
				return _airfoil;
			}
			set
			{
				_airfoil = value;
			}
		}

		public bool AllowControlSurfaces
		{
			get
			{
				return _allowControlSurfaces;
			}
			set
			{
				_allowControlSurfaces = value;
			}
		}

		public float AngleOfAttack
		{
			get
			{
				return _angleOfAttack;
			}
			set
			{
				_angleOfAttack = value;
			}
		}

		public bool AutoResize
		{
			get
			{
				if (_autoResize)
				{
					return Game.Instance.Settings.Game.Designer.EnableAutoResize;
				}
				return false;
			}
			set
			{
				_autoResize = value;
			}
		}

		public float BaseChord => RootLeadingOffset + RootTrailingOffset;

		public AnimationCurve CDrag
		{
			get
			{
				if (string.IsNullOrEmpty(_cDragOverride))
				{
					return null;
				}
				if (!Game.Instance.GameState.Validator.IsItemAvailable("Cheats.TinkerPanel"))
				{
					_cDragOverride = string.Empty;
					return null;
				}
				AnimationCurve animationCurve = new AnimationCurve();
				UserCurve.AddKeyframes(animationCurve, _cDragOverride);
				if (animationCurve.length <= 0)
				{
					return null;
				}
				return animationCurve;
			}
			set
			{
				IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
				if (!Game.Instance.GameState.Validator.IsItemAvailable("Cheats.TinkerPanel"))
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "This career doesn't allow the use of custom Drag Coefficients.";
				}
				else if (features.IsFeatureUnlocked(features.WingCurves, "save custom Wing Curves."))
				{
					_cDragOverride = UserCurve.GetKeyframesAsString(value, UserCurve.CurveStyle.Custom);
					base.Script.WingPhysicsScript.CD = value;
				}
			}
		}

		public AnimationCurve CLift
		{
			get
			{
				if (string.IsNullOrEmpty(_cLiftOverride))
				{
					return null;
				}
				if (!Game.Instance.GameState.Validator.IsItemAvailable("Cheats.TinkerPanel"))
				{
					_cLiftOverride = string.Empty;
					return null;
				}
				AnimationCurve animationCurve = new AnimationCurve();
				UserCurve.AddKeyframes(animationCurve, _cLiftOverride);
				if (animationCurve.length <= 0)
				{
					return null;
				}
				return animationCurve;
			}
			set
			{
				if (!Game.Instance.GameState.Validator.IsItemAvailable("Cheats.TinkerPanel"))
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "This career doesn't allow the use of custom Lift Coefficients.";
					return;
				}
				_cLiftOverride = UserCurve.GetKeyframesAsString(value, UserCurve.CurveStyle.Custom);
				base.Script.WingPhysicsScript.CL = value;
			}
		}

		public float ControlSurfacePriceMultiplier
		{
			get
			{
				return _controlSurfacePriceMultiplier;
			}
			set
			{
				_controlSurfacePriceMultiplier = value;
			}
		}

		public CraftSideType CraftSide
		{
			get
			{
				return _craftSide;
			}
			set
			{
				_craftSide = value;
			}
		}

		public float CurveLength => _curveLength;

		public float Density
		{
			get
			{
				if (!(_densityOverride >= 0f))
				{
					if (base.Version <= 1)
					{
						return 1f;
					}
					return _density;
				}
				return _densityOverride;
			}
			set
			{
				_densityOverride = -1f;
			}
		}

		public float FuelPercentage
		{
			get
			{
				return _fuelPercentage;
			}
			set
			{
				_fuelPercentage = value;
			}
		}

		public float HingeDistanceFromTrailingEdge
		{
			get
			{
				return Mathf.Clamp(_hingeDistanceFromTrailingEdge, 0f, IsFancy ? 0.4f : 1f);
			}
			set
			{
				_hingeDistanceFromTrailingEdge = value;
			}
		}

		public bool InvertAirfoil
		{
			get
			{
				return _invertAirfoil;
			}
			set
			{
				_invertAirfoil = value;
			}
		}

		public bool IsInverted => base.Script?.InvertAirfoil ?? InvertAirfoil;

		public bool IsFancy => _isFancy;

		public bool IsStylish => _isStylish;

		public override float MassDry => (Mathf.Max(0f, WingArea * Thickness - ((base.Version == 1) ? 0f : (0.001f * MaxFuelCapacity))) * Density + (float)((base.Version == 1) ? 2 : 0)) * 0.01f;

		public float MaxFuelCapacity
		{
			get
			{
				return _maxFuelCapacity;
			}
			set
			{
				_maxFuelCapacity = value;
			}
		}

		public float MinSectionLength
		{
			get
			{
				return _minSectionLength;
			}
			set
			{
				_minSectionLength = value;
			}
		}

		public override long Price => (long)Mathf.Sqrt(2000000f * MassDry * ControlSurfacePriceMultiplier);

		public float RootLeadingOffset
		{
			get
			{
				return _rootLeadingOffset;
			}
			set
			{
				_rootLeadingOffset = value;
			}
		}

		public float RootTrailingOffset
		{
			get
			{
				return _rootTrailingOffset;
			}
			set
			{
				_rootTrailingOffset = value;
			}
		}

		public float Thickness
		{
			get
			{
				return _thickness;
			}
			set
			{
				_thickness = value;
			}
		}

		public float ThicknessDelta
		{
			get
			{
				if (_isStylish)
				{
					if (!(_thicknessDelta < 0f))
					{
						return _thicknessDelta;
					}
					return _thicknessDeltaStyle;
				}
				return 1f;
			}
			set
			{
				_thicknessDeltaStyle = value;
			}
		}

		public float ThicknessOffset
		{
			get
			{
				if (_isStylish)
				{
					return (float)(IsInverted ? 1 : (-1)) * ((_thicknessOffset < 0f) ? _thicknessOffsetStyle : _thicknessOffset);
				}
				return 0f;
			}
			set
			{
				_thicknessOffsetStyle = value;
			}
		}

		public float ThicknessTip
		{
			get
			{
				if (_isStylish)
				{
					if (!(_thicknessTip < 0f))
					{
						return _thicknessTip;
					}
					return _thicknessTipAuto;
				}
				return _thickness;
			}
			set
			{
				_thicknessTipAuto = value;
			}
		}

		public float LeadingBulge
		{
			get
			{
				return Mathf.Max(0.5f, (_leadingBulge < 0f) ? _leadingBulgeStyle : _leadingBulge);
			}
			set
			{
				_leadingBulgeStyle = value;
			}
		}

		public float TipChord => TipLeadingOffset + TipTrailingOffset;

		public float TipLeadingOffset
		{
			get
			{
				return _tipLeadingOffset;
			}
			set
			{
				_tipLeadingOffset = value;
			}
		}

		public Vector3 TipPosition
		{
			get
			{
				return _tipPosition;
			}
			set
			{
				_tipPosition = value;
			}
		}

		public float TipTrailingOffset
		{
			get
			{
				return _tipTrailingOffset;
			}
			set
			{
				_tipTrailingOffset = value;
			}
		}

		public float WingArea => (BaseChord + TipChord) * WingSpan * 0.5f;

		public bool WingPhysicsEnabled
		{
			get
			{
				return _wingPhysicsEnabled;
			}
			set
			{
				_wingPhysicsEnabled = value;
			}
		}

		public float WingSpan => Mathf.Sqrt(TipPosition.x * TipPosition.x + TipPosition.y * TipPosition.y);

		public float WingStrength
		{
			get
			{
				if (_wingStrengthOverride > 0f)
				{
					return BaseChord * Thickness * _wingStrengthOverride * 30000f;
				}
				if (base.Version > 1)
				{
					return BaseChord * Thickness * _wingStrength * 30000f;
				}
				return float.PositiveInfinity;
			}
			set
			{
				_wingStrengthOverride = -1f;
			}
		}

		public event PropertyChangedHandler InvertAirfoilChanged;

		public override void OnDesignerPullout(string designerPartName, Assembly assembly, bool skipStartPartScale)
		{
			if (Game.Instance.GameState.Validator.IsCareerMode && !skipStartPartScale)
			{
				float initialPartScale = Game.Instance.GameState.Validator.GetInitialPartScale(IGameStateValidator.InitialPartScaleType.Wing);
				Thickness *= initialPartScale;
				RootLeadingOffset *= initialPartScale;
				RootTrailingOffset *= initialPartScale;
				TipLeadingOffset *= initialPartScale;
				TipTrailingOffset *= initialPartScale;
				TipPosition *= initialPartScale;
			}
		}

		public void DesignStart()
		{
			_fuelTank = base.Part.GetModifier<FuelTankData>();
			if (_fuelTank != null)
			{
				_fuelTank.FuelTypeChanged += OnFuelTypeChanged;
			}
		}

		public void InitialiseStyles()
		{
			IPartStyle style = base.Part.Styles[0].Style;
			_wingStrength = style.GetData("wingStrength", 1f);
			_density = style.GetData("density", 1f);
		}

		public void UpdateFuel()
		{
			InitialiseStyles();
			if (_fuelTank == null)
			{
				_fuelTank = base.Part.GetModifier<FuelTankData>();
			}
			if (_fuelTank == null)
			{
				_maxFuelCapacity = 0f;
				return;
			}
			float num = 0.25f * ((base.Version == 1) ? 1f : ((base.Version == 2) ? Thickness : Mathf.Sqrt(Thickness * 0.1f)));
			float num2 = Mathf.Max(0f, (BaseChord + TipChord) * (1f - HingeDistanceFromTrailingEdge) - num * 4f) * Mathf.Max(0f, WingSpan - num) * 0.5f * (Thickness + ThicknessTip) * 450f;
			_maxFuelCapacity = ((num2 < 10f) ? 0f : num2);
			_fuelTank.CalculateInitialFuel(_maxFuelCapacity, FuelPercentage);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnVisibilityRequested(() => _fuelPercentage, (bool x) => _fuelTank != null);
			d.OnVisibilityRequested(() => _airfoil, (bool x) => _allowAirfoilSelection);
			d.OnPropertyChanged(() => _invertAirfoil, delegate(bool newVal, bool oldVal)
			{
				this.InvertAirfoilChanged?.Invoke(newVal, oldVal);
				UpdateShape();
			});
			d.OnPropertyChanged(() => _fuelPercentage, delegate
			{
				OnFuelPercentageChanged();
			});
			d.OnPropertyChanged(() => _craftSide, delegate
			{
				this.InvertAirfoilChanged?.Invoke(InvertAirfoil, InvertAirfoil);
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			});
			d.OnPropertyChanged(() => _airfoil, delegate(string newVal, string oldVal)
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(WingData modifier)
				{
					modifier.Script.UpdateAirfoil(newVal);
				});
				UpdateShape();
			});
			d.OnPropertyChanged(() => _isFancy, delegate
			{
				UpdateShape();
			});
			d.OnPropertyChanged(() => _isStylish, delegate
			{
				UpdateShape();
			});
			d.OnValueLabelRequested(() => _fuelPercentage, (float x) => GetDesignerFuelLabel());
		}

		private string GetDesignerFuelLabel()
		{
			if (_fuelTank == null)
			{
				_fuelTank = base.Part.GetModifier<FuelTankData>();
			}
			if (_fuelTank != null)
			{
				return FuelTankScript.GetAmountLabel(_fuelTank.Script);
			}
			return string.Empty;
		}

		private void OnFuelPercentageChanged()
		{
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			UpdateFuel();
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}

		private void OnFuelTypeChanged(FuelTankData fuelTank)
		{
			UpdateFuel();
		}

		private void UpdateShape()
		{
			base.Script.UpdateWing();
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
		}
	}
}
