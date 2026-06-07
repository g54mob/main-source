using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectPool<T> : IObjectPool, IObjectPool<T> where T : class
	{
		protected readonly Queue<T> _pool;

		protected readonly Func<T> _createInstanceDelegate;

		protected readonly Action<T> _processOnReturnDelegate;

		private ulong GLddPruxWirtKIvWqBbXZvenluNy;

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

		private object cHisVEmRuKGYwqRMWYviZxRAScLV()
		{
			return null;
		}

		object IObjectPool.Get()
		{
			//ILSpy generated this explicit interface implementation from .override directive in cHisVEmRuKGYwqRMWYviZxRAScLV
			return this.cHisVEmRuKGYwqRMWYviZxRAScLV();
		}

		private bool LuesDksRDjrSBSWpbaUGZoAxpsFS(object P_0)
		{
			return false;
		}

		bool IObjectPool.Return(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in LuesDksRDjrSBSWpbaUGZoAxpsFS
			return this.LuesDksRDjrSBSWpbaUGZoAxpsFS(P_0);
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
