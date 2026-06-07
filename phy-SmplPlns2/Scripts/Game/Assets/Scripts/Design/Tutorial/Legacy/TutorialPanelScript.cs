using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class TutorialPanelScript : MonoBehaviour
	{
		private ImageWidget _highlight;

		private TextWidget _messageLabel;

		private GameObject _restartButton;

		private GameObject _skipButton;

		public ImageWidget Highlight => _highlight;

		public string Message
		{
			get
			{
				return _messageLabel.Text;
			}
			set
			{
				_messageLabel.Text = value;
			}
		}

		public TutorialScript TutorialScript { get; set; }

		public void HidePanelButtons()
		{
			_restartButton.SetActive(value: false);
			_skipButton.SetActive(value: false);
		}

		public void RestartStepClicked()
		{
			TutorialScript.RestartStep();
		}

		public void SkipStepClicked()
		{
			TutorialScript.SkipStep();
		}
	}
}
