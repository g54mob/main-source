using System;
using System.Collections.Generic;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class AddPartStep : TutorialStep
	{
		public enum PartPlacementCriteria
		{
			Position = 0,
			PositionAndRotation = 1,
			AttachPoint = 2
		}

		private string _categoryName;

		private string _designerPartName;

		private MouseInputSettingsDesigner _mouseInputSettings;

		public int ClonePartId { get; set; }

		public PartPlacementCriteria PlacementCriteria { get; set; }

		public bool RecenterAfterClone { get; set; }

		public AddPartStep(int partId, TutorialScript tutorialScript, string designerPartName)
			: base(partId, tutorialScript)
		{
			DesignerPart designerPart = tutorialScript.GetDesignerPart(designerPartName);
			if (designerPart != null)
			{
				_designerPartName = designerPartName;
				_categoryName = designerPart.Category.Id;
				PlacementCriteria = PartPlacementCriteria.Position;
				base.CenterOnTarget = true;
				_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
				return;
			}
			throw new ArgumentException("Could not find designer part: " + designerPartName);
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			if (ProcessUserParts(PlacementCriteria) != null)
			{
				base.TutorialScript.Accomplishment("Complete", 0.25f);
				base.TutorialScript.NextStep();
			}
		}

		protected PartData ProcessUserParts(PartPlacementCriteria criteria)
		{
			List<PartData> list = FindUserAddedParts();
			base.TutorialScript.DisplayError(string.Empty);
			if (Device.IsMobileBuild)
			{
				base.TutorialScript.DesignerUi.FingerTool.Enabled = true;
			}
			PartData partData = null;
			if (ClonePartId > 0)
			{
				partData = base.TutorialScript.GetCraftPart(ClonePartId);
				if (partData != null)
				{
					HighlightPart(partData, highlight: false, solid: true);
				}
				else
				{
					ClonePartId = 0;
				}
			}
			if (list.Count == 0)
			{
				if (ClonePartId == 0)
				{
					if (!base.TutorialScript.DesignerUi.Flyouts.PartList.IsOpen)
					{
						DisplayInstruction("Open the Part List by [clicking|tapping] on the button with the plus symbol.");
						base.TutorialScript.HighlightUiElement("ButtonPanel.AddPart", Vector2.zero);
					}
					else if (HighlightPartButton(_designerPartName))
					{
						if (base.TutorialScript.IsHighlightOffscreen)
						{
							DisplayInstruction("Scroll through the part list until the '" + _designerPartName + "' part is in view.");
						}
						else
						{
							DisplayInstruction("Drag the '" + _designerPartName + "' part out from the list.");
						}
					}
					else if (HighlightPartCategory(_categoryName))
					{
						DisplayInstruction("[Click|Tap] on the " + _categoryName + " category to find the part we are looking for.");
					}
					else if (base.TutorialScript.HighlightUiElement("PartsPanel", Vector2.zero))
					{
						DisplayInstruction("[Click|Tap] on the back arrow at the top so we can look for the next part in a different category.");
					}
				}
				else
				{
					ShowTargetPart(show: false);
					if (partData != null)
					{
						if (Device.IsMobileBuild)
						{
							if (!base.TutorialScript.DesignerUi.FingerTool.Enabled)
							{
								base.TutorialScript.HighlightUiElement("ToggleFingerTool", new Vector2(3f, 3f));
								DisplayInstruction("Tap the button in the lower right to enable the Finger Tool.");
							}
							else if (base.TutorialScript.DesignerScript.SelectedPart?.Data == partData && base.TutorialScript.DesignerUi.FingerTool.PartButtonsEnabled)
							{
								base.TutorialScript.HighlightUiElement("FingerTool.ClonePart", new Vector2(3f, 3f));
								DisplayInstruction("Drag the Clone Part button on the Finger Tool to clone this part.");
							}
							else
							{
								base.TutorialScript.HighlightUiElement("FingerTool.SelectPart", new Vector2(3f, 3f));
								DisplayInstruction("Reposition the Finger Tool over the part we added earlier. It's flashing blue.");
								HighlightPart(partData, highlight: true, solid: true);
							}
						}
						else
						{
							MouseInputSettings.MouseClickType value = _mouseInputSettings.ClonePart.Value;
							if (value == MouseInputSettings.MouseClickType.None)
							{
								value = _mouseInputSettings.ClonePartAlt.Value;
							}
							string text = "RIGHT";
							switch (value)
							{
							case MouseInputSettings.MouseClickType.LeftClick:
								text = "LEFT";
								break;
							case MouseInputSettings.MouseClickType.MiddleClick:
								text = "MIDDLE";
								break;
							}
							base.TutorialScript.DisableUiHighlight();
							DisplayInstruction(text + "-click and drag the '" + _designerPartName + "' we added earlier to clone it. It's flashing blue. Cloning is quicker and easier than dragging a new part out of the part list.");
							HighlightPart(partData, highlight: true, solid: true);
						}
					}
				}
			}
			else if (list.Count > 0)
			{
				if (ClonePartId > 0 && RecenterAfterClone)
				{
					RecenterAfterClone = false;
					base.FocusPartId = base.TargetPartId;
					UpdateCamera();
				}
				ShowTargetPart(show: true);
				PartData partData2 = null;
				switch (criteria)
				{
				case PartPlacementCriteria.Position:
				case PartPlacementCriteria.PositionAndRotation:
					partData2 = FindPartAtTargetPosition(list);
					break;
				case PartPlacementCriteria.AttachPoint:
					partData2 = GetPartAtAttachPoint(list);
					break;
				}
				if (partData2 != null)
				{
					if (partData2.PartType.Id == base.TargetPart.PartType.Id)
					{
						if (Quaternion.Angle(partData2.PartScript.Transform.rotation, base.TargetPart.PartScript.Transform.rotation) < 0.5f || criteria != PartPlacementCriteria.PositionAndRotation)
						{
							return partData2;
						}
						DisplayInstruction("It's in the right place, now it just needs to be rotated.");
						if (!base.TutorialScript.DesignerScript.RotatePartTool.Active)
						{
							base.TutorialScript.HighlightUiElement("TransformPartButton", Vector2.zero);
						}
						else
						{
							base.TutorialScript.HighlightUiElement("RotateYButton", Vector2.zero);
						}
					}
					else
					{
						DisplayInstruction("You have it in the right place, but this is the wrong part. Try dragging this part up to the trash can and delete it.");
					}
				}
				else
				{
					base.TutorialScript.DisableUiHighlight();
					bool flag = false;
					bool flag2 = false;
					foreach (PartData item in list)
					{
						if (item.PartType.Id == base.TargetPart.PartType.Id)
						{
							flag = true;
							if (!item.PartScript.Disconnected)
							{
								flag2 = true;
							}
						}
					}
					if (flag2)
					{
						base.TutorialScript.DisplayError("If you are having trouble, you can always restart this step by [clicking|tapping] the button in the lower left. Or you can [click|tap] the button in the lower right to skip this step.");
						DisplayInstruction("You have the right part, but it's not in the right place. Try and move it to the spot that I'm indicating.");
					}
					else if (flag)
					{
						DisplayInstruction("Now drag this part to the craft where I'm indicating.");
					}
					else
					{
						DisplayInstruction("It looks like you have the wrong part. You can drag it up to the trash in the top right to delete it.");
					}
				}
			}
			return null;
		}

		private PartData GetPartAtAttachPoint(List<PartData> parts)
		{
			if (base.TargetPartDestinationAttachPoints[0].PartConnections.Count > 0)
			{
				PartData otherPart = base.TargetPartDestinationAttachPoints[0].PartConnections[0].GetOtherPart(base.CraftPart);
				if (parts.Contains(otherPart))
				{
					return otherPart;
				}
			}
			return null;
		}

		private bool HighlightPartButton(string partButtonName)
		{
			return base.TutorialScript.HighlightUiElement("PartList.Item." + partButtonName, Vector2.zero);
		}

		private bool HighlightPartCategory(string partButtonName)
		{
			return base.TutorialScript.HighlightUiElement("PartList.Category." + partButtonName, Vector2.zero);
		}
	}
}
