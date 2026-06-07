using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Engine")]
	public class EngineData : PartModifierData, IModifierWithOutputs
	{
		public bool AlphaTiedToThrottle { get; private set; }

		public bool DuctedThrust { get; set; }

		public string EngineType { get; private set; }

		public Vector3 ExhaustScale { get; private set; }

		public Color? ExhaustStartColorOverridePrimary { get; set; }

		public Color? ExhaustStartColorOverrideSecondary { get; set; }

		public float FuelConsumptionRate { get; set; }

		public virtual Type ModifierScriptType => typeof(EngineScript);

		public float Power { get; set; }

		public float PowerMultiplier { get; private set; }

		public float RequiredAirIntake { get; private set; }

		public string SoundOverride { get; private set; }

		public float ThrottleResponse { get; private set; }

		public float? ThrottleResponseOverride { get; set; }

		public EngineData(XElement element)
			: base(element)
		{
			Power = element.GetFloatAttribute("power") * 0.01f;
			FuelConsumptionRate = float.Parse(element.Attribute("fuelConsumptionRate").Value);
			RequiredAirIntake = element.GetFloatAttribute("requiredAirIntake");
			EngineType = element.Attribute("type").Value;
			ThrottleResponse = float.Parse(element.Attribute("throttleResponse").Value);
			DuctedThrust = element.GetBoolAttribute("ductedThrust");
			SoundOverride = element.GetStringAttribute("soundOverride");
			AlphaTiedToThrottle = element.GetBoolAttribute("alphaTiedToThrottle", defaultValue: true);
			PowerMultiplier = 1f;
			ExhaustScale = Vector3.one;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("powerMultiplier", PowerMultiplier));
			xElement.Add(new XAttribute("exhaustScale", ExhaustScale.ToXAttributeValue()));
			if (ExhaustStartColorOverridePrimary.HasValue)
			{
				xElement.Add(new XAttribute("exhaustStartColorOverridePrimary", ColorUtility.ToHtmlStringRGBA(ExhaustStartColorOverridePrimary.Value)));
			}
			if (ExhaustStartColorOverrideSecondary.HasValue)
			{
				xElement.Add(new XAttribute("exhaustStartColorOverrideSecondary", ColorUtility.ToHtmlStringRGBA(ExhaustStartColorOverrideSecondary.Value)));
			}
			if (ThrottleResponseOverride.HasValue)
			{
				xElement.Add(new XAttribute("throttleResponse", ThrottleResponseOverride.Value));
			}
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject(EngineType);
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			PartModifierScript result = null;
			EngineScript engineScript = null;
			if (EngineType == "Prop")
			{
				engineScript = gameObject.AddComponent<PropEngineScript>();
				engineScript.Engine = this;
				result = engineScript;
			}
			else if (EngineType == "Turbojet")
			{
				engineScript = gameObject.AddComponent<JetEngineScript>();
				engineScript.Engine = this;
				result = engineScript;
			}
			else if (EngineType == "AfterburningTurbojet")
			{
				engineScript = gameObject.AddComponent<JetEngineAfterburningScript>();
				engineScript.Engine = this;
				result = engineScript;
			}
			else
			{
				Debug.LogWarning("Unknown engine type: " + EngineType);
			}
			engineScript?.OnModifierInitialized();
			return result;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			PowerMultiplier = Mathf.Min(1000000f, stateElement.GetFloatAttribute("powerMultiplier", 1f));
			ExhaustScale = stateElement.GetVector3Attribute("exhaustScale", Vector3.one);
			ExhaustStartColorOverridePrimary = stateElement.GetHtmlColorAttributeOrNull("exhaustStartColorOverridePrimary");
			ExhaustStartColorOverrideSecondary = stateElement.GetHtmlColorAttributeOrNull("exhaustStartColorOverrideSecondary");
			ThrottleResponseOverride = stateElement.GetFloatAttributeOrNull("throttleResponse");
			if (ThrottleResponseOverride.HasValue)
			{
				ThrottleResponse = ThrottleResponseOverride.Value;
			}
		}
	}
}
