using System;
using System.Collections.Generic;
using System.Threading;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class SingletonDispenser<TKey, TItem> where TItem : class
	{
		private readonly ReaderWriterLockSlim locker;

		private readonly Dictionary<TKey, object> items;

		private readonly Func<TKey, TItem> factory;

		public TItem this[TKey key]
		{
			get
			{
				return GetOrCreate(key);
			}
			protected set
			{
				items[key] = value;
			}
		}

		public SingletonDispenser(Func<TKey, TItem> factory)
		{
			if (factory == null)
			{
				throw Error.ArgumentNull("factory");
			}
			locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
			items = new Dictionary<TKey, object>();
			this.factory = factory;
		}

		private TItem GetOrCreate(TKey key)
		{
			if (!TryGetExistingItem(key, out var item))
			{
				return Create(key, item);
			}
			return (item as TItem) ?? WaitForCreate(key, item);
		}

		private bool TryGetExistingItem(TKey key, out object item)
		{
			locker.EnterReadLock();
			try
			{
				if (items.TryGetValue(key, out item))
				{
					return true;
				}
			}
			finally
			{
				locker.ExitReadLock();
			}
			locker.EnterUpgradeableReadLock();
			try
			{
				if (items.TryGetValue(key, out item))
				{
					return true;
				}
				locker.EnterWriteLock();
				try
				{
					items[key] = (item = new ManualResetEvent(initialState: false));
					return false;
				}
				finally
				{
					locker.ExitWriteLock();
				}
			}
			finally
			{
				locker.ExitUpgradeableReadLock();
			}
		}

		private TItem WaitForCreate(TKey key, object item)
		{
			((ManualResetEvent)item).WaitOne();
			locker.EnterReadLock();
			try
			{
				return (TItem)items[key];
			}
			finally
			{
				locker.ExitReadLock();
			}
		}

		private TItem Create(TKey key, object item)
		{
			ManualResetEvent manualResetEvent = (ManualResetEvent)item;
			TItem val = factory(key);
			locker.EnterWriteLock();
			try
			{
				items[key] = val;
			}
			finally
			{
				locker.ExitWriteLock();
			}
			manualResetEvent.Set();
			return val;
		}
	}
}
