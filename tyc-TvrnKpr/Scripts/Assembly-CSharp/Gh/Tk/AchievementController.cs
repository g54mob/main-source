using System.Collections.Generic;
using Gh.Tk.UI;
using Gh.Tk.UI.Dialogs;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class AchievementController : SingletonMonoBehaviour<AchievementController>
	{
		public const float DISPLAY_ACHIEVEMENT_DELAY_SECONDS = 2f;

		public const float NEXT_ACHIEVEMENT_DELAY_SECONDS = 1f;

		public const string BronzeTierKey = "bronze";

		public const string SilverTierKey = "silver";

		public const string GoldTierKey = "gold";

		public static string[] TiersOrdered;

		[SerializeField]
		private List<Achievement> _allAchievements;

		private Dictionary<string, List<Achievement>> _lockedAchievements;

		private List<(Achievement achievement, List<GreenbackRewardData> rewards, float delayTime)> _queuedAchievements;

		[SerializeField]
		private GameObject _visualParent;

		private Animator _visualAnimator;

		private static readonly int AchievementUnlock_AKey;

		private static readonly int CardUnlock_AKey;

		[SerializeField]
		private TextMeshProI18n _titleText;

		[SerializeField]
		private TextBlock3DUIView _descriptionText;

		[SerializeField]
		private Transform _achievementTrophyParent;

		[SerializeField]
		private List<GameObject> _collectibleCardVisuals;

		[SerializeField]
		private List<GameObject> _achievementTrophyVisuals;

		private GameObject _trophyInstance;

		private Achievement _currentAchievementPlaying;

		private List<GreenbackRewardData> _currentRewardGroup;

		private List<GameObject> _trophies;

		[SerializeField]
		private GameObject _bronzeFallbackTrophy;

		[SerializeField]
		private GameObject _silverFallbackTrophy;

		[SerializeField]
		private GameObject _goldFallbackTrophy;

		public IEnumerable<Achievement> AllAchievements => null;

		public bool IsAchievementQueuedOrPlaying => false;

		public void Init()
		{
		}

		public void Reset()
		{
		}

		private void PlayerProfile_CurrentProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		private void GameStats_StatChangedGlobal(object sender, EventArgs<(string key, int value)> e)
		{
		}

		private void EvaluateAchievement(string key)
		{
		}

		private void EvaluateAchievement(Achievement achievement)
		{
		}

		public void QueueRewardAchievement(List<GreenbackRewardData> rewardGroup, float delayTime = 2f)
		{
		}

		public bool IsRewardQueued(GreenbackRewardData reward)
		{
			return false;
		}

		public void QueueAchievement(Achievement achievement, float delayTime = 2f)
		{
		}

		private void Update()
		{
		}

		private bool IsAnimating()
		{
			return false;
		}

		public bool IsAchievementPlaying(Achievement achievement)
		{
			return false;
		}

		private void EnableAchievementVisuals()
		{
		}

		private void EnableCollectibleCardVisuals()
		{
		}

		private void PlayAchievement(Achievement data)
		{
		}

		private void PlayRewardAchievement(List<GreenbackRewardData> rewardGroup)
		{
		}

		private void OnAchievementPlayed()
		{
		}

		private string GetTrophyName(string achievementId)
		{
			return null;
		}

		private GameObject GetFallbackTrophy(Achievement data)
		{
			return null;
		}

		private GameObject GetTrophyPrefab(Achievement data)
		{
			return null;
		}

		public Trophy3DUIView GetAchievementTrophy(Achievement data)
		{
			return null;
		}
	}
}
