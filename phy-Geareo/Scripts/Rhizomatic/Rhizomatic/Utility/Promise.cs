using System;
using UnityEngine.Events;

namespace Rhizomatic.Utility
{
	public class Promise<T>
	{
		public UnityAction<UnityAction<T>, UnityAction<Exception>> body { get; }

		public Promise(UnityAction<UnityAction<T>, UnityAction<Exception>> body)
		{
		}

		public Promise(UnityAction<UnityAction<T>> body)
		{
		}
	}
	public class Promise : Promise<int>
	{
		public Promise(UnityAction<UnityAction, UnityAction<Exception>> body)
			: base((UnityAction<UnityAction<int>, UnityAction<Exception>>)null)
		{
		}

		public Promise(UnityAction<UnityAction> body)
			: base((UnityAction<UnityAction<int>, UnityAction<Exception>>)null)
		{
		}
	}
}
