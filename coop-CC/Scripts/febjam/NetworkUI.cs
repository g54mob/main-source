using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NetworkUI : EntityBehaviourBase
{
	public GameObject container;

	public GameObject playerTemplate;

	[Space]
	public Selectable exitSelectable;

	private List<PoolableReference<NetworkPlayerUI>> _uis = new List<PoolableReference<NetworkPlayerUI>>();

	private List<Selectable> _selectables = new List<Selectable>();

	private static List<NetworkPlayerManager.PlayerStats> _playerStats = new List<NetworkPlayerManager.PlayerStats>();

	protected override void OnEntityCreated()
	{
		playerTemplate.PopulateForTemplatePool(3);
		playerTemplate.SetActive(value: false);
	}

	protected override void OnUpdatePresentation()
	{
		_playerStats.Clear();
		NetworkAggroManagerBase<NetworkPlayerManager>.instance.PopulatePlayerStats(_playerStats);
		string text = null;
		int x = 0;
		if (AggroInputManager.mode == InputMode.Gamepad && EventSystem.current.currentSelectedGameObject != null)
		{
			for (int i = 0; i < _uis.Count; i++)
			{
				if (EventSystem.current.currentSelectedGameObject == _uis[i].component.GetSelectable().gameObject)
				{
					text = _uis[i].component.voiceName;
					x = i;
					break;
				}
			}
		}
		if (_playerStats.Count != _uis.Count)
		{
			_uis.ReleaseToPool();
			_uis.Clear();
			for (int j = 0; j < _playerStats.Count; j++)
			{
				PoolableReference<NetworkPlayerUI> fromTemplatePool = playerTemplate.GetFromTemplatePool<NetworkPlayerUI>();
				_uis.Add(fromTemplatePool);
			}
		}
		if (_uis.Count > 0)
		{
			container.SetActive(value: true);
			for (int k = 0; k < _playerStats.Count; k++)
			{
				_uis[k].component.Sync(_playerStats[k]);
			}
			_selectables.Clear();
			Selectable selectable = null;
			for (int l = 0; l < _uis.Count; l++)
			{
				NetworkPlayerUI component = _uis[l].component;
				if (text != null && text == component.voiceName)
				{
					selectable = component.GetSelectable();
					_selectables.Add(component.GetSelectable());
				}
				else if (component.IsSelectable())
				{
					_selectables.Add(component.GetSelectable());
				}
			}
			SetNavigation();
			if (selectable != null)
			{
				EventSystem.current.SetSelectedGameObject(selectable.gameObject);
			}
			else if (text != null)
			{
				int index = math.min(x, _selectables.Count - 1);
				EventSystem.current.SetSelectedGameObject(_selectables[index].gameObject);
			}
		}
		else
		{
			container.SetActive(value: false);
			SetNavigation();
			if (text != null)
			{
				EventSystem.current.SetSelectedGameObject(exitSelectable.gameObject);
			}
		}
	}

	private void SetNavigation()
	{
		Navigation navigation = exitSelectable.navigation;
		if (navigation.mode != Navigation.Mode.Explicit)
		{
			navigation = default(Navigation);
		}
		if (_selectables.Count > 0)
		{
			UIUtil.SetNavigation(exitSelectable, navigation.selectOnLeft, _selectables[_selectables.Count - 1], navigation.selectOnRight, navigation.selectOnDown);
			UIUtil.SetVerticalSelectables(_selectables, null, null, null, exitSelectable);
		}
		else
		{
			UIUtil.SetNavigation(exitSelectable, navigation.selectOnLeft, null, navigation.selectOnRight, navigation.selectOnDown);
		}
	}
}
