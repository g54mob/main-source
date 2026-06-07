using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class AddPartStep : TutorialStep
	{
		private string _categoryName;

		private string _designerPartName;

		public string PreMessage { get; set; }

		public AddPartStep(int partId, TutorialScript tutorialScript, string designerPartName)
			: base(partId, tutorialScript)
		{
			DesignerPart designerPart = tutorialScript.GetDesignerPart(designerPartName);
			_designerPartName = designerPartName;
			_categoryName = designerPart.Category;
			PreMessage = string.Empty;
		}

		public override void End()
		{
			_tutorialScript.UIScript.SelectedPanel = null;
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			if (GetPartAtCorrectPositionAndRotation() != null)
			{
				_tutorialScript.Accomplishment("Complete");
				_tutorialScript.NextStep();
			}
		}

		protected PartData GetPartAtCorrectPositionAndRotation()
		{
			List<PartData> list = FindUserAddedParts();
			if (list.Count == 0)
			{
				if (_tutorialScript.UIScript.Flyouts.Selected == null)
				{
					_tutorialScript.DisplayMessage("Open the Part List by clicking on the button with the plus symbol.");
					_tutorialScript.HighlightUiElement("AddPartButton", new Vector2(0f, 0f), new Vector2(75f, 75f));
				}
				else if (HighlightPartButton(_designerPartName))
				{
					_tutorialScript.DisplayMessage(PreMessage + "Click and drag the '" + _designerPartName + "' part out from the list.");
				}
				else if (HighlightPartButton(_categoryName))
				{
					_tutorialScript.DisplayMessage("Click on '" + _categoryName + "' to find the part we are looking for");
				}
				else if (_tutorialScript.HighlightUiElement("PartsPanel", new Vector2(130f, -35f), new Vector2(250f, 60f)))
				{
					_tutorialScript.DisplayMessage("Click on the back arrow at the top so we can look for the next part in a different category.");
				}
			}
			else if (list.Count > 0)
			{
				PartData partData = FindPartAtTargetPosition(list);
				if (partData != null)
				{
					if (partData.PartType.PartTypeId == base.TargetPart.PartType.PartTypeId)
					{
						if (Quaternion.Angle(partData.PartScript.transform.rotation, base.TargetPart.PartScript.transform.rotation) < 0.5f)
						{
							return partData;
						}
						_tutorialScript.DisplayMessage("It's in the right place, now it just needs to be rotated.");
						if (!_tutorialScript.UIScript.IsPartOptionsPanelOpened)
						{
							_tutorialScript.HighlightUiElement("TransformPartButton", new Vector2(0f, 0f), new Vector2(75f, 75f));
						}
						else
						{
							_tutorialScript.HighlightUiElement("RotateYButton", new Vector2(0f, 0f), new Vector2(75f, 75f));
						}
					}
					else
					{
						_tutorialScript.DisplayMessage("You have it in the right place, but this is the wrong part. Try dragging this part up to the trash can and delete it.");
					}
				}
				else
				{
					_tutorialScript.DisableUiHighlight();
					if (list.Count <= 2)
					{
						bool flag = false;
						bool flag2 = false;
						foreach (PartData item in list)
						{
							if (item.PartType.PartTypeId == base.TargetPart.PartType.PartTypeId)
							{
								flag = true;
								if (item.PartScript.ConnectedToMainCockpit)
								{
									flag2 = true;
								}
							}
						}
						if (flag2)
						{
							_tutorialScript.DisplayMessage("You have the right part, but it's not in the right place. Try and move it to the spot that I'm indicating. You can always restart this step by clicking the button to the left, or click the button to the right to skip this step.");
						}
						else if (flag)
						{
							_tutorialScript.DisplayMessage("Now drag this part to the aircraft where I'm indicating.");
						}
						else
						{
							_tutorialScript.DisplayMessage("It looks like you have the wrong part. You can drag it up to the trash in the top right to delete it.");
						}
					}
					else
					{
						DisplayRetryMessage();
					}
				}
			}
			return null;
		}

		private bool HighlightPartButton(string partButtonName)
		{
			Vector2 size = new Vector2(316f, 100f);
			return _tutorialScript.HighlightUiElement("PartButton-" + partButtonName, new Vector2(158f, -50f), size);
		}
	}
}
