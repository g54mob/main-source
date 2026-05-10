using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;

public class ActionListCanvas : CTSBehaviour
{
	[SerializeField]
	private ActionButton _defaultButtonPrefab;

	[SerializeField]
	private ActionButtonConstructor[] _buttons;

	[SerializeField]
	private Transform _buttonsSpawnParent;

	private readonly List<ActionButton> _spawnedButtons = new List<ActionButton>();

	private ActionButton _currentAction;

	protected override void OnAwake()
	{
		base.OnAwake();
		if (!_buttonsSpawnParent)
		{
			_buttonsSpawnParent = base.transform;
		}
		ActionButtonConstructor[] buttons = _buttons;
		foreach (ActionButtonConstructor obj in buttons)
		{
			ActionButton actionButton = CTSFactory.Instantiate(_defaultButtonPrefab, _buttonsSpawnParent, instantiateInWorldSpace: false, false);
			obj.ConstructButton(actionButton);
			_spawnedButtons.Add(actionButton);
			actionButton.gameObject.SetActive(value: true);
		}
	}

	public void QuickPlay(int index)
	{
		if (index.IsCorrectArrayIndex(_spawnedButtons) && base.isActiveAndEnabled)
		{
			GetComponent<CanvasGroupController>().QuickShow();
			_spawnedButtons[index].QuickPlay();
		}
	}

	protected override void OnEnabled()
	{
		base.OnEnabled();
		foreach (ActionButton spawnedButton in _spawnedButtons)
		{
			spawnedButton.Started += OnActionStarted;
		}
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		foreach (ActionButton spawnedButton in _spawnedButtons)
		{
			spawnedButton.Started -= OnActionStarted;
		}
		CancelCurrentAction();
	}

	private void OnActionStarted(ActionButton button)
	{
		CancelCurrentAction();
		_currentAction = button;
		_currentAction.Stopped += OnCurrentActionStopped;
	}

	private void OnCurrentActionStopped(ActionButton button)
	{
		if (!(button != _currentAction))
		{
			DeregisterCurrentAction();
		}
	}

	public bool IsInProgress()
	{
		return (object)_currentAction != null;
	}

	public void CancelCurrentAction()
	{
		if (IsInProgress())
		{
			_currentAction.EndAction();
		}
	}

	private void DeregisterCurrentAction()
	{
		if ((bool)_currentAction)
		{
			_currentAction.Stopped -= OnCurrentActionStopped;
		}
		_currentAction = null;
	}
}
