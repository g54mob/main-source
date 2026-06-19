using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class EventInARangeOfTime : MonoBehaviour
	{
		[SerializeField]
		private float _minTime;

		[SerializeField]
		private float _maxTime;

		public UnityEvent OnEvent;

		private bool _canInvokeEvent;

		public void InvokeEvent()
		{
			float delay = Random.Range(_minTime, _maxTime);
			this.Invoke(delegate
			{
				OnEvent?.Invoke();
			}, delay);
		}

		public void StartLoopInvoke()
		{
			_canInvokeEvent = true;
			LoopInvokeEvent(0f);
		}

		public void StopLoopInvoke()
		{
			_canInvokeEvent = false;
			StopAllCoroutines();
		}

		private void LoopInvokeEvent(float timeToInvoke)
		{
			this.Invoke(delegate
			{
				OnEvent?.Invoke();
				if (_canInvokeEvent)
				{
					float timeToInvoke2 = Random.Range(_minTime, _maxTime);
					LoopInvokeEvent(timeToInvoke2);
				}
			}, timeToInvoke);
		}
	}
}
