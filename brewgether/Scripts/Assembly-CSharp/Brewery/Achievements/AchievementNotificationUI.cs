using UnityEngine;

namespace Brewery.Achievements
{
	public class AchievementNotificationUI : MonoBehaviour
	{
		[Header("Settings")]
		[Tooltip("Duration for achievement notifications")]
		[SerializeField]
		private float unlockNotificationDuration;

		[Tooltip("Duration for near-completion notifications")]
		[SerializeField]
		private float progressNotificationDuration;

		[Tooltip("Show near-completion notifications")]
		[SerializeField]
		private bool showNearCompletionNotifications;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static AchievementNotificationUI Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void SubscribeToEvents()
		{
		}

		private void TrySubscribeLater()
		{
		}

		private void UnsubscribeFromEvents()
		{
		}

		private void HandleAchievementUnlocked(AchievementDefinition achievement)
		{
		}

		private void HandleNearCompletion(AchievementDefinition achievement, float percentage)
		{
		}

		private string GetUnlockTitle(AchievementRarity rarity)
		{
			return null;
		}

		private void Log(string message)
		{
		}
	}
}
