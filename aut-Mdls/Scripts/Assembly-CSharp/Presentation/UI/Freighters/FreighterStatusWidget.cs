using Data;
using Data.FactoryFloor.Freighter;
using Data.Variables;
using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.GamecontrolMenus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.Freighters
{
	public class FreighterStatusWidget : MonoBehaviour
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		[SerializeField]
		private FreighterNameDisplay _nameDisplay;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _editNameAndColorMenuUILocator;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private FreighterViewsPoolLocator _freighterViewsPoolLocator;

		[SerializeField]
		private EditNameAndColorUIData _editNameAndColorUIData;

		[Space]
		[SerializeField]
		private Button _locateButton;

		[SerializeField]
		private Button _pauseButton;

		[SerializeField]
		private GameObject _pauseButtonIcon;

		[SerializeField]
		private GameObject _resumeButtonIcon;

		[Space]
		[SerializeField]
		private Button _emptyButton;

		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private Button _renameButton;

		private FreighterObject _freighter;

		private void Start()
		{
			_locateButton.onClick.AddListener(LocateButtonClicked);
			_pauseButton.onClick.AddListener(PauseButtonClicked);
			_emptyButton.onClick.AddListener(EmptyButtonClicked);
			_resetButton.onClick.AddListener(DeleteButtonClicked);
			_renameButton.onClick.AddListener(RenameButtonClicked);
			_selectedFreighterInUI.ValueChanged += OnSelectedFreighterChanged;
			OnSelectedFreighterChanged(_selectedFreighterInUI.Value);
		}

		private void OnDestroy()
		{
			_locateButton.onClick.RemoveListener(LocateButtonClicked);
			_pauseButton.onClick.RemoveListener(PauseButtonClicked);
			_emptyButton.onClick.RemoveListener(EmptyButtonClicked);
			_resetButton.onClick.RemoveListener(DeleteButtonClicked);
			_renameButton.onClick.RemoveListener(RenameButtonClicked);
			_selectedFreighterInUI.ValueChanged -= OnSelectedFreighterChanged;
		}

		private void OnSelectedFreighterChanged(int createdId)
		{
			if (_freightersManagerLocator.Manager.TryGetFreighter(createdId, out _freighter))
			{
				_nameDisplay.Populate(_freighter);
				_pauseButtonIcon.SetActive(!_freighter.IsPaused);
				_resumeButtonIcon.SetActive(_freighter.IsPaused);
			}
		}

		private void LocateButtonClicked()
		{
			if (_freighter != null && _freighterViewsPoolLocator.Value.TryGetFreighterView(_freighter.CreatedId, out var freighterView))
			{
				_cameraViewLocator.CameraView.SetFollowTarget(freighterView.transform);
			}
		}

		private void PauseButtonClicked()
		{
			_freighter.SetPaused(!_freighter.IsPaused);
			_pauseButtonIcon.SetActive(!_freighter.IsPaused);
			_resumeButtonIcon.SetActive(_freighter.IsPaused);
		}

		private void EmptyButtonClicked()
		{
			_freighter.EmptySlots();
		}

		private void DeleteButtonClicked()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("FreightersUI.DeleteConfirmation", Sizes.S, DeleteFreighter, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.AcceptButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void DeleteFreighter()
		{
			_freighter.ClearConfiguration();
			_freightersManagerLocator.Manager.DestroyFreighter(_freighter.CreatedId);
			_selectedFreighterInUI.SetValue(-1);
		}

		private void RenameButtonClicked()
		{
			_showUIMenuEvent.Fire(new EditNameAndColorUIMenuData(_editNameAndColorMenuUILocator.UIMenu, _editNameAndColorUIData));
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).UseEditMode(_freighter.Name, _freighter.Color);
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues += HandleNewFreighterNameInput;
		}

		private void HandleNewFreighterNameInput(bool success, string name, Color color)
		{
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues -= HandleNewFreighterNameInput;
			if (success)
			{
				_freighter.SetNewName(name, color);
				_selectedFreighterInUI.SetValue(_selectedFreighterInUI.Value);
			}
		}
	}
}
