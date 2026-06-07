using System.Collections.Generic;
using Data.Variables;
using Events;
using Events.Generic;
using Events.UI.Overlays;
using NaughtyAttributes;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using Presentation.UI.Overlays;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Presentation.UI.Menus
{
	public class UIMenuManager : MonoBehaviour
	{
		[SerializeField]
		private UIMenuManagerLocator _managerLocator;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private InputActionReference _escapeAction;

		[SerializeField]
		private InputActionReference _toggleAllUIAction;

		[SerializeField]
		private BaseEvent _hideHUDUIEvent;

		[SerializeField]
		private BaseEvent _showHUDUIEvent;

		[SerializeField]
		private BoolVariableSO _HUDUIIsHidden;

		[SerializeField]
		private BaseEvent _hideTopHUDUIEvent;

		[SerializeField]
		private BaseEvent _showTopHUDUIEvent;

		[SerializeField]
		private BoolVariableSO _TopHUDUIIsHidden;

		[SerializeField]
		private BoolVariableSO _factoryFloorActionsEnabled;

		[SerializeField]
		private GoBackSourceSO _uiMenuManagerGoBackSource;

		[SerializeField]
		private UIMenu _pauseMenu;

		[SerializeField]
		private BaseEvent _openOperatorUIEvent;

		[SerializeField]
		private BaseEvent _closeOperatorUIEvent;

		[SerializeField]
		private BoolEvent _uiMenuStackEmptyChangedEvent;

		[SerializeField]
		private BoolVariableSO _operatorUIIsOpen;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[SerializeField]
		private UIMenuLocator _pauseMenuLocator;

		[SerializeField]
		private UIModalLocator _modalLocator;

		[SerializeField]
		private UIMenuModalLocator _menuModalLocator;

		[Header("Show / Hide Events")]
		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private ShowUIMenuEvent _willShowUIMenuEvent;

		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private HideUIMenuEvent _hideUIMenuEvent;

		[Header("Audio")]
		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private BoolVariableSO _uiVisibility;

		[SerializeField]
		[EnumFlags]
		private AbstractUIMenuData.ToggleTypes _pauseMenuUIToggles;

		private readonly Stack<AbstractUIMenuData> _openMenusStack = new Stack<AbstractUIMenuData>();

		private readonly Stack<AbstractUIModalDialogData> _openFactoryModalsStack = new Stack<AbstractUIModalDialogData>();

		private readonly Stack<AbstractUIModalDialogData> _openPageModalsStack = new Stack<AbstractUIModalDialogData>();

		private readonly Stack<AbstractUIModalDialogData> _openMenuModalsStack = new Stack<AbstractUIModalDialogData>();

		private readonly Dictionary<AbstractUIMenuData.UIDomain, Stack<AbstractUIModalDialogData>> _openModals = new Dictionary<AbstractUIMenuData.UIDomain, Stack<AbstractUIModalDialogData>>();

		private InputActionMap _factoryFloorActionMap;

		private InputActionMap _uiActionMap;

		private AbstractUIMenuData.UIDomain _currentDomain;

		private void Awake()
		{
			_openModals.Add(AbstractUIMenuData.UIDomain.Factory, _openFactoryModalsStack);
			_openModals.Add(AbstractUIMenuData.UIDomain.Page, _openPageModalsStack);
			_openModals.Add(AbstractUIMenuData.UIDomain.Menu, _openMenuModalsStack);
			_managerLocator.SetUIMenuManager(this);
			_showUIMenuEvent.Register(ShowMenu);
			_showModalDialogEvent.Register(ShowModal);
			_showMenuModalDialogEvent.Register(ShowModal);
			_closeOperatorUIEvent.Register(OperatorUIClosed);
			_escapeAction.action.performed += HandleEscapeAction;
			_toggleAllUIAction.action.performed += ToggleAllUIAction;
			_factoryFloorActionMap = _inputActionAsset.FindActionMap("FactoryFloor");
			_uiActionMap = _inputActionAsset.FindActionMap("UI");
			_factoryFloorActionMap.Enable();
			_uiActionMap.Enable();
			ShowHUD(toggle: true);
			ShowTopHUD(toggle: true);
		}

		private void OnDestroy()
		{
			_showUIMenuEvent.UnRegister(ShowMenu);
			_showModalDialogEvent.UnRegister(ShowModal);
			_showMenuModalDialogEvent.UnRegister(ShowModal);
			_closeOperatorUIEvent.UnRegister(OperatorUIClosed);
			_escapeAction.action.performed -= HandleEscapeAction;
			_toggleAllUIAction.action.performed -= ToggleAllUIAction;
		}

		private void OperatorUIClosed()
		{
			_operatorUIIsOpen.SetValue(value: false);
		}

		private void ShowMenu(AbstractUIMenuData menuData)
		{
			if (menuData != null)
			{
				if (_openModals[_currentDomain].TryPeek(out var result))
				{
					GetModal(result).HideModal();
				}
				_currentDomain = menuData.Domain;
				AbstractUIMenuData result2;
				if (_pauseMenu != null && menuData.UIMenu == _pauseMenu)
				{
					CloseAllMenusAndFactoryModalsForThePauseMenu();
				}
				else if (_openMenusStack.TryPeek(out result2))
				{
					_hideUIMenuEvent.Fire(result2);
					result2.UIMenu.HideMenu();
				}
				_willShowUIMenuEvent.Fire(menuData);
				_openMenusStack.Push(menuData);
				_audioManagerLocator?.AudioManager.PlayOpenUI();
				ToggleSettings(menuData);
				menuData.UIMenu.ShowMenu(menuData);
				_uiMenuStackEmptyChangedEvent.Fire(data: false);
			}
		}

		private void CloseAllMenusAndFactoryModalsForThePauseMenu()
		{
			foreach (AbstractUIMenuData item in _openMenusStack)
			{
				_hideUIMenuEvent.Fire(item);
				item.UIMenu.HideMenu();
			}
			_openMenusStack.Clear();
			for (int num = _openModals[AbstractUIMenuData.UIDomain.Factory].Count - 1; num >= 0; num--)
			{
				AbstractUIModalDialogData abstractUIModalDialogData = _openModals[AbstractUIMenuData.UIDomain.Factory].Peek();
				if (abstractUIModalDialogData != null && ((abstractUIModalDialogData is UIMenuModalDialogData uIMenuModalDialogData && uIMenuModalDialogData.Dto.ShowCancelButton) || (abstractUIModalDialogData is UIModaldialogData uIModaldialogData && uIModaldialogData.Dto.ShowCancelButton)))
				{
					GetModal(abstractUIModalDialogData).HideModal();
					_openModals[AbstractUIMenuData.UIDomain.Factory].Pop();
				}
			}
		}

		private void ShowModal(AbstractUIModalDialogData modalData)
		{
			if (modalData != null)
			{
				if (_openModals[_currentDomain].TryPeek(out var result))
				{
					GetModal(result).HideModal();
				}
				_openModals[_currentDomain].Push(modalData);
				_audioManagerLocator?.AudioManager.PlayOpenModal();
				GetModal(modalData).ShowModal(modalData);
				ToggleFactoryFloorActionMap(toggle: false);
				ToggleUIActionMap(toggle: false);
			}
		}

		private UIModalDialog GetModal(AbstractUIModalDialogData modalData)
		{
			if (modalData is UIMenuModalDialogData)
			{
				return _menuModalLocator.Value;
			}
			if (modalData is UIModaldialogData)
			{
				return _modalLocator.Value;
			}
			return modalData.UIModal;
		}

		private void ToggleSettings(AbstractUIMenuData menuData, bool inverse = false)
		{
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.HideHUD))
			{
				ShowHUD(inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.ShowHUD))
			{
				ShowHUD(!inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.EnableFactoryActions))
			{
				ToggleFactoryFloorActionMap(!inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.DisableFactoryActions))
			{
				ToggleFactoryFloorActionMap(inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.ShowOperatorView))
			{
				ShowOperatorView(!inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.HideOperatorView))
			{
				ShowOperatorView(inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.HideTopHUD))
			{
				ShowTopHUD(inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.ShowTopHUD))
			{
				ShowTopHUD(!inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.EnableUIActions))
			{
				ToggleUIActionMap(!inverse);
			}
			if (menuData.Toggles.HasFlag(AbstractUIMenuData.ToggleTypes.DisableUIActions))
			{
				ToggleUIActionMap(inverse);
			}
		}

		private void ShowOperatorView(bool toggle)
		{
			if (toggle)
			{
				if (!_operatorUIIsOpen.Value)
				{
					_openOperatorUIEvent.Fire();
				}
			}
			else if (_operatorUIIsOpen.Value)
			{
				_closeOperatorUIEvent.Fire();
			}
			_operatorUIIsOpen.SetValue(toggle);
		}

		private void ShowHUD(bool toggle)
		{
			if (toggle)
			{
				if (_HUDUIIsHidden.Value)
				{
					_HUDUIIsHidden.SetValue(value: false);
					_showHUDUIEvent.Fire();
				}
			}
			else if (!_HUDUIIsHidden.Value)
			{
				_HUDUIIsHidden.SetValue(value: true);
				_hideHUDUIEvent.Fire();
			}
		}

		private void ShowTopHUD(bool toggle)
		{
			if (toggle)
			{
				if (_TopHUDUIIsHidden.Value)
				{
					_TopHUDUIIsHidden.SetValue(value: false);
					_showTopHUDUIEvent.Fire();
				}
			}
			else if (!_TopHUDUIIsHidden.Value)
			{
				_TopHUDUIIsHidden.SetValue(value: true);
				_hideTopHUDUIEvent.Fire();
			}
		}

		public void GoBack(GoBackSourceSO source = null)
		{
			if (_openMenusStack == null)
			{
				return;
			}
			if (_openMenusStack.TryPeek(out var result))
			{
				if (result.IgnoredSources.Contains(source))
				{
					return;
				}
				AbstractUIMenuData abstractUIMenuData = _openMenusStack.Pop();
				if (abstractUIMenuData != null && abstractUIMenuData.UIMenu != null)
				{
					_audioManagerLocator?.AudioManager.PlayCloseUI();
					_hideUIMenuEvent.Fire(abstractUIMenuData);
					abstractUIMenuData.UIMenu.HideMenu();
					ToggleSettings(abstractUIMenuData, inverse: true);
				}
			}
			Stack<AbstractUIModalDialogData> stack = new Stack<AbstractUIModalDialogData>();
			for (int i = 0; i < _openModals[_currentDomain].Count; i++)
			{
				stack.Push(_openModals[_currentDomain].Pop());
			}
			if (_openMenusStack.TryPeek(out var result2))
			{
				result2.UIMenu.ShowMenu(result2);
				ToggleSettings(result2);
				_currentDomain = result2.Domain;
			}
			else
			{
				_currentDomain = AbstractUIMenuData.UIDomain.Factory;
			}
			for (int j = 0; j < stack.Count; j++)
			{
				_openModals[_currentDomain].Push(stack.Pop());
			}
			if (_openModals[_currentDomain].TryPeek(out var result3))
			{
				GetModal(result3).ShowModal(result3);
				ToggleFactoryFloorActionMap(toggle: false);
				ToggleUIActionMap(toggle: false);
			}
			_uiMenuStackEmptyChangedEvent.Fire(!IsCurrentlyShowingAnything());
		}

		public void GoBackModal()
		{
			if (_openModals[_currentDomain] == null)
			{
				return;
			}
			if (_openModals[_currentDomain].TryPeek(out var result))
			{
				_openModals[_currentDomain].Pop();
				if (result != null)
				{
					_audioManagerLocator.AudioManager.PlayCloseUI();
					GetModal(result).HideModal();
					ToggleFactoryFloorActionMap(toggle: true);
					ToggleUIActionMap(toggle: true);
					if (_openMenusStack.TryPeek(out var result2))
					{
						ToggleSettings(result2);
					}
				}
			}
			if (_openModals[_currentDomain].TryPeek(out var result3))
			{
				GetModal(result3).ShowModal(result3);
				ToggleFactoryFloorActionMap(toggle: false);
				ToggleUIActionMap(toggle: false);
			}
		}

		public void GoBack(int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				GoBack(_uiMenuManagerGoBackSource);
			}
		}

		public void CloseAllOpenMenus()
		{
			foreach (Stack<AbstractUIModalDialogData> value in _openModals.Values)
			{
				for (int num = value.Count - 1; num >= 0; num--)
				{
					if (value.TryPeek(out var result))
					{
						GetModal(result).HideModal();
						value.Pop();
					}
				}
			}
			for (int num2 = _openMenusStack.Count - 1; num2 >= 0; num2--)
			{
				if (_openMenusStack.TryPeek(out var result2))
				{
					_hideUIMenuEvent.Fire(result2);
					result2.UIMenu.HideMenu();
					_openMenusStack.Pop();
				}
			}
			if (_operatorUIIsOpen.Value)
			{
				_closeOperatorUIEvent.Fire();
				_operatorUIIsOpen.SetValue(value: false);
			}
			if (_HUDUIIsHidden.Value)
			{
				_showHUDUIEvent.Fire();
				_HUDUIIsHidden.SetValue(value: false);
			}
			if (_TopHUDUIIsHidden.Value)
			{
				_showTopHUDUIEvent.Fire();
				_TopHUDUIIsHidden.SetValue(value: false);
			}
			ToggleFactoryFloorActionMap(toggle: true);
			ToggleUIActionMap(toggle: true);
			_uiMenuStackEmptyChangedEvent.Fire(!IsCurrentlyShowingAnything());
		}

		private void HandleEscapeAction(InputAction.CallbackContext obj)
		{
			if (!_uiVisibility.Value)
			{
				_uiVisibility.SetValue(value: true);
			}
			else if (_currentDomain == AbstractUIMenuData.UIDomain.Factory && _openModals[AbstractUIMenuData.UIDomain.Factory].Count == 0 && _openMenusStack.Count == 0 && _toolSystemLocator.ToolSystem != null && _toolSystemLocator.ToolSystem.OpenToolSelected && _pauseMenuLocator != null)
			{
				_showUIMenuEvent.Fire(new UIMenuMenuData(_pauseMenuLocator.UIMenu, _pauseMenuUIToggles));
			}
			else if (_openModals[_currentDomain].Count > 0)
			{
				if (_openModals[_currentDomain].TryPeek(out var result) && GetModal(result).TryCanCancel())
				{
					GoBackModal();
				}
			}
			else
			{
				GoBack(_uiMenuManagerGoBackSource);
			}
		}

		private void ToggleFactoryFloorActionMap(bool toggle)
		{
			if (toggle)
			{
				_factoryFloorActionMap.Enable();
			}
			else
			{
				_factoryFloorActionMap.Disable();
			}
			_factoryFloorActionsEnabled.SetValue(toggle);
		}

		private void ToggleUIActionMap(bool toggle)
		{
			if (toggle)
			{
				_uiActionMap.Enable();
			}
			else
			{
				_uiActionMap.Disable();
			}
		}

		public bool IsFactoryFloorActive()
		{
			if (!_HUDUIIsHidden)
			{
				return !_TopHUDUIIsHidden;
			}
			return false;
		}

		public bool IsCurrentlyShowing(UIMenu uiMenu)
		{
			if (_openMenusStack.TryPeek(out var result))
			{
				return result.UIMenu == uiMenu;
			}
			return false;
		}

		public bool IsCurrentlyShowingAnything()
		{
			return _openMenusStack.Count != 0;
		}

		public bool IsCurrentlyShowingAnyMenuOrModal()
		{
			if (_openMenusStack.Count == 0)
			{
				return _openPageModalsStack.Count != 0;
			}
			return true;
		}

		public bool IsCurrentlyShowingOnlyFactoryPanels()
		{
			foreach (AbstractUIMenuData item in _openMenusStack)
			{
				if (!(item.UIMenu is FactoryPanelUIMenu))
				{
					return false;
				}
			}
			return true;
		}

		private void ToggleAllUIAction(InputAction.CallbackContext obj)
		{
			if (!(EventSystem.current.currentSelectedGameObject != null))
			{
				_uiVisibility.SetValue(!_uiVisibility.Value);
			}
		}
	}
}
