using UnityEngine;
using UnityEngine.Events;

namespace Jundroo.Common.Events
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

		protected virtual void OnDestroy()
		{
			Destroyed.Invoke();
			RemoveAllListeners();
		}

		protected virtual void OnDisable()
		{
			Disabled.Invoke();
		}

		protected virtual void OnEnable()
		{
			Enabled.Invoke();
		}
	}
}
