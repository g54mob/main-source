using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.SaveLoad
{
	public static class SaveSystemExtensions
	{
		public static bool TryGetCapturedData<TCaptured, TResult>(this object capturedObject, out TResult restoredData) where TCaptured : Component
		{
			Dictionary<string, object> obj = (Dictionary<string, object>)capturedObject;
			string key = typeof(TCaptured).ToString();
			object value;
			bool result = obj.TryGetValue(key, out value);
			restoredData = (TResult)value;
			return result;
		}

		public static object GetCapturedData<T>(this object capturedObject) where T : Component
		{
			Dictionary<string, object> obj = (Dictionary<string, object>)capturedObject;
			string key = typeof(T).ToString();
			if (obj.TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}

		public static void SetCapturedData<T>(this object capturedObject, object newValue) where T : Component
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)capturedObject;
			string key = typeof(T).ToString();
			if (dictionary.ContainsKey(key))
			{
				dictionary[key] = newValue;
			}
		}
	}
}
