using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class ConfigureRocketEngineStep : ConfigurePartPropertiesBase
	{
		public float TargetExtensionSize { get; set; }

		public float TargetSize { get; set; }

		public float TargetThroatRadius { get; set; }

		public ConfigureRocketEngineStep(int partId, string partName, TutorialScript tutorialScript)
			: base(partId, partName, tutorialScript)
		{
		}

		protected override bool ConfigurePartProperties(PartData part)
		{
			RocketEngineData modifier = part.GetModifier<RocketEngineData>();
			if (modifier.Scale > TargetSize * 1.0125f)
			{
				base.TutorialScript.HighlightUiElement("PartProperties.Size", new Vector2(16f, 8f));
				DisplayInstruction("Change the Size to " + Utilities.FormatPercentage(TargetSize));
			}
			else if (!Utilities.CompareFloats(modifier.UserNozzleThroatRadius, TargetThroatRadius, TargetThroatRadius * 0.025f))
			{
				base.TutorialScript.HighlightUiElement("PartProperties.Nozzle Throat Size", new Vector2(16f, 8f));
				DisplayInstruction("Change the Nozzle Throat Size to " + Utilities.FormatPercentage(TargetThroatRadius));
			}
			else if (!Utilities.CompareFloats(modifier.ExtensionSize, TargetExtensionSize, TargetExtensionSize * 0.025f))
			{
				base.TutorialScript.HighlightUiElement("PartProperties.Nozzle Length", new Vector2(16f, 8f));
				DisplayInstruction("Change the Nozzle Length to " + Utilities.FormatPercentage(TargetExtensionSize));
			}
			else
			{
				if (Utilities.CompareFloats(modifier.Scale, TargetSize, TargetSize * 0.025f))
				{
					return true;
				}
				base.TutorialScript.HighlightUiElement("PartProperties.Size", new Vector2(16f, 8f));
				DisplayInstruction("Change the Size to " + Utilities.FormatPercentage(TargetSize));
			}
			return false;
		}
	}
}
