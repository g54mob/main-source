using System;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Targeting Pod")]
	public class TargetingPodData : PartModifierData
	{
		[DesignerPropertyToggleButton(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 0, AllowFunkyInput = false)]
		private string _activationGroup;

		private float _defaultDistance;

		public string ActivationGroup => _activationGroup;

		public Vector3 CameraOffset { get; set; }

		public float MaxDistance { get; set; }

		public Type ModifierScriptType => typeof(TargetingPodScript);

		public TargetingPodData(XElement element)
			: base(element)
		{
			CameraOffset = element.GetVector3Attribute("offset");
			_activationGroup = element.GetStringAttribute("defaultActivationGroup", "0");
			_defaultDistance = element.GetFloatAttribute("maxDistance");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			if (!Mathf.Approximately(MaxDistance, _defaultDistance))
			{
				xElement.Add(new XAttribute("maxDistance", MaxDistance));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_activationGroup" && value == "0")
			{
				return "None";
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("TargetingPod");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = CameraOffset;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			TargetingPodScript targetingPodScript = gameObject.AddComponent<TargetingPodScript>();
			targetingPodScript.Data = this;
			return targetingPodScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_activationGroup = stateElement.GetStringAttribute("activationGroup", ActivationGroup);
			MaxDistance = stateElement.GetFloatAttribute("maxDistance", _defaultDistance);
		}
	}
}
