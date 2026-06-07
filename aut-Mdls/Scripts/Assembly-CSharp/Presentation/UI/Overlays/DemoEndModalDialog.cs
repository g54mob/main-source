using DG.Tweening;
using Events;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays
{
	public class DemoEndModalDialog : UIModalDialog
	{
		[SerializeField]
		private Button _bgButton;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private Button _successButton;

		[SerializeField]
		private BaseEvent _closedModalDialogEvent;

		private void Awake()
		{
			_successButton.onClick.AddListener(OnSuccessButtonClicked);
			_bgButton.onClick.AddListener(OnPanelPressed);
			base.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			_bgButton.onClick.RemoveListener(OnPanelPressed);
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
		}

		public override void ShowModal(AbstractUIModalDialogData menuData)
		{
			base.gameObject.SetActive(value: true);
		}

		public override void HideModal()
		{
			_closedModalDialogEvent.Fire();
			base.gameObject.SetActive(value: false);
		}

		private void OnSuccessButtonClicked()
		{
			_uiMenuManagerLocator.UIMenuManager.GoBackModal();
		}

		public override bool TryCanCancel()
		{
			return false;
		}

		private void OnPanelPressed()
		{
			if (_successButton.interactable)
			{
				RectTransform obj = _successButton.transform as RectTransform;
				obj.DOKill();
				obj.localScale = Vector3.one;
				obj.DOPunchScale(Vector2.one * 0.3f, 0.2f, 4);
			}
		}
	}
}
