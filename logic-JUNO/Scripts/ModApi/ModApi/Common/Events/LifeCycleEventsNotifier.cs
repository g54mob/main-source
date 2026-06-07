using UnityEngine;
using UnityEngine.Events;

namespace ModApi.Common.Events
{
	public class LifeCycleEventsNotifier : MonoBehaviour
	{
		public class LifeCycleEvent : UnityEvent
		{
		}

		public LifeCycleEvent Destroyed { get; private set; } = new LifeCycleEvent();

		public LifeCycleEvent Disabled { get; private set; } = new LifeCycleEvent();

		public LifeCycleEvent Enabled { get; private set; } = new LifeCycleEvent();

		public void RemoveAllListeners()
		{
			LifeCycleEvent lifeCycleEvent = (Enabled = null);
			LifeCycleEvent destroyed = (Disabled = lifeCycleEvent);
			Destroyed = destroyed;
		}

		private void OnDestroy()
		{
			Destroyed.Invoke();
			RemoveAllListeners();
		}

		private void OnDisable()
		{
			Disabled.Invoke();
		}

		private void OnEnable()
		{
			Enabled.Invoke();
		}
	}
}
