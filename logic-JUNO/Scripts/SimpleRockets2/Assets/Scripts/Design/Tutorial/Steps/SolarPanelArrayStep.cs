using Assets.Scripts.Craft.Parts.Modifiers.Solar;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class SolarPanelArrayStep : TutorialStep
	{
		private bool _complete;

		private bool _error;

		public int PartId { get; private set; }

		public string PartName { get; set; }

		public SolarPanelArrayStep(int partId, string partName, TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
			PartName = partName;
			PartId = partId;
		}

		public override void Start()
		{
			base.Start();
			_error = false;
			_complete = false;
			PartData craftPart = base.TutorialScript.GetCraftPart(PartId);
			SolarPanelArrayData modifier = craftPart.GetModifier<SolarPanelArrayData>();
			modifier.Rows = 3;
			modifier.RowSize = 3;
			Symmetry.SynchronizePartModifiers(craftPart.PartScript);
		}

		public override void Update()
		{
			IDesignerUi designerUi = base.TutorialScript.DesignerUi;
			if (_error)
			{
				base.TutorialScript.DisableUiHighlight();
				DisplayRetryMessage();
			}
			else if (!_complete)
			{
				PartData craftPart = base.TutorialScript.GetCraftPart(PartId);
				if (craftPart == null)
				{
					_error = true;
				}
				else
				{
					if (!EnsurePartSelected(craftPart, PartName))
					{
						return;
					}
					SolarPanelArrayData modifier = craftPart.GetModifier<SolarPanelArrayData>();
					if (modifier.RowSize == 1 && modifier.Rows == 4)
					{
						if (designerUi.SelectedFlyout == designerUi.Flyouts.PartProperties)
						{
							base.TutorialScript.Accomplishment("Rows");
							base.TutorialScript.HighlightUiElement("Flyout.PartProperties.Close", new Vector2(-2f, -4f));
							DisplayInstruction("Great! Now close the panel.");
						}
						else
						{
							_complete = true;
						}
					}
					else if (designerUi.SelectedFlyout == designerUi.Flyouts.PartProperties)
					{
						if (modifier.RowSize != 1)
						{
							base.TutorialScript.HighlightUiElement("PartProperties.Row Size", new Vector2(16f, 8f));
							DisplayInstruction("Change the Row Size to 1");
						}
						else if (modifier.Rows != 4)
						{
							base.TutorialScript.Accomplishment("RowSize");
							base.TutorialScript.HighlightUiElement("PartProperties.Rows", new Vector2(16f, 8f));
							DisplayInstruction("Change the Rows to 4");
						}
					}
					else
					{
						base.TutorialScript.HighlightUiElement("ButtonPanel.PartProperties", Vector2.zero);
						DisplayInstruction("Click the Part Properties button on the left.");
					}
				}
			}
			else
			{
				base.TutorialScript.NextStep(playSound: true);
			}
		}
	}
}
