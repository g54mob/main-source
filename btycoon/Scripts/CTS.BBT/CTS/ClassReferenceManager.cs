using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public static class ClassReferenceManager
	{
		private static Dictionary<Guid, object> _refs = new Dictionary<Guid, object>();

		private static readonly Dictionary<object, Guid> _objectsDictionary = new Dictionary<object, Guid>();

		private static readonly Dictionary<Guid, object> _saveDictionary = new Dictionary<Guid, object>();

		public static bool Dirty { get; set; } = true;

		public static void Clear()
		{
			_refs.Clear();
			_objectsDictionary.Clear();
		}

		public static Guid GetOrCreateRef<T>(T obj) where T : class
		{
			if (obj == null)
			{
				return default(Guid);
			}
			if (!_objectsDictionary.TryGetValue(obj, out var value))
			{
				value = Guid.NewGuid();
				_objectsDictionary[obj] = value;
				_refs[value] = obj;
				Dirty = true;
			}
			return value;
		}

		public static void SaveValues(ES3Settings settings)
		{
			if (_refs.Count <= 0)
			{
				return;
			}
			Dirty = true;
			int num = 0;
			while (Dirty && num < 10)
			{
				Dirty = false;
				_saveDictionary.Clear();
				foreach (var (key, value) in _refs)
				{
					_saveDictionary[key] = value;
				}
				ES3.Save("ClassReferences", _saveDictionary, settings);
				num++;
			}
		}

		public static void LoadValues(ES3Settings settings)
		{
			Clear();
			if (!ES3.KeyExists("ClassReferences", settings))
			{
				return;
			}
			try
			{
				LoadPass();
				LoadIntoPass();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Clear();
			}
			void LoadIntoPass()
			{
				ES3.LoadInto("ClassReferences", _refs, settings);
			}
			void LoadPass()
			{
				_refs = ES3.Load<Dictionary<Guid, object>>("ClassReferences", settings);
				_objectsDictionary.Clear();
				foreach (var (value, key) in _refs)
				{
					_objectsDictionary[key] = value;
				}
			}
		}

		public static void WriteClassRefProperty<T>(this ES3Writer writer, string key, T obj) where T : class
		{
			writer.WriteProperty<ClassRef<T>>(key, new ClassRef<T>(obj));
		}

		public static T ReadClassRef<T>(this ES3Reader reader, string key) where T : class
		{
			return GetClass<T>(reader.Read(key, default(ClassRef<T>)).Ref);
		}

		public static T ReadClassRef<T>(this ES3Reader reader) where T : class
		{
			return GetClass<T>(reader.Read<ClassRef<T>>().Ref);
		}

		public static T GetClass<T>(Guid guid) where T : class
		{
			if (guid == default(Guid))
			{
				return null;
			}
			if (_refs.TryGetValue(guid, out var value))
			{
				return value as T;
			}
			return null;
		}
	}
}
