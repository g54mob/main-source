using System;
using System.Collections.Generic;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Logic.FactoryTools;
using UnityEngine;

public class BreadcrumbsAddManager : MonoBehaviour
{
	[SerializeField]
	private BreadcrumbsPersistentSO _breadcrumbsPersistentSO;

	[SerializeField]
	private BreadcrumbStateSO _isNewBreadcrumbState;

	[SerializeField]
	private BaseEvent _finishedLoadingSaveEvent;

	[SerializeField]
	private ZenModeVariableSO _zenMode;

	[Header("Factory Objects")]
	[SerializeField]
	private LockedFactoryObjectsUpdatedEventSO _lockedFactoryObjectsUpdatedEvent;

	[SerializeField]
	private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

	[Header("Tools")]
	[SerializeField]
	private LockedFactoryToolsUpdatedEventSO _lockedFactoryToolsUpdatedEvent;

	[SerializeField]
	private LockedFactoryToolsPersistentSO _lockedFactoryToolsPersistentSO;

	[SerializeField]
	private List<FactoryTool> _ignoreTools = new List<FactoryTool>();

	[Header("Menus")]
	[SerializeField]
	private UnlockedMenusPersistentSO _unlockedMenusPersistentSO;

	[SerializeField]
	private Action<bool>[] _unlockedMenuDelegates;

	private bool _isInitalized;

	private void Start()
	{
		_finishedLoadingSaveEvent.Register(OnSaveLoaded);
	}

	private void OnSaveLoaded()
	{
		_finishedLoadingSaveEvent.UnRegister(OnSaveLoaded);
		if (_zenMode.Value)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		_lockedFactoryObjectsUpdatedEvent.Register(OnLockedFactoryObjectUpdated);
		_lockedFactoryToolsUpdatedEvent.Register(OnLockedToolsUpdated);
		_unlockedMenuDelegates = new Action<bool>[_unlockedMenusPersistentSO.UnlockedMenusVariables.Count];
		for (int i = 0; i < _unlockedMenusPersistentSO.UnlockedMenusVariables.Count; i++)
		{
			BoolVariableSO unlockedMenu = _unlockedMenusPersistentSO.UnlockedMenusVariables[i];
			_unlockedMenuDelegates[i] = delegate(bool inUnlocked)
			{
				OnMenuUnlocked(unlockedMenu, inUnlocked);
			};
			unlockedMenu.ValueChanged += _unlockedMenuDelegates[i];
		}
		_isInitalized = true;
	}

	private void OnDestroy()
	{
		if (_isInitalized)
		{
			_isInitalized = false;
			_finishedLoadingSaveEvent.UnRegister(OnSaveLoaded);
			_lockedFactoryObjectsUpdatedEvent.UnRegister(OnLockedFactoryObjectUpdated);
			_lockedFactoryToolsUpdatedEvent.UnRegister(OnLockedToolsUpdated);
			for (int i = 0; i < _unlockedMenusPersistentSO.UnlockedMenusVariables.Count; i++)
			{
				_unlockedMenusPersistentSO.UnlockedMenusVariables[i].ValueChanged -= _unlockedMenuDelegates[i];
			}
			_unlockedMenuDelegates = null;
		}
	}

	private void OnLockedFactoryObjectUpdated(FactoryObjectData data)
	{
		if (!_lockedFactoryObjectsPersistentSO.IsFactoryObjectLocked(data) && !string.IsNullOrEmpty(data.BreadcrumbId))
		{
			_breadcrumbsPersistentSO.AddBreadcrumbState(_isNewBreadcrumbState, data.BreadcrumbId);
		}
	}

	private void OnLockedToolsUpdated(FactoryTool tool)
	{
		if (!_lockedFactoryToolsPersistentSO.IsFactoryToolLocked(tool) && !string.IsNullOrEmpty(tool.BreadcrumbId) && !_ignoreTools.Contains(tool))
		{
			_breadcrumbsPersistentSO.AddBreadcrumbState(_isNewBreadcrumbState, tool.BreadcrumbId);
		}
	}

	private void OnMenuUnlocked(BoolVariableSO boolVariable, bool isUnlocked)
	{
		if (isUnlocked)
		{
			_breadcrumbsPersistentSO.AddBreadcrumbState(_isNewBreadcrumbState, BreadcrumbUtilities.UnlockedMenuBreadcrumbId(boolVariable));
		}
	}
}
