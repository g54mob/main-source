using System;
using System.Runtime.CompilerServices;

namespace Libs
{
	public class ReactiveProperty<T>
	{
		private class Subscription : IDisposable
		{
			private ReactiveProperty<T> _reactiveProperty;

			private Action<T> _callback;

			private bool _isDisposed;

			public Subscription(ReactiveProperty<T> reactiveProperty, Action<T> callback)
			{
			}

			public void Dispose()
			{
			}
		}

		private T _value;

		public T Value
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		private event Action<T> OnValueChanged
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

		public ReactiveProperty()
		{
		}

		public ReactiveProperty(T initialValue)
		{
		}

		public IDisposable Subscribe(Action<T> callback)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
