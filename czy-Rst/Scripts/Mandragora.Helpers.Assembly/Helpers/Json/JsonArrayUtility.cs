using System;
using UnityEngine;

namespace Helpers.Json
{
	public static class JsonArrayUtility
	{
		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}

		public static T[] FromJson<T>(string json)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			T[] result = new T[0];
			try
			{
				wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
				if (wrapper == null || wrapper.Items == null)
				{
					return result;
				}
				result = wrapper.Items;
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Debug.LogErrorFormat("Unity Amicum: JsonArrayUtility can't parse next message: {0}\nError message: {1}", json, ex);
			}
			return result;
		}

		public static string ToJson<T>(T[] array)
		{
			return JsonUtility.ToJson(new Wrapper<T>
			{
				Items = array
			});
		}

		public static string ToJson<T>(T[] array, bool prettyPrint)
		{
			return JsonUtility.ToJson(new Wrapper<T>
			{
				Items = array
			}, prettyPrint);
		}
	}
}
