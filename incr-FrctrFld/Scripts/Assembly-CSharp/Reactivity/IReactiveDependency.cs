using System;

namespace Reactivity
{
	public interface IReactiveDependency
	{
		DisposableAction Register(Action action, bool runImmediately = true);

		void Unregister(Action action);

		void UnregisterAll();

		Action Subscribe(IReactiveEffect effect);

		void Unsubscribe(IReactiveEffect effect);

		void Cleanup();
	}
}
