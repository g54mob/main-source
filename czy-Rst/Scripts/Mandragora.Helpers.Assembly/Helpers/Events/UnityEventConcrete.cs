using System;
using UnityEngine.Events;

namespace Helpers.Events
{
	[Serializable]
	public class UnityEventConcrete<T> : UnityEvent<T>
	{
	}
	[Serializable]
	public class UnityEventConcrete<T0, T1> : UnityEvent<T0, T1>
	{
	}
	[Serializable]
	public class UnityEventConcrete<T0, T1, T2> : UnityEvent<T0, T1, T2>
	{
	}
	[Serializable]
	public class UnityEventConcrete<T0, T1, T2, T3> : UnityEvent<T0, T1, T2, T3>
	{
	}
}
