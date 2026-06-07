using Events;
using UnityEngine;

public class SavingSpinnerUI : MonoBehaviour
{
	[SerializeField]
	private BaseEvent _finishedSavingEvent;

	[SerializeField]
	private float _minimumSpinnerTime = 1f;

	private float _timeShown;

	private bool _shouldDestroy;

	private void Awake()
	{
		_timeShown = 0f;
		Object.DontDestroyOnLoad(base.gameObject);
		_finishedSavingEvent.Register(DestroySpinner);
	}

	private void OnDestroy()
	{
		_finishedSavingEvent.UnRegister(DestroySpinner);
	}

	private void Update()
	{
		_timeShown += Time.deltaTime;
		if (_shouldDestroy && _timeShown > _minimumSpinnerTime)
		{
			DestroySpinner();
		}
	}

	public void DestroySpinner()
	{
		if (_timeShown > _minimumSpinnerTime)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			_shouldDestroy = true;
		}
	}
}
