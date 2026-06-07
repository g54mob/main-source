using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class ConfigureControlSurfaceStep : ConfigurePartPropertiesBase
	{
		public string TargetInput { get; set; }

		public ConfigureControlSurfaceStep(int partId, string partName, TutorialScript tutorialScript, string initialInput)
			: base(partId, partName, tutorialScript)
		{
			ConfigureControlSurfaceStep configureControlSurfaceStep = this;
			base.MustClosePartProperties = false;
			base.CraftDataLoaded = delegate(CraftData craftData)
			{
				ControlSurfaceData modifier = craftData.Assembly.Parts.Where((PartData x) => x.Id == partId).First().GetModifier<ControlSurfaceData>();
				if (modifier != null)
				{
					configureControlSurfaceStep.TargetInput = modifier.Input;
					if (initialInput != null)
					{
						modifier.Input = initialInput;
					}
					else
					{
						modifier.RemoveModifier();
					}
				}
			};
		}

		protected override bool ConfigurePartProperties(PartData part)
		{
			ControlSurfaceData modifier = part.GetModifier<ControlSurfaceData>();
			if (modifier == null)
			{
				base.TutorialScript.HighlightUiElement("PartProperties.AddControlSurface", new Vector2(16f, 8f));
				DisplayInstruction("Click the Add Control surface button");
			}
			else
			{
				if (TargetInput == null || !(TargetInput != modifier.Input))
				{
					return true;
				}
				base.TutorialScript.HighlightUiElement("PartProperties.Input", new Vector2(16f, 8f));
				DisplayInstruction("Change the input to " + TargetInput);
			}
			return false;
		}
	}
}
