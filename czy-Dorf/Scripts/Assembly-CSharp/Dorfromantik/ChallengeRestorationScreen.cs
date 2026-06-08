using System;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class ChallengeRestorationScreen : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<SessionQuest, ChallengeId> _003C_003E9__5_0;

			internal ChallengeId _003CStart_003Eb__5_0(SessionQuest x)
			{
				return x.id;
			}
		}

		[SerializeField]
		private SessionQuestManager sessionQuestManager;

		[SerializeField]
		private ChallengeRestorationRow challengeRestorationRowPrefab;

		[SerializeField]
		private Transform rowContainer;

		[SerializeField]
		private RewardTileViewerManager rewardTileViewerManager;

		[SerializeField]
		private RewardLibrary rewardLibrary;

		private void Start()
		{
			sessionQuestManager.Setup();
			rewardLibrary.Setup();
			sessionQuestManager.SetupFromLoadedRewards(rewardLibrary.allRewards);
			rewardLibrary.SetupFromLoadedChallenges(sessionQuestManager.sessionQuests);
			foreach (SessionQuest item in Enumerable.OrderBy(sessionQuestManager.sessionQuests, (SessionQuest x) => x.id))
			{
				if (item.compositeParentQuest == null)
				{
					SetupChallengeRow(item, rewardTileViewerManager.GetTileViewer(item));
				}
			}
		}

		private void SetupChallengeRow(SessionQuest challenge, RewardTileViewer tileViewer)
		{
			UnityEngine.Object.Instantiate(challengeRestorationRowPrefab, rowContainer).Setup(this, challenge, tileViewer);
		}

		public void UpdateChallengeState(SessionQuest challenge)
		{
			if (challenge is CompositeSessionQuest compositeSessionQuest)
			{
				sessionQuestManager.UpdateSessionQuestData(compositeSessionQuest.GetActiveChildSessionQuest(), save: true);
			}
			sessionQuestManager.UpdateSessionQuestData(challenge, save: true);
			for (int i = 0; i < challenge.LevelCount; i++)
			{
				RewardState newState = ((challenge.CurrentLevelIndex > i) ? RewardState.Completed : RewardState.Hidden);
				rewardLibrary.UpdateRewardState(challenge.GetLevel(i).reward.id, newState, saveRewards: true);
			}
		}
	}
}
