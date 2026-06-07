using Assets.Scripts.Craft.Parts.Modifiers;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class CommandPodConfigurationStep : ConfigurePartPropertiesBase
	{
		public string BatteryStepText { get; set; }

		public float? TargetBattery { get; set; }

		public float? TargetGyro { get; set; }

		public CrafConfigurationType TargetType { get; set; } = CrafConfigurationType.Plane;

		public CommandPodConfigurationStep(int partId, string partName, TutorialScript tutorialScript)
			: base(partId, partName, tutorialScript)
		{
		}

		protected override bool ConfigurePartProperties(PartData part)
		{
			CommandPodData modifier = part.GetModifier<CommandPodData>();
			if (modifier.CraftConfiguration.Type != TargetType)
			{
				base.TutorialScript.HighlightUiElement("PartProperties.Configuration", new Vector2(16f, 8f));
				DisplayInstruction("Change the configuration to Plane");
			}
			else if (TargetGyro.HasValue && !Utilities.CompareFloats(TargetGyro.Value, modifier.Gyros))
			{
				base.TutorialScript.HighlightUiElement("PartProperties.Volume for Gyros", new Vector2(16f, 8f));
				DisplayInstruction("Change the Volume for Gyros to " + Utilities.FormatPercentage(TargetGyro.Value));
			}
			else
			{
				if (!TargetBattery.HasValue || Utilities.CompareFloats(TargetBattery.Value, modifier.Battery))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(BatteryStepText))
				{
					base.TutorialScript.DisplayStepText(BatteryStepText);
				}
				base.TutorialScript.HighlightUiElement("PartProperties.Volume for Battery", new Vector2(16f, 8f));
				DisplayInstruction("Change the Volume for Battery to " + Utilities.FormatPercentage(TargetBattery.Value));
			}
			return false;
		}
	}
}
