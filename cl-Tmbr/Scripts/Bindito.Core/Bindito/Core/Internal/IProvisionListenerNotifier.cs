using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IProvisionListenerNotifier
	{
		IReadOnlyList<IProvisionListener> Listeners { get; }

		void AddListener(IProvisionListener provisionListener);

		void NotifyAllListeners(object providedObject);
	}
}
