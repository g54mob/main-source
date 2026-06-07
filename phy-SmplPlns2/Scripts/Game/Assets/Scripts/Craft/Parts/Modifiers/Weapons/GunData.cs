using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Gun")]
	public class GunData : PartModifierData
	{
		public const float DefaultDamage = 30f;

		public const float DefaultImpactForce = 10f;

		public const float DefaultLifetime = 3f;

		public static readonly Color DefaultTracerColor = new Color(2f, 1f, 0f);

		public static readonly float DefaultTracerIntensity = 1f;

		protected const string DesignerActivationGroupAlwaysArmedText = "All";

		[DesignerPropertyToggleButton(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Armed Group", Order = 1, AllowFunkyInput = true)]
		private string _designerActivationGroup = "All";

		private float _minTimeBetweenRounds;

		private float _roundsPerSecond;

		private Color _tracerColor;

		private ColorStringFormat _tracerColorFormat = ColorStringFormat.FloatRGB;

		public string ActivationGroup { get; private set; }

		public int AmmoCount { get; set; }

		public Vector3 BulletScale { get; private set; }

		public int BurstCount { get; set; }

		public float Damage { get; private set; }

		public float ImpactForce { get; private set; }

		public float Lifetime { get; private set; }

		public float MinTimeBetweenRounds => _minTimeBetweenRounds;

		public bool MuzzleFlash { get; private set; }

		public float MuzzleVelocity { get; set; }

		public float RoundsPerSecond
		{
			get
			{
				return _roundsPerSecond;
			}
			set
			{
				_roundsPerSecond = value;
				_minTimeBetweenRounds = 1f / value;
			}
		}

		public float Spread { get; private set; }

		public float TimeBetweenBursts { get; set; }

		public Color TracerColor => new Color(_tracerColor.r * TracerIntensity, _tracerColor.g * TracerIntensity, _tracerColor.b * TracerIntensity, 1f);

		public float TracerIntensity { get; private set; }

		public GunData(XElement element)
			: base(element)
		{
			AmmoCount = element.GetIntAttribute("ammoCount", 200);
			BurstCount = element.GetIntAttribute("burstCount", 10);
			TimeBetweenBursts = element.GetFloatAttribute("timeBetweenBursts", 2f);
			MuzzleVelocity = element.GetFloatAttribute("muzzleVelocity", 1000f);
			RoundsPerSecond = element.GetFloatAttribute("roundsPerSecond", 1f);
			ActivationGroup = element.GetStringAttribute("activationGroup", "0");
			Lifetime = element.GetFloatAttribute("lifetime", 3f);
			Damage = element.GetFloatAttribute("damage", 30f);
			ImpactForce = element.GetFloatAttribute("impactForce", 10f);
			_tracerColor = DefaultTracerColor;
			TracerIntensity = DefaultTracerIntensity;
			BulletScale = Vector3.one;
			MuzzleFlash = true;
			Spread = 1f;
			_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("ammoCount", AmmoCount.ToString()), new XAttribute("burstCount", BurstCount.ToString()), new XAttribute("timeBetweenBursts", TimeBetweenBursts.ToString()), new XAttribute("muzzleVelocity", MuzzleVelocity.ToString()), new XAttribute("roundsPerSecond", RoundsPerSecond.ToString()), new XAttribute("spread", Spread.ToString()), new XAttribute("activationGroup", ActivationGroup.ToString()), (_tracerColor == DefaultTracerColor) ? null : new XAttribute("tracerColor", ColorsUtility.ToString(_tracerColor, _tracerColorFormat)), (TracerIntensity == DefaultTracerIntensity) ? null : new XAttribute("tracerIntensity", TracerIntensity), (Lifetime == 3f) ? null : new XAttribute("lifetime", Lifetime), (Damage == 30f) ? null : new XAttribute("damage", Damage), (ImpactForce == 10f) ? null : new XAttribute("impactForce", ImpactForce), (BulletScale == Vector3.one) ? null : new XAttribute("bulletScale", BulletScale.ToXAttributeValue()), MuzzleFlash ? null : new XAttribute("muzzleFlash", "false"));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Gun");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.rotation = Quaternion.identity;
			GunScript gunScript = gameObject.AddComponent<GunScript>();
			gunScript.Gun = this;
			return gunScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_designerActivationGroup")
			{
				if (value != _designerActivationGroup)
				{
					Debug.LogError("What? Uh oh...");
				}
				ActivationGroup = ((value == "All") ? "0" : value);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			AmmoCount = stateElement.GetIntAttribute("ammoCount", 200);
			BurstCount = stateElement.GetIntAttribute("burstCount", 10);
			TimeBetweenBursts = stateElement.GetFloatAttribute("timeBetweenBursts", 2f);
			MuzzleVelocity = stateElement.GetFloatAttribute("muzzleVelocity", 1000f);
			RoundsPerSecond = stateElement.GetFloatAttribute("roundsPerSecond", 1f);
			string stringAttributeOrNullIfEmpty = stateElement.GetStringAttributeOrNullIfEmpty("tracerColor");
			if (stringAttributeOrNullIfEmpty != null)
			{
				if (ColorsUtility.TryParse(stringAttributeOrNullIfEmpty, ColorStringFormat.HexRGB, out _tracerColor))
				{
					_tracerColorFormat = ColorStringFormat.HexRGB;
				}
				else if (ColorsUtility.TryParse(stringAttributeOrNullIfEmpty, ColorStringFormat.FloatRGB, out _tracerColor))
				{
					_tracerColorFormat = ColorStringFormat.FloatRGB;
				}
				else if (ColorsUtility.TryParse(stringAttributeOrNullIfEmpty, ColorStringFormat.ByteRGB, out _tracerColor))
				{
					_tracerColorFormat = ColorStringFormat.ByteRGB;
				}
				else
				{
					_tracerColor = DefaultTracerColor;
					_tracerColorFormat = ColorStringFormat.FloatRGB;
				}
			}
			TracerIntensity = stateElement.GetFloatAttribute("tracerIntensity", TracerIntensity);
			Spread = stateElement.GetFloatAttribute("spread", 1f);
			Lifetime = stateElement.GetFloatAttribute("lifetime", Lifetime);
			Damage = stateElement.GetFloatAttribute("damage", Damage);
			ImpactForce = stateElement.GetFloatAttribute("impactForce", ImpactForce);
			BulletScale = stateElement.GetVector3Attribute("bulletScale", BulletScale);
			MuzzleFlash = stateElement.GetBoolAttribute("muzzleFlash", defaultValue: true);
			ActivationGroup = ((string)stateElement.Attribute("activationGroup")) ?? "0";
			_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup);
			XElement xElement = ((stateElement.Document != null) ? stateElement.Document.Root : null);
			if (((xElement != null && xElement.Name == "Aircraft") ? ((int?)xElement.Attribute("xmlVersion")).GetValueOrDefault() : 23) < 6)
			{
				BulletScale = base.Part.PartScale ?? Vector3.one;
			}
		}
	}
}
