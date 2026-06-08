using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class InjectionListenerNotifier : IInjectionListenerNotifier
	{
		private readonly List<IInjectionListener> _listeners = new List<IInjectionListener>();

		public IReadOnlyList<IInjectionListener> Listeners => _listeners.AsReadOnly();

		public void AddListener(IInjectionListener injectionListener)
		{
			_listeners.Add(injectionListener);
		}

		public void NotifyAllListeners(object injectee)
		{
			foreach (IInjectionListener listener in _listeners)
			{
				listener.Listen(injectee);
			}
		}
	}
}
