using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.JObjectExtstensions
{
	public static class JObjectExtensions
	{
		public static int? GetInt(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Integer)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested int), returning null");
				return null;
			}
			return jToken.ToObject<int>();
		}

		public static void SetInt(this JObject dataObject, string key, int value)
		{
			dataObject[key] = value;
		}

		public static int[] GetIntArray(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Array)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested int array), returning null");
				return null;
			}
			return jToken.ToObject<int[]>();
		}

		public static void SetIntArray(this JObject dataObject, string key, int[] value)
		{
			dataObject[key] = new JArray(value);
		}

		public static float? GetFloat(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Float && jToken.Type != JTokenType.Integer)
			{
				Debug.LogWarning($"Found property '{key}' but it's type is {jToken.Type} (requested float), returning null");
				return null;
			}
			return jToken.ToObject<float>();
		}

		public static void SetFloat(this JObject dataObject, string key, float value)
		{
			dataObject[key] = value;
		}

		public static double? GetDouble(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Float && jToken.Type != JTokenType.Integer)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested double), returning null");
				return null;
			}
			return jToken.ToObject<double>();
		}

		public static void SetDouble(this JObject dataObject, string key, double value)
		{
			dataObject[key] = value;
		}

		public static string GetString(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.String)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested string), returning null");
				return null;
			}
			return jToken.ToObject<string>();
		}

		public static void SetString(this JObject dataObject, string key, string value)
		{
			dataObject[key] = value;
		}

		public static string[] GetStringArray(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Array)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested string array), returning null");
				return null;
			}
			return jToken.ToObject<string[]>();
		}

		public static void SetStringArray(this JObject dataObject, string key, string[] value)
		{
			dataObject[key] = new JArray(value);
		}

		public static bool? GetBool(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Boolean)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested bool), returning null");
				return null;
			}
			return jToken.ToObject<bool>();
		}

		public static void SetBool(this JObject dataObject, string key, bool value)
		{
			dataObject[key] = value;
		}

		public static Vector3? GetVector3(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Object)
			{
				Debug.LogWarning(string.Format("Found property '{0}' but its type is {1} (requested {2}), returning null", key, jToken.Type, "Vector3"));
				return null;
			}
			return jToken.ToObject<Vector3>();
		}

		public static void SetVector3(this JObject dataObject, string key, Vector3 value)
		{
			dataObject[key] = GetJObjectFromVector3(value);
		}

		public static void SetVector3Array(this JObject dataObject, string key, Vector3[] value)
		{
			if (value == null)
			{
				Debug.LogWarning("Given array is null - SetVector3Array skipping.");
				return;
			}
			int num = value.Length;
			JObject[] array = new JObject[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = GetJObjectFromVector3(value[i]);
			}
			dataObject.SetJObjectArray(key, array);
		}

		public static Vector3?[] GetVector3Array(this JObject dataObject, string key)
		{
			JObject[] jObjectArray = dataObject.GetJObjectArray(key);
			if (jObjectArray == null)
			{
				return null;
			}
			int num = jObjectArray.Length;
			Vector3?[] array = new Vector3?[num];
			for (int i = 0; i < num; i++)
			{
				JObject jObject = jObjectArray[i];
				if (jObject.Type != JTokenType.Object)
				{
					Debug.LogWarning(string.Format("Found property '{0}' but its type is {1} (requested {2}), setting array element {3} to null.", key, jObject.Type, "Vector3", i));
					array[i] = null;
				}
				else
				{
					array[i] = jObject.ToObject<Vector3>();
				}
			}
			return array;
		}

		private static JObject GetJObjectFromVector3(Vector3 value)
		{
			return new JObject(new JProperty("x", value.x), new JProperty("y", value.y), new JProperty("z", value.z));
		}

		public static JObject GetJObject(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null || jToken.Type == JTokenType.Null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Object)
			{
				Debug.LogWarning(string.Format("Found property '{0}' but its type is {1} (requested {2}), returning null", key, jToken.Type, "JObject"));
				return null;
			}
			return jToken.ToObject<JObject>();
		}

		public static void SetJObject(this JObject dataObject, string key, JObject value)
		{
			dataObject[key] = value;
		}

		public static JObject[] GetJObjectArray(this JObject dataObject, string key)
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			if (jToken.Type != JTokenType.Array)
			{
				Debug.LogWarning($"Found property '{key}' but its type is {jToken.Type} (requested JObject array), returning null");
				return null;
			}
			return jToken.ToObject<JObject[]>();
		}

		public static void SetJObjectArray(this JObject dataObject, string key, JObject[] value)
		{
			object value2;
			if (value == null)
			{
				value2 = null;
			}
			else
			{
				value2 = new JArray(value);
			}
			dataObject[key] = (JToken)value2;
		}

		public static void SetObjectViaJSON(this JObject dataObject, string key, object value, JsonSerializerSettings serializerSettings = null)
		{
			if (!value.GetType().IsClass)
			{
				Debug.LogError($"SetObject currently only supports Classes but passed object is of type {value.GetType()}. Object serialization aborted.");
			}
			else
			{
				dataObject[key] = JsonConvert.SerializeObject(value, serializerSettings);
			}
		}

		public static T GetObjectViaJSON<T>(this JObject dataObject, string key, JsonSerializerSettings serializerSettings = null) where T : class
		{
			JToken jToken = dataObject[key];
			if (jToken == null)
			{
				return null;
			}
			return JsonConvert.DeserializeObject<T>(jToken.ToString(), serializerSettings);
		}

		public static T GetValueOrDefault<T>(this JObject dataObject, string key, T defaultValue)
		{
			if (dataObject == null || string.IsNullOrEmpty(key))
			{
				return defaultValue;
			}
			JToken jToken = dataObject[key];
			if (jToken != null)
			{
				try
				{
					return jToken.Value<T>();
				}
				catch (Exception)
				{
					return defaultValue;
				}
			}
			return defaultValue;
		}

		public static void AddToStringArray(this JObject dataObject, string key, string value, bool enforceUnique = false)
		{
			JArray jArray;
			if (dataObject.TryGetValue(key, out var value2))
			{
				jArray = value2 as JArray;
			}
			else
			{
				dataObject.Add(key, jArray = new JArray());
			}
			if (!enforceUnique || !jArray.Contains(value))
			{
				jArray.Add(value);
			}
		}
	}
}
