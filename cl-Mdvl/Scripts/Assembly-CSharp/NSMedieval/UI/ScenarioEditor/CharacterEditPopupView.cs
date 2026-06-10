using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	public class CharacterEditPopupView : UIView
	{
		[SerializeField]
		protected GameObject blur;

		[SerializeField]
		protected SoundButton outClickCloseButton;

		[SerializeField]
		protected GameObject panel;

		[SerializeField]
		protected TMP_Text popupTitle;

		[SerializeField]
		private SoundButton closeButton;

		protected virtual void Start()
		{
			closeButton.onClick.AddListener(Hide);
			outClickCloseButton.onClick.AddListener(Hide);
		}

		protected void SetTitle(string title)
		{
			popupTitle.SetText(title);
		}

		public override void Show()
		{
			panel.SetActive(value: true);
			blur.SetActive(value: true);
			if (!(outClickCloseButton == null))
			{
				outClickCloseButton.gameObject.SetActive(value: true);
				if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
				{
					MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, base.gameObject);
				}
			}
		}

		public override void Hide()
		{
			panel.SetActive(value: false);
			blur.SetActive(value: false);
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Hide, base.gameObject);
			}
			if (!(outClickCloseButton == null))
			{
				outClickCloseButton.gameObject.SetActive(value: false);
			}
		}
	}
}
