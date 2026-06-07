using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Input;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class ConfigureMotorInputStep : ConfigurePartPropertiesBase
	{
		public string InputControllerId { get; set; }

		public string StartingInput { get; set; }

		public string TargetInput { get; set; }

		public ConfigureMotorInputStep(int partId, string partName, TutorialScript tutorialScript)
			: base(partId, partName, tutorialScript)
		{
		}

		public override void Start()
		{
			base.Start();
			PartData craftPart = base.TutorialScript.GetCraftPart(base.PartId);
			TutorialStep.GetDesignerPartModifier<ResizableWheelData>(base.TutorialScript, base.PartName);
			craftPart.GetModifier<ResizableWheelData>();
			GetInputController(craftPart).Input = StartingInput;
		}

		protected override bool ConfigurePartProperties(PartData part)
		{
			InputControllerData inputController = GetInputController(part);
			if (inputController != null)
			{
				if (!(inputController.Input != TargetInput))
				{
					return true;
				}
				if (base.TutorialScript.HighlightUiElement("PartProperties_InputControllerData_1/PartProperties.Input", new Vector2(16f, 8f)))
				{
					DisplayInstruction("Change the Input to " + TargetInput);
				}
				else
				{
					base.TutorialScript.HighlightUiElement("PartProperties_InputControllerData_1", new Vector2(16f, 8f));
					DisplayInstruction("Click to expand this section");
				}
			}
			return false;
		}

		private InputControllerData GetInputController(PartData part)
		{
			List<InputControllerData> list = new List<InputControllerData>();
			part.GetModifiers(list);
			return list.Where((InputControllerData x) => x.InputId == InputControllerId).FirstOrDefault();
		}
	}
}
