using UnityEngine;

public class InputFlagsToggle : MonoBehaviour
{
	[SerializeField]
	private InputFlags _flags = InputFlags.All;

	[SerializeField]
	private string _enableTrigger;

	[SerializeField]
	private string _disableTrigger;

	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		if ((FlotsamInputManager.ActiveInput & _flags) == 0)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		if ((FlotsamInputManager.ActiveInput & _flags) == 0)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		if ((FlotsamInputManager.ActiveInput & _flags) == 0)
		{
			if (!SetTrigger(_disableTrigger))
			{
				base.gameObject.SetActive(value: false);
			}
		}
		else
		{
			base.gameObject.SetActive(value: true);
			SetTrigger(_enableTrigger);
		}
	}

	private bool SetTrigger(string trigger)
	{
		if (_animator == null || string.IsNullOrEmpty(trigger))
		{
			return false;
		}
		_animator.ResetTrigger(_enableTrigger);
		_animator.ResetTrigger(_disableTrigger);
		_animator.SetTrigger(trigger);
		return true;
	}
}
