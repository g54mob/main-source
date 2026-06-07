using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class ObjectPool<T> : IObjectPool<T>, IObjectPool where T : class
	{
		protected readonly Queue<T> _pool;

		protected readonly Func<T> _createInstanceDelegate;

		protected readonly Action<T> _processOnReturnDelegate;

		private ulong HLXIthjjXyQtOJyYvvoSLBDPjbmi;

		protected ulong InstanceCount => 0uL;

		public ObjectPool(int P_0, Func<T> P_1, Action<T> P_2 = null)
		{
		}

		public ObjectPool(Func<T> P_0)
		{
		}

		public void Clear(bool reduceSize = false)
		{
		}

		public T Get()
		{
			return null;
		}

		public bool Return(T item)
		{
			return false;
		}

		private object VQKWYOJVZiJjHXRjeFhfxUmzwHHU()
		{
			return null;
		}

		object IObjectPool.Get()
		{
			//ILSpy generated this explicit interface implementation from .override directive in VQKWYOJVZiJjHXRjeFhfxUmzwHHU
			return this.VQKWYOJVZiJjHXRjeFhfxUmzwHHU();
		}

		private bool JvCKWNPgFruoPVEwVbmqBVxrlsCB(object P_0)
		{
			return false;
		}

		bool IObjectPool.Return(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JvCKWNPgFruoPVEwVbmqBVxrlsCB
			return this.JvCKWNPgFruoPVEwVbmqBVxrlsCB(P_0);
		}

		protected T CreateInstance()
		{
			return null;
		}

		protected ulong IncrementInstanceCount()
		{
			return 0uL;
		}
	}
}
