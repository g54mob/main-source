using UnityEngine;

namespace NSEipix.Base
{
	public abstract class MonoController<T> : MonoSingleton<T> where T : MonoBehaviour
	{
		private Notifier notifier = new Notifier();

		public void Attach(IObserver observer)
		{
			notifier.Attach(observer);
		}

		public void Detach(IObserver observer)
		{
			notifier.Detach(observer);
		}

		public void NotifyAll(string notification, params object[] parameters)
		{
			notifier.NotifyAll(notification, parameters);
		}

		public void NotifyOne(string notification, params object[] parameters)
		{
			notifier.NotifyOne(notification, parameters);
		}

		public void NotifyCount(string notification, int count, params object[] parameters)
		{
			notifier.NotifyCount(notification, count, parameters);
		}

		protected override void OnDestroy()
		{
			notifier.RemoveAllObservers();
			notifier = null;
			base.OnDestroy();
		}
	}
}
