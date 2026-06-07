using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Flight.Combat;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[Serializable]
	[PartModifierDesignerHeader("Missile Configuration")]
	public class ProceduralMissileData : PartModifierData
	{
		private const float AirframeDensity = 1745.7795f;

		private const float AvionicsVolumePercentage = 0.1f;

		private const float InternalVolumeRatio = 0.85f;

		private const float JetFuelDensity = 1200f;

		private const float MaxRadiusPercentage = 2.5f;

		private const float MinRadiusPercentage = 0.5f;

		private const float SolidRocketFuelDensity = 1200f;

		private const float WarheadBiasInfluence = 0.15f;

		private const float WarheadDensity = 1700f;

		[DesignerPropertySlider(-1f, 1f, 201, Label = "Attach Position", Order = 20, Tooltip = "Changes the attach position along the length of the missile.")]
		private float _attachPosition;

		private string _bodyType = "Basic";

		[DesignerPropertySlider(0f, 1f, 101, Label = "Burn Time", Order = 105, Tooltip = "Changes how long the engine burns.")]
		private float _burnTimePercentage = 0.1f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Engine Type", Header = "Engine", Tooltip = "The type of engine the missile uses", Order = 100)]
		private MissileEngineType _engineType;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Mode", Tooltip = "The mode the weapon is used with", Order = 51)]
		private WeaponFunction _function;

		[DesignerPropertySlider(0f, 5f, 51, Label = "Guidance Activation Delay", Order = 55, Tooltip = "How long to wait after launch before the missile starts guiding. A short delay helps to ensure the missile safely clears your aircraft before turning.")]
		private float _guidanceActivationDelay = 1f;

		[DesignerPropertySlider(0f, 5f, 51, Label = "Ignition Delay", Order = 110, Tooltip = "How long to wait after firing until the engine is ignited.")]
		private float _ignitionDelay = 1f;

		private float _lastRadius;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Lofting", Order = 58, Tooltip = "Changes the amount the missile lofts after launch.")]
		private float _loftPercentage;

		[DesignerPropertySlider(0.1f, 1f, 91, Label = "Nose Length", Order = 59, Tooltip = "Changes how long the nose is, but longer doesn't necessarily mean it's lying.")]
		private float _noseLength = 1f;

		private string _noseType;

		[DesignerPropertyLabel(Label = "Acceleration", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 502, Tooltip = "How quickly the missile reaches its top speed. Higher acceleration results in a higher achievable top speed.")]
		private string _performanceAcceleration;

		[DesignerPropertyLabel(Label = "Explosiveness", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 515, Tooltip = "How explosive the missile is.")]
		private string _performanceExplosiveness;

		[DesignerPropertyLabel(Label = "Tracking Rate", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 510, Tooltip = "How quickly the missile can change its heading.")]
		private string _performanceHeadingRate;

		[DesignerPropertyLabel(Label = "Max Speed", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 500, Tooltip = "A ballpark estimate for the maximum speed of the missile", Header = "Performance")]
		private string _performanceMaxSpeed;

		[DesignerPropertyLabel(Label = "Turn Rate", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 505, Tooltip = "The missile's agility and maximum G-load capacity during maneuvers.")]
		private string _performanceTurnRate;

		[DesignerPropertySlider(0.5f, 2.5f, 201, Label = "Diameter", Order = 15, Tooltip = "Changes the overall diameter of the missile.")]
		private float _radius = 1f;

		private bool _refreshUI;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Seeker FOV", Order = 52, Tooltip = "Changes the radius of the FOV circle (in degrees).")]
		private float _seekerFovPercentage;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Guidance Type", Header = "Guidance", Tooltip = "The type of seeker the missile uses.", Order = 50)]
		private SeekerType _seekerType = SeekerType.ActiveRadar;

		[DesignerPropertySlider(0.5f, 1.5f, 101, Label = "Size", Order = 10, Tooltip = "Changes the overall size of the missile.")]
		private float _sizePercentage = 1f;

		private bool _updateMissileModifier = true;

		private float _warheadBias;

		public float Acceleration
		{
			get
			{
				if (BurnTime <= 0f)
				{
					return 0f;
				}
				return AdjustedDeltaV / BurnTime * 0.35f;
			}
		}

		public override bool AllowDisableSymmetry => false;

		public float AttachPosition => _attachPosition;

		public float BodySurfaceArea => Length * Radius * MathF.PI * 2f;

		public float BurnTime
		{
			get
			{
				MissileEngineData engineData = EngineData;
				return Mathf.Lerp(engineData.MinBurnTime, engineData.MaxBurnTime, _burnTimePercentage);
			}
		}

		public float BurnTimePercentage => _burnTimePercentage;

		public MissileEngineData EngineData { get; private set; }

		public float Length => 3f * Size;

		public float MissileLength { get; set; }

		public Vector3 MissileScale
		{
			get
			{
				Vector3 baseSize = ProceduralMissileBuilder.BaseSize;
				baseSize.Scale(new Vector3(RadiusScale, RadiusScale, 1f) * Size);
				return baseSize;
			}
		}

		public float NoseLength => _noseLength;

		public string NoseTypeOverride => _noseType;

		public float Radius => 0.08f * RadiusScale * Size;

		public float RadiusScale => _radius;

		public ProceduralMissileScript Script { get; private set; }

		public SeekerData Seeker { get; private set; }

		public float Size => EngineData.BaseSize * _sizePercentage;

		public float Volume => Radius * Radius * MathF.PI * Length;

		private float AdjustedDeltaV
		{
			get
			{
				float num = 1f - _warheadBias * 0.5f;
				float num2 = Mathf.Clamp(Mathf.Sqrt(Size * RadiusScale), 0.5f, 2.5f);
				return EngineData.DeltaV * num * num2;
			}
		}

		private float SeekerFov => Mathf.Lerp(Seeker.MinFOV, Seeker.MaxFOV, _seekerFovPercentage);

		private float WarheadMass => WarheadVolume * 1700f;

		private float WarheadVolume
		{
			get
			{
				float num = Volume * 0.9f;
				float num2 = 0.5f + _warheadBias * 0.5f;
				return num * num2;
			}
		}

		public ProceduralMissileData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("attachPosition", AttachPosition));
			xElement.Add(new XAttribute("body", _bodyType));
			xElement.Add(new XAttribute("engine", _engineType));
			xElement.Add(new XAttribute("seeker", _seekerType));
			xElement.Add(new XAttribute("radius", _radius));
			xElement.Add(new XAttribute("size", _sizePercentage));
			xElement.Add(new XAttribute("burnTime", _burnTimePercentage));
			xElement.Add(new XAttribute("seekerFOV", _seekerFovPercentage));
			xElement.Add(new XAttribute("noseLength", _noseLength));
			xElement.Add(new XAttribute("warheadBias", _warheadBias));
			if (!string.IsNullOrEmpty(_noseType))
			{
				xElement.Add(new XAttribute("nose", _noseType));
			}
			if (!_updateMissileModifier)
			{
				xElement.Add(new XAttribute("updateMissileModifier", _updateMissileModifier));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_sizePercentage":
				return Utilities.FormatPercentage(sliderValue) + " (" + MissileLength.Format(UnitType.ShortDistance, solo: false, longName: false, "#,###.00") + ")";
			case "_radius":
				return Utilities.FormatPercentage(sliderValue) + " (" + (Radius * 2f).Format(UnitType.TinyDistance, solo: false, longName: false, "#,###.0") + ")";
			case "_noseLength":
			case "_loftPercentage":
			case "_attachPosition":
				return Utilities.FormatPercentage(sliderValue);
			case "_warheadBias":
			{
				string text = Utilities.FormatPercentage(Mathf.Abs(sliderValue));
				string text2 = ((sliderValue == 0f) ? "Balanced" : ((sliderValue < 0f) ? "More Fuel" : "More Warhead"));
				return "+" + text + " " + text2;
			}
			case "_seekerFovPercentage":
			{
				float seekerFov = SeekerFov;
				float value = CalculateMaxLockRange(seekerFov);
				return string.Format("{0:n1}° ({1})", seekerFov, value.Format(UnitType.LongDistance, solo: false, longName: false, "0.0"));
			}
			case "_ignitionDelay":
			case "_guidanceActivationDelay":
				return $"{sliderValue:n1}s";
			case "_burnTimePercentage":
				if (BurnTime < 60f)
				{
					return $"{BurnTime:n1}s";
				}
				return $"{BurnTime / 60f:n1}m";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_seekerFovPercentage":
			case "_loftPercentage":
			case "_guidanceActivationDelay":
				return delegate
				{
					SeekerData seeker = Seeker;
					return seeker != null && seeker.MaxFOV > 0f;
				};
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<ProceduralMissileScript>();
			Script.Data = this;
			return Script;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshUI)
			{
				genericPartProperties.RefreshUI();
				_refreshUI = false;
			}
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			UpdatePerformanceDisplay(base.Part.GetModifier<MissileData>());
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			bool flag = false;
			switch (propertyName)
			{
			case "_seekerType":
				Seeker = SeekerData.GetSeeker(_seekerType);
				Script.Build();
				_function = Seeker.Function;
				flag = true;
				break;
			case "_sizePercentage":
				_radius = Mathf.Clamp(_lastRadius / (0.08f * Size), 0.5f, 2.5f);
				flag = true;
				break;
			case "_radius":
			case "_noseLength":
			case "_burnTimePercentage":
			case "_warheadBias":
				flag = true;
				break;
			case "_engineType":
				EngineData = MissileEngineData.GetEngineData(_engineType);
				Script.Build();
				flag = true;
				break;
			}
			_lastRadius = Radius;
			UpdateComponents();
			RecalculateMass(recalculatePartMass: true);
			if (flag)
			{
				_refreshUI = true;
				Designer.Instance.SetAircraftStructureChanged();
			}
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			MissileData modifier = base.Part.GetModifier<MissileData>();
			_function = modifier.Function;
			_guidanceActivationDelay = modifier.GuidanceActivationDelay;
			_ignitionDelay = modifier.IgnitionDelay;
			_loftPercentage = modifier.LoftPercentage;
		}

		public override void OnPartNameChanged(string name)
		{
			base.OnPartNameChanged(name);
			UpdateMissileData();
		}

		public void RefreshPerformance()
		{
			UpdateMissileData();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_attachPosition = stateElement.GetFloatAttribute("attachPosition", _attachPosition);
			_bodyType = stateElement.GetStringAttribute("body", _bodyType);
			_engineType = stateElement.GetEnumAttribute("engine", _engineType);
			_seekerType = stateElement.GetEnumAttribute("seeker", _seekerType);
			_seekerFovPercentage = stateElement.GetFloatAttribute("seekerFOV", _seekerFovPercentage);
			_radius = stateElement.GetFloatAttribute("radius", _radius);
			_sizePercentage = stateElement.GetFloatAttribute("size", _sizePercentage);
			_burnTimePercentage = stateElement.GetFloatAttribute("burnTime", _burnTimePercentage);
			_noseLength = stateElement.GetFloatAttribute("noseLength", _noseLength);
			_noseType = stateElement.GetStringAttribute("nose");
			_warheadBias = stateElement.GetFloatAttribute("warheadBias", _warheadBias);
			_updateMissileModifier = stateElement.GetBoolAttribute("updateMissileModifier", _updateMissileModifier);
			Seeker = SeekerData.GetSeeker(_seekerType);
			EngineData = MissileEngineData.GetEngineData(_engineType);
			_lastRadius = Radius;
		}

		public void UpdateMissileData()
		{
			if (_updateMissileModifier)
			{
				MissileData modifier = base.Part.GetModifier<MissileData>();
				modifier.Seeker = Seeker.Type;
				float seekerFov = SeekerFov;
				modifier.CustomName = base.Part.Name;
				modifier.MaxTargetingAngle = seekerFov;
				modifier.MaxRange = CalculateMaxLockRange(seekerFov);
				modifier.MinRange = 0f;
				modifier.MaxFuelTime = BurnTime;
				modifier.MaxForwardThrustForce = Acceleration * CalculateMass() / 0.01f;
				modifier.ProximityDetonationRangeMin = 1f;
				modifier.Function = _function;
				modifier.GuidanceActivationDelay = _guidanceActivationDelay;
				modifier.IgnitionDelay = _ignitionDelay;
				modifier.ExplosionScale = Mathf.Pow(WarheadMass, 1f / 3f) * 0.75f;
				modifier.LoftPercentage = _loftPercentage;
				UpdatePerformance(modifier);
			}
		}

		protected override float CalculateMass()
		{
			float num = 0.35f;
			float num2 = Volume * 1745.7795f * num;
			float num3 = Volume * 0.85f;
			float num4 = num3 * 0.1f * 1745.7795f;
			float num5 = ((_engineType == MissileEngineType.Jet) ? 0.45f : 0.25f);
			float num6 = num3 * 0.9f;
			float value = num5 + _warheadBias * 0.15f;
			value = Mathf.Clamp(value, 0.05f, 0.95f);
			float num7 = num6 * value;
			float num8 = num6 * (1f - value);
			float num9 = ((_engineType == MissileEngineType.Jet) ? 1200f : 1200f);
			float num10 = num7 * 1700f;
			float num11 = num8 * num9;
			return (num2 + num4 + num10 + num11) / (1f - EngineData.MassPercentage) * 0.01f;
		}

		private float CalculateMaxLockRange(float seekerFov)
		{
			if (seekerFov < Seeker.MinFOV)
			{
				seekerFov = Seeker.MinFOV;
			}
			return Seeker.MaxLockRange * Seeker.MinFOV / seekerFov;
		}

		private void UpdateComponents()
		{
			Script.Adjust(repositionConnectedParts: true);
			UpdateMissileData();
		}

		private void UpdatePerformance(MissileData missileData)
		{
			Script.CalculateFinPerformanceCharacteristics(out var totalFinSurfaceArea, out var centerOfLift);
			float num = Mathf.Clamp(totalFinSurfaceArea / CalculateMass(), 0.05f, 2f);
			Mathf.InverseLerp(1f, 0.1f, num);
			missileData.MaxSpeed = EngineData.MaxSpeed * Mathf.Clamp(1f - num * 0.2f, 0.25f, 1f);
			missileData.MaxVelocityAngleAdjustmentRate = num * 50f;
			missileData.MaxThrustVectoringRate = (EngineData.IsThrustVectoring ? (Acceleration * 0.25f) : 0f);
			float num2 = Mathf.Lerp(0.5f, 1f, Mathf.InverseLerp(-1f, 0f, centerOfLift));
			missileData.MaxHeadingAngleAdjustmentRate = num * 100f * num2;
			UpdatePerformanceDisplay(missileData);
		}

		private void UpdatePerformanceDisplay(MissileData missileData)
		{
			float num = Mathf.Min(BurnTime, 12f);
			float num2 = Acceleration * num;
			float num3 = 1f / Mathf.Max(1f, RadiusScale);
			Mathf.Min(250f + num2 * 0.75f * num3, missileData.MaxSpeed);
			_performanceMaxSpeed = missileData.MaxSpeed.Format(UnitType.Speed) ?? "";
			_performanceExplosiveness = $"{missileData.ExplosionScale:n1} BOOMS";
			_performanceHeadingRate = $"{missileData.MaxHeadingAngleAdjustmentRate + missileData.MaxThrustVectoringRate:n1} deg/s";
			float num4 = Acceleration / 9.81f;
			_performanceAcceleration = $"{num4:n1} Gs";
			float num5 = missileData.MaxVelocityAngleAdjustmentRate * (MathF.PI / 180f);
			float num6 = missileData.MaxSpeed * num5 / 9.81f;
			_performanceTurnRate = $"{num6:n1} Gs";
		}
	}
}
