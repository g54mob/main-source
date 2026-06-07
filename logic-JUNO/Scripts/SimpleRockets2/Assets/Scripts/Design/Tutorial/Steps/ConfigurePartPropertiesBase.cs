using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public abstract class ConfigurePartPropertiesBase : TutorialStep
	{
		private bool _complete;

		private bool _error;

		public bool MustClosePartProperties { get; set; } = true;

		public int PartId { get; private set; }

		public string PartName { get; set; }

		public ConfigurePartPropertiesBase(int partId, string partName, TutorialScript tutorialScript)
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
		}

		public override void Update()
		{
			IDesignerUi designerUi = base.TutorialScript.DesignerUi;
			if (_error)
			{
				base.TutorialScript.DisableUiHighlight();
				DisplayRetryMessage();
				return;
			}
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
				if (designerUi.SelectedFlyout == designerUi.Flyouts.PartProperties)
				{
					if (ConfigurePartProperties(craftPart))
					{
						if (MustClosePartProperties)
						{
							_complete = true;
							base.TutorialScript.Accomplishment("PartProperties", 0.25f);
							base.TutorialScript.HighlightUiElement("Flyout.PartProperties.Close", new Vector2(-2f, -4f));
							DisplayInstruction("Great! Now close the panel by clicking the X in the top left.");
						}
						else
						{
							base.TutorialScript.NextStep(playSound: true);
						}
					}
				}
				else if (_complete)
				{
					base.TutorialScript.NextStep(playSound: true);
				}
				else
				{
					base.TutorialScript.HighlightUiElement("ButtonPanel.PartProperties", Vector2.zero);
					DisplayInstruction("Click the Part Properties button on the left.");
				}
			}
		}

		protected abstract bool ConfigurePartProperties(PartData part);
	}
}
