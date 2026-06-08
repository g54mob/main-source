using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class UiSteamChinaVisibility : MonoBehaviour
	{
		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		[FormerlySerializedAs("shouldShow")]
		private bool shouldShowInSteamChinaVersion;

		private void Awake()
		{
			SetupVisibility();
		}

		private void SetupVisibility()
		{
			bool flag = (settingsRouter.defaultSettings.isSteamChinaVersion ? shouldShowInSteamChinaVersion : (!shouldShowInSteamChinaVersion));
			HideableUi component = GetComponent<HideableUi>();
			if ((bool)component)
			{
				if (!flag || component.IsShown)
				{
					component.Show(flag, shouldAnimate: false);
				}
				if (!flag)
				{
					component.Lock(shouldLock: true, HideableUi.LockType.LockedForever);
				}
			}
			else
			{
				base.gameObject.SetActive(flag);
			}
		}
	}
}
