using System.Collections.Generic;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Presentation.Locators;
using UnityEngine;

public class SupportersEditionActivator : MonoBehaviour
{
	[SerializeField]
	private BaseEvent _finishedLoadingSaveEvent;

	[SerializeField]
	private IntegrationManagerLocator _intergrationManagerLocator;

	[SerializeField]
	private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

	[SerializeField]
	private List<FactoryObjectData> _supportersFactoryObjectsToUnlock;

	[SerializeField]
	private BoolVariableSO _tutorialSupportersEditionDecorationsIsLocked;

	private bool _isFinishedLoading;

	private void Awake()
	{
		_finishedLoadingSaveEvent.Register(UpdateLockedSupportersEditionFactoryObjectLocks);
		_tutorialSupportersEditionDecorationsIsLocked.ValueChanged += OnIsLockedChanged;
	}

	private void OnDestroy()
	{
		_finishedLoadingSaveEvent.UnRegister(UpdateLockedSupportersEditionFactoryObjectLocks);
		_tutorialSupportersEditionDecorationsIsLocked.ValueChanged -= OnIsLockedChanged;
	}

	private void UpdateLockedSupportersEditionFactoryObjectLocks()
	{
		if (_intergrationManagerLocator.Integration.IsSupportersEdition() && !_tutorialSupportersEditionDecorationsIsLocked.Value)
		{
			foreach (FactoryObjectData item in _supportersFactoryObjectsToUnlock)
			{
				_lockedFactoryObjectsPersistentSO.UnlockObject(item);
			}
		}
		else
		{
			foreach (FactoryObjectData item2 in _supportersFactoryObjectsToUnlock)
			{
				_lockedFactoryObjectsPersistentSO.Lock(item2);
			}
		}
		_isFinishedLoading = true;
	}

	private void OnIsLockedChanged(bool isLocked)
	{
		if (_isFinishedLoading)
		{
			UpdateLockedSupportersEditionFactoryObjectLocks();
		}
	}
}
