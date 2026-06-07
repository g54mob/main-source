using UnityEngine;

public abstract class CancelTriggerBase : SceneBehaviour, ICancelable
{
	[SerializeField]
	private InputFlags _activeInputs = InputFlags.All;

	private bool _push;

	private void OnEnable()
	{
		if (FlotsamInputManager.GetUICancel())
		{
			_push = true;
		}
		else
		{
			FlotsamInputManager.PushCancelable(this);
		}
	}

	private void Update()
	{
		if (_push && !FlotsamInputManager.GetUICancel())
		{
			FlotsamInputManager.PushCancelable(this);
			_push = false;
		}
	}

	private void OnDisable()
	{
		FlotsamInputManager.RemoveCancelable(this);
		_push = false;
	}

	public abstract bool TryCancel();

	protected bool HasActiveInput()
	{
		return FlotsamInputManager.HasActiveInput(_activeInputs);
	}
}
