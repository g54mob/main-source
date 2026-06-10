using System;
using NSMedieval.State.Timers;
using UnityEngine;

namespace NSMedieval
{
	public class AutoDestroyObject : MonoBehaviour
	{
		[SerializeField]
		private float destroyAfterTime;

		[SerializeField]
		private bool unscaledTime;

		private BaseTimer timer;

		public event Action OnDestroyedEvent;

		private void OnDestroy()
		{
			timer?.Dispose();
			timer = null;
			this.OnDestroyedEvent = null;
		}

		private void Start()
		{
			timer = (unscaledTime ? ((BaseTimer)new UnscaledTimer(destroyAfterTime)) : ((BaseTimer)new Timer(destroyAfterTime)));
			timer.AddCallback(DestroyCallback);
		}

		private void DestroyCallback()
		{
			this.OnDestroyedEvent?.Invoke();
			if (base.gameObject != null)
			{
				timer?.Dispose();
				timer = null;
				UnityEngine.Object.Destroy(base.gameObject);
			}
			this.OnDestroyedEvent = null;
		}
	}
}
