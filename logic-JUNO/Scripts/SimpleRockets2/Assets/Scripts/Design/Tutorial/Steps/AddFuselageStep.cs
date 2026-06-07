using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class AddFuselageStep : AddPartStep
	{
		private string _arrowText;

		private FuselageData _fuselage;

		private FuselageScript _fuselageScript;

		private Vector2 _originalBottomScale;

		private Vector3 _originalOffset;

		private Vector3 _originalPosition;

		private float _originalRadius;

		private Vector2 _originalTopScale;

		private bool _positioned;

		private bool _resized;

		private bool _updatePosition;

		public FuselageData DesignerFuselage { get; private set; }

		public bool FlipDeltaPosition { get; set; }

		public bool MultipleGreenArrows { get; set; }

		public string PartName { get; set; }

		public bool RequireRadius { get; set; }

		public AddFuselageStep(int partId, TutorialScript tutorialScript, string designerPartName, bool updatePosition)
			: base(partId, tutorialScript, designerPartName)
		{
			DesignerFuselage = TutorialStep.GetDesignerPartModifier<FuselageData>(tutorialScript, designerPartName);
			_updatePosition = updatePosition;
			base.PlacementCriteria = PartPlacementCriteria.AttachPoint;
			PartName = designerPartName;
		}

		public override void Start()
		{
			base.Start();
			_fuselage = base.TargetPart.GetModifier<FuselageData>();
			_fuselageScript = base.TargetPart.PartScript.GetModifier<FuselageScript>();
			Game.Instance.Settings.Game.Designer.EnableGizmos.UpdateAndCommit(value: true);
			Game.Instance.Settings.Game.Designer.EnableAutoResize.UpdateAndCommit(value: true);
			_originalPosition = _fuselage.Part.PartScript.Transform.position;
			_originalOffset = _fuselage.Offset;
			_originalBottomScale = _fuselage.BottomScale;
			_originalTopScale = _fuselage.TopScale;
			_originalRadius = CalculateRadius(_fuselage);
			_arrowText = "arrow";
			if (MultipleGreenArrows)
			{
				_arrowText = "arrows";
			}
			ResizeToDesignerPart();
		}

		public override void Update()
		{
			PartData partData = ProcessUserParts(base.PlacementCriteria);
			if (partData != null)
			{
				if (!_positioned)
				{
					_positioned = true;
					base.TutorialScript.Accomplishment("Positioned", 0.25f);
				}
				if (!_resized)
				{
					ResizeToTargetPart();
					return;
				}
				bool flag = true;
				foreach (DesignerTool tool in base.TutorialScript.DesignerScript.Tools)
				{
					if (!tool.IsBaseTool && tool.Active && tool != base.TutorialScript.DesignerScript.FuselageTool)
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
				DisplayStep("Resize the " + PartName + " to match the desired size, which is flashing green.");
				base.TutorialScript.DisableUiHighlight();
				if (base.TutorialScript.DesignerScript.SelectedPart == partData.PartScript)
				{
					FuselageData modifier = partData.GetModifier<FuselageData>();
					float num = CalculateRadius(modifier);
					if (!Utilities.CompareFloats(modifier.Offset.y, _fuselage.Offset.y, _fuselage.Offset.y * 0.025f))
					{
						if (modifier.Offset.y > _originalOffset.y)
						{
							DisplayInstruction("Drag the green " + _arrowText + " to make the " + PartName + " shorter.");
						}
						else if (modifier.Offset.y < _originalOffset.y)
						{
							DisplayInstruction("Drag the green " + _arrowText + " to make the " + PartName + " taller.");
						}
					}
					else if (RequireRadius && !Utilities.CompareFloats(_originalRadius, num, _originalRadius * 0.05f))
					{
						base.TutorialScript.Accomplishment("Height");
						if (num < _originalRadius)
						{
							DisplayInstruction("Great! Now drag the orange arrow to make the " + PartName + " fatter.");
						}
						else
						{
							DisplayInstruction("Great! Now drag the orange arrow to make the " + PartName + " thinner.");
						}
					}
					else
					{
						base.TutorialScript.NextStep(playSound: true);
					}
				}
				else
				{
					DisplayInstruction("Click on the part you just added to select it.");
				}
			}
			else if (_resized)
			{
				DisplayStep(base.StepText);
				ResizeToDesignerPart();
			}
		}

		private static float CalculateRadius(FuselageData fuselage)
		{
			return (fuselage.TopScale.magnitude + fuselage.BottomScale.magnitude) * 0.5f;
		}

		private void ResizeToDesignerPart()
		{
			_resized = false;
			Vector3 vector = DesignerFuselage.Offset - _originalOffset;
			_fuselage.Offset = DesignerFuselage.Offset;
			_fuselage.BottomScale = DesignerFuselage.BottomScale;
			_fuselage.TopScale = DesignerFuselage.TopScale;
			_fuselageScript.PartScript.Transform.position = _originalPosition;
			if (_updatePosition)
			{
				_fuselageScript.PartScript.Transform.position -= (FlipDeltaPosition ? (-vector) : vector);
			}
			_fuselageScript.UpdateMeshes(updateNormalSmoothing: true);
		}

		private void ResizeToTargetPart()
		{
			_resized = true;
			_fuselage.Offset = _originalOffset;
			_fuselage.BottomScale = _originalBottomScale;
			_fuselage.TopScale = _originalTopScale;
			_fuselageScript.PartScript.Transform.position = _originalPosition;
			_fuselageScript.UpdateMeshes(updateNormalSmoothing: true);
			_fuselageScript.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
