using System;
using System.Collections.Generic;
using System.Threading;

namespace Amazon.Runtime.Internal
{
	public class CapacityManager : IDisposable
	{
		public enum CapacityType
		{
			Increment = 0,
			Retry = 1,
			Timeout = 2
		}

		private bool _disposed;

		private static Dictionary<string, RetryCapacity> _serviceUrlToCapacityMap = new Dictionary<string, RetryCapacity>();

		private static ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();

		private readonly int retryCost;

		private readonly int timeoutRetryCost;

		private readonly int initialRetryTokens;

		private readonly int noRetryIncrement;

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				_disposed = true;
			}
		}

		public CapacityManager(int throttleRetryCount, int throttleRetryCost, int throttleCost)
			: this(throttleRetryCount, throttleRetryCost, throttleCost, throttleRetryCost)
		{
		}

		public CapacityManager(int throttleRetryCount, int throttleRetryCost, int throttleCost, int timeoutRetryCost)
		{
			retryCost = throttleRetryCost;
			initialRetryTokens = throttleRetryCount;
			noRetryIncrement = throttleCost;
			this.timeoutRetryCost = timeoutRetryCost;
		}

		public bool TryAcquireCapacity(RetryCapacity retryCapacity)
		{
			return TryAcquireCapacity(retryCapacity, CapacityType.Retry);
		}

		public bool TryAcquireCapacity(RetryCapacity retryCapacity, CapacityType capacityType)
		{
			int num = ((capacityType == CapacityType.Timeout) ? timeoutRetryCost : retryCost);
			if (num < 0)
			{
				return false;
			}
			lock (retryCapacity)
			{
				if (retryCapacity.AvailableCapacity - num >= 0)
				{
					retryCapacity.AvailableCapacity -= num;
					return true;
				}
				return false;
			}
		}

		public void ReleaseCapacity(CapacityType capacityType, RetryCapacity retryCapacity)
		{
			switch (capacityType)
			{
			case CapacityType.Retry:
				ReleaseCapacity(retryCost, retryCapacity);
				break;
			case CapacityType.Timeout:
				ReleaseCapacity(timeoutRetryCost, retryCapacity);
				break;
			case CapacityType.Increment:
				ReleaseCapacity(noRetryIncrement, retryCapacity);
				break;
			default:
				throw new NotSupportedException($"Unsupported CapacityType {capacityType}");
			}
		}

		public RetryCapacity GetRetryCapacity(string serviceURL)
		{
			if (!TryGetRetryCapacity(serviceURL, out var value))
			{
				return AddNewRetryCapacity(serviceURL);
			}
			return value;
		}

		private static bool TryGetRetryCapacity(string key, out RetryCapacity value)
		{
			_rwlock.EnterReadLock();
			try
			{
				if (_serviceUrlToCapacityMap.TryGetValue(key, out value))
				{
					return true;
				}
				return false;
			}
			finally
			{
				_rwlock.ExitReadLock();
			}
		}

		private RetryCapacity AddNewRetryCapacity(string serviceURL)
		{
			_rwlock.EnterUpgradeableReadLock();
			try
			{
				if (!_serviceUrlToCapacityMap.TryGetValue(serviceURL, out var value))
				{
					_rwlock.EnterWriteLock();
					try
					{
						value = new RetryCapacity(retryCost * initialRetryTokens);
						_serviceUrlToCapacityMap.Add(serviceURL, value);
						return value;
					}
					finally
					{
						_rwlock.ExitWriteLock();
					}
				}
				return value;
			}
			finally
			{
				_rwlock.ExitUpgradeableReadLock();
			}
		}

		private static void ReleaseCapacity(int capacity, RetryCapacity retryCapacity)
		{
			if (retryCapacity.AvailableCapacity >= 0 && retryCapacity.AvailableCapacity < retryCapacity.MaxCapacity)
			{
				lock (retryCapacity)
				{
					retryCapacity.AvailableCapacity = Math.Min(retryCapacity.AvailableCapacity + capacity, retryCapacity.MaxCapacity);
				}
			}
		}
	}
}
