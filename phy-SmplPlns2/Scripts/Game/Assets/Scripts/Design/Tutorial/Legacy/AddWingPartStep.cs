using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class AddWingPartStep : AddPartStep
	{
		private float _originalRootLeadingOffset;

		private float _originalRootTrailingOffset;

		private float _originalTipLeadingOffset;

		private Vector3 _originalTipPosition;

		private float _originalTipTrailingOffset;

		private bool _positioned;

		private float _rootLeadingOffset;

		private float _rootTrailingOffset;

		private float _tipLeadingOffset;

		private Vector3 _tipPosition;

		private float _tipTrailingOffset;

		private WingData _wing;

		private bool _wingResized;

		private WingScript _wingScript;

		public AddWingPartStep(int partId, TutorialScript tutorialScript, string designerPartName, float rootLeadingOffset, float rootTrailingOffset, float tipLeadingOffset, float tipTrailingOffset, Vector3 tipPosition)
			: base(partId, tutorialScript, designerPartName)
		{
			_rootLeadingOffset = rootLeadingOffset;
			_rootTrailingOffset = rootTrailingOffset;
			_tipLeadingOffset = tipLeadingOffset;
			_tipTrailingOffset = tipTrailingOffset;
			_tipPosition = tipPosition;
		}

		public override void Start()
		{
			base.Start();
			_wing = base.TargetPart.GetModifier<WingData>();
			_wingScript = base.TargetPart.PartScript.GetModifier<WingScript>();
			while (_wingScript.ControlSurfaces.Count > 0)
			{
				_wingScript.DeleteControlSurface(_wingScript.ControlSurfaces[0]);
			}
			_originalRootLeadingOffset = _wingScript.Wing.RootLeadingOffset;
			_originalRootTrailingOffset = _wingScript.Wing.RootTrailingOffset;
			_originalTipLeadingOffset = _wingScript.Wing.TipLeadingOffset;
			_originalTipTrailingOffset = _wingScript.Wing.TipTrailingOffset;
			_originalTipPosition = _wingScript.Wing.TipPosition;
			ResizeWingToDesignerPartSize();
			base.TargetPart.PartScript.transform.localScale = new Vector3(1.1f, 1f, 1f);
		}

		public override void Update()
		{
			PartData partAtCorrectPositionAndRotation = GetPartAtCorrectPositionAndRotation();
			if (partAtCorrectPositionAndRotation != null)
			{
				if (!_positioned)
				{
					_positioned = true;
					_tutorialScript.Accomplishment("Positioned");
				}
				if (!_wingResized)
				{
					ResizeTargetWing();
				}
				else if (CompareWingToTarget(partAtCorrectPositionAndRotation))
				{
					if (_tutorialScript.DesignerScript.DesignerUI.InEditingState)
					{
						_tutorialScript.Accomplishment("WingShape");
						_tutorialScript.DisplayMessage("Great! Now click the 'Done' button at the top left.");
						_tutorialScript.HighlightUiElement("DoneEditingButton", new Vector2(125f, -30f), new Vector2(250f, 60f));
					}
					else
					{
						_tutorialScript.Accomplishment("Complete");
						_tutorialScript.NextStep();
					}
				}
				else if (_tutorialScript.DesignerScript.DesignerUI.InEditingState)
				{
					_tutorialScript.DisplayMessage("Resize your wing by dragging the blue arrows until it matches the shape of the flashing wing.");
					_tutorialScript.DisableUiHighlight();
				}
				else if (_tutorialScript.UIScript.Flyouts.Selected == _tutorialScript.UIScript.Flyouts.PartProperties)
				{
					_tutorialScript.DisplayMessage("This panel lets you customize several aspects of a wing. Right now we just want to edit its shape, so click the 'Edit Wing Shape' button.");
					_tutorialScript.HighlightUiElement("EditWingShapeButton", new Vector2(0f, -30f), new Vector2(250f, 60f), highlightEvenIfInactive: true);
				}
				else if (_tutorialScript.DesignerScript.Designer.SelectedPart == partAtCorrectPositionAndRotation.PartScript)
				{
					_tutorialScript.DisplayMessage("Now click the wing properties button on the right so we can customize this wing section.");
					_tutorialScript.HighlightUiElement("EditPartButton", new Vector2(0f, 0f), new Vector2(75f, 75f), highlightEvenIfInactive: true);
				}
				else
				{
					_tutorialScript.DisplayMessage("Click on the wing section you just added to select it.");
					_tutorialScript.DisableUiHighlight();
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
			if (Utilities.CompareFloats(modifier.RootLeadingOffset, _wing.RootLeadingOffset, 0.01f) && Utilities.CompareFloats(modifier.RootTrailingOffset, _wing.RootTrailingOffset, 0.01f) && Utilities.CompareFloats(modifier.TipPosition.y, _wing.TipPosition.y, 0.01f) && Utilities.CompareFloats(modifier.TipPosition.z + modifier.TipLeadingOffset, _wing.TipPosition.z + _wing.TipLeadingOffset, 0.01f) && Utilities.CompareFloats(modifier.TipPosition.z - modifier.TipTrailingOffset, _wing.TipPosition.z - _wing.TipTrailingOffset, 0.01f))
			{
				return true;
			}
			return false;
		}

		private void ResizeTargetWing()
		{
			_wingResized = true;
			_wingScript.Wing.RootLeadingOffset = _originalRootLeadingOffset;
			_wingScript.Wing.RootTrailingOffset = _originalRootTrailingOffset;
			_wingScript.Wing.TipLeadingOffset = _originalTipLeadingOffset;
			_wingScript.Wing.TipTrailingOffset = _originalTipTrailingOffset;
			_wingScript.Wing.TipPosition = _originalTipPosition;
			_wingScript.UpdateWingShape();
		}

		private void ResizeWingToDesignerPartSize()
		{
			_wingResized = false;
			_wingScript.Wing.RootLeadingOffset = _rootLeadingOffset;
			_wingScript.Wing.RootTrailingOffset = _rootTrailingOffset;
			_wingScript.Wing.TipLeadingOffset = _tipLeadingOffset;
			_wingScript.Wing.TipTrailingOffset = _tipTrailingOffset;
			_wingScript.Wing.TipPosition = _tipPosition;
			_wingScript.UpdateWingShape();
		}
	}
}
