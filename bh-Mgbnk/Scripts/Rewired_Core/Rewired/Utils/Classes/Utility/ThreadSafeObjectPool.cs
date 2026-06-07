using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadSafeObjectPool<T> : IObjectPool, IObjectPool<T> where T : class
	{
		private const int xeXOcqnFcuQnGTpxXpyDMvcJMFNr = 1;

		private const int ivejtKqDQtIuUfVnzdAkFHkNmpXy = 0;

		protected readonly AList<T> _pool;

		protected readonly Func<T> _createInstanceDelegate;

		protected readonly Action<T> _processOnReturnDelegate;

		private ulong jEBwIFbpeVLuZCkxaNshqNAWjSOD;

		private int XITfHHymOzqFfmZqfMubOjMVmALd;

		protected ulong InstanceCount => 0uL;

		public ThreadSafeObjectPool(int P_0, Func<T> P_1, Action<T> P_2 = null)
		{
		}

		public ThreadSafeObjectPool(Func<T> P_0)
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

		public bool Return(IList<T> items)
		{
			return false;
		}

		private object adUQFIiTvdcxPqpLgQwdTwSYrjab()
		{
			return null;
		}

		object IObjectPool.Get()
		{
			//ILSpy generated this explicit interface implementation from .override directive in adUQFIiTvdcxPqpLgQwdTwSYrjab
			return this.adUQFIiTvdcxPqpLgQwdTwSYrjab();
		}

		private bool ZIsiIMYgsAnavemRIuzIXMEdNNfl(object P_0)
		{
			return false;
		}

		bool IObjectPool.Return(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZIsiIMYgsAnavemRIuzIXMEdNNfl
			return this.ZIsiIMYgsAnavemRIuzIXMEdNNfl(P_0);
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
