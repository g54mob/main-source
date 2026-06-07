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

		private ulong SuyafVHJxmwFeVDiwIkbrjLzUIhP;

		protected ulong InstanceCount => 0uL;

		public ObjectPool(int startingSize, Func<T> createInstanceDelegate, Action<T> processOnReturnDelegate = null)
		{
		}

		public ObjectPool(Func<T> instancerDelegate)
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

		private object GUnteehldmqppZtXfguSPMuVsgS()
		{
			return null;
		}

		object IObjectPool.Get()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GUnteehldmqppZtXfguSPMuVsgS
			return this.GUnteehldmqppZtXfguSPMuVsgS();
		}

		private bool ASfItqtqUtchGAJkEQgTHhVHGGfi(object P_0)
		{
			return false;
		}

		bool IObjectPool.Return(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ASfItqtqUtchGAJkEQgTHhVHGGfi
			return this.ASfItqtqUtchGAJkEQgTHhVHGGfi(P_0);
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
