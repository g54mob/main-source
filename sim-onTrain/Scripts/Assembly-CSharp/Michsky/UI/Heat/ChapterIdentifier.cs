using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	public class ChapterIdentifier : MonoBehaviour
	{
		[Header("Resources")]
		public Animator animator;

		[SerializeField]
		private RectTransform backgroundRect;

		public Image backgroundImage;

		public TextMeshProUGUI titleObject;

		public TextMeshProUGUI descriptionObject;

		public ButtonManager continueButton;

		public ButtonManager playButton;

		public ButtonManager replayButton;

		public GameObject completedIndicator;

		public GameObject unlockedIndicator;

		public GameObject lockedIndicator;

		[HideInInspector]
		public ChapterManager chapterManager;

		[HideInInspector]
		public bool isLocked;

		[HideInInspector]
		public bool isCurrent;

		public void UpdateBackgroundRect()
		{
			chapterManager.currentBackgroundRect = backgroundRect;
			chapterManager.DoStretch();
		}

		public void SetCurrent()
		{
			completedIndicator.SetActive(value: false);
			unlockedIndicator.SetActive(value: true);
			lockedIndicator.SetActive(value: false);
			continueButton.gameObject.SetActive(value: true);
			playButton.gameObject.SetActive(value: false);
			replayButton.gameObject.SetActive(value: true);
			isLocked = false;
			isCurrent = true;
			continueButton.isInteractable = true;
			replayButton.isInteractable = true;
		}

		public void SetLocked()
		{
			completedIndicator.SetActive(value: false);
			unlockedIndicator.SetActive(value: false);
			lockedIndicator.SetActive(value: true);
			continueButton.gameObject.SetActive(value: false);
			playButton.gameObject.SetActive(value: true);
			replayButton.gameObject.SetActive(value: false);
			isLocked = true;
			isCurrent = false;
			playButton.isInteractable = false;
		}

		public void SetUnlocked()
		{
			completedIndicator.SetActive(value: false);
			unlockedIndicator.SetActive(value: true);
			lockedIndicator.SetActive(value: false);
			continueButton.gameObject.SetActive(value: false);
			playButton.gameObject.SetActive(value: true);
			replayButton.gameObject.SetActive(value: false);
			isLocked = false;
			isCurrent = false;
			playButton.isInteractable = true;
		}

		public void SetCompleted()
		{
			completedIndicator.SetActive(value: true);
			unlockedIndicator.SetActive(value: false);
			lockedIndicator.SetActive(value: false);
			continueButton.gameObject.SetActive(value: false);
			playButton.gameObject.SetActive(value: false);
			replayButton.gameObject.SetActive(value: true);
			isLocked = false;
			isCurrent = false;
			replayButton.isInteractable = true;
		}
	}
}
