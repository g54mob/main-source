using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class SymmetryStep : TutorialStep
	{
		private bool _complete;

		private bool _error;

		public bool ClosePanelRequired { get; set; } = true;

		public int PartId { get; private set; }

		public string PartName { get; set; }

		public SymmetryMode SymmetryMode { get; }

		public SymmetryStep(int partId, string partName, TutorialScript tutorialScript, SymmetryMode symmetryMode = SymmetryMode.Mirror)
			: base(-1, tutorialScript)
		{
			PartName = partName;
			PartId = partId;
			SymmetryMode = symmetryMode;
		}

		public override void Start()
		{
			base.Start();
			_error = false;
			_complete = false;
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
					if (craftPart.SymmetryMode == SymmetryMode)
					{
						if (designerUi.SelectedFlyout == designerUi.Flyouts.Symmetry && ClosePanelRequired)
						{
							base.TutorialScript.HighlightUiElement("Flyout.Symmetry.Close", new Vector2(-2f, -4f));
							DisplayInstruction("Great! Now close the Symmetry panel by clicking the X in the top left.");
							base.TutorialScript.Accomplishment("Symmetry");
						}
						else
						{
							_complete = true;
						}
					}
					else if (designerUi.SelectedFlyout == designerUi.Flyouts.Symmetry)
					{
						base.TutorialScript.HighlightUiElement("Symmetry.ModeSpinner", new Vector2(16f, 8f));
						DisplayInstruction($"Cycle through the Modes until you get '{SymmetryMode}'");
					}
					else
					{
						base.TutorialScript.HighlightUiElement("ButtonPanel.Symmetry", Vector2.zero);
						DisplayInstruction("Click the Symmetry button on the left.");
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
