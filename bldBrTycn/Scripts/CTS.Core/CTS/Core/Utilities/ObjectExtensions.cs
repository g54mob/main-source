using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class ObjectExtensions
	{
		private static readonly Dictionary<UnityEngine.Object, Dictionary<string, (float, bool)>> _cooldowns = new Dictionary<UnityEngine.Object, Dictionary<string, (float, bool)>>();

		public static T Cast<T>(this object p_object) where T : class
		{
			return (T)p_object;
		}

		public static bool EqualsNull(this object obj)
		{
			return obj?.Equals(null) ?? true;
		}

		[Obsolete("Use for testing purposes only")]
		public static void StartTimer(this UnityEngine.Object obj, string name, float duration, bool scaledTime = true)
		{
			if (!_cooldowns.ContainsKey(obj))
			{
				_cooldowns.Add(obj, new Dictionary<string, (float, bool)>());
			}
			Dictionary<string, (float, bool)> dictionary = _cooldowns[obj];
			float item = (scaledTime ? (Time.time + duration) : (Time.unscaledTime + duration));
			dictionary[name] = (item, scaledTime);
		}

		[Obsolete("Use for testing purposes only")]
		public static bool IsTimerOver(this UnityEngine.Object obj, string name)
		{
			if (!_cooldowns.TryGetValue(obj, out var value))
			{
				return true;
			}
			if (!value.TryGetValue(name, out var value2))
			{
				return true;
			}
			if (!value2.Item2)
			{
				return Time.unscaledTime >= value2.Item1;
			}
			return Time.time >= value2.Item1;
		}
	}
}
