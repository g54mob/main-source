using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ParadoxNotion.Serialization.FullSerializer;
using ParadoxNotion.Serialization.FullSerializer.Internal;
using ParadoxNotion.Services;
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
			serializerLock = new object();
			FlushMem();
		}

		public static void FlushMem()
		{
			serializer = new fsSerializer();
			dataCache = new Dictionary<string, fsData>();
			fsMetaType.FlushMem();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void __FlushDataCache()
		{
			dataCache = new Dictionary<string, fsData>();
		}

		public static string Serialize(Type type, object instance, List<UnityEngine.Object> references = null, bool pretyJson = false)
		{
			lock (serializerLock)
			{
				serializer.PurgeTemporaryData();
				serializer.ReferencesDatabase = references;
				Type overrideConverterType = (typeof(UnityEngine.Object).RTIsAssignableFrom(type) ? typeof(fsReflectedConverter) : null);
				_ = serializer.TrySerialize(type, instance, out var data, overrideConverterType).AssertSuccess().HasWarnings;
				serializer.ReferencesDatabase = null;
				string text = fsJsonPrinter.ToJson(data, pretyJson);
				if (Threader.applicationIsPlaying || Application.isPlaying)
				{
					dataCache[text] = data;
				}
				return text;
			}
		}

		public static T Deserialize<T>(string json, List<UnityEngine.Object> references = null)
		{
			return (T)Internal_Deserialize(typeof(T), json, references, null);
		}

		public static object Deserialize(Type type, string json, List<UnityEngine.Object> references = null)
		{
			return Internal_Deserialize(type, json, references, null);
		}

		public static T TryDeserializeOverwrite<T>(T instance, string json, List<UnityEngine.Object> references = null) where T : class
		{
			return (T)Internal_Deserialize(typeof(T), json, references, instance);
		}

		public static object TryDeserializeOverwrite(object instance, string json, List<UnityEngine.Object> references = null)
		{
			return Internal_Deserialize(instance.GetType(), json, references, instance);
		}

		private static object Internal_Deserialize(Type type, string json, List<UnityEngine.Object> references, object instance)
		{
			lock (serializerLock)
			{
				serializer.PurgeTemporaryData();
				fsData value = null;
				if (Threader.applicationIsPlaying)
				{
					if (!dataCache.TryGetValue(json, out value))
					{
						value = (dataCache[json] = fsJsonParser.Parse(json));
					}
				}
				else
				{
					value = fsJsonParser.Parse(json);
				}
				serializer.ReferencesDatabase = references;
				Type overrideConverterType = ((instance is UnityEngine.Object) ? typeof(fsReflectedConverter) : null);
				_ = serializer.TryDeserialize(value, type, ref instance, overrideConverterType).AssertSuccess().HasWarnings;
				serializer.ReferencesDatabase = null;
				return instance;
			}
		}

		public static void SerializeAndExecuteNoCycles(Type type, object instance, Action<object, fsData> call)
		{
			lock (serializerLock)
			{
				serializer.IgnoreSerializeCycleReferences = true;
				serializer.onAfterObjectSerialized += call;
				try
				{
					Serialize(type, instance);
				}
				finally
				{
					serializer.IgnoreSerializeCycleReferences = false;
					serializer.onAfterObjectSerialized -= call;
				}
			}
		}

		public static void SerializeAndExecuteNoCycles(Type type, object instance, Action<object> beforeCall, Action<object, fsData> afterCall)
		{
			lock (serializerLock)
			{
				serializer.IgnoreSerializeCycleReferences = true;
				serializer.onBeforeObjectSerialized += beforeCall;
				serializer.onAfterObjectSerialized += afterCall;
				try
				{
					Serialize(type, instance);
				}
				finally
				{
					serializer.IgnoreSerializeCycleReferences = false;
					serializer.onBeforeObjectSerialized -= beforeCall;
					serializer.onAfterObjectSerialized -= afterCall;
				}
			}
		}

		public static T Clone<T>(T original)
		{
			return (T)Clone((object)original);
		}

		public static object Clone(object original)
		{
			Type type = original.GetType();
			List<UnityEngine.Object> references = new List<UnityEngine.Object>();
			string json = Serialize(type, original, references);
			return Deserialize(type, json, references);
		}

		public static void CopySerialized(object source, object target)
		{
			Type type = source.GetType();
			List<UnityEngine.Object> references = new List<UnityEngine.Object>();
			string json = Serialize(type, source, references);
			TryDeserializeOverwrite(target, json, references);
		}

		public static void ShowData(string json, string fileName = "")
		{
			string contents = PrettifyJson(json);
			string text = Path.GetTempPath() + (string.IsNullOrEmpty(fileName) ? Guid.NewGuid().ToString() : fileName) + ".json";
			File.WriteAllText(text, contents);
			Process.Start(text);
		}

		public static string PrettifyJson(string json)
		{
			return fsJsonPrinter.PrettyJson(fsJsonParser.Parse(json));
		}
	}
}
