using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IInjectionListenerNotifier
	{
		IReadOnlyList<IInjectionListener> Listeners { get; }

		void AddListener(IInjectionListener injectionListener);

		void NotifyAllListeners(object injectee);
	}
}
