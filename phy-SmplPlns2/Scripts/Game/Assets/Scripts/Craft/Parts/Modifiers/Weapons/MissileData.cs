using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Missile")]
	public class MissileData : ExplosiveWeaponBaseData, IModifierWithOutputs
	{
		private WeaponFunction _defaultFunction;

		private float _defaultGuidanceActivationDelay;

		private float _defaultIgnitionDelay;

		private bool _defaultKillCam;

		private float _defaultLoftPercentage;

		private float _defaultMaxForwardThrustForce;

		private float _defaultMaxFuelTime;

		private float _defaultMaxHeadingAngleAdjustmentRate;

		private float _defaultMaxRange;

		private float _defaultMaxSpeed;

		private float _defaultMaxTargetingAngle;

		private float _defaultMaxThrustVectoringRate;

		private float _defaultMaxVelocityAngleAdjustmentRate;

		private float _defaultMinRange;

		private float _defaultProximityDetonationRangeMax;

		private float _defaultProximityDetonationRangeMin;

		private SeekerType _defaultSeeker;

		private float _defaultSmokeOpacity;

		private float _defaultSmokeScale;

		private bool _defaultWaterproof;

		[DesignerPropertyToggleButton(new string[] { "Disabled", "Enabled" }, Label = "Impact Cam")]
		private bool _killCam;

		private float _maxTorque;

		public WeaponFunction Function { get; set; }

		public float GuidanceActivationDelay { get; set; }

		public float IgnitionDelay { get; set; }

		public bool KillCam
		{
			get
			{
				return _killCam;
			}
			private set
			{
				_killCam = value;
			}
		}

		public float LoftPercentage { get; set; }

		public float MaxForwardThrustForce { get; set; }

		public float MaxFuelTime { get; set; }

		public float MaxHeadingAngleAdjustmentRate { get; set; }

		public float MaxRange { get; set; }

		public float MaxSpeed { get; set; }

		public float MaxTargetingAngle { get; set; }

		public float MaxThrustVectoringRate { get; set; }

		public float MaxTorque { get; set; }

		public float MaxVelocityAngleAdjustmentRate { get; set; }

		public float MinRange { get; set; }

		public Type ModifierScriptType => typeof(MissileScript);

		public float ProximityDetonationRangeMax { get; set; }

		public float ProximityDetonationRangeMin { get; set; }

		public SeekerType Seeker { get; set; }

		public float SmokeOpacity { get; set; }

		public float SmokeScale { get; set; }

		public bool Waterproof { get; private set; }

		protected override float DefaultFiringDelay => 2f;

		public MissileData(XElement element)
			: base(element)
		{
			Function = (_defaultFunction = element.GetEnumAttribute("function", WeaponFunction.AirToAir));
			GuidanceActivationDelay = (_defaultGuidanceActivationDelay = ((float?)element.Attribute("guidanceActivationDelay")).GetValueOrDefault());
			KillCam = (_defaultKillCam = (bool?)element.Attribute("killCam") == true);
			LoftPercentage = (_defaultLoftPercentage = ((float?)element.Attribute("loft")).GetValueOrDefault());
			MaxRange = (_defaultMaxRange = ((float?)element.Attribute("maxRange")).GetValueOrDefault());
			MinRange = (_defaultMinRange = ((float?)element.Attribute("minRange")).GetValueOrDefault());
			MaxTargetingAngle = (_defaultMaxTargetingAngle = ((float?)element.Attribute("maxTargetingAngle")).GetValueOrDefault());
			MaxSpeed = (_defaultMaxSpeed = ((float?)element.Attribute("maxSpeed")).GetValueOrDefault());
			MaxFuelTime = (_defaultMaxFuelTime = ((float?)element.Attribute("maxFuelTime")).GetValueOrDefault());
			MaxForwardThrustForce = (_defaultMaxForwardThrustForce = ((float?)element.Attribute("maxForwardThrustForce")).GetValueOrDefault());
			MaxHeadingAngleAdjustmentRate = (_defaultMaxHeadingAngleAdjustmentRate = ((float?)element.Attribute("maxHeadingAngleAdjustmentRate")).GetValueOrDefault());
			MaxVelocityAngleAdjustmentRate = (_defaultMaxVelocityAngleAdjustmentRate = ((float?)element.Attribute("maxVelocityAngleAdjustmentRate")).GetValueOrDefault());
			MaxThrustVectoringRate = (_defaultMaxThrustVectoringRate = ((float?)element.Attribute("maxThrustVectoringRate")).GetValueOrDefault());
			ProximityDetonationRangeMin = (_defaultProximityDetonationRangeMin = ((float?)element.Attribute("proximityDetonationRangeMin")).GetValueOrDefault());
			ProximityDetonationRangeMax = (_defaultProximityDetonationRangeMax = ((float?)element.Attribute("proximityDetonationRangeMax")).GetValueOrDefault());
			Seeker = (_defaultSeeker = element.GetEnumAttribute("seeker", SeekerType.ActiveRadar));
			SmokeOpacity = (_defaultSmokeOpacity = ((float?)element.Attribute("smokeOpacity")) ?? 1f);
			SmokeScale = (_defaultSmokeScale = ((float?)element.Attribute("smokeScale")) ?? 1f);
			Waterproof = (_defaultWaterproof = (bool?)element.Attribute("waterproof") == true);
			IgnitionDelay = (_defaultIgnitionDelay = ((float?)element.Attribute("ignitionDelay")).GetValueOrDefault());
			MaxTorque = (_maxTorque = ((float?)element.Attribute("maxTorque")).GetValueOrDefault());
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			if (KillCam)
			{
				xElement.Add(new XAttribute("killCam", KillCam));
			}
			if (Function != _defaultFunction)
			{
				xElement.Add(new XAttribute("function", Function));
			}
			SaveXmlAttribute(xElement, "loft", LoftPercentage, _defaultLoftPercentage);
			SaveXmlAttribute(xElement, "guidanceActivationDelay", GuidanceActivationDelay, _defaultGuidanceActivationDelay);
			SaveXmlAttribute(xElement, "maxRange", MaxRange, _defaultMaxRange);
			SaveXmlAttribute(xElement, "minRange", MinRange, _defaultMinRange);
			SaveXmlAttribute(xElement, "maxTargetingAngle", MaxTargetingAngle, _defaultMaxTargetingAngle);
			SaveXmlAttribute(xElement, "maxSpeed", MaxSpeed, _defaultMaxSpeed);
			SaveXmlAttribute(xElement, "maxFuelTime", MaxFuelTime, _defaultMaxFuelTime);
			SaveXmlAttribute(xElement, "maxForwardThrustForce", MaxForwardThrustForce, _defaultMaxForwardThrustForce);
			SaveXmlAttribute(xElement, "maxHeadingAngleAdjustmentRate", MaxHeadingAngleAdjustmentRate, _defaultMaxHeadingAngleAdjustmentRate);
			SaveXmlAttribute(xElement, "maxVelocityAngleAdjustmentRate", MaxVelocityAngleAdjustmentRate, _defaultMaxVelocityAngleAdjustmentRate);
			SaveXmlAttribute(xElement, "maxThrustVectoringRate", MaxThrustVectoringRate, _defaultMaxThrustVectoringRate);
			SaveXmlAttribute(xElement, "proximityDetonationRangeMin", ProximityDetonationRangeMin, _defaultProximityDetonationRangeMin);
			SaveXmlAttribute(xElement, "proximityDetonationRangeMax", ProximityDetonationRangeMax, _defaultProximityDetonationRangeMax);
			SaveXmlAttribute(xElement, "waterproof", Waterproof, _defaultWaterproof);
			SaveXmlAttribute(xElement, "ignitionDelay", IgnitionDelay, _defaultIgnitionDelay);
			SaveXmlAttribute(xElement, "maxTorque", MaxTorque, _maxTorque);
			SaveXmlAttribute(xElement, "smokeOpacity", SmokeOpacity, _defaultSmokeOpacity);
			SaveXmlAttribute(xElement, "smokeScale", SmokeScale, _defaultSmokeScale);
			xElement.SetAttributeValue("seeker", Seeker);
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			return parentGameObject.GetComponent<MissileScript>();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement != null)
			{
				base.RestoreFromState(stateElement);
				KillCam = ((bool?)stateElement.Attribute("killCam")) ?? _defaultKillCam;
				if (stateElement.Attribute("function") != null)
				{
					Function = stateElement.GetEnumAttribute("function", _defaultFunction);
				}
				LoftPercentage = ((float?)stateElement.Attribute("loft")) ?? _defaultLoftPercentage;
				GuidanceActivationDelay = ((float?)stateElement.Attribute("guidanceActivationDelay")) ?? _defaultGuidanceActivationDelay;
				MaxRange = ((float?)stateElement.Attribute("maxRange")) ?? _defaultMaxRange;
				MinRange = ((float?)stateElement.Attribute("minRange")) ?? _defaultMinRange;
				MaxTargetingAngle = ((float?)stateElement.Attribute("maxTargetingAngle")) ?? _defaultMaxTargetingAngle;
				MaxSpeed = ((float?)stateElement.Attribute("maxSpeed")) ?? _defaultMaxSpeed;
				MaxFuelTime = ((float?)stateElement.Attribute("maxFuelTime")) ?? _defaultMaxFuelTime;
				MaxForwardThrustForce = ((float?)stateElement.Attribute("maxForwardThrustForce")) ?? _defaultMaxForwardThrustForce;
				MaxHeadingAngleAdjustmentRate = ((float?)stateElement.Attribute("maxHeadingAngleAdjustmentRate")) ?? _defaultMaxHeadingAngleAdjustmentRate;
				MaxVelocityAngleAdjustmentRate = ((float?)stateElement.Attribute("maxVelocityAngleAdjustmentRate")) ?? _defaultMaxVelocityAngleAdjustmentRate;
				MaxThrustVectoringRate = ((float?)stateElement.Attribute("maxThrustVectoringRate")) ?? _defaultMaxThrustVectoringRate;
				ProximityDetonationRangeMin = ((float?)stateElement.Attribute("proximityDetonationRangeMin")) ?? _defaultProximityDetonationRangeMin;
				ProximityDetonationRangeMax = ((float?)stateElement.Attribute("proximityDetonationRangeMax")) ?? _defaultProximityDetonationRangeMax;
				Waterproof = ((bool?)stateElement.Attribute("waterproof")) ?? _defaultWaterproof;
				IgnitionDelay = ((float?)stateElement.Attribute("ignitionDelay")) ?? _defaultIgnitionDelay;
				MaxTorque = ((float?)stateElement.Attribute("maxTorque")) ?? _maxTorque;
				Seeker = stateElement.GetEnumAttribute("seeker", Seeker);
				SmokeOpacity = stateElement.GetFloatAttribute("smokeOpacity", _defaultSmokeOpacity);
				SmokeScale = stateElement.GetFloatAttribute("smokeScale", _defaultSmokeScale);
				XElement xElement = ((stateElement.Document != null) ? stateElement.Document.Root : null);
				if (((xElement != null && xElement.Name == "Aircraft") ? ((int?)xElement.Attribute("xmlVersion")).GetValueOrDefault() : 23) < 6 && base.Part.MassScale < 0.95f)
				{
					MaxSpeed *= 1f + Mathf.Abs(Mathf.Log10(Mathf.Max(base.Part.MassScale, 0.0001f))) / 4f;
				}
			}
		}

		private static void SaveXmlAttribute(XElement xml, string name, float value, float defaultValue)
		{
			if (!Mathf.Approximately(value, defaultValue))
			{
				xml.Add(new XAttribute(name, value));
			}
		}

		private static void SaveXmlAttribute(XElement xml, string name, bool value, bool defaultValue)
		{
			if (value != defaultValue)
			{
				xml.Add(new XAttribute(name, value));
			}
		}
	}
}
