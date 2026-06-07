using System.Collections.Generic;

namespace Reactivity
{
	public class ReactivityManager
	{
		private readonly List<DisposableAction> _registeredActions;

		public void Register(DisposableAction action)
		{
		}

		public void Unregister(DisposableAction action)
		{
		}

		public void UnregisterAll()
		{
		}
	}
}
