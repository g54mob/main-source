using UnityEngine;

namespace Dorfromantik
{
	public class NintendoSwitchNotificationManager : Singleton<NintendoSwitchNotificationManager>
	{
		[SerializeField]
		private DefaultSettings handheldModeSettings;

		[SerializeField]
		private DefaultSettings dockedModeSettings;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private SessionQuestManager sessionQuestManager;

		[SerializeField]
		private RewardLibrary rewardLibrary;
	}
}
