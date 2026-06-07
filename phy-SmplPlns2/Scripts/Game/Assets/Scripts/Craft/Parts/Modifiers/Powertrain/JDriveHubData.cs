using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[PartModifierDesignerHeader("Drive Shaft")]
	public class JDriveHubData : PartModifierData
	{
		[DesignerPropertyToggleButton(new string[] { }, Label = "Reverse Direction", Order = 30, Tooltip = "Reverses the direction of the spin.")]
		private bool _reversed;

		public bool IsReversed => _reversed;

		public JDriveHubScript Script { get; private set; }

		public JDriveHubData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("reversed", _reversed);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<JDriveHubScript>();
			Script.Initialize(this);
			return Script;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_reversed = stateElement.GetBoolAttribute("reversed", _reversed);
		}
	}
}
