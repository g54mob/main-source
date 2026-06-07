using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Cockpit Sound")]
	public class CockpitSoundData : PartModifierData
	{
		public const string ActivationGroupAlwaysOnText = "AlwaysOn";

		public const string ActivationGroupAlwaysOffText = "AlwaysOff";

		[DesignerPropertyToggleButton(new string[] { "AlwaysOn", "AlwaysOff", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 1, AllowFunkyInput = true)]
		private string _activationGroup = "AlwaysOn";

		[DesignerPropertySlider(0f, 1f, 21, Label = "Intensity", Tooltip = "The intensity of the filter when active.")]
		private float _intensity = 1f;

		public string ActivationGroup => _activationGroup;

		public float Intensity => _intensity;

		public CockpitSoundScript Script { get; private set; }

		public CockpitSoundData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", _activationGroup));
			xElement.Add(new XAttribute("intensity", _intensity));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_intensity")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<CockpitSoundScript>();
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_activationGroup = stateElement.GetStringAttribute("activationGroup", "AlwaysOn");
			_intensity = stateElement.GetFloatAttribute("intensity", 1f);
		}
	}
}
