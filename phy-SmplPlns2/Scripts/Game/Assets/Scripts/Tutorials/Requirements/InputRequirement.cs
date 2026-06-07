using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Input")]
	public class InputRequirement : TargetValueRequirement
	{
		public string InputId { get; set; }

		public InputRequirement()
		{
		}

		public InputRequirement(string inputId)
		{
			InputId = inputId;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("inputId", InputId);
			base.GenerateXml(xml);
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.Controls.GetAxisGetter(InputId)?.Invoke();
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput(InputId);
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			InputId = (string)xml.Attribute("inputId");
		}
	}
}
