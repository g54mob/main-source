using System;

namespace Logic.Threading.Events
{
	public class MainThreadEvent
	{
		public class Queue : MainThreadQueue<Context>
		{
		}

		public struct Context : IMainThreadEventContext
		{
			public MainThreadEvent Source;

			public void Fire()
			{
				Source.FireInternal();
			}
		}

		private event Action _queuedAction = delegate
		{
		};

		private event Action _inlineAction = delegate
		{
		};

		public void RegisterMainThread(Action listener)
		{
			_queuedAction += listener;
		}

		public void UnRegisterMainThread(Action listener)
		{
			_queuedAction -= listener;
		}

		public void RegisterInline(Action listener)
		{
			_inlineAction += listener;
		}

		public void UnRegisterInline(Action listener)
		{
			_inlineAction -= listener;
		}

		public void UnRegisterAll()
		{
			this._queuedAction = delegate
			{
			};
			this._inlineAction = delegate
			{
			};
		}

		public void FireInternal()
		{
			this._queuedAction();
		}

		public void Fire()
		{
			MainThreadEventDispatcher.Instance.Enqueue<Queue, Context>(new Context
			{
				Source = this
			});
			this._inlineAction();
		}
	}
	public class MainThreadEvent<T>
	{
		public class Queue : MainThreadQueue<Context>
		{
		}

		public struct Context : IMainThreadEventContext
		{
			public T Value;

			public MainThreadEvent<T> Source;

			public void Fire()
			{
				Source.FireInternal(Value);
			}
		}

		private event Action<T> _queuedAction = delegate
		{
		};

		private event Action<T> _inlineAction = delegate
		{
		};

		public void RegisterMainThread(Action<T> listener)
		{
			_queuedAction += listener;
		}

		public void UnRegisterMainThread(Action<T> listener)
		{
			_queuedAction -= listener;
		}

		public void RegisterInline(Action<T> listener)
		{
			_inlineAction += listener;
		}

		public void UnRegisterInline(Action<T> listener)
		{
			_inlineAction -= listener;
		}

		public void UnRegisterAll()
		{
			this._queuedAction = delegate
			{
			};
			this._inlineAction = delegate
			{
			};
		}

		public void FireInternal(T data)
		{
			this._queuedAction(data);
		}

		public void Fire(T data)
		{
			MainThreadEventDispatcher.Instance.Enqueue<Queue, Context>(new Context
			{
				Value = data,
				Source = this
			});
			this._inlineAction(data);
		}
	}
	public class MainThreadEvent<T, Y>
	{
		public class Queue : MainThreadQueue<Context>
		{
		}

		public struct Context : IMainThreadEventContext
		{
			public T ValueA;

			public Y ValueB;

			public MainThreadEvent<T, Y> Source;

			public void Fire()
			{
				Source.FireInternal(ValueA, ValueB);
			}
		}

		private event Action<T, Y> _queuedAction = delegate
		{
		};

		private event Action<T, Y> _inlineAction = delegate
		{
		};

		public void RegisterMainThread(Action<T, Y> listener)
		{
			_queuedAction += listener;
		}

		public void UnRegisterMainThread(Action<T, Y> listener)
		{
			_queuedAction -= listener;
		}

		public void RegisterInline(Action<T, Y> listener)
		{
			_inlineAction += listener;
		}

		public void UnRegisterInline(Action<T, Y> listener)
		{
			_inlineAction -= listener;
		}

		public void UnRegisterAll()
		{
			this._queuedAction = delegate
			{
			};
			this._inlineAction = delegate
			{
			};
		}

		public void FireInternal(T dataA, Y dataB)
		{
			this._queuedAction(dataA, dataB);
		}

		public void Fire(T dataA, Y dataB)
		{
			MainThreadEventDispatcher.Instance.Enqueue<Queue, Context>(new Context
			{
				ValueA = dataA,
				ValueB = dataB,
				Source = this
			});
			this._inlineAction(dataA, dataB);
		}
	}
	public class MainThreadEvent<T, Y, U>
	{
		public class Queue : MainThreadQueue<Context>
		{
		}

		public struct Context : IMainThreadEventContext
		{
			public T ValueA;

			public Y ValueB;

			public U ValueC;

			public MainThreadEvent<T, Y, U> Source;

			public void Fire()
			{
				Source.FireInternal(ValueA, ValueB, ValueC);
			}
		}

		private event Action<T, Y, U> _queuedAction = delegate
		{
		};

		private event Action<T, Y, U> _inlineAction = delegate
		{
		};

		public void RegisterMainThread(Action<T, Y, U> listener)
		{
			_queuedAction += listener;
		}

		public void UnRegisterMainThread(Action<T, Y, U> listener)
		{
			_queuedAction -= listener;
		}

		public void RegisterInline(Action<T, Y, U> listener)
		{
			_inlineAction += listener;
		}

		public void UnRegisterInline(Action<T, Y, U> listener)
		{
			_inlineAction -= listener;
		}

		public void UnRegisterAll()
		{
			this._queuedAction = delegate
			{
			};
			this._inlineAction = delegate
			{
			};
		}

		public void FireInternal(T dataA, Y dataB, U dataC)
		{
			this._queuedAction(dataA, dataB, dataC);
		}

		public void Fire(T dataA, Y dataB, U dataC)
		{
			MainThreadEventDispatcher.Instance.Enqueue<Queue, Context>(new Context
			{
				ValueA = dataA,
				ValueB = dataB,
				ValueC = dataC,
				Source = this
			});
			this._inlineAction(dataA, dataB, dataC);
		}
	}
	public class MainThreadEvent<T, Y, U, V>
	{
		public class Queue : MainThreadQueue<Context>
		{
		}

		public struct Context : IMainThreadEventContext
		{
			public T ValueA;

			public Y ValueB;

			public U ValueC;

			public V ValueV;

			public MainThreadEvent<T, Y, U, V> Source;

			public void Fire()
			{
				Source.FireInternal(ValueA, ValueB, ValueC, ValueV);
			}
		}

		private event Action<T, Y, U, V> _queuedAction = delegate
		{
		};

		private event Action<T, Y, U, V> _inlineAction = delegate
		{
		};

		public void RegisterMainThread(Action<T, Y, U, V> listener)
		{
			_queuedAction += listener;
		}

		public void UnRegisterMainThread(Action<T, Y, U, V> listener)
		{
			_queuedAction -= listener;
		}

		public void RegisterInline(Action<T, Y, U, V> listener)
		{
			_inlineAction += listener;
		}

		public void UnRegisterInline(Action<T, Y, U, V> listener)
		{
			_inlineAction -= listener;
		}

		public void UnRegisterAll()
		{
			this._queuedAction = delegate
			{
			};
			this._inlineAction = delegate
			{
			};
		}

		public void FireInternal(T dataA, Y dataB, U dataC, V dataD)
		{
			this._queuedAction(dataA, dataB, dataC, dataD);
		}

		public void Fire(T dataA, Y dataB, U dataC, V dataD)
		{
			MainThreadEventDispatcher.Instance.Enqueue<Queue, Context>(new Context
			{
				ValueA = dataA,
				ValueB = dataB,
				ValueC = dataC,
				ValueV = dataD,
				Source = this
			});
			this._inlineAction(dataA, dataB, dataC, dataD);
		}
	}
}
