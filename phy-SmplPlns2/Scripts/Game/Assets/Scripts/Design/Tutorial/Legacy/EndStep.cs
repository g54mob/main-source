using Assets.Scripts.Design.UI;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class EndStep : TutorialStep
	{
		private string _message;

		public EndStep(string message, TutorialScript tutorialScript)
			: base(0, tutorialScript)
		{
			_message = message;
		}

		public override void End()
		{
		}

		public override void Start()
		{
			DesignerUIScript.TutorialCenterViewOnPart(_tutorialScript.DesignerScript.Aircraft.MainCockpit);
			_tutorialScript.HidePanelButtons();
			_tutorialScript.DisplayMessage(_message);
			_tutorialScript.HighlightUiElement("PlayButton", new Vector2(0f, 0f), new Vector2(75f, 75f));
		}

		public override void Update()
		{
		}
	}
}
