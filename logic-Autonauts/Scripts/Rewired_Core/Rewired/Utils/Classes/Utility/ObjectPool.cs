using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectPool<T> : IObjectPool<T>, IObjectPool where T : class
	{
		protected readonly Queue<T> _pool;

		protected readonly Func<T> _createInstanceDelegate;

		protected readonly Action<T> _processOnReturnDelegate;

		private ulong OZMhGVpOZfPIYdcvncDNFeKocLk;

		protected ulong InstanceCount
		{
			get
			{
				return OZMhGVpOZfPIYdcvncDNFeKocLk;
			}
		}

		public ObjectPool(int startingSize, Func<T> createInstanceDelegate, Action<T> processOnReturnDelegate = null)
		{
			if (createInstanceDelegate == null)
			{
				throw new ArgumentNullException("instancerDelegate");
			}
			_processOnReturnDelegate = processOnReturnDelegate;
			_pool = ((startingSize > 0) ? new Queue<T>(startingSize) : new Queue<T>());
			_createInstanceDelegate = createInstanceDelegate;
		}

		public ObjectPool(Func<T> instancerDelegate)
			: this(0, instancerDelegate, (Action<T>)null)
		{
		}

		public void Clear(bool reduceSize = false)
		{
			lock (_pool)
			{
				_pool.Clear();
				if (reduceSize)
				{
					_pool.TrimExcess();
				}
			}
		}

		public T Get()
		{
			lock (_pool)
			{
				if (_pool.Count == 0)
				{
					goto IL_001a;
				}
				goto IL_0050;
				IL_001a:
				int num = 967927959;
				goto IL_001f;
				IL_001f:
				T val = default(T);
				while (true)
				{
					switch (num ^ 0x39B16895)
					{
					case 3:
						break;
					case 2:
						return CreateInstance();
					case 4:
						goto IL_0050;
					case 0:
						(val as IPoolableObject_Internal).pool = this;
						num = 967927956;
						continue;
					default:
						return val;
					}
					break;
				}
				goto IL_001a;
				IL_0050:
				val = _pool.Dequeue();
				int num2;
				if (!(val is IPoolableObject_Internal))
				{
					num = 967927956;
					num2 = num;
				}
				else
				{
					num = 967927957;
					num2 = num;
				}
				goto IL_001f;
			}
		}

		public bool Return(T item)
		{
			if (item == null)
			{
				return false;
			}
			if (_processOnReturnDelegate != null)
			{
				goto IL_0012;
			}
			goto IL_0047;
			IL_006b:
			lock (_pool)
			{
				_pool.Enqueue(item);
			}
			return true;
			IL_0012:
			int num = -852098679;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ -852098680)
				{
				case 3:
					break;
				case 1:
					_processOnReturnDelegate(item);
					num = -852098678;
					continue;
				case 2:
					goto IL_0047;
				default:
					goto IL_006b;
				}
				break;
			}
			goto IL_0012;
			IL_0047:
			if (item is IPoolableObject_Internal)
			{
				(item as IPoolableObject_Internal).Clear();
				num = -852098680;
				goto IL_0017;
			}
			goto IL_006b;
		}

		object IObjectPool.Get()
		{
			return Get();
		}

		bool IObjectPool.Return(object P_0)
		{
			return Return(P_0 as T);
		}

		protected T CreateInstance()
		{
			T val = _createInstanceDelegate();
			if (val is IPoolableObject_Internal)
			{
				while (true)
				{
					int num = 1669062628;
					while (true)
					{
						switch (num ^ 0x637BDFE5)
						{
						case 0:
							break;
						case 1:
							(val as IPoolableObject_Internal).pool = this;
							num = 1669062631;
							continue;
						default:
							goto end_IL_0019;
						}
						break;
					}
					continue;
					end_IL_0019:
					break;
				}
			}
			IncrementInstanceCount();
			return val;
		}

		protected ulong IncrementInstanceCount()
		{
			OZMhGVpOZfPIYdcvncDNFeKocLk = ((OZMhGVpOZfPIYdcvncDNFeKocLk < ulong.MaxValue) ? (OZMhGVpOZfPIYdcvncDNFeKocLk + 1) : 0);
			return OZMhGVpOZfPIYdcvncDNFeKocLk;
		}
	}
}
