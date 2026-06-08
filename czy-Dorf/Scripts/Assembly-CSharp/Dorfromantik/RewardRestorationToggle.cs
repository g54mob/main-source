using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class RewardRestorationToggle : MonoBehaviour
	{
		[SerializeField]
		private RawImage hiddenImage;

		[SerializeField]
		private RawImage unlockedImage;

		[SerializeField]
		private SessionQuestReward toggleReward;

		public void Setup(RewardRestorationScreen rewardRestorationScreen, SessionQuestReward reward, RewardTileViewer tileViewer)
		{
			hiddenImage.texture = tileViewer.GetRenderTexture(reward.rewardLevel, RewardState.Hidden);
			unlockedImage.texture = tileViewer.GetRenderTexture(reward.rewardLevel, RewardState.Completed);
			toggleReward = reward;
		}
	}
}
