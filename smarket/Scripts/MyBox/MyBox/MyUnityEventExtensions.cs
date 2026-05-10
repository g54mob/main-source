using JetBrains.Annotations;
using UnityEngine.Events;

namespace MyBox
{
	[PublicAPI]
	public static class MyUnityEventExtensions
	{
		public static UnityEvent Once(this UnityEvent source, UnityAction action)
		{
			return null;
		}

		public static UnityEvent<T> Once<T>(this UnityEvent<T> source, UnityAction<T> action)
		{
			return null;
		}

		public static UnityEvent<T0, T1> Once<T0, T1>(this UnityEvent<T0, T1> source, UnityAction<T0, T1> action)
		{
			return null;
		}

		public static UnityEvent<T0, T1, T2> Once<T0, T1, T2>(this UnityEvent<T0, T1, T2> source, UnityAction<T0, T1, T2> action)
		{
			return null;
		}

		public static UnityEvent<T0, T1, T2, T3> Once<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> source, UnityAction<T0, T1, T2, T3> action)
		{
			return null;
		}
	}
}
