using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Flight.Combat;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Cannon")]
	public class CannonData : PartModifierData
	{
		public enum ProjectileStyle
		{
			Sphere = 0,
			Slug = 1
		}

		public enum ProjectileType
		{
			Basic = 0,
			Explosive = 1
		}

		public const float BaseDamage = 0.3f;

		public const float DiameterScalar = 0.5f;

		public const float ProjectileBaseDensity = 1f;

		[DesignerPropertySlider(MinValue = 10f, MaxValue = 1000f, NumberOfSteps = 100, Label = "Ammo Count", Order = 6)]
		private int _ammoCount = 100;

		[DesignerPropertySlider(MinValue = 0.5f, MaxValue = 2.5f, NumberOfSteps = 21, Label = "Barrel Length", Order = 11)]
		private float _barrelLength = 2.5f;

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 1f, NumberOfSteps = 21, Label = "Barrel Recoil", Order = 13)]
		private float _barrelRecoil = 1f;

		[DesignerPropertySlider(MinValue = 0.5f, MaxValue = 2.5f, NumberOfSteps = 21, Label = "Base Length", Order = 10)]
		private float _baseLength = 2.5f;

		[DesignerPropertyToggleButton(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Armed Group", Order = 0, AllowFunkyInput = true)]
		private string _designerActivationGroup = "All";

		[DesignerPropertyToggleButton(new string[] { "Ground", "Air", "Multi-Role" }, Label = "Target", Order = 3)]
		private string _designerTarget = "Ground";

		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 2f, NumberOfSteps = 20, Label = "Caliber: \n", Order = 9)]
		private float _diameter = 0.3f;

		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 5f, NumberOfSteps = 50, Label = "Minimum Firing Delay", Order = 7)]
		private float _firingDelay = 1f;

		private float _launchVolume = 1f;

		[DesignerPropertyToggleButton(new string[] { "Off", "On" }, Label = "Muzzle Brake", Order = 12)]
		private bool _muzzleBrake = true;

		[DesignerPropertyToggleButton(new string[] { "Sphere", "Slug" }, Label = "Projectile Style", Order = 2)]
		private ProjectileStyle _projectileStyle = ProjectileStyle.Slug;

		[DesignerPropertyToggleButton(new string[] { "Basic", "Explosive" }, Label = "Projectile Type", Order = 1)]
		private ProjectileType _projectileType = ProjectileType.Explosive;

		[DesignerPropertyLabel(Order = 5)]
		private string _velocitySpacer = " ";

		[DesignerPropertySlider(MinValue = 50f, MaxValue = 1250f, NumberOfSteps = 25, Label = "Projectile Velocity: \n", Order = 4)]
		private float _projectileVelocity = 500f;

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 2.5f, NumberOfSteps = 26, Label = "Recoil Force", Order = 14)]
		private float _recoilForce = 1f;

		private CannonScript _script;

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 101f, NumberOfSteps = 102, Label = "Tracer Spacing", Order = 15)]
		private int _tracerSpacing = int.MaxValue;

		[DesignerPropertyLabel(Order = 8)]
		private string _caliberSpacer = " ";

		public string ActivationGroup { get; private set; } = "0";

		public int AmmoCount => _ammoCount;

		public ProjectileStyle AmmoStyle => _projectileStyle;

		public ProjectileType AmmoType => _projectileType;

		public float BarrelLength => _barrelLength;

		public float BarrelRecoil => _barrelRecoil;

		public float BaseLength => _baseLength;

		public float CaliberInMilimeters => _diameter * 0.5f * 1000f;

		public string CustomName { get; private set; }

		public float Diameter => _diameter;

		public float ExplosionScalar { get; private set; } = 1f;

		public float FiringDelay => _firingDelay;

		public string FuseInput { get; private set; }

		public WeaponFunction Function { get; private set; } = WeaponFunction.AirToSurface;

		public float ImpactDamageScalar { get; private set; } = 1f;

		public float LaunchVolume => Mathf.Clamp01(_launchVolume);

		public override float Mass => base.Mass;

		public bool MuzzleBrake => _muzzleBrake;

		public float MuzzleFlashScale { get; private set; } = 1f;

		public ParticleSystemSimulationSpace MuzzleFlashSpace { get; private set; }

		public float ProjectileLifetime { get; private set; } = -1f;

		public float ProjectileVelocity => _projectileVelocity;

		public float ProjectileVolume
		{
			get
			{
				float num = _diameter * 0.5f / 2f;
				if (_projectileStyle == ProjectileStyle.Slug)
				{
					float num2 = 1.5f * _diameter * 0.5f;
					return MathF.PI * num * num * num2;
				}
				return MathF.PI * num * num * num;
			}
		}

		public float RecoilForce => _recoilForce;

		public float TotalCannonVolume
		{
			get
			{
				Vector2 vector = new Vector2(0.34225f, 0.4019442f);
				vector.Scale(new Vector2(_diameter, _baseLength));
				Vector2 vector2 = new Vector2(0.292435f, 1.420245f);
				vector2.Scale(new Vector2(_diameter, _barrelLength));
				Vector2 vector3 = new Vector2(0.292435f, 0.881173f);
				vector3.Scale(new Vector2(_diameter, _diameter));
				float num = MathF.PI * vector.x * vector.x * vector.y;
				float num2 = MathF.PI * vector2.x * vector2.x * vector2.y;
				float num3 = MathF.PI * vector3.x * vector3.x * vector3.y;
				float num4 = vector2.x - 0.085f * _diameter;
				float num5 = MathF.PI * num4 * num4 * vector2.y;
				float num6 = MathF.PI * num4 * num4 * vector3.y;
				return num + (num2 - num5) + (_muzzleBrake ? (num3 - num6) : 0f);
			}
		}

		public Color TracerColour { get; private set; } = Color.red;

		public float TracerLength { get; private set; } = 0.1f;

		public int TracerSpacing => _tracerSpacing;

		public float TrueCaliber => _diameter * 0.5f * 39.37008f;

		public CannonData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup));
			xElement.Add(new XAttribute("projectileStyle", _projectileStyle));
			xElement.Add(new XAttribute("projectileType", _projectileType));
			xElement.Add(new XAttribute("projectileVelocity", _projectileVelocity));
			xElement.Add(new XAttribute("ammoCount", _ammoCount));
			xElement.Add(new XAttribute("firingDelay", _firingDelay));
			xElement.Add(new XAttribute("diameter", _diameter));
			xElement.Add(new XAttribute("baseLength", _baseLength));
			xElement.Add(new XAttribute("barrelLength", _barrelLength));
			xElement.Add(new XAttribute("barrelRecoil", _barrelRecoil));
			xElement.Add(new XAttribute("recoilForce", _recoilForce));
			xElement.Add(new XAttribute("tracerSpacing", (_tracerSpacing != int.MaxValue) ? _tracerSpacing : (-1)));
			xElement.Add(new XAttribute("tracerLength", TracerLength));
			xElement.Add(new XAttribute("tracerColor", ColorUtility.ToHtmlStringRGBA(TracerColour)));
			xElement.Add(new XAttribute("muzzleBrake", _muzzleBrake));
			xElement.Add(new XAttribute("flashScale", MuzzleFlashScale));
			xElement.Add(new XAttribute("flashSpace", MuzzleFlashSpace));
			xElement.Add(new XAttribute("projectileLifetime", (ProjectileLifetime < 0f) ? GetDefaultLifetime(_projectileType) : ProjectileLifetime));
			xElement.Add(new XAttribute("launchVolume", LaunchVolume));
			xElement.Add(new XAttribute("explosionScalar", ExplosionScalar));
			xElement.Add(new XAttribute("impactDamageScalar", ImpactDamageScalar));
			if (Function != WeaponFunction.AirToSurface)
			{
				xElement.Add(new XAttribute("function", Function));
			}
			if (CustomName != null)
			{
				xElement.Add(new XAttribute("name", CustomName));
			}
			if (!string.IsNullOrWhiteSpace(FuseInput))
			{
				xElement.Add(new XAttribute("fuseInput", FuseInput));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_projectileVelocity":
				return (_projectileVelocity * 3.28084f).ToString("#ft/s") + "\n" + _projectileVelocity.ToString("#m/s");
			case "_firingDelay":
				return _firingDelay.ToString("0.0s");
			case "_muzzleLength":
			case "_barrelLength":
			case "_baseLength":
			case "_barrelRecoil":
			case "_recoilForce":
				return Utilities.FormatPercentage(sliderValue);
			case "_tracerSpacing":
				if (sliderValue != 101f && sliderValue != 2.1474836E+09f)
				{
					if (sliderValue != 0f)
					{
						return sliderValue.ToString("0");
					}
					return "All Tracers";
				}
				return "No Tracers";
			case "_diameter":
				return Utilities.FormatPercentage(_diameter) + " (" + TrueCaliber.ToString("#.00#in") + "\n" + CaliberInMilimeters.ToString("0") + "mm)";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			_script = parentGameObject.AddComponent<CannonScript>();
			_script.Initialize(this);
			return _script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			switch (propertyName)
			{
			case "_designerActivationGroup":
				if (value != _designerActivationGroup)
				{
					Debug.LogError("What? Uh oh...");
				}
				ActivationGroup = ((value == "All") ? "0" : value);
				break;
			case "_muzzleLength":
			case "_barrelLength":
			case "_baseLength":
			case "_diameter":
				_script.UpdateScales();
				Designer.Instance.OnAircraftStructureChanged();
				break;
			case "_muzzleBrake":
				_script.SetMuzzleBrakeActive(_muzzleBrake);
				Designer.Instance.OnAircraftStructureChanged();
				break;
			case "_tracerSpacing":
				if (_tracerSpacing == 101)
				{
					_tracerSpacing = int.MaxValue;
				}
				break;
			case "_designerTarget":
				switch (_designerTarget)
				{
				case "Ground":
					Function = WeaponFunction.AirToSurface;
					break;
				case "Air":
					Function = WeaponFunction.AirToAir;
					break;
				case "Multi-Role":
					Function = WeaponFunction.MultiRole;
					break;
				}
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			if (stateElement != null)
			{
				ActivationGroup = stateElement.GetStringAttribute("activationGroup", "0");
				CustomName = ((string)stateElement.Attribute("name")) ?? null;
				_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup.ToString());
				_projectileStyle = stateElement.GetEnumAttribute("projectileStyle", ProjectileStyle.Slug);
				_projectileType = stateElement.GetEnumAttribute("projectileType", ProjectileType.Explosive);
				_projectileVelocity = stateElement.GetFloatAttribute("projectileVelocity", 500f);
				_ammoCount = stateElement.GetIntAttribute("ammoCount", 100);
				_firingDelay = stateElement.GetFloatAttribute("firingDelay", 1f);
				_diameter = stateElement.GetFloatAttribute("diameter", 1f);
				Function = stateElement.GetEnumAttribute("function", WeaponFunction.AirToSurface);
				_baseLength = Mathf.Clamp(stateElement.GetFloatAttribute("baseLength", 1f), 1E-10f, float.MaxValue);
				_barrelLength = Mathf.Clamp(stateElement.GetFloatAttribute("barrelLength", 1f), 1E-10f, float.MaxValue);
				_barrelRecoil = stateElement.GetFloatAttribute("barrelRecoil", 1f);
				_recoilForce = stateElement.GetFloatAttribute("recoilForce", 1f);
				_tracerSpacing = stateElement.GetIntAttribute("tracerSpacing", -1);
				if (_tracerSpacing == -1)
				{
					_tracerSpacing = int.MaxValue;
				}
				TracerLength = stateElement.GetFloatAttribute("tracerLength", 0.1f);
				TracerColour = stateElement.GetHtmlColorAttribute("tracerColor", Color.red);
				_muzzleBrake = stateElement.GetBoolAttribute("muzzleBrake", defaultValue: true);
				MuzzleFlashScale = stateElement.GetFloatAttribute("flashScale", 1f);
				MuzzleFlashSpace = stateElement.GetEnumAttribute("flashSpace", ParticleSystemSimulationSpace.Local);
				if (MuzzleFlashSpace == ParticleSystemSimulationSpace.Custom)
				{
					MuzzleFlashSpace = ParticleSystemSimulationSpace.Local;
				}
				ProjectileLifetime = stateElement.GetFloatAttribute("projectileLifetime", GetDefaultLifetime(_projectileType));
				_launchVolume = stateElement.GetFloatAttribute("launchVolume", 1f);
				ExplosionScalar = stateElement.GetFloatAttribute("explosionScalar", 1f);
				ImpactDamageScalar = stateElement.GetFloatAttribute("impactDamageScalar", 1f);
				FuseInput = stateElement.GetStringAttribute("fuseInput");
				switch (Function)
				{
				case WeaponFunction.AirToSurface:
					_designerTarget = "Ground";
					break;
				case WeaponFunction.AirToAir:
					_designerTarget = "Air";
					break;
				case WeaponFunction.MultiRole:
					_designerTarget = "Multi-Role";
					break;
				}
			}
		}

		protected override float CalculateMass()
		{
			return TotalCannonVolume * 558.45f * 0.01f * base.Part.MassScale;
		}

		private static float GetDefaultLifetime(ProjectileType type)
		{
			if (type != ProjectileType.Basic)
			{
				return float.MaxValue;
			}
			return 60f;
		}
	}
}
