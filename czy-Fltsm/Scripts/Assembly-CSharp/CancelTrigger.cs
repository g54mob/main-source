using UnityEngine;
using UnityEngine.Events;

public class CancelTrigger : CancelTriggerBase
{
	[SerializeField]
	private UnityEvent _onCancel;

	public override bool TryCancel()
	{
		if (HasActiveInput())
		{
			_onCancel?.Invoke();
			return true;
		}
		return false;
	}
}
