using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	internal static class EventManagerInternal<TEventArgs> where TEventArgs : struct
	{
		internal static readonly Dictionary<int, Action<TEventArgs>> StaticEvents = new Dictionary<int, Action<TEventArgs>>();

		internal static readonly Dictionary<(UnityEngine.Object, int), Action<TEventArgs>> ObjectEvents = new Dictionary<(UnityEngine.Object, int), Action<TEventArgs>>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			StaticEvents.Clear();
			ObjectEvents.Clear();
		}
	}
}
