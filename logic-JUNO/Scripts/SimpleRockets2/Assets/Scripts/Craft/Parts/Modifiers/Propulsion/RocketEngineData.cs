using System;
using System.Collections.Generic;
using System.Linq;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using ModApi.Craft.Propulsion;
using ModApi.Data;
using ModApi.Design.PartProperties;
using ModApi.Math;
using ModApi.Mods;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	[Serializable]
	[DesignerPartModifier("Rocket Engine")]
	public class RocketEngineData : PartModifierData<RocketEngineScript>, IPartTextureStyleProvider
	{
		private RocketEngineType _engineSubType;

		private RocketEngineType _engineType;

		private UserCurve _thrustCurve;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 1f, 51, Label = "Chamber Pressure", Order = 15, Tooltip = "Higher chamber pressures can increase thrust and efficiency, but add additional cost.")]
		private float _chamberPressure = 1f;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Power Cycle", Order = 10, Tooltip = "The method used for injecting the propellant, which can greatly impact the performance of the engine.")]
		private string _engineSubTypeId = "GasGenerator";

		[SerializeField]
		[DesignerPropertySpinner(Label = "Engine Type", Order = 5, Tooltip = "The type of rocket engine.")]
		private string _engineTypeId = "Liquid";

		[SerializeField]
		[DesignerPropertySpinner(Label = "Fuel Type", Order = 12, Tooltip = "The type of fuel to use. Connected fuel tanks will be automatically updated to this fuel type if they have the Auto Select Fuel Type setting enabled.")]
		private string _fuelType = "LOX/RP1";

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Label = "Gimbal Range", Order = 20, Tooltip = "The maximum allowable range that the engine can rotate to assist in controlling the craft's attitude.")]
		private float _gimbalRange = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 201, Label = "Nozzle Length", Order = 35, Tooltip = "Increasing the nozzle length can increase the Nozzle Ratio, which will improve vacuum efficiency but it can decrease sea level efficiency and it adds additional mass and cost.")]
		private float _nozzleSize = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 1f, 51, Label = "Nozzle Throat Size", Order = 30, Tooltip = "Increasing the throat size can increase thrust, but will decrease the Nozzle Ratio, which decreases efficiency in a vacuum.")]
		private float _nozzleThroatSize = 0.75f;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Nozzle", Order = 25, Tooltip = "The nozzle style.")]
		private string _nozzleTypeId = "Bell";

		[SerializeField]
		[DesignerPropertySpinner(Label = "Fuel Grain", Order = 11, Tooltip = "The fuel grain of the solid propellant, defining its thrust curve.")]
		private string _fuelGrain = "Star";

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 151, Label = "Size", Order = 1, Tooltip = "Changes the overall size of the engine. Increasing size can increase thrust, but it also increases mass and price.", TechTreeIdForMaxValue = "MaxSize.RocketEngine")]
		private float _size = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _supportsWarpBurn;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thrustOverride = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _massFlowRateOverride = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _wattsPerFuelFlowOverride;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _ignited;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _ignitionsOverride = -1;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _ignitionsUsed;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _minThrottleOverride = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _throttleResponse = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _heatTransferOverride;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _directDamage;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _overexpansionDamage = 10f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _engineSoundOverride = "None";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector2 _exhaustExpansionRange = new Vector2(-1f, -1f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustGlobalIntensity = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustOffset;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustShockIntensity = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustShockDirectionOffset;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustRimShade = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustSootIntensity;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustSootLength;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColor = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorExpanded = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorTip = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorShock = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorFlame = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorSoot = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _smokeColor = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _hasSmoke = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _smokeOffset = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _smokeSpeedOverride = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _exhaustTextureStrength = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _nozzleDiscStrength = 5f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _mass;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private long _price = 1L;

		public bool IsPimped
		{
			get
			{
				if (_thrustOverride == 1f && _massFlowRateOverride == -1f && _wattsPerFuelFlowOverride == -1f && _minThrottleOverride == -1f && _throttleResponse == -1f && _heatTransferOverride == 1f && _directDamage == 0f && _overexpansionDamage == 10f)
				{
					return _supportsWarpBurn;
				}
				return true;
			}
			set
			{
				_thrustOverride = 1f;
				_massFlowRateOverride = -1f;
				_wattsPerFuelFlowOverride = -1f;
				_minThrottleOverride = -1f;
				_throttleResponse = -1f;
				_heatTransferOverride = 1f;
				_directDamage = 0f;
				_overexpansionDamage = 10f;
				_supportsWarpBurn = false;
			}
		}

		public UserCurve ThrustCurve => _thrustCurve;

		public Color ExhaustColor
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColor, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColor;
			}
		}

		public Color ExhaustColorExpanded
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorExpanded, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColorExpanded;
			}
		}

		public Color ExhaustColorTip
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorTip, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColorTip;
			}
		}

		public Color ExhaustColorShock
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorShock, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColorShock;
			}
		}

		public Color ExhaustColorFlame
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorFlame, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColorFlame;
			}
		}

		public Color ExhaustColorSoot
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorSoot, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColorSoot;
			}
		}

		public Vector2 ExhaustExpansionRange => _exhaustExpansionRange;

		public float ExhaustGlobalIntensity => _exhaustGlobalIntensity;

		public float ExhaustOffset => _exhaustOffset;

		public float ExhaustRimShade => _exhaustRimShade;

		public float ExhaustShockIntensity => _exhaustShockIntensity;

		public float ExhaustShockDirectionOffset => _exhaustShockDirectionOffset;

		public float ExhaustSootIntensity => _exhaustSootIntensity;

		public float ExhaustSootLength => _exhaustSootLength;

		public Color SmokeColor
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_smokeColor, out var color))
				{
					return color;
				}
				return FuelType.ExhaustColorSmoke;
			}
		}

		public float SmokeOffset
		{
			get
			{
				if (!(_smokeOffset < 0f))
				{
					return _smokeOffset;
				}
				return FuelType.SmokeOffset;
			}
		}

		public float SmokeSpeed => _smokeSpeedOverride;

		public float AltitudeCompensation => NozzleType.GetAltitudeCompensation(ExtensionSize);

		public float ChamberPressure => _chamberPressure * EngineType.ChamberPressure;

		public float UserChamberPressure => _chamberPressure;

		public string EngineSound => _engineSoundOverride;

		public string EngineSubTypeId => _engineSubType?.Id;

		public RocketEngineType EngineType => _engineSubType ?? _engineType;

		public string EngineTypeId => _engineType.Id;

		public float ExhaustScale => _exhaustScale;

		public float ThrustOverride => _thrustOverride;

		public float MassFlowRateOverride => _massFlowRateOverride;

		public float WattsPerFuelFlowOverride => _wattsPerFuelFlowOverride;

		public bool Ignited
		{
			get
			{
				return _ignited;
			}
			set
			{
				_ignited = value;
			}
		}

		public int IgnitionsMax
		{
			get
			{
				if (_ignitionsOverride >= 0)
				{
					return _ignitionsOverride;
				}
				return EngineType.Ignitions;
			}
		}

		public int IgnitionsUsed
		{
			get
			{
				return _ignitionsUsed;
			}
			set
			{
				_ignitionsUsed = value;
			}
		}

		public float MinThrottleOverride => _minThrottleOverride;

		public float ThrottleResponse => _throttleResponse;

		public float HeatTransferOverride => _heatTransferOverride;

		public float DirectDamage => _directDamage;

		public float OverexpansionDamage => _overexpansionDamage;

		public bool HasSmoke
		{
			get
			{
				if (_hasSmoke)
				{
					return FuelType.ExhaustColorSmoke.a > 0f;
				}
				return false;
			}
		}

		public float ExhaustTextureStrength => _exhaustTextureStrength;

		public float NozzleDiscStrength => _nozzleDiscStrength;

		public float ExtensionSize
		{
			get
			{
				return _nozzleSize;
			}
			set
			{
				_nozzleSize = value;
			}
		}

		public FuelType FuelType { get; private set; }

		public float GimbalRange
		{
			get
			{
				return _gimbalRange;
			}
			set
			{
				_gimbalRange = value;
			}
		}

		public override float MassDry => _mass;

		public float NozzleAreaExit { get; private set; }

		public float NozzleAreaThroat { get; private set; }

		public float NozzleExitRadius => Size * (NozzleType?.GetExitRadius(ExtensionSize) ?? 0f);

		public float NozzleThroatRadius => Size * NozzleType.ThroatRadius * _nozzleThroatSize;

		public float UserNozzleThroatRadius
		{
			get
			{
				return _nozzleThroatSize;
			}
			set
			{
				_nozzleThroatSize = value;
			}
		}

		public RocketNozzleType NozzleType { get; private set; }

		public FuelGrain FuelGrain { get; private set; }

		public override long Price => _price;

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

		public override string ScaleCareerID => "MaxSize.RocketEngine";

		public float Size => _size * EngineType.BaseScale;

		public bool SupportsWarpBurn => _supportsWarpBurn;

		public float TopRadius => EngineType.Radius * Size;

		public static string FormatRatio(float x)
		{
			return $"{x:n2}x";
		}

		public void CalculateMassAndPrice(float normalizedMassFlow, float coreThrust)
		{
			float size = Size;
			float num = NozzleType?.CalculateMass(size, ExtensionSize) ?? 0f;
			_mass = (normalizedMassFlow * EngineType.MassScale + EngineType.BaseMass + num) * 0.01f;
			float num2 = num * 30f * NozzleType.PriceScale;
			_price = (long)(1f * coreThrust / _nozzleThroatSize * EngineType.PriceScale * FuelType.EnginePriceScale + EngineType.BasePrice + num2);
			if (EngineType.GimbalRange > 0f && _gimbalRange > 0f)
			{
				_mass += _mass * 0.2f;
				_price += (long)((float)_price * 0.5f);
			}
		}

		public IReadOnlyList<IPartTextureStyle> GetAvailablePartTextureStyles(string partTypeId, int subpartIndex, string partStyleId)
		{
			List<IPartTextureStyle> list = new List<IPartTextureStyle>();
			List<string> list2 = null;
			switch (subpartIndex)
			{
			case 0:
				list2 = EngineType?.TextureStyleIds;
				break;
			case 1:
				list2 = EngineType?.SubTextureStyleIds;
				break;
			case 2:
				list2 = NozzleType?.TextureStyleIds;
				break;
			case 3:
				list2 = NozzleType?.ExtensionTextureStyleIds;
				break;
			}
			if (list2 == null || list2.Count == 0)
			{
				return list;
			}
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			foreach (string item in list2)
			{
				IPartTextureStyle textureStyle = partStyleManager.GetTextureStyle(item);
				if (item == null)
				{
					Debug.LogError("Could not find texture style '" + item + "' for RocketEngine.");
				}
				else
				{
					list.Add(textureStyle);
				}
			}
			return list;
		}

		public override void GetModRequirements(AddModRequirementDelegate addModRequirement)
		{
			base.GetModRequirements(addModRequirement);
			if (_engineType?.Mod != null)
			{
				addModRequirement(_engineType.Mod.ModInfo, requiresCodeExecution: false);
			}
			if (_engineSubType?.Mod != null)
			{
				addModRequirement(_engineSubType.Mod.ModInfo, requiresCodeExecution: false);
			}
			if (NozzleType?.Mod != null)
			{
				addModRequirement(NozzleType.Mod.ModInfo, requiresCodeExecution: false);
			}
			if (FuelGrain?.Mod != null)
			{
				addModRequirement(FuelGrain.Mod.ModInfo, requiresCodeExecution: false);
			}
		}

		public void OnSymmetry(IPartScript originalPart)
		{
			RocketEngineData modifier = originalPart.Data.GetModifier<RocketEngineData>();
			_fuelType = modifier._fuelType;
			FuelType = modifier.FuelType;
			base.Script.UpdateAutoFuelTypeFuelTanks();
		}

		public void UpdateEngineType(bool updateFuelType)
		{
			_engineType = Game.Instance.PropulsionData.RocketEngines.First((RocketEngineType x) => x.Id == _engineTypeId);
			if (_engineType.SubTypes.Count > 0)
			{
				_engineSubType = _engineType.SubTypes.FirstOrDefault((RocketEngineType x) => x.Id == _engineSubTypeId);
				if (_engineSubType == null)
				{
					if (_engineType.IsAbstractType)
					{
						if (Game.InDesignerScene && Game.IsCareer)
						{
							IGameStateValidator validator = Game.Instance.GameState.Validator;
							foreach (RocketEngineType subType in _engineType.SubTypes)
							{
								if (validator.IsItemAvailable("RocketEngine.Power.{0}", subType.Id))
								{
									_engineSubType = subType;
									_engineSubTypeId = subType.Id;
								}
							}
						}
						if (_engineSubType == null)
						{
							_engineSubType = _engineType.SubTypes.First();
							_engineSubTypeId = _engineSubType.Id;
						}
					}
					else
					{
						_engineSubTypeId = string.Empty;
					}
				}
			}
			else
			{
				_engineSubType = null;
			}
			if (updateFuelType)
			{
				FuelType fuelType = EngineType.SupportedFuels.Where((FuelType x) => x.Id == _fuelType).FirstOrDefault();
				if (fuelType == null)
				{
					fuelType = EngineType.SupportedFuels.First();
				}
				if (fuelType != FuelType)
				{
					FuelType = fuelType;
					base.Script.UpdateAutoFuelTypeFuelTanks();
				}
			}
			NozzleType = EngineType.SupportedNozzles.Where((RocketNozzleType x) => x.Id == _nozzleTypeId).FirstOrDefault();
			if (NozzleType == null)
			{
				if (Game.InDesignerScene && Game.IsCareer)
				{
					IGameStateValidator validator2 = Game.Instance.GameState.Validator;
					foreach (RocketNozzleType supportedNozzle in EngineType.SupportedNozzles)
					{
						if (validator2.IsItemAvailable("RocketEngine.Nozzle.{0}", supportedNozzle.Id))
						{
							NozzleType = supportedNozzle;
							_nozzleTypeId = supportedNozzle.Id;
						}
					}
				}
				if (NozzleType == null)
				{
					NozzleType = EngineType.SupportedNozzles.First();
					_nozzleTypeId = NozzleType.Id;
				}
			}
			FuelGrain = EngineType.FuelGrains.Where((FuelGrain x) => x.Id == _fuelGrain).FirstOrDefault();
			if (FuelGrain == null && EngineType.FuelGrains.Count > 0)
			{
				if (Game.InDesignerScene && Game.IsCareer)
				{
					IGameStateValidator validator3 = Game.Instance.GameState.Validator;
					foreach (FuelGrain fuelGrain in EngineType.FuelGrains)
					{
						if (validator3.IsItemAvailable("RocketEngine.Grain.{0}", fuelGrain.Id))
						{
							FuelGrain = fuelGrain;
							_fuelGrain = fuelGrain.Id;
						}
					}
				}
				if (FuelGrain == null)
				{
					FuelGrain = EngineType.FuelGrains.First();
					_fuelGrain = FuelGrain.Id;
				}
			}
			UpdateThrustCurve();
			if (_nozzleThroatSize < 0.001f)
			{
				_nozzleThroatSize = 0.001f;
			}
			float num = NozzleThroatRadius * EngineType.NozzleRadiusScale;
			float num2 = NozzleExitRadius * EngineType.NozzleRadiusScale;
			NozzleAreaThroat = num * num * MathF.PI;
			NozzleAreaExit = num2 * num2 * MathF.PI;
			if (!Game.InDesignerScene)
			{
				return;
			}
			if (_engineType.SubTypes.Count > 0)
			{
				base.DesignerPartProperties.GetSpinnerProperty(() => _engineSubTypeId)?.UpdateValues();
			}
			if (EngineType.FuelGrains.Count > 0)
			{
				base.DesignerPartProperties.GetSpinnerProperty(() => _nozzleTypeId)?.UpdateValues();
			}
			base.DesignerPartProperties.GetSpinnerProperty(() => _fuelType)?.UpdateValues();
			if (EngineType.SupportedNozzles.Count > 0)
			{
				base.DesignerPartProperties.GetSpinnerProperty(() => _nozzleTypeId)?.UpdateValues();
			}
			if (_engineType.FuelGrains.Count > 0)
			{
				base.DesignerPartProperties.GetSpinnerProperty(() => _fuelGrain)?.UpdateValues();
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPropertyChanged(() => _size, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: false);
			});
			d.OnPropertyChanged(() => _engineTypeId, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: true, d);
			});
			d.OnPropertyChanged(() => _engineSubTypeId, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: true, d);
			});
			d.OnPropertyChanged(() => _fuelType, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: false, d);
			});
			d.OnPropertyChanged(() => _nozzleTypeId, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: true);
			});
			d.OnPropertyChanged(() => _nozzleSize, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: false);
			});
			d.OnPropertyChanged(() => _nozzleThroatSize, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: false);
			});
			d.OnPropertyChanged(() => _chamberPressure, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: false);
			});
			d.OnPropertyChanged(() => _gimbalRange, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: false);
			});
			d.OnPropertyChanged(() => _fuelGrain, delegate
			{
				UpdateAndSyncComponents(refreshTextureStyles: true);
				UpdateThrustCurve();
			});
			d.OnValueLabelRequested(() => _size, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _gimbalRange, (float x) => (x != 0f) ? Units.GetAngleString(x * EngineType.GimbalRange, 1) : "Disabled");
			d.OnValueLabelRequested(() => _chamberPressure, (float x) => FormatChamberPressure());
			d.OnValueLabelRequested(() => _nozzleSize, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _nozzleThroatSize, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _engineTypeId, (string x) => _engineType.Name);
			d.OnValueLabelRequested(() => _engineSubTypeId, (string x) => _engineSubType?.Name ?? "Default");
			d.OnValueLabelRequested(() => _fuelGrain, (string x) => FuelGrain?.Name);
			d.OnValueLabelRequested(() => _fuelType, (string x) => FuelType.Name);
			d.OnValueLabelRequested(() => _nozzleTypeId, (string x) => NozzleType?.Name);
			d.OnVisibilityRequested(() => _engineSubTypeId, (bool x) => _engineType.SubTypes.Count > 0);
			d.OnVisibilityRequested(() => _fuelGrain, (bool x) => EngineType.FuelGrains.Count > 0);
			d.OnVisibilityRequested(() => _fuelType, (bool x) => EngineType.SupportedFuels.Count > 1);
			d.OnVisibilityRequested(() => _nozzleTypeId, (bool x) => EngineType.SupportedNozzles.Count > 0);
			d.OnVisibilityRequested(() => _nozzleSize, (bool x) => NozzleType?.ExtensionPrefabId != null);
			d.OnVisibilityRequested(() => _gimbalRange, (bool x) => EngineType.GimbalRange > 0f);
			d.OnPartStyleChanged(delegate
			{
				OnPartStyleChanged();
			});
			d.OnSpinnerValuesRequested(() => _engineTypeId, GetEngineTypes);
			d.OnSpinnerValuesRequested(() => _engineSubTypeId, GetEngineSubTypes);
			d.OnSpinnerValuesRequested(() => _fuelGrain, GetFuelGrains);
			d.OnSpinnerValuesRequested(() => _fuelType, GetFuelTypes);
			d.OnSpinnerValuesRequested(() => _nozzleTypeId, GetNozzleTypes);
			d.OnActivated(delegate
			{
				base.Script.PreviewExhaust = true;
			});
			d.OnDeactivated(delegate
			{
				base.Script.PreviewExhaust &= base.Part.IsDestroyed;
			});
			d.OnAnyPropertyChanged(delegate
			{
				base.Script.InitializeExhaust();
			});
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			FuelType = Game.Instance.PropulsionData.GetFuelType(_fuelType);
			UpdateEngineType(updateFuelType: false);
			UpdateThrustCurve();
		}

		private string FormatChamberPressure()
		{
			return Units.GetPressureString(ChamberPressure);
		}

		private void GetEngineSubTypes(List<string> list)
		{
			list.Clear();
			if (_engineType.SubTypes.Count > 0 && !_engineType.IsAbstractType)
			{
				list.Add(string.Empty);
			}
			foreach (RocketEngineType subType in _engineType.SubTypes)
			{
				if (Game.Instance.GameState.Validator.IsItemAvailable("RocketEngine.Power.{0}", subType.Id))
				{
					list.Add(subType.Id);
				}
			}
		}

		private void GetEngineTypes(List<string> obj)
		{
			obj.Clear();
			foreach (RocketEngineType rocketEngine in Game.Instance.PropulsionData.RocketEngines)
			{
				if (Game.Instance.GameState.Validator.IsItemAvailable("RocketEngine.Power.{0}", rocketEngine.Id))
				{
					obj.Add(rocketEngine.Id);
				}
			}
		}

		private void GetFuelTypes(List<string> obj)
		{
			obj.Clear();
			foreach (FuelType supportedFuel in EngineType.SupportedFuels)
			{
				if (Game.Instance.GameState.Validator.IsItemAvailable("FuelType.{0}", supportedFuel.Id))
				{
					obj.Add(supportedFuel.Id);
				}
			}
		}

		private void GetNozzleTypes(List<string> obj)
		{
			obj.Clear();
			foreach (RocketNozzleType supportedNozzle in EngineType.SupportedNozzles)
			{
				if (Game.Instance.GameState.Validator.IsItemAvailable("RocketEngine.Nozzle.{0}", supportedNozzle.Id))
				{
					obj.Add(supportedNozzle.Id);
				}
			}
		}

		private void GetFuelGrains(List<string> obj)
		{
			obj.Clear();
			foreach (FuelGrain fuelGrain in EngineType.FuelGrains)
			{
				if (Game.Instance.GameState.Validator.IsItemAvailable("RocketEngine.Grain.{0}", fuelGrain.Id))
				{
					obj.Add(fuelGrain.Id);
				}
			}
			if (obj.Count == 0)
			{
				obj.Add(string.Empty);
			}
		}

		private void OnPartStyleChanged()
		{
			UpdateAndSyncComponents(refreshTextureStyles: true);
		}

		private void UpdateAndSyncComponents(bool refreshTextureStyles, IDesignerPartPropertiesModifierInterface d = null)
		{
			base.Script.UpdateComponentsInDesigner(updateFuel: true, updateSymmetricParts: true);
			base.Script.PartScript.CraftScript.SetStructureChanged();
			if (d != null)
			{
				base.Script.VisibilityThrottle(EngineType.FuelGrains.Count == 0);
				d.Manager.Flyout.RefreshUI();
			}
			if (refreshTextureStyles)
			{
				base.DesignerPartProperties.Manager.Flyout.RefreshTextureStyles();
			}
		}

		private void UpdateThrustCurve()
		{
			_thrustCurve = FuelGrain?.ThrustCurve;
		}
	}
}
