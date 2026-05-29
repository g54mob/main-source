using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.Polling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Polling
{
	public class PollPanel : MonoBehaviour
	{
		public const float BUTTON_PRESS_TIME = 0.8f;

		public const string ResponseSubmittedMessage = "Your vote has been recorded.\n Thank you!";

		public GameObject ButtonPrefab;

		public Color TextColor_Green;

		public Color TextColor_Red;

		[Header("References")]
		public PollManager PollManager;

		public GameObject Container;

		public GameObject ActivePill;

		public GameObject ClosedPill;

		public TextMeshProUGUI QuestionLabel;

		public RectTransform ButtonContainer;

		public TextMeshProUGUI InstructionLabel;

		public TextMeshProUGUI ConfirmationMessageLabel;

		public AudioSourceController SubmissionStartSound;

		public AudioSourceController SubmissionSuccessSound;

		public AudioSourceController SubmissionFailSound;

		private List<Button> buttons;

		private List<Image> buttonFills;

		private int heldButton;

		private int selectedButton;

		private int lastHeldButton;

		private float buttonPressTime;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void DisplayActivePoll(PollData poll)
		{
		}

		public void DisplayConfirmedPoll(PollData poll)
		{
		}

		private void DisplaySubmittedAnswer(int buttonIndex)
		{
		}

		private void Rebuild()
		{
		}

		private List<Button> CreateButtons(PollData data)
		{
			return null;
		}

		private void ButtonPressed(int buttonIndex)
		{
		}

		private void FinalizeButtonPress(int buttonIndex)
		{
		}
	}
}
