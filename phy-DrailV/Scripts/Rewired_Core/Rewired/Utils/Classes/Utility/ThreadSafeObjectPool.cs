using System;
using System.Collections.Generic;
using System.Threading;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadSafeObjectPool<T> : IObjectPool<T>, IObjectPool where T : class
	{
		private const int KSHnOpxGblMtnpsCrlqedDRUggY = 1;

		private const int uaZdCYSFBUDpXCGBtziithdqAscn = 0;

		protected readonly AList<T> _pool;

		protected readonly Func<T> _createInstanceDelegate;

		protected readonly Action<T> _processOnReturnDelegate;

		private ulong yUPBRkbHziNrmggsaWDwmAeIAxgMc;

		private int CTRtJmWIWOCaDqgjXpQJREtEkbOR;

		protected ulong InstanceCount => yUPBRkbHziNrmggsaWDwmAeIAxgMc;

		public ThreadSafeObjectPool(int P_0, Func<T> P_1, Action<T> P_2 = null)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("instancerDelegate");
			}
			_processOnReturnDelegate = P_2;
			_pool = ((P_0 > 0) ? new AList<T>(P_0) : new AList<T>());
			_createInstanceDelegate = P_1;
		}

		public ThreadSafeObjectPool(Func<T> P_0)
			: this(0, P_0, (Action<T>)null)
		{
		}

		public void Clear(bool reduceSize = false)
		{
			while (Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			_pool.Clear();
			if (reduceSize)
			{
				_pool.TrimExcess();
			}
			Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 0);
		}

		public T Get()
		{
			while (Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			if (_pool._count == 0)
			{
				T result = CreateInstance();
				Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 0);
				return result;
			}
			_pool._count--;
			T val = _pool._items[_pool._count];
			_pool._items[_pool._count] = null;
			if (val is IPoolableObject_Internal)
			{
				(val as IPoolableObject_Internal).pool = this;
			}
			Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 0);
			return val;
		}

		public bool Return(T item)
		{
			if (item == null)
			{
				return false;
			}
			if (_processOnReturnDelegate != null)
			{
				_processOnReturnDelegate(item);
			}
			if (item is IPoolableObject_Internal)
			{
				(item as IPoolableObject_Internal).Clear();
			}
			while (Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			if (_pool._count < _pool._items.Length)
			{
				_pool._items[_pool._count] = item;
				_pool._count++;
			}
			else
			{
				_pool.Add(item);
			}
			Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 0);
			return true;
		}

		public bool Return(IList<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			int count = items.Count;
			bool result = false;
			Action<T> processOnReturnDelegate = _processOnReturnDelegate;
			while (Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 1) != 0)
			{
				Thread.SpinWait(1);
			}
			for (int i = 0; i < count; i++)
			{
				T val = items[i];
				if (val != null)
				{
					processOnReturnDelegate?.Invoke(val);
					if (val is IPoolableObject_Internal)
					{
						(val as IPoolableObject_Internal).Clear();
					}
					if (_pool._count < _pool._items.Length)
					{
						_pool._items[_pool._count] = val;
						_pool._count++;
					}
					else
					{
						_pool.Add(val);
					}
				}
			}
			Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 0);
			items.Clear();
			return result;
		}

		private object auWHxDhjlyUrxklZPVcVkCTeVELK()
		{
			return Get();
		}

		object IObjectPool.Get()
		{
			//ILSpy generated this explicit interface implementation from .override directive in auWHxDhjlyUrxklZPVcVkCTeVELK
			return this.auWHxDhjlyUrxklZPVcVkCTeVELK();
		}

		private bool uRMJDLplKbcDKwWawaFIUokelbyo(object P_0)
		{
			return Return(P_0 as T);
		}

		bool IObjectPool.Return(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uRMJDLplKbcDKwWawaFIUokelbyo
			return this.uRMJDLplKbcDKwWawaFIUokelbyo(P_0);
		}

		protected T CreateInstance()
		{
			T val = _createInstanceDelegate();
			if (val is IPoolableObject_Internal)
			{
				(val as IPoolableObject_Internal).pool = this;
			}
			IncrementInstanceCount();
			return val;
		}

		protected ulong IncrementInstanceCount()
		{
			yUPBRkbHziNrmggsaWDwmAeIAxgMc = ((yUPBRkbHziNrmggsaWDwmAeIAxgMc < ulong.MaxValue) ? (yUPBRkbHziNrmggsaWDwmAeIAxgMc + 1) : 0);
			return yUPBRkbHziNrmggsaWDwmAeIAxgMc;
		}
	}
}
