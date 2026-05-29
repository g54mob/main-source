using System;
using System.Collections.Generic;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	public static class JSONSerializer
	{
		private static object serializerLock;

		private static fsSerializer serializer;

		private static Dictionary<string, fsData> dataCache;

		static JSONSerializer()
		{
		}

		public static void FlushMem()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void __FlushDataCache()
		{
		}

		public static string Serialize(Type type, object instance, List<UnityEngine.Object> references = null, bool pretyJson = false)
		{
			return null;
		}

		public static T Deserialize<T>(string json, List<UnityEngine.Object> references = null)
		{
			return default(T);
		}

		public static object Deserialize(Type type, string json, List<UnityEngine.Object> references = null)
		{
			return null;
		}

		public static T TryDeserializeOverwrite<T>(T instance, string json, List<UnityEngine.Object> references = null) where T : class
		{
			return null;
		}

		public static object TryDeserializeOverwrite(object instance, string json, List<UnityEngine.Object> references = null)
		{
			return null;
		}

		private static object Internal_Deserialize(Type type, string json, List<UnityEngine.Object> references, object instance)
		{
			return null;
		}

		public static void SerializeAndExecuteNoCycles(Type type, object instance, Action<object, fsData> call)
		{
		}

		public static void SerializeAndExecuteNoCycles(Type type, object instance, Action<object> beforeCall, Action<object, fsData> afterCall)
		{
		}

		public static T Clone<T>(T original)
		{
			return default(T);
		}

		public static object Clone(object original)
		{
			return null;
		}

		public static void CopySerialized(object source, object target)
		{
		}

		public static void ShowData(string json, string fileName = "")
		{
		}

		public static string PrettifyJson(string json)
		{
			return null;
		}
	}
}
