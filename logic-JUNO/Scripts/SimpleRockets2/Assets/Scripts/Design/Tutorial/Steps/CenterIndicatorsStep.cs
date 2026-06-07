using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class CenterIndicatorsStep : TutorialStep
	{
		private bool _complete;

		public CenterIndicatorsStep(TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
		}

		public override void Start()
		{
			base.Start();
			_complete = false;
		}

		public override void Update()
		{
			DesignerUiScript designerUiScript = base.TutorialScript.DesignerUi as DesignerUiScript;
			designerUiScript.Designer.Gizmos.GizmoScale = 0.5f;
			if (!_complete)
			{
				if (designerUiScript.SelectedFlyout == designerUiScript.Flyouts.ViewOptions)
				{
					if (!designerUiScript.Designer.Gizmos.CenterOfMassGizmoEnabled)
					{
						base.TutorialScript.HighlightUiElement("ViewOptions.CoM", new Vector2(12f, 12f));
						DisplayInstruction("Click the red button to show the Center of Mass indicator as a red ball.");
					}
					else if (!designerUiScript.Designer.Gizmos.CenterOfLiftGizmoEnabled)
					{
						base.TutorialScript.HighlightUiElement("ViewOptions.CoL", new Vector2(12f, 12f));
						DisplayInstruction("Click the blue button to show the Center of Lift indicator as a blue ball.");
					}
					else
					{
						_complete = true;
					}
				}
				else
				{
					base.TutorialScript.HighlightUiElement("ButtonPanel.ViewOptions", Vector2.zero);
					DisplayInstruction("Click the View Options button on the left.");
				}
			}
			else
			{
				designerUiScript.SelectedFlyout = null;
				base.TutorialScript.NextStep(playSound: true);
			}
		}
	}
}
