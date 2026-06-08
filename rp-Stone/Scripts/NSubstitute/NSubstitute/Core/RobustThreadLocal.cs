using System;
using System.Threading;

namespace NSubstitute.Core
{
	internal class RobustThreadLocal<T>
	{
		private readonly ThreadLocal<T> _threadLocal;

		private readonly Func<T>? _initialValueFactory;

		public T Value
		{
			get
			{
				try
				{
					return _threadLocal.Value;
				}
				catch (ObjectDisposedException)
				{
					return (_initialValueFactory != null) ? _initialValueFactory() : default(T);
				}
			}
			set
			{
				try
				{
					_threadLocal.Value = value;
				}
				catch (ObjectDisposedException)
				{
				}
			}
		}

		public RobustThreadLocal()
		{
			_threadLocal = new ThreadLocal<T>();
		}

		public RobustThreadLocal(Func<T> initialValueFactory)
		{
			_initialValueFactory = initialValueFactory;
			_threadLocal = new ThreadLocal<T>(initialValueFactory);
		}
	}
}
