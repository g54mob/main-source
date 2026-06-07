using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class LaunchStep : TutorialStep
	{
		public string InstructionText { get; set; }

		public LaunchStep(TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
		}

		public override void Start()
		{
			base.Start();
			base.TutorialScript.HighlightUiElement("LaunchButton", new Vector2(0f, 0f));
			base.TutorialScript.DisplayInstructionText(InstructionText);
			base.TutorialScript.CompleteTutorial();
		}

		public override void Update()
		{
		}
	}
}
