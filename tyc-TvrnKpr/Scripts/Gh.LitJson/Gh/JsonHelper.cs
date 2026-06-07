using System.Collections.Generic;
using System.IO;
using LitJson;

namespace Gh
{
	public static class JsonHelper
	{
		public static string ToJson(object o)
		{
			return null;
		}

		public static T ToObject<T>(string json)
		{
			return default(T);
		}

		public static JsonData ToData(string json)
		{
			return null;
		}

		public static Dictionary<string, object> ToDictionary(string json)
		{
			return null;
		}

		internal static Dictionary<string, object> ToDictionary(JsonData data)
		{
			return null;
		}

		private static object ToPersistable(JsonData val)
		{
			return null;
		}

		public static Stream ToJsonTextStream(object obj)
		{
			return null;
		}
	}
}
