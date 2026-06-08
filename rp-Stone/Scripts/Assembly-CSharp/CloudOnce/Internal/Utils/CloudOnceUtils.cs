using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace CloudOnce.Internal.Utils
{
	public static class CloudOnceUtils
	{
		public static IAchievementUtils AchievementUtils { get; private set; }

		public static ILeaderboardUtils LeaderboardUtils { get; private set; }

		static CloudOnceUtils()
		{
			AchievementUtils = new EditorAchievementUtils();
			LeaderboardUtils = new EditorLeaderboardUtils();
		}

		public static string ToBase64String(this string str)
		{
			if (str == null)
			{
				str = string.Empty;
			}
			return Convert.ToBase64String(Encoding.Default.GetBytes(str));
		}

		public static string FromBase64StringToString(this string base64String)
		{
			if (base64String == null)
			{
				base64String = string.Empty;
			}
			byte[] bytes = Convert.FromBase64String(base64String);
			return Encoding.Default.GetString(bytes);
		}

		public static IEnumerator InvokeUnscaledTime(UnityAction callback, float time)
		{
			if (callback != null)
			{
				float startTime = Time.unscaledTime;
				while (Time.unscaledTime - startTime < time)
				{
					yield return null;
				}
				callback();
			}
		}

		public static IEnumerator InvokeUnscaledTime<T>(UnityAction<T> callback, T parameter, float time)
		{
			if (callback != null)
			{
				float startTime = Time.unscaledTime;
				while (Time.unscaledTime - startTime < time)
				{
					yield return null;
				}
				callback(parameter);
			}
		}

		public static void SafeInvoke(Action action)
		{
			action?.Invoke();
		}

		public static void SafeInvoke(UnityAction unityAction)
		{
			unityAction?.Invoke();
		}

		public static void SafeInvoke<T>(Action<T> action, T param)
		{
			action?.Invoke(param);
		}

		public static void SafeInvoke<T>(UnityAction<T> unityAction, T param)
		{
			unityAction?.Invoke(param);
		}

		public static bool IsJson(this string input)
		{
			input = input.TrimStart();
			if (!input.StartsWith("{"))
			{
				return input.StartsWith("[");
			}
			return true;
		}

		public static string GetAlias(string className, JSONObject jsonObject, params string[] aliases)
		{
			foreach (string text in aliases)
			{
				if (jsonObject.HasFields(text))
				{
					return text;
				}
			}
			throw new SerializationException("JSONObject missing fields, cannot deserialize to " + className);
		}
	}
}
