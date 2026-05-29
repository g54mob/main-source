using System;
using UnityEngine;
using com.ootii.Utilities;

namespace com.ootii.Data.Serializers
{
	public class JSONSerializer
	{
		public const string RootObjectID = "[OOTII_ROOT]";

		public static GameObject RootObject;

		public static string Serialize(object rObject, bool rIncludeProperties)
		{
			return null;
		}

		public static string Serialize(object rObject)
		{
			return null;
		}

		public static string SerializeValue(string rName, object rValue)
		{
			return null;
		}

		public static Type GetType(string rJSON)
		{
			return null;
		}

		public static Type GetType(JSONNode rNode)
		{
			return null;
		}

		public static Type GetType(string rJSON, string rTypeKey, out bool rUpdateType)
		{
			rUpdateType = default(bool);
			return null;
		}

		public static T DeserializeValue<T>(string rJSON)
		{
			return default(T);
		}

		public static T Deserialize<T>(string rJSON)
		{
			return default(T);
		}

		public static object Deserialize(string rJSON)
		{
			return null;
		}

		public static void DeserializeInto(string rJSON, ref object rObject)
		{
		}

		private static string SerializeValue(object rValue)
		{
			return null;
		}

		private static object DeserializeValue(Type rType, JSONNode rValue)
		{
			return null;
		}

		private static bool IsSimpleType(Type rType)
		{
			return false;
		}

		public static string GetFullPath(Transform rTransform)
		{
			return null;
		}

		public static string ReplaceFirst(string rText, string rSearch, string rReplace)
		{
			return null;
		}
	}
}
