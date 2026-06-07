using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Gh.Tk;
using LitJson;
using UnityEngine.Scripting;

namespace Gh
{
	[InitializeOnGameStarted]
	public static class SaveLoadExtensions
	{
		public class DetailedInfo
		{
			public bool hasPersistenceObjectReferenceAttribute;

			public bool isAssignableFromGameItem;

			public bool hasPersistenceDefaultValueAttribute;

			public bool hasPersistenceAllowBrokenReferenceOnLoadAttribute;

			public object defaultValue;
		}

		public class DetailedPropertyInfo : DetailedInfo
		{
			public PropertyInfo propertyInfo;
		}

		public class DetailedFieldInfo : DetailedInfo
		{
			public FieldInfo fieldInfo;
		}

		private static readonly Dictionary<Type, Dictionary<string, DetailedPropertyInfo>> _propertyInfosCache;

		private static readonly Dictionary<Type, Dictionary<string, DetailedFieldInfo>> _fieldInfosCache;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public static Dictionary<string, DetailedPropertyInfo> GetPropertyInfosCache(Type type)
		{
			return null;
		}

		public static Dictionary<string, DetailedFieldInfo> GetFieldInfosCache(Type type)
		{
			return null;
		}

		public static DetailedFieldInfo GetDetailedFieldInfoForPersistence(this Type type, string name)
		{
			return null;
		}

		public static DetailedPropertyInfo GetDetailedPropertyInfoForPersistence(this Type type, string name)
		{
			return null;
		}

		public static void SetDefaultPersistenceValues(object o)
		{
		}

		public static object ToObject(this JsonData data, Type targetType)
		{
			return null;
		}

		public static T ToObject<T>(this JsonData data)
		{
			return default(T);
		}

		private static object TryLoadingGenericDictionary(Type type, JsonData data)
		{
			return null;
		}

		private static object LoadArrayOrList(Type type, JsonData data)
		{
			return null;
		}

		private static void QueueResolvedArrayItemReference(JsonData data, IList array, string fieldName, bool allowBrokenReference)
		{
		}

		private static void QueueAddResolvedListItemReferences(JsonData data, IList list, string fieldName, bool allowBrokenReference)
		{
		}

		public static T ApplyToObject<T>(this JsonData data, T obj)
		{
			return default(T);
		}

		public static bool ContainsKey(this JsonData data, string name)
		{
			return false;
		}

		public static JsonData GetObjectOrNull(this JsonData data, string name)
		{
			return null;
		}

		public static DateTime ParseDateTime(string value)
		{
			return default(DateTime);
		}
	}
}
