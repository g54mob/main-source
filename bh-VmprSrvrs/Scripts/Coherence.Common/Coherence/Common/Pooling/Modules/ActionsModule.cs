using System;
using System.Collections.Generic;

namespace Coherence.Common.Pooling.Modules
{
	internal class ActionsModule<T> : IPoolModule<T>
	{
		private List<Action<T>> rentActions;

		private List<Action<T>> returnActions;

		public ActionsModule<T> WithRentAction(Action<T> action)
		{
			return null;
		}

		public ActionsModule<T> WithReturnAction(Action<T> action)
		{
			return null;
		}

		public void OnRent(in T item)
		{
		}

		public void OnReturn(in T item)
		{
		}

		public void AddRentAction(Action<T> action)
		{
		}

		public void AddReturnAction(Action<T> action)
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
