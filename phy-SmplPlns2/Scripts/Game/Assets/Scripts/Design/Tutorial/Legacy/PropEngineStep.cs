using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class PropEngineStep : TutorialStep
	{
		public PropEngineStep(TutorialScript tutorialScript)
			: base(0, tutorialScript)
		{
		}

		public override void End()
		{
		}

		public override void Start()
		{
			foreach (PartData part in _tutorialScript.DesignerScript.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				if (part.PartScript.gameObject.GetComponent<TutorialPartScript>() != null && part.GetModifier<PropEngineAdvancedData>() != null)
				{
					_tutorialScript.DesignerScript.Designer.SelectedPart = part.PartScript;
				}
			}
		}

		public override void Update()
		{
			List<PropEngineAdvancedData> list = new List<PropEngineAdvancedData>();
			foreach (PartData part in _tutorialScript.DesignerScript.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				if (part.PartScript.gameObject.GetComponent<TutorialPartScript>() != null)
				{
					PropEngineAdvancedData modifier = part.GetModifier<PropEngineAdvancedData>();
					if (modifier != null)
					{
						list.Add(modifier);
					}
				}
			}
			if (list.Count != 1)
			{
				DisplayRetryMessage();
			}
			else if (list[0].BladeCount == 5)
			{
				_tutorialScript.Accomplishment("Complete");
				_tutorialScript.NextStep();
			}
			else if (_tutorialScript.DesignerScript.Designer.SelectedPart == null || _tutorialScript.DesignerScript.Designer.SelectedPart.Part.PartType.PartTypeId != "Engine-Prop-5")
			{
				_tutorialScript.DisplayMessage("Click on the propeller engine to select it.");
			}
			else if (_tutorialScript.UIScript.Flyouts.Selected == _tutorialScript.UIScript.Flyouts.PartProperties)
			{
				_tutorialScript.DisplayMessage("Click on the gear button to open the Part Properties for this propeller engine.");
				_tutorialScript.HighlightUiElement("EditPartButton", new Vector2(0f, 0f), new Vector2(75f, 75f), highlightEvenIfInactive: true);
			}
			else
			{
				_tutorialScript.DisplayMessage("Like many other parts, propeller engines are extremely customizable. Right now, just find the Blade Count button and click it until it says 5.");
				_tutorialScript.HighlightUiElement("Blade Count", new Vector2(165f, -38f), new Vector2(320f, 72f), highlightEvenIfInactive: true);
			}
		}
	}
}
