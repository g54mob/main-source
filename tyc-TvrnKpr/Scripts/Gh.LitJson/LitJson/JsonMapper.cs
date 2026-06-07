using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Gh;

namespace LitJson
{
	public class JsonMapper
	{
		private class ExportHandler
		{
			public Func<object, bool> CanHandle { get; set; }

			public Action<object, JsonWriter> Export { get; set; }
		}

		private static readonly int maxNestingDepth;

		private static readonly IFormatProvider datetimeFormat;

		private static readonly IDictionary<Type, ExporterFunc> baseExportTable;

		private static readonly IDictionary<Type, ExporterFunc> customExportTable;

		private static readonly IDictionary<Type, IDictionary<Type, ImporterFunc>> baseImportTable;

		private static readonly IDictionary<Type, IDictionary<Type, ImporterFunc>> customImportTable;

		private static readonly IDictionary<Type, FactoryFunc> customFactoryTable;

		private static readonly IDictionary<Type, ArrayMetadata> arrayMetadata;

		private static readonly IDictionary<Type, IDictionary<Type, MethodInfo>> convOps;

		private static readonly IDictionary<Type, ObjectMetadata> objectMetadata;

		private static List<ExportHandler> _exportHandlers;

		static JsonMapper()
		{
		}

		private static ArrayMetadata AddArrayMetadata(Type type)
		{
			return default(ArrayMetadata);
		}

		private static ObjectMetadata AddObjectMetadata(Type type)
		{
			return default(ObjectMetadata);
		}

		private static object CreateInstance(Type type)
		{
			return null;
		}

		private static MethodInfo GetConvOp(Type t1, Type t2)
		{
			return null;
		}

		private static ImporterFunc GetImporter(Type jsonType, Type valueType)
		{
			return null;
		}

		private static ExporterFunc GetExporter(Type valueType)
		{
			return null;
		}

		private static object ReadValue(Type instType, JsonReader reader, bool returnDefaultForNullValues = false)
		{
			return null;
		}

		private static ReferencableLookupKey ReadReferencableId(JsonReader reader)
		{
			return default(ReferencableLookupKey);
		}

		private static IJsonWrapper ReadValue(WrapperFactory factory, JsonReader reader)
		{
			return null;
		}

		private static void ReadSkip(JsonReader reader)
		{
		}

		private static void RegisterBaseExporters()
		{
		}

		private static void RegisterBaseImporters()
		{
		}

		private static void RegisterImporter(IDictionary<Type, IDictionary<Type, ImporterFunc>> table, Type jsonType, Type valueType, ImporterFunc importer)
		{
		}

		private static void WriteValue(object obj, JsonWriter writer, bool privateWriter, int depth)
		{
		}

		public static string ToJson(object obj)
		{
			return null;
		}

		public static void ToJson(object obj, JsonWriter writer)
		{
		}

		public static JsonData ToObject(JsonReader reader)
		{
			return null;
		}

		public static JsonData ToObject(TextReader reader)
		{
			return null;
		}

		public static JsonData ToObject(string json)
		{
			return null;
		}

		public static T ToObject<T>(JsonReader reader)
		{
			return default(T);
		}

		public static T ToObject<T>(TextReader reader)
		{
			return default(T);
		}

		public static T ToObject<T>(string json)
		{
			return default(T);
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, JsonReader reader)
		{
			return null;
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, string json)
		{
			return null;
		}

		public static void RegisterExporter<T>(ExporterFunc<T> exporter)
		{
		}

		public static void RegisterImporter<TJson, TValue>(ImporterFunc<TJson, TValue> importer)
		{
		}

		public static void RegisterFactory<T>(FactoryFunc<T> factory)
		{
		}

		public static void UnregisterFactories()
		{
		}

		public static void UnregisterExporters()
		{
		}

		public static void UnregisterImporters()
		{
		}

		public static void AddExportHandler(Func<object, bool> canHandle, Action<object, JsonWriter> export)
		{
		}

		protected static bool TryExport(object o, JsonWriter writer)
		{
			return false;
		}

		private static void LoadFieldAsPersistenceObjectReference(JsonReader reader, object instance, FieldInfo fInfo)
		{
		}
	}
}
