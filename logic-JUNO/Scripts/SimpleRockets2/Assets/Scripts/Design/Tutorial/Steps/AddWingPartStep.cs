using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class AddWingPartStep : AddPartStep
	{
		private WingData _initialWingData;

		private float _originalRootLeadingOffset;

		private float _originalRootTrailingOffset;

		private float _originalTipLeadingOffset;

		private Vector3 _originalTipPosition;

		private float _originalTipTrailingOffset;

		private bool _positioned;

		private WingData _wing;

		private bool _wingResized;

		private WingScript _wingScript;

		public Vector2? ResizeCameraRotation { get; set; }

		public float? ResizeCameraZoom { get; set; }

		public AddWingPartStep(int partId, TutorialScript tutorialScript, string designerPartName, int clonePartId = 0)
			: base(partId, tutorialScript, designerPartName)
		{
			base.ClonePartId = clonePartId;
			_initialWingData = TutorialStep.GetDesignerPartModifier<WingData>(tutorialScript, designerPartName);
		}

		public override void Start()
		{
			base.Start();
			base.TutorialScript.DesignerScript.WingAdjustmentTool.ThicknessGizmoEnabled = false;
			_wing = base.TargetPart.GetModifier<WingData>();
			_wingScript = base.TargetPart.PartScript.GetModifier<WingScript>();
			while (_wingScript.ControlSurfaces.Count > 0)
			{
				_wingScript.DeleteControlSurface(_wingScript.ControlSurfaces[0]);
			}
			_originalRootLeadingOffset = _wingScript.Data.RootLeadingOffset;
			_originalRootTrailingOffset = _wingScript.Data.RootTrailingOffset;
			_originalTipLeadingOffset = _wingScript.Data.TipLeadingOffset;
			_originalTipTrailingOffset = _wingScript.Data.TipTrailingOffset;
			_originalTipPosition = _wingScript.Data.TipPosition;
			ResizeWingToDesignerPartSize();
			base.TargetPart.PartScript.Transform.localScale = new Vector3(1.1f, 1f, 1f);
		}

		public override void Update()
		{
			PartData partData = ProcessUserParts(base.PlacementCriteria);
			if (partData != null)
			{
				if (!_positioned)
				{
					_positioned = true;
					base.TutorialScript.Accomplishment("Positioned");
					if (ResizeCameraZoom.HasValue)
					{
						base.TutorialScript.DesignerScript.DesignerCamera.SetTargetZoom(ResizeCameraZoom.Value);
					}
					if (ResizeCameraRotation.HasValue)
					{
						base.TutorialScript.DesignerScript.DesignerCamera.SetTargetRotation(ResizeCameraRotation.Value);
					}
				}
				if (!_wingResized)
				{
					ResizeTargetWing();
					return;
				}
				if (CompareWingToTarget(partData))
				{
					base.TutorialScript.Accomplishment("Complete");
					base.TutorialScript.NextStep();
					return;
				}
				bool flag = true;
				foreach (DesignerTool tool in base.TutorialScript.DesignerScript.Tools)
				{
					if (!tool.IsBaseTool && tool.Active && tool != base.TutorialScript.DesignerScript.WingAdjustmentTool)
					{
						flag = false;
						if (base.TutorialScript.HighlightUiElement("ToolPanel.MovePartTool", Vector2.zero))
						{
							DisplayInstruction("Select the Move Part tool.");
							break;
						}
						DisplayInstruction("Open the Tools panel.");
						base.TutorialScript.HighlightUiElement("ButtonPanel.Tools", Vector2.zero);
						break;
					}
				}
				if (!flag)
				{
					if (base.TutorialScript.HighlightUiElement("ToolPanel.MovePartTool", Vector2.zero))
					{
						DisplayInstruction("Select the Move Part tool.");
						return;
					}
					DisplayInstruction("Open the Tools panel.");
					base.TutorialScript.HighlightUiElement("ButtonPanel.Tools", Vector2.zero);
					return;
				}
				if (base.TutorialScript.DesignerUi.FingerTool.Enabled)
				{
					base.TutorialScript.DesignerUi.FingerTool.Enabled = false;
				}
				DisplayStep("Now we need to resize the wing to match the desired size, which is flashing green.");
				base.TutorialScript.DisableUiHighlight();
				if (base.TutorialScript.DesignerScript.SelectedPart == partData.PartScript)
				{
					DisplayInstruction("Resize by dragging the arrows until it matches the desired shape.");
				}
				else
				{
					DisplayInstruction("Click on the part you just added to select it.");
				}
			}
			else if (_wingResized)
			{
				ResizeWingToDesignerPartSize();
			}
		}

		private bool CompareWingToTarget(PartData part)
		{
			WingData modifier = part.GetModifier<WingData>();
			if (Utilities.CompareFloats(modifier.BaseChord, _wing.BaseChord, 0.06f) && Utilities.CompareFloats(modifier.TipChord, _wing.TipChord, 0.06f) && Utilities.CompareFloats(modifier.TipPosition.y, _wing.TipPosition.y, 0.06f) && Utilities.CompareFloats(modifier.TipPosition.z + modifier.TipLeadingOffset, _wing.TipPosition.z + _wing.TipLeadingOffset, 0.06f) && Utilities.CompareFloats(modifier.TipPosition.z - modifier.TipTrailingOffset, _wing.TipPosition.z - _wing.TipTrailingOffset, 0.06f))
			{
				return true;
			}
			return false;
		}

		private void ResizeTargetWing()
		{
			_wingResized = true;
			_wingScript.Data.RootLeadingOffset = _originalRootLeadingOffset;
			_wingScript.Data.RootTrailingOffset = _originalRootTrailingOffset;
			_wingScript.Data.TipLeadingOffset = _originalTipLeadingOffset;
			_wingScript.Data.TipTrailingOffset = _originalTipTrailingOffset;
			_wingScript.Data.TipPosition = _originalTipPosition;
			_wingScript.UpdateWingShape();
		}

		private void ResizeWingToDesignerPartSize()
		{
			if (base.ClonePartId > 0)
			{
				PartData craftPart = base.TutorialScript.GetCraftPart(base.ClonePartId);
				_initialWingData = craftPart.GetModifier<WingData>();
			}
			_wingResized = false;
			_wingScript.Data.RootLeadingOffset = _initialWingData.RootLeadingOffset;
			_wingScript.Data.RootTrailingOffset = _initialWingData.RootTrailingOffset;
			_wingScript.Data.TipLeadingOffset = _initialWingData.TipLeadingOffset;
			_wingScript.Data.TipTrailingOffset = _initialWingData.TipTrailingOffset;
			_wingScript.Data.TipPosition = _initialWingData.TipPosition;
			_wingScript.UpdateWingShape();
		}
	}
}
