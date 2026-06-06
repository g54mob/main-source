using System;
using UnityEngine;
using UnityEngine.Events;

public class Spawnable : MonoBehaviour
{
	public class Event : UnityEvent<Spawnable, EventType>
	{
	}

	public enum EventType
	{
		Salvaged = 0,
		OutOfRange = 1,
		Unloaded = 2
	}

	[NonSerialized]
	public Event OnDestroyed = new Event();

	private FlotsamBehaviour _flotsam;

	private IRangeTester _destructionRangeTester;

	private bool _isUI;

	public void Initialize(FlotsamBehaviour flotsam, IRangeTester destructionRangeTester)
	{
		_flotsam = flotsam;
		_destructionRangeTester = destructionRangeTester;
		_isUI = flotsam == null;
	}

	private void Update()
	{
		if (_isUI && !_destructionRangeTester.IsInRange(base.transform))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		EventType arg = (_isUI ? ((!_destructionRangeTester.IsInRange(base.transform)) ? EventType.OutOfRange : EventType.Salvaged) : ((_flotsam.ReturnCompositionProgress() != 0f) ? ((!_destructionRangeTester.IsInRange(base.transform)) ? EventType.OutOfRange : EventType.Unloaded) : EventType.Salvaged));
		OnDestroyed.Invoke(this, arg);
		OnDestroyed.RemoveAllListeners();
	}
}
