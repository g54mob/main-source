using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.Events;

public class ConstructionModeChanged : CTSBehaviour
{
	[SerializeField]
	private UnityEvent _disabled;

	[SerializeField]
	private UnityEvent _interior;

	[SerializeField]
	private UnityEvent _assignation;

	[SerializeField]
	private UnityEvent _destruction;

	private EConstructionMode _currentMode;

	protected override void OnEnabled()
	{
		base.OnEnabled();
		ConstructionSystem.OnConstructionModeChanged += OnConstructionModeChanged;
		OnConstructionModeChanged();
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		ConstructionSystem.OnConstructionModeChanged -= OnConstructionModeChanged;
	}

	private void OnConstructionModeChanged()
	{
		if (_currentMode != MonoSingleton<ConstructionSystem>.Instance.CurrentMode)
		{
			_currentMode = MonoSingleton<ConstructionSystem>.Instance.CurrentMode;
			switch (_currentMode)
			{
			case EConstructionMode.None:
				_disabled.Invoke();
				break;
			case EConstructionMode.Destruction:
				_destruction.Invoke();
				break;
			case EConstructionMode.Construction:
				_interior.Invoke();
				break;
			case EConstructionMode.Assingation:
				_assignation.Invoke();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
