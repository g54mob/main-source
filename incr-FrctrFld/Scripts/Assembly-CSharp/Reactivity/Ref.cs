using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Reactivity
{
	public class Ref<T> : IReactiveDependency
	{
		private T _value;

		private readonly HashSet<IReactiveEffect> _subscribers;

		private readonly List<IReactiveEffect> _subscribersCache;

		private readonly HashSet<Action> _registeredActions;

		public bool AlwaysEmit { get; set; }

		[JsonProperty]
		public T Value
		{
			get
			{
				return default(T);
			}
			private set
			{
			}
		}

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

		public Ref()
		{
		}

		public Ref(T initialValue)
		{
		}

		public void Set(T newValue)
		{
		}

		protected void ForceSet(T newValue)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public Action Subscribe(IReactiveEffect effect)
		{
			return null;
		}

		public void Unsubscribe(IReactiveEffect effect)
		{
		}

		public void UnsubscribeAll()
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

		public void RegisterOnce(Action action, bool runImmediately = false)
		{
		}

		public void UnregisterAll()
		{
		}

		public void Cleanup()
		{
		}

		public void CopyTo(Ref<T> other)
		{
		}

		public void CopyFrom(Ref<T> other)
		{
		}

		public bool IsSame(Ref<T> other)
		{
			return false;
		}

		public bool IsSame(T other)
		{
			return false;
		}

		protected void TriggerValueChanged()
		{
		}

		protected void TriggerNotifySubscribers()
		{
		}
	}
}
