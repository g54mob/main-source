using System;

namespace DV.Util.EventWrapper
{
	public struct event_
	{
		private event Action InternalEvent;

		public void Register(Action func)
		{
			InternalEvent += func;
		}

		public void Unregister(Action func)
		{
			InternalEvent -= func;
		}

		public void Manage(Action func, bool register)
		{
			if (register)
			{
				InternalEvent += func;
			}
			else
			{
				InternalEvent -= func;
			}
		}

		public void Invoke()
		{
			this.InternalEvent?.Invoke();
		}
	}
	public struct event_<T1>
	{
		private event Action<T1> InternalEvent;

		public void Register(Action<T1> func)
		{
			InternalEvent += func;
		}

		public void Unregister(Action<T1> func)
		{
			InternalEvent -= func;
		}

		public void Manage(Action<T1> func, bool register)
		{
			if (register)
			{
				InternalEvent += func;
			}
			else
			{
				InternalEvent -= func;
			}
		}

		public void Invoke(T1 arg1)
		{
			this.InternalEvent?.Invoke(arg1);
		}
	}
	public struct event_<T1, T2>
	{
		private event Action<T1, T2> InternalEvent;

		public void Register(Action<T1, T2> func)
		{
			InternalEvent += func;
		}

		public void Unregister(Action<T1, T2> func)
		{
			InternalEvent -= func;
		}

		public void Manage(Action<T1, T2> func, bool register)
		{
			if (register)
			{
				InternalEvent += func;
			}
			else
			{
				InternalEvent -= func;
			}
		}

		public void Invoke(T1 arg1, T2 arg2)
		{
			this.InternalEvent?.Invoke(arg1, arg2);
		}
	}
	public struct event_<T1, T2, T3>
	{
		private event Action<T1, T2, T3> InternalEvent;

		public void Register(Action<T1, T2, T3> func)
		{
			InternalEvent += func;
		}

		public void Unregister(Action<T1, T2, T3> func)
		{
			InternalEvent -= func;
		}

		public void Manage(Action<T1, T2, T3> func, bool register)
		{
			if (register)
			{
				InternalEvent += func;
			}
			else
			{
				InternalEvent -= func;
			}
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3)
		{
			this.InternalEvent?.Invoke(arg1, arg2, arg3);
		}
	}
}
