using System;
using System.Collections.Generic;
using System.Threading;

namespace Amazon.RuntimeDependencies
{
	public abstract class BaseRuntimeDependencyRegistry : IDisposable
	{
		private ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();

		private IDictionary<string, RuntimeDependencyFactory> _runtimeDependency = new Dictionary<string, RuntimeDependencyFactory>();

		private bool _disposedValue;

		protected void RegisterInstance(string assemblyName, string className, object instance)
		{
			RegisterInstance(assemblyName, className, (CreateInstanceContext context) => instance);
		}

		protected void RegisterInstance(string assemblyName, string className, RuntimeDependencyFactory factory)
		{
			try
			{
				_rwlock.EnterWriteLock();
				_runtimeDependency[FormatKey(assemblyName, className)] = factory;
			}
			finally
			{
				if (_rwlock.IsWriteLockHeld)
				{
					_rwlock.ExitWriteLock();
				}
			}
		}

		public virtual T GetInstance<T>(string assemblyName, string className, CreateInstanceContext context) where T : class
		{
			try
			{
				_rwlock.EnterReadLock();
				if (_runtimeDependency.TryGetValue(FormatKey(assemblyName, className), out var value))
				{
					return value(context) as T;
				}
				return null;
			}
			finally
			{
				if (_rwlock.IsReadLockHeld)
				{
					_rwlock.ExitReadLock();
				}
			}
		}

		private static string FormatKey(string assemblyName, string className)
		{
			return assemblyName + "_" + className;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					_rwlock.Dispose();
				}
				_disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
