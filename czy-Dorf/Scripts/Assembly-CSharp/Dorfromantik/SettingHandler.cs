using UnityEngine;
using UnityEngine.Events;

namespace Dorfromantik
{
	public class SettingHandler : MonoBehaviour
	{
		[SerializeField]
		private SettingType settingType;

		[SerializeField]
		private UnityEvent onSettingEnabled;

		[SerializeField]
		private UnityEvent onSettingDisabled;

		[SerializeField]
		private SettingsRouter settingsRouter;

		private void Start()
		{
			if (settingType == SettingType.HighlightingMatchingEdges)
			{
				settingsRouter.OnHighlightMatchingEdgesChanged += ChangeSetting;
				ChangeSetting(settingsRouter.HighlightingMatchingEdges);
			}
		}

		private void ChangeSetting(bool newValue)
		{
			if (newValue)
			{
				onSettingEnabled?.Invoke();
			}
			else
			{
				onSettingDisabled?.Invoke();
			}
		}

		private void OnDestroy()
		{
			if (settingType == SettingType.HighlightingMatchingEdges)
			{
				settingsRouter.OnHighlightMatchingEdgesChanged -= ChangeSetting;
			}
		}
	}
}
