using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI.MainMenu
{
	public class UiTutorialSelectionScreen : MonoBehaviour
	{
		[SerializeField]
		private SessionQuestReward windmillSessionQuestReward;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Sprite windmillUnlockedSprite;

		[SerializeField]
		private Sprite windmillLockedSprite;

		private void Awake()
		{
			SetupBackground();
		}

		private void OnEnable()
		{
			SetupBackground();
		}

		private void SetupBackground()
		{
			if (windmillSessionQuestReward.state == RewardState.Completed)
			{
				backgroundImage.sprite = windmillUnlockedSprite;
			}
			else
			{
				backgroundImage.sprite = windmillLockedSprite;
			}
		}
	}
}
