using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class FingerToolStep : TutorialStep
	{
		public FingerToolStep(TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
		}

		public override void End()
		{
			base.End();
			base.TutorialScript.HasFingerToolBeenIntroduced = true;
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			if (!base.TutorialScript.DesignerUi.FingerTool.Enabled)
			{
				base.TutorialScript.HighlightUiElement("ToggleFingerTool", new Vector2(2f, 2f));
				DisplayInstruction("Tap the Finger Tool button in the bottom right.");
			}
			else
			{
				base.TutorialScript.NextStep(playSound: true);
			}
		}
	}
}
