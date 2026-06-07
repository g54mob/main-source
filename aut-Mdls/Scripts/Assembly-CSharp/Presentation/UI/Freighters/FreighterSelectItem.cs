using System.Collections.Generic;
using Data.FactoryFloor.Freighter;
using Data.Variables;
using Presentation.Locators;
using Presentation.UI.Menus.HudPanelTabGroups;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.Freighters
{
	public class FreighterSelectItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private FreighterNameDisplay _nameDisplay;

		[SerializeField]
		private Button _selectButton;

		[SerializeField]
		private Button _locateButton;

		[SerializeField]
		private GameObject _selectedContainer;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		[SerializeField]
		private GameObject _errorSymbol;

		[SerializeField]
		private FreighterViewsPoolLocator _freighterViewsPoolLocator;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private List<FreighterInventorySlotDisplay> _inventorySlots;

		[SerializeField]
		protected ShowHudPanelEvent _showHudPanelEvent;

		[SerializeField]
		protected TabGroupPanelSO _tabGroupPanelSo;

		private bool _initialized;

		private FreighterObject _freighter;

		public void Initalize(FreighterObject freighter)
		{
			_freighter = freighter;
			OnSelectedFreighterChanged(freighter.CreatedId);
			_nameDisplay.Populate(_freighter);
			_errorSymbol.SetActive(_freighter.Path.HasInvalidStop());
			_initialized = true;
		}

		private void OnEnable()
		{
			if (_initialized)
			{
				_errorSymbol.SetActive(_freighter.Path.HasInvalidStop());
			}
		}

		private void Start()
		{
			_selectButton.onClick.AddListener(SelectButton);
			_locateButton.onClick.AddListener(LocateButtonClicked);
		}

		private void OnDestroy()
		{
			_selectButton.onClick.RemoveListener(SelectButton);
			_locateButton.onClick.RemoveListener(LocateButtonClicked);
		}

		private void OnSelectedFreighterChanged(int createdId)
		{
			if (!_initialized)
			{
				return;
			}
			_errorSymbol.SetActive(_freighter.Path.HasInvalidStop());
			foreach (FreighterInventorySlotDisplay inventorySlot in _inventorySlots)
			{
				inventorySlot.SelectFreighter(_freighter);
			}
		}

		private void SelectButton()
		{
			_selectedContainer.SetActive(value: false);
			if (_showHudPanelEvent != null)
			{
				_showHudPanelEvent.Fire(new EmptyHudPanelData(_tabGroupPanelSo));
			}
			_selectedFreighterInUI.SetValue(_freighter.CreatedId);
		}

		private void LocateButtonClicked()
		{
			if (_freighter != null && _freighterViewsPoolLocator.Value.TryGetFreighterView(_freighter.CreatedId, out var freighterView))
			{
				_cameraViewLocator.CameraView.SetFollowTarget(freighterView.transform);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_selectedContainer.SetActive(value: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_selectedContainer.SetActive(value: false);
		}
	}
}
