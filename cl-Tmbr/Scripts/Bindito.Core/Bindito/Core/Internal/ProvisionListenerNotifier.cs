using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class ProvisionListenerNotifier : IProvisionListenerNotifier
	{
		private readonly List<IProvisionListener> _listeners = new List<IProvisionListener>();

		public IReadOnlyList<IProvisionListener> Listeners => _listeners.AsReadOnly();

		public void AddListener(IProvisionListener provisionListener)
		{
			_listeners.Add(provisionListener);
		}

		public void NotifyAllListeners(object providedObject)
		{
			foreach (IProvisionListener listener in _listeners)
			{
				listener.Listen(providedObject);
			}
		}
	}
}
