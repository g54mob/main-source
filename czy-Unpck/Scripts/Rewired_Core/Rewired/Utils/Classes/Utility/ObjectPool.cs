using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ObjectPool<T> : IObjectPool<T>, IObjectPool where T : class
	{
		protected readonly Queue<T> _pool;

		protected readonly Func<T> _createInstanceDelegate;

		protected readonly Action<T> _processOnReturnDelegate;

		private ulong vDOjWSFwejAQRWbOeCXIiDiruUZh;

		protected ulong InstanceCount => vDOjWSFwejAQRWbOeCXIiDiruUZh;

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
				if (!reduceSize)
				{
					return;
				}
				while (true)
				{
					int num = -830977609;
					while (true)
					{
						switch (num ^ -830977610)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0039;
						case 2:
							return;
						}
						break;
						IL_0039:
						_pool.TrimExcess();
						num = -830977612;
					}
				}
			}
		}

		public T Get()
		{
			T result = default(T);
			lock (_pool)
			{
				if (_pool.Count == 0)
				{
					goto IL_001a;
				}
				goto IL_0059;
				IL_001a:
				int num = -1944055517;
				goto IL_001f;
				IL_001f:
				switch (num ^ -1944055518)
				{
				case 0:
					break;
				default:
					goto end_IL_000d;
				case 1:
					result = CreateInstance();
					goto end_IL_000d;
				case 2:
					goto IL_0050;
				case 3:
					goto IL_0059;
				case 4:
					goto end_IL_000d;
				}
				goto IL_001a;
				IL_0050:
				T val = default(T);
				result = val;
				num = -1944055514;
				goto IL_001f;
				IL_0059:
				val = _pool.Dequeue();
				if (val is IPoolableObject_Internal)
				{
					(val as IPoolableObject_Internal).pool = this;
					num = -1944055520;
					goto IL_001f;
				}
				goto IL_0050;
				end_IL_000d:;
			}
			return result;
		}

		public bool Return(T item)
		{
			if (item == null)
			{
				goto IL_0008;
			}
			int num;
			if (_processOnReturnDelegate != null)
			{
				_processOnReturnDelegate(item);
				num = -926931236;
				goto IL_000d;
			}
			goto IL_0045;
			IL_000d:
			while (true)
			{
				switch (num ^ -926931236)
				{
				case 2:
					break;
				case 3:
					(item as IPoolableObject_Internal).Clear();
					num = -926931235;
					continue;
				case 0:
					goto IL_0045;
				case 4:
					return false;
				default:
					lock (_pool)
					{
						_pool.Enqueue(item);
					}
					return true;
				}
				break;
			}
			goto IL_0008;
			IL_0045:
			int num2;
			if (!(item is IPoolableObject_Internal))
			{
				num = -926931235;
				num2 = num;
			}
			else
			{
				num = -926931233;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = -926931240;
			goto IL_000d;
		}

		private object dZPWglpkuhtvYMAphNPdjhDBazy()
		{
			return Get();
		}

		object IObjectPool.Get()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dZPWglpkuhtvYMAphNPdjhDBazy
			return this.dZPWglpkuhtvYMAphNPdjhDBazy();
		}

		private bool hzPZWdpkTgJwnMlQIaLaFkwLgAPD(object P_0)
		{
			return Return(P_0 as T);
		}

		bool IObjectPool.Return(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hzPZWdpkTgJwnMlQIaLaFkwLgAPD
			return this.hzPZWdpkTgJwnMlQIaLaFkwLgAPD(P_0);
		}

		protected T CreateInstance()
		{
			T val = _createInstanceDelegate();
			while (true)
			{
				int num = 1269324069;
				while (true)
				{
					switch (num ^ 0x4BA85927)
					{
					case 0:
						break;
					case 2:
					{
						int num2;
						if (val is IPoolableObject_Internal)
						{
							num = 1269324068;
							num2 = num;
						}
						else
						{
							num = 1269324070;
							num2 = num;
						}
						continue;
					}
					case 3:
						(val as IPoolableObject_Internal).pool = this;
						num = 1269324070;
						continue;
					default:
						IncrementInstanceCount();
						return val;
					}
					break;
				}
			}
		}

		protected ulong IncrementInstanceCount()
		{
			vDOjWSFwejAQRWbOeCXIiDiruUZh = ((vDOjWSFwejAQRWbOeCXIiDiruUZh < ulong.MaxValue) ? (vDOjWSFwejAQRWbOeCXIiDiruUZh + 1) : 0);
			return vDOjWSFwejAQRWbOeCXIiDiruUZh;
		}
	}
}
