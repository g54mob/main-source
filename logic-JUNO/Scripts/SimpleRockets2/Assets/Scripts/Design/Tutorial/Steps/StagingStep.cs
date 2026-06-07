using Assets.Scripts.Design.Staging;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class StagingStep : TutorialStep
	{
		private bool _complete;

		private bool _error;

		public int InitialStageIndex { get; set; }

		public string MainText { get; set; }

		public int PartId { get; private set; }

		public int TargetStageIndex { get; set; }

		public StagingStep(int partId, TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
			PartId = partId;
		}

		public override void Start()
		{
			base.Start();
			_error = false;
			_complete = false;
			PartData craftPart = base.TutorialScript.GetCraftPart(PartId);
			craftPart.ActivationStage = InitialStageIndex;
			craftPart.PartScript.CraftScript.PrimaryCommandPod.AutoRecalculateStages = false;
			base.TutorialScript.DesignerUi.SelectedFlyout = null;
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
				StagingEditorScript componentInChildren = designerUi.Transform.GetComponentInChildren<StagingEditorScript>();
				if (craftPart.ActivationStage == TargetStageIndex)
				{
					if (componentInChildren != null)
					{
						base.TutorialScript.Accomplishment("Staged", 0.25f);
						base.TutorialScript.HighlightUiElement("Flyout.Preflight.Close", new Vector2(-2f, -4f));
						DisplayInstruction("Great! Now close the panel by clicking the X in the top left.");
					}
					else
					{
						_complete = true;
					}
				}
				else if (componentInChildren != null)
				{
					DisplayStep(MainText);
					if (craftPart.ActivationStage == TargetStageIndex)
					{
						return;
					}
					PartNodeScript partNode = componentInChildren.GetPartNode(craftPart);
					if (!(partNode != null))
					{
						return;
					}
					if (partNode.gameObject.activeInHierarchy)
					{
						StageNodeScript stageNode = componentInChildren.GetStageNode(TargetStageIndex + 1);
						if (stageNode == null)
						{
							base.TutorialScript.HighlightUiElement("Staging.AddStage", new Vector2(6f, 6f));
							DisplayInstruction($"Click the Add Stage button to add Stage {TargetStageIndex + 1}");
							return;
						}
						if (!stageNode.Expanded)
						{
							stageNode.Expanded = true;
						}
						if (partNode.IsDragging)
						{
							base.TutorialScript.HighlightUiElement(stageNode.gameObject, Vector2.zero, highlightEvenIfInactive: false);
							DisplayInstruction($"Drop it in Stage {stageNode.StageNumber}");
							return;
						}
						base.TutorialScript.HighlightUiElement(partNode.gameObject, Vector2.zero, highlightEvenIfInactive: false);
						if (Device.IsMobileBuild)
						{
							DisplayInstruction($"Tap and hold {craftPart.Name} and then drag it to Stage {stageNode.StageNumber}");
						}
						else
						{
							DisplayInstruction($"Left click and drag the {craftPart.Name} and drop it in Stage {stageNode.StageNumber}");
						}
					}
					else if (partNode.CategoryNode.gameObject.activeInHierarchy)
					{
						base.TutorialScript.HighlightUiElement(partNode.CategoryNode.gameObject, Vector2.zero, highlightEvenIfInactive: false);
						DisplayInstruction("[Left click|Tap] on the " + partNode.CategoryNode.Text + " category to expand it.");
					}
					else if (partNode.StageNode.gameObject.activeInHierarchy)
					{
						base.TutorialScript.HighlightUiElement(partNode.StageNode.gameObject, Vector2.zero, highlightEvenIfInactive: false);
						DisplayInstruction($"[Left click|Tap] on Stage {partNode.StageNode.StageNumber} to expand it.");
					}
				}
				else
				{
					DisplayStep("One last step before we call it a day. Let's look at the staging for this rocket. Staging just means the order that parts are activated. Stage 1 activates first, followed by Stage 2, etc.\n\nTypically, your big engines should activate first and burn up their fuel. When they are empty, use interstages to jettison them to lighten the load for the later stages.");
					if (base.TutorialScript.HighlightUiElement("PreflightPanel.StagingPanelButton", Vector2.zero))
					{
						DisplayInstruction("Click the Staging Editor button on the left.");
						return;
					}
					base.TutorialScript.HighlightUiElement("ButtonPanel.Preflight", Vector2.zero);
					DisplayInstruction("Click the Preflight Configuration button on the left.");
				}
			}
			else
			{
				base.TutorialScript.NextStep(playSound: true);
			}
		}
	}
}
