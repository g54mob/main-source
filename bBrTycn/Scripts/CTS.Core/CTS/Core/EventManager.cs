using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public static class EventManager
	{
		public static void SubscribeEvent<TEventArgs>(StringKey eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			SubscribeEvent((int)eventKey.Id, action);
		}

		[Obsolete("Use for debugging purposes only, use the StringKey variant instead")]
		public static void SubscribeEvent<TEventArgs>(string eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			SubscribeEvent(eventKey.GetHashCode(), action);
		}

		public static void SubscribeEvent<TEventArgs>(int eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			if (EventManagerInternal<TEventArgs>.StaticEvents.ContainsKey(eventKey))
			{
				Dictionary<int, Action<TEventArgs>> staticEvents = EventManagerInternal<TEventArgs>.StaticEvents;
				staticEvents[eventKey] = (Action<TEventArgs>)Delegate.Combine(staticEvents[eventKey], action);
			}
			else
			{
				EventManagerInternal<TEventArgs>.StaticEvents[eventKey] = action;
			}
		}

		public static void UnsubscribeEvent<TEventArgs>(StringKey eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			UnsubscribeEvent((int)eventKey.Id, action);
		}

		[Obsolete("Use for debugging purposes only, use the StringKey variant instead")]
		public static void UnsubscribeEvent<TEventArgs>(string eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			UnsubscribeEvent(eventKey.GetHashCode(), action);
		}

		public static void UnsubscribeEvent<TEventArgs>(int eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			if (EventManagerInternal<TEventArgs>.StaticEvents.ContainsKey(eventKey))
			{
				Dictionary<int, Action<TEventArgs>> staticEvents = EventManagerInternal<TEventArgs>.StaticEvents;
				staticEvents[eventKey] = (Action<TEventArgs>)Delegate.Remove(staticEvents[eventKey], action);
			}
		}

		public static void RaiseEvent<TEventArgs>(StringKey eventKey, TEventArgs args) where TEventArgs : struct
		{
			RaiseEvent((int)eventKey.Id, args);
		}

		[Obsolete("Use for debugging purposes only, use the StringKey variant instead")]
		public static void RaiseEvent<TEventArgs>(string eventKey, TEventArgs args) where TEventArgs : struct
		{
			RaiseEvent(eventKey.GetHashCode(), args);
		}

		public static void RaiseEvent<TEventArgs>(int eventKey, TEventArgs args) where TEventArgs : struct
		{
			if (EventManagerInternal<TEventArgs>.StaticEvents.TryGetValue(eventKey, out var value))
			{
				value?.Invoke(args);
			}
		}

		public static void SubscribeEvent<TEventArgs>(this UnityEngine.Object target, StringKey eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			target.SubscribeEvent((int)eventKey.Id, action);
		}

		[Obsolete("Use for debugging purposes only, use the StringKey variant instead")]
		public static void SubscribeEvent<TEventArgs>(this UnityEngine.Object target, string eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			target.SubscribeEvent(eventKey.GetHashCode(), action);
		}

		public static void SubscribeEvent<TEventArgs>(this UnityEngine.Object target, int eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			(UnityEngine.Object, int) tuple = (target, eventKey);
			if (EventManagerInternal<TEventArgs>.ObjectEvents.ContainsKey((target, eventKey)))
			{
				Dictionary<(UnityEngine.Object, int), Action<TEventArgs>> objectEvents = EventManagerInternal<TEventArgs>.ObjectEvents;
				(UnityEngine.Object, int) key = tuple;
				objectEvents[key] = (Action<TEventArgs>)Delegate.Combine(objectEvents[key], action);
			}
			else
			{
				EventManagerInternal<TEventArgs>.ObjectEvents[tuple] = action;
			}
		}

		public static void UnsubscribeEvent<TEventArgs>(this UnityEngine.Object target, StringKey eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			target.UnsubscribeEvent((int)eventKey.Id, action);
		}

		[Obsolete("Use for debugging purposes only, use the StringKey variant instead")]
		public static void UnsubscribeEvent<TEventArgs>(this UnityEngine.Object target, string eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			target.UnsubscribeEvent(eventKey.GetHashCode(), action);
		}

		public static void UnsubscribeEvent<TEventArgs>(this UnityEngine.Object target, int eventKey, Action<TEventArgs> action) where TEventArgs : struct
		{
			(UnityEngine.Object, int) tuple = (target, eventKey);
			if (EventManagerInternal<TEventArgs>.ObjectEvents.ContainsKey(tuple))
			{
				Dictionary<(UnityEngine.Object, int), Action<TEventArgs>> objectEvents = EventManagerInternal<TEventArgs>.ObjectEvents;
				(UnityEngine.Object, int) key = tuple;
				objectEvents[key] = (Action<TEventArgs>)Delegate.Remove(objectEvents[key], action);
			}
		}

		public static void RaiseEvent<TEventArgs>(this UnityEngine.Object target, StringKey eventKey, TEventArgs args) where TEventArgs : struct
		{
			target.RaiseEvent((int)eventKey.Id, args);
		}

		[Obsolete("Use for debugging purposes only, use the StringKey variant instead")]
		public static void RaiseEvent<TEventArgs>(this UnityEngine.Object target, string eventKey, TEventArgs args) where TEventArgs : struct
		{
			target.RaiseEvent(eventKey.GetHashCode(), args);
		}

		public static void RaiseEvent<TEventArgs>(this UnityEngine.Object target, int eventKey, TEventArgs args) where TEventArgs : struct
		{
			(UnityEngine.Object, int) key = (target, eventKey);
			if (EventManagerInternal<TEventArgs>.ObjectEvents.TryGetValue(key, out var value))
			{
				value?.Invoke(args);
			}
		}
	}
}
