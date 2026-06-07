using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Variables;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;

namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public class HudPanelTabGroup : MonoBehaviour
	{
		[Serializable]
		private struct ButtonPanelPair
		{
			public TabGroupButton TabButton;

			public TabGroupPanel Panel;

			public TabGroupPanelSO PanelSO;
		}

		[Serializable]
		private struct PanelBehaviourPair
		{
			public TabGroupPanelSO PanelSO;

			public PanelGroupBehaviourEnum Behaviour;
		}

		private enum PanelGroupBehaviourEnum
		{
			HideToggle = 0,
			CollapseOnly = 1,
			CollapseToggle = 2
		}

		[SerializeField]
		private SerializedDictionary<TabGroupPanelSO, ButtonPanelPair> _panels = new SerializedDictionary<TabGroupPanelSO, ButtonPanelPair>();

		[SerializeField]
		private SerializedDictionary<BoolVariableRefSO, List<PanelBehaviourPair>> _behaviours;

		[SerializeField]
		private ShowHudPanelEvent _showHudPanelEvent;

		[SerializeField]
		private GameObject _window;

		[SerializeField]
		private HideHudPanelEvent _hideHudPanelEvent;

		[SerializeField]
		private TabGroupPanelSO _panelToActivateOnStart;

		private List<TabGroupPanelSO> _activePanels = new List<TabGroupPanelSO>();

		private TabGroupPanelSO _currentPanel;

		private AbstractHudPanelData _nextHudPanelData;

		private TabGroupPanelSO _nextPanelSo;

		private void Awake()
		{
			_showHudPanelEvent.Register(ShowWindow);
			_hideHudPanelEvent.Register(ClosePanel);
			foreach (BoolVariableRefSO key in _behaviours.Keys)
			{
				key.ValueChangedWithRef += OnBehaviourChange;
			}
		}

		private void Start()
		{
			foreach (KeyValuePair<TabGroupPanelSO, ButtonPanelPair> panel in _panels)
			{
				panel.Value.Panel.Initialize();
				panel.Value.Panel.HidePanel();
				panel.Value.TabButton.HideButton();
				panel.Value.TabButton.SO = panel.Key;
				TabGroupButton tabButton = panel.Value.TabButton;
				tabButton.OnTabClick = (Action<ScriptableObject>)Delegate.Combine(tabButton.OnTabClick, new Action<ScriptableObject>(TogglePanel));
			}
			if (_panelToActivateOnStart != null)
			{
				ShowWindow(new EmptyHudPanelData(_panelToActivateOnStart, toggle: true));
			}
			else
			{
				_window.SetActive(value: false);
			}
		}

		private void ShowWindow(AbstractHudPanelData hudPanelData)
		{
			if (hudPanelData.Toggle)
			{
				if (!_window.activeSelf)
				{
					_window.SetActive(value: true);
				}
				TogglePanel(hudPanelData.PanelSo);
			}
			else
			{
				_window.SetActive(value: true);
				OpenPanelWithData(hudPanelData);
			}
		}

		private void HideWindow()
		{
			HideCurrentPanel();
			_currentPanel = null;
			_window.SetActive(value: false);
		}

		private void OnDestroy()
		{
			_showHudPanelEvent.UnRegister(ShowWindow);
			_hideHudPanelEvent.UnRegister(ClosePanel);
			foreach (ButtonPanelPair value in _panels.Values)
			{
				TabGroupButton tabButton = value.TabButton;
				tabButton.OnTabClick = (Action<ScriptableObject>)Delegate.Remove(tabButton.OnTabClick, new Action<ScriptableObject>(TogglePanel));
			}
			foreach (BoolVariableRefSO key in _behaviours.Keys)
			{
				key.ValueChangedWithRef -= OnBehaviourChange;
			}
		}

		private void OnBehaviourChange(bool value, BoolVariableRefSO boolVariable)
		{
			List<PanelBehaviourPair> list = _behaviours[boolVariable];
			for (int i = 0; i < list.Count; i++)
			{
				TabGroupPanelSO panelSO = list[i].PanelSO;
				if (!_activePanels.Contains(panelSO))
				{
					continue;
				}
				PanelGroupBehaviourEnum behaviour = list[i].Behaviour;
				ButtonPanelPair buttonPanelPair = _panels[panelSO];
				switch (behaviour)
				{
				case PanelGroupBehaviourEnum.HideToggle:
					if (value)
					{
						buttonPanelPair.TabButton.Cancel();
						buttonPanelPair.TabButton.HideButton();
						buttonPanelPair.Panel.HidePanel();
						break;
					}
					buttonPanelPair.TabButton.ShowButton();
					if (_currentPanel == panelSO)
					{
						buttonPanelPair.Panel.ShowPanel();
					}
					break;
				case PanelGroupBehaviourEnum.CollapseOnly:
					if (value)
					{
						if (_currentPanel == buttonPanelPair.PanelSO)
						{
							_currentPanel = null;
						}
						buttonPanelPair.TabButton.Cancel();
						HidePanel(buttonPanelPair.PanelSO);
					}
					break;
				case PanelGroupBehaviourEnum.CollapseToggle:
					buttonPanelPair.TabButton.Cancel();
					TogglePanel(buttonPanelPair.PanelSO);
					break;
				}
			}
		}

		private void TogglePanel(ScriptableObject tabgroupSo)
		{
			if (tabgroupSo == _currentPanel)
			{
				TryCanHideCurrentPanel(ResetCurrentPanel);
				return;
			}
			_nextPanelSo = tabgroupSo as TabGroupPanelSO;
			if (_currentPanel == null)
			{
				ShowCurrentPanel();
			}
			else
			{
				TryCanHideCurrentPanel(ShowCurrentPanel);
			}
		}

		private void ResetCurrentPanel()
		{
			HideCurrentPanel();
			_currentPanel = null;
		}

		private void ShowCurrentPanel()
		{
			HideCurrentPanel();
			_currentPanel = _nextPanelSo;
			if (!_activePanels.Contains(_currentPanel))
			{
				_activePanels.Add(_currentPanel);
			}
			_panels[_currentPanel].TabButton.ShowButton();
			_panels[_currentPanel].TabButton.ActiveState = true;
			_panels[_currentPanel].Panel.ShowPanel();
		}

		private void OpenPanelWithData(AbstractHudPanelData hudPanelData)
		{
			_nextHudPanelData = hudPanelData;
			TryCanHideCurrentPanel(OpenPanelWithNextPanelData);
		}

		private void OpenPanelWithNextPanelData()
		{
			if (_nextHudPanelData.PanelSo != _currentPanel)
			{
				HideCurrentPanel();
				_currentPanel = _nextHudPanelData.PanelSo;
				if (!_activePanels.Contains(_currentPanel))
				{
					_activePanels.Add(_currentPanel);
				}
				_panels[_currentPanel].TabButton.ShowButton();
				_panels[_currentPanel].TabButton.ActiveState = true;
			}
			_panels[_currentPanel].Panel.ShowPanel(_nextHudPanelData);
		}

		private bool TryCanHideCurrentPanel(Action successsMethod = null)
		{
			if (_currentPanel == null)
			{
				successsMethod();
				return false;
			}
			return _panels[_currentPanel].TabButton.TryCanClose(successsMethod);
		}

		private void HideCurrentPanel()
		{
			if (!(_currentPanel == null))
			{
				_panels[_currentPanel].TabButton.ActiveState = false;
				_panels[_currentPanel].Panel.HidePanel();
			}
		}

		private void HidePanel(TabGroupPanelSO panelSo)
		{
			_panels[panelSo].TabButton.ActiveState = false;
			_panels[panelSo].Panel.HidePanel();
		}

		private void ClosePanel(TabGroupPanelSO tabGroupPanelSo)
		{
			if (tabGroupPanelSo != null)
			{
				_panels[tabGroupPanelSo].TabButton.HideButton();
				_panels[tabGroupPanelSo].TabButton.ActiveState = false;
				_panels[tabGroupPanelSo].Panel.HidePanel();
			}
			_activePanels.Remove(tabGroupPanelSo);
			if (_activePanels.Count == 0)
			{
				_currentPanel = null;
			}
			else if (_currentPanel != null && !_panels[_currentPanel].TabButton.ActiveState)
			{
				TogglePanel(_activePanels[0]);
			}
		}
	}
}
