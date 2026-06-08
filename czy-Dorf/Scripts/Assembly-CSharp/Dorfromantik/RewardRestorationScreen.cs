using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class RewardRestorationScreen : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<SessionQuestReward, string> _003C_003E9__5_0;

			internal string _003CStart_003Eb__5_0(SessionQuestReward x)
			{
				return x.id;
			}
		}

		[SerializeField]
		private RewardTileViewerManager rewardTileViewerManager;

		[SerializeField]
		private RewardLibrary rewardLibrary;

		[SerializeField]
		private RewardRestorationToggle rewardRestorationTogglePrefab;

		[SerializeField]
		private Transform toggleContainer;

		private List<RewardRestorationToggle> allRewardToggles;

		private void Start()
		{
			allRewardToggles = new List<RewardRestorationToggle>();
			foreach (SessionQuestReward item in Enumerable.ToList(Enumerable.OrderBy(rewardLibrary.allRewards, (SessionQuestReward x) => x.id)))
			{
				SetupRewardToggle(item, rewardTileViewerManager.GetTileViewer(item.sessionQuest));
			}
		}

		private void SetupRewardToggle(SessionQuestReward reward, RewardTileViewer tileViewer)
		{
			RewardRestorationToggle rewardRestorationToggle = UnityEngine.Object.Instantiate(rewardRestorationTogglePrefab, toggleContainer);
			rewardRestorationToggle.Setup(this, reward, tileViewer);
			allRewardToggles.Add(rewardRestorationToggle);
		}
	}
}
