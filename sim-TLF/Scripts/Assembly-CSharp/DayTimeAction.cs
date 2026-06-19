using Services.Time;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class DayTimeAction : MonoBehaviour
{
	[Range(0f, 24f)]
	[SerializeField]
	private float _timeToExecute;

	[SerializeField]
	private UnityEvent _event;

	private bool _firedOnce;

	[Inject]
	private ITimeService _timeService;

	private void Start()
	{
	}

	private void Update()
	{
		if (_timeService.CurrentTime >= _timeToExecute && !_firedOnce)
		{
			_firedOnce = true;
			_event.Invoke();
		}
		if (_timeService.CurrentTime > 0f && (double)_timeService.CurrentTime < 0.2 && _firedOnce)
		{
			_firedOnce = false;
		}
	}
}
