using System;
using System.Reflection;

namespace UniJSON
{
	public static class GenericInvokeCallFactory
	{
		public static Action StaticAction(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (Action)Delegate.CreateDelegate(typeof(Action), null, m);
		}

		public static Action<S> OpenAction<S>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return delegate(S s)
			{
				m.Invoke(s, new object[0]);
			};
		}

		public static Action BindAction<S>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return delegate
			{
				m.Invoke(instance, new object[0]);
			};
		}

		public static Func<T> StaticFunc<T>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return () => (T)m.Invoke(null, new object[0]);
		}

		public static Func<S, T> OpenFunc<S, T>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (S s) => (T)m.Invoke(s, new object[0]);
		}

		public static Func<T> BindFunc<S, T>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return () => (T)m.Invoke(instance, new object[0]);
		}

		public static Action<A0> StaticAction<A0>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (Action<A0>)Delegate.CreateDelegate(typeof(Action<A0>), null, m);
		}

		public static Action<A0, A1> StaticAction<A0, A1>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (Action<A0, A1>)Delegate.CreateDelegate(typeof(Action<A0, A1>), null, m);
		}

		public static Action<A0, A1, A2> StaticAction<A0, A1, A2>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (Action<A0, A1, A2>)Delegate.CreateDelegate(typeof(Action<A0, A1, A2>), null, m);
		}

		public static Action<A0, A1, A2, A3> StaticAction<A0, A1, A2, A3>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (Action<A0, A1, A2, A3>)Delegate.CreateDelegate(typeof(Action<A0, A1, A2, A3>), null, m);
		}

		public static Action<S, A0> OpenAction<S, A0>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<S, A0>)Delegate.CreateDelegate(typeof(Action<S, A0>), m);
		}

		public static Action<S, A0, A1> OpenAction<S, A0, A1>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<S, A0, A1>)Delegate.CreateDelegate(typeof(Action<S, A0, A1>), m);
		}

		public static Action<S, A0, A1, A2> OpenAction<S, A0, A1, A2>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<S, A0, A1, A2>)Delegate.CreateDelegate(typeof(Action<S, A0, A1, A2>), m);
		}

		public static Action<A0> BindAction<S, A0>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<A0>)Delegate.CreateDelegate(typeof(Action<A0>), instance, m);
		}

		public static Action<A0, A1> BindAction<S, A0, A1>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<A0, A1>)Delegate.CreateDelegate(typeof(Action<A0, A1>), instance, m);
		}

		public static Action<A0, A1, A2> BindAction<S, A0, A1, A2>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<A0, A1, A2>)Delegate.CreateDelegate(typeof(Action<A0, A1, A2>), instance, m);
		}

		public static Action<A0, A1, A2, A3> BindAction<S, A0, A1, A2, A3>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (Action<A0, A1, A2, A3>)Delegate.CreateDelegate(typeof(Action<A0, A1, A2, A3>), instance, m);
		}

		public static Func<A0, T> StaticFunc<A0, T>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (A0 a0) => (T)m.Invoke(null, new object[1] { a0 });
		}

		public static Func<A0, A1, T> StaticFunc<A0, A1, T>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (A0 a0, A1 a1) => (T)m.Invoke(null, new object[2] { a0, a1 });
		}

		public static Func<A0, A1, A2, T> StaticFunc<A0, A1, A2, T>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (A0 a0, A1 a1, A2 a2) => (T)m.Invoke(null, new object[3] { a0, a1, a2 });
		}

		public static Func<A0, A1, A2, A3, T> StaticFunc<A0, A1, A2, A3, T>(MethodInfo m)
		{
			if (!m.IsStatic)
			{
				throw new ArgumentException($"{m} is not static");
			}
			return (A0 a0, A1 a1, A2 a2, A3 a3) => (T)m.Invoke(null, new object[4] { a0, a1, a2, a3 });
		}

		public static Func<S, A0, T> OpenFunc<S, A0, T>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (S s, A0 a0) => (T)m.Invoke(s, new object[1] { a0 });
		}

		public static Func<S, A0, A1, T> OpenFunc<S, A0, A1, T>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (S s, A0 a0, A1 a1) => (T)m.Invoke(s, new object[2] { a0, a1 });
		}

		public static Func<S, A0, A1, A2, T> OpenFunc<S, A0, A1, A2, T>(MethodInfo m)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (S s, A0 a0, A1 a1, A2 a2) => (T)m.Invoke(s, new object[3] { a0, a1, a2 });
		}

		public static Func<A0, T> BindFunc<S, A0, T>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (A0 a0) => (T)m.Invoke(instance, new object[1] { a0 });
		}

		public static Func<A0, A1, T> BindFunc<S, A0, A1, T>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (A0 a0, A1 a1) => (T)m.Invoke(instance, new object[2] { a0, a1 });
		}

		public static Func<A0, A1, A2, T> BindFunc<S, A0, A1, A2, T>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (A0 a0, A1 a1, A2 a2) => (T)m.Invoke(instance, new object[3] { a0, a1, a2 });
		}

		public static Func<A0, A1, A2, A3, T> BindFunc<S, A0, A1, A2, A3, T>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				throw new ArgumentException($"{m} is static");
			}
			return (A0 a0, A1 a1, A2 a2, A3 a3) => (T)m.Invoke(instance, new object[4] { a0, a1, a2, a3 });
		}
	}
}
