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

		private ulong pbQDaYJgPflojVjuHQmFyxQcOKp;

		protected ulong InstanceCount
		{
			get
			{
				return pbQDaYJgPflojVjuHQmFyxQcOKp;
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
					return CreateInstance();
				}
				T val;
				while (true)
				{
					val = _pool.Dequeue();
					if (!(val is IPoolableObject_Internal))
					{
						break;
					}
					(val as IPoolableObject_Internal).pool = this;
					int num = -2143604883;
					while (true)
					{
						switch (num ^ -2143604883)
						{
						case 2:
							num = -2143604884;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0041;
						}
						break;
					}
					continue;
					end_IL_0041:
					break;
				}
				return val;
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
				_processOnReturnDelegate(item);
				goto IL_001e;
			}
			goto IL_003c;
			IL_003c:
			int num;
			if (item is IPoolableObject_Internal)
			{
				(item as IPoolableObject_Internal).Clear();
				num = -1308895655;
				goto IL_0023;
			}
			goto IL_0060;
			IL_0060:
			lock (_pool)
			{
				_pool.Enqueue(item);
			}
			return true;
			IL_001e:
			num = -1308895656;
			goto IL_0023;
			IL_0023:
			switch (num ^ -1308895655)
			{
			case 2:
				break;
			case 1:
				goto IL_003c;
			default:
				goto IL_0060;
			}
			goto IL_001e;
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
				(val as IPoolableObject_Internal).pool = this;
			}
			IncrementInstanceCount();
			return val;
		}

		protected ulong IncrementInstanceCount()
		{
			pbQDaYJgPflojVjuHQmFyxQcOKp = ((pbQDaYJgPflojVjuHQmFyxQcOKp < ulong.MaxValue) ? (pbQDaYJgPflojVjuHQmFyxQcOKp + 1) : 0);
			return pbQDaYJgPflojVjuHQmFyxQcOKp;
		}
	}
}
