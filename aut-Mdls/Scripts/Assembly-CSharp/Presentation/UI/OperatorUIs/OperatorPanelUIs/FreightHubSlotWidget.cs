using System;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class FreightHubSlotWidget : FreightHubSlotWidgetSimple, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Space]
		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanel;

		[Space]
		[SerializeField]
		private GameObject _buttons;

		[SerializeField]
		private Button _clearButton;

		[SerializeField]
		private Button _passButton;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private TextMeshProUGUI _totalText;

		private Action<int> _onClearPressed;

		private Func<int, bool> _canPassResources;

		private Action<int> _onPassPressed;

		protected override void Awake()
		{
			base.Awake();
			_buttons.SetActive(value: false);
			_clearButton.onClick.AddListener(OnClearButtonClicked);
			if (_passButton != null)
			{
				_passButton.onClick.AddListener(OnPassButtonClicked);
			}
		}

		private void OnDestroy()
		{
			_clearButton.onClick.RemoveListener(OnClearButtonClicked);
			if (_passButton != null)
			{
				_passButton.onClick.RemoveListener(OnPassButtonClicked);
			}
		}

		private void OnEnable()
		{
			_buttons.SetActive(value: false);
		}

		public void Setup(int slotIndex, Action<int> onClearPressed, Func<int, bool> canPassResources = null, Action<int> onPassPressed = null)
		{
			Setup(slotIndex);
			_onClearPressed = onClearPressed;
			_canPassResources = canPassResources;
			_onPassPressed = onPassPressed;
		}

		public void UpdateDisplay(FreightHubBehaviour.FreightHubSlot freightHubSlot, float maxStorage)
		{
			_amountText.SetText($"{freightHubSlot.Amount}");
			_totalText.SetText($"/{maxStorage}");
			if (_passButton != null)
			{
				_passButton.interactable = freightHubSlot.Amount > 0;
			}
			UpdateDisplay(freightHubSlot);
		}

		protected override void SetResourceCanHaveInfoPanel(bool value, NonShapeResourceDataSO resourceData = null)
		{
			_resourceInfoPanel.enabled = value;
			if (value)
			{
				_resourceInfoPanel.UpdateContent(resourceData);
			}
		}

		private void OnClearButtonClicked()
		{
			ModalDialogDto dto = new ModalDialogDto(new ModalDialogContent("FreightHub.DiscardWarning"), Sizes.Xs, HandleClear, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.YesButton",
				OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
			};
			_showModalDialogEvent.Fire(new UIModaldialogData(dto));
		}

		private void HandleClear()
		{
			ClearDisplay();
			_onClearPressed(_slotIndex);
		}

		private void OnPassButtonClicked()
		{
			if (_canPassResources(_slotIndex))
			{
				HandlePass();
				return;
			}
			ModalDialogDto dto = new ModalDialogDto(new ModalDialogContent("FreightHub.PassDiscardWarning"), Sizes.Xs, HandlePass, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.YesButton",
				OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
			};
			_showModalDialogEvent.Fire(new UIModaldialogData(dto));
		}

		private void HandlePass()
		{
			ClearDisplay();
			_onPassPressed(_slotIndex);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_buttons.SetActive(value: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_buttons.SetActive(value: false);
		}
	}
}
