using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public static class Database
	{
		private static Dictionary<Type, BaseDataContainer> _instances = new Dictionary<Type, BaseDataContainer>();

		private static BaseDataContainer GetInstance(Type type)
		{
			if (!IsTypeDatabase(type))
			{
				return null;
			}
			if (!_instances.TryGetValue(type, out var value) || value == null)
			{
				if (DatabaseSettings.TryGetDatabase(type, out value))
				{
					return value;
				}
				UnityEngine.Object[] array = Resources.LoadAll("Databases", type);
				if (array != null && array.Length != 0)
				{
					value = array[0] as BaseDataContainer;
					_instances[type] = value;
				}
			}
			return value;
		}

		public static T Get<T>() where T : BaseDataContainer
		{
			return GetInstance(typeof(T)) as T;
		}

		public static BaseDataContainer Get(Type type)
		{
			return GetInstance(type);
		}

		public static void ClearInstances()
		{
			_instances.Clear();
		}

		public static bool IsTypeDatabase(Type type)
		{
			DatabaseAttribute att;
			return IsTypeDatabase(type, out att);
		}

		private static bool IsTypeDatabase(Type type, out DatabaseAttribute att)
		{
			att = null;
			if (type.IsSubclassOf(typeof(BaseDataContainer)))
			{
				return !type.IsAbstract;
			}
			return false;
		}

		private static bool TryGetDatabaseInstance<T>(out T database) where T : BaseDataContainer
		{
			T val = Get<T>();
			if (val != null)
			{
				database = val;
				return true;
			}
			Debug.LogError("This DataContainer type is not a Database");
			database = null;
			return false;
		}

		public static UnityEngine.Object GetDataAtIndex<T>(int index) where T : BaseDataContainer
		{
			if (TryGetDatabaseInstance<T>(out var database))
			{
				return database.GetDataAtIndex(index);
			}
			return null;
		}

		public static U GetDataAtIndex<T, U>(int index) where T : BaseDataContainer where U : UnityEngine.Object, IDataContainerElement
		{
			if (TryGetDatabaseInstance<T>(out var database))
			{
				return database.GetDataAtIndex<U>(index);
			}
			return null;
		}

		public static bool GetDataByUID<T>(int uid, out UnityEngine.Object obj) where T : BaseDataContainer
		{
			if (TryGetDatabaseInstance<T>(out var database))
			{
				return database.TryGetDataByUID(uid, out obj);
			}
			obj = null;
			return false;
		}

		public static bool GetDataByUID<T, U>(int uid, out U data) where T : BaseDataContainer where U : UnityEngine.Object, IDataContainerElement
		{
			if (TryGetDatabaseInstance<T>(out var database))
			{
				return database.TryGetDataByUID(uid, out data);
			}
			data = null;
			return false;
		}

		public static IEnumerator Enumerate<T>() where T : BaseDataContainer
		{
			if (!TryGetDatabaseInstance<T>(out var database))
			{
				yield break;
			}
			foreach (object item in (IEnumerable)database)
			{
				yield return item;
			}
		}

		public static IEnumerable<U> Enumerate<T, U>() where T : BaseDataContainer where U : UnityEngine.Object, IDataContainerElement
		{
			if (!TryGetDatabaseInstance<T>(out var database))
			{
				yield break;
			}
			foreach (U item in database.GetDataEnumerator<U>())
			{
				yield return item;
			}
		}
	}
}
