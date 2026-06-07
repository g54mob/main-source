using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Arresting Hook")]
	public class ArrestingHookData : PartModifierData
	{
		[DesignerPropertyToggleButton(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 0, AllowFunkyInput = true)]
		private string _activationGroup = "1";

		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 2f, NumberOfSteps = 20, Label = "Cable Deceleration")]
		private float _cableDeceleration = 1f;

		[DesignerPropertySlider(MinValue = 20f, MaxValue = 75f, NumberOfSteps = 12, Label = "Deployed Angle")]
		private float _deployedAngle = 30f;

		public string ActivationGroup => _activationGroup;

		public float CableDeceleration => _cableDeceleration;

		public float DeployedAngle => _deployedAngle;

		public bool EditingProperties { get; set; }

		public ArrestingHookData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", _activationGroup));
			xElement.Add(new XAttribute("cableDeceleration", _cableDeceleration));
			xElement.Add(new XAttribute("deployedAngle", _deployedAngle));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_deployedAngle")
			{
				return sliderValue.ToString("0") + "°";
			}
			if (propertyName == "_cableDeceleration")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			ArrestingHookScript arrestingHookScript = parentGameObject.AddComponent<ArrestingHookScript>();
			arrestingHookScript.Initialize(this);
			return arrestingHookScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			EditingProperties = true;
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_activationGroup = stateElement.GetStringAttribute("activationGroup", "1");
			_cableDeceleration = stateElement.GetFloatAttribute("cableDeceleration", 1f);
			_deployedAngle = stateElement.GetFloatAttribute("deployedAngle", 30f);
		}
	}
}
