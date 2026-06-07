using System;
using System.Xml.Linq;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Assets.Scripts.XR.UI;

namespace Assets.Scripts.Tutorials.Requirements.UI
{
	[Serializable]
	[TutorialRequirement("RadialMenuButtonClicked")]
	public class RadialMenuButtonClickedRequirement : TutorialRequirement
	{
		private bool _buttonClicked;

		public string ButtonId { get; set; }

		public string HighlightedButtonIds { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public RadialMenuButtonClickedRequirement()
		{
		}

		public RadialMenuButtonClickedRequirement(string buttonId)
		{
			ButtonId = buttonId;
		}

		public RadialMenuButtonClickedRequirement(string buttonId, string message)
		{
			ButtonId = buttonId;
			base.RequirementNotMetMessage = message;
		}

		public RadialMenuButtonClickedRequirement(string buttonId, string highlightedButtonIds, string message)
		{
			ButtonId = buttonId;
			HighlightedButtonIds = highlightedButtonIds;
			base.RequirementNotMetMessage = message;
		}

		public override void OnRadialMenuButtonClicked(RadialMenuButtonScript button)
		{
			if (button?.Id == ButtonId)
			{
				_buttonClicked = true;
			}
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("id", ButtonId);
			if (!string.IsNullOrWhiteSpace(HighlightedButtonIds))
			{
				xml.SetAttributeValue("highlightedButtons", HighlightedButtonIds);
			}
			base.GenerateXml(xml);
		}

		protected override void OnHighlightDefaultParts()
		{
			HighlightUIElements(ButtonId);
			if (!string.IsNullOrWhiteSpace(HighlightedButtonIds))
			{
				string[] array = HighlightedButtonIds.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string text in array)
				{
					HighlightUIElements(text.Trim());
				}
			}
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			if (!_buttonClicked)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			ButtonId = (string)xml.Attribute("id");
			HighlightedButtonIds = (string)xml.Attribute("highlightedButtons");
		}
	}
}
