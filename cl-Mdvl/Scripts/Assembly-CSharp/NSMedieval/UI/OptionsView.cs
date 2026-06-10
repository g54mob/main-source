using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.UI
{
	public class OptionsView : MonoBehaviour
	{
		[SerializeField]
		private SoundButton doneButton;

		private LocalizationController localize;

		private GlobalSettings globalSettings;

		protected LocalizationController Localize => localize ?? (localize = MonoSingleton<LocalizationController>.Instance);

		protected GlobalSettings GlobalSettings => globalSettings ?? (globalSettings = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings);

		private void Awake()
		{
			doneButton.onClick.AddListener(Hide);
		}

		public virtual void Show()
		{
			base.gameObject.SetActive(value: true);
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, base.gameObject);
			}
		}

		public void Hide()
		{
			if (base.gameObject.activeInHierarchy)
			{
				MonoSingleton<GlobalSaveController>.Instance.Serialize();
				base.gameObject.SetActive(value: false);
				if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
				{
					MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Hide, base.gameObject);
				}
			}
		}
	}
}
