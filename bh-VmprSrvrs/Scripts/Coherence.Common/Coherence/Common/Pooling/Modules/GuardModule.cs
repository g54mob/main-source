using System.Collections.Generic;

namespace Coherence.Common.Pooling.Modules
{
	internal class GuardModule<T> : IPoolModule<T>
	{
		private readonly bool threadSafe;

		private readonly bool enabled;

		private readonly HashSet<T> rented;

		public GuardModule(bool threadSafe = false, bool enabled = true)
		{
		}

		public void OnRent(in T item)
		{
		}

		public void OnReturn(in T item)
		{
		}

		private void VerifyRentedOnce(in T item)
		{
		}

		private void VerifyReturnedWasRented(in T item)
		{
		}

		void IPoolModule<T>.OnRent(in T item)
		{
		}

		void IPoolModule<T>.OnReturn(in T item)
		{
		}
	}
}
