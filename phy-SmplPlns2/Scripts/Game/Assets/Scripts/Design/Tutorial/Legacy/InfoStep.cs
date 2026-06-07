using Assets.Scripts.UI;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class InfoStep : TutorialStep
	{
		private string _message;

		public InfoStep(string message, TutorialScript tutorialScript)
			: base(0, tutorialScript)
		{
			_message = message;
		}

		public override void End()
		{
		}

		public override void Start()
		{
			_tutorialScript.ShowPanel(show: false);
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = _message;
			messageDialogScript.OkayClicked += OnOkayClicked;
			messageDialogScript.CancelClicked += OnCancelClicked;
			messageDialogScript.OkayButtonText = "Start";
			messageDialogScript.CancelButtonText = "Cancel";
			_tutorialScript.DisplayMessage(string.Empty);
			_tutorialScript.DisableUiHighlight();
		}

		public override void Update()
		{
		}

		private void OnCancelClicked(MessageDialogScript dialog)
		{
			dialog.Close();
			_tutorialScript.CloseTutorial();
		}

		private void OnOkayClicked(MessageDialogScript dialog)
		{
			dialog.Close();
			_tutorialScript.ShowPanel(show: true);
			_tutorialScript.NextStep();
		}
	}
}
