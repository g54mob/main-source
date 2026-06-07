using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Reactivity
{
	public class Computed<T> : ReactiveEffectBase, IReactiveDependency
	{
		private readonly Func<T> _getter;

		private T _cachedValue;

		private readonly HashSet<IReactiveEffect> _subscribers;

		private readonly List<IReactiveEffect> _subscribersCache;

		private bool _isDirty;

		private readonly HashSet<Action> _registeredActions;

		public T Value => default(T);

		private event Action ValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public Computed(Func<T> getter)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void Evaluate()
		{
		}

		public override void Invalidate()
		{
		}

		public Action Subscribe(IReactiveEffect effect)
		{
			return null;
		}

		public void Unsubscribe(IReactiveEffect effect)
		{
		}

		private void NotifySubscribers()
		{
		}

		public DisposableAction Register(Action action, bool runImmediately = true)
		{
			return null;
		}

		public void Unregister(Action action)
		{
		}

		public void UnregisterAll()
		{
		}
	}
}
