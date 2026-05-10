using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS.Core
{
	public static class Tags
	{
		private static readonly Stack<HashSet<StringKey>> _hashSetPool = new Stack<HashSet<StringKey>>();

		private static readonly Dictionary<GameObject, HashSet<StringKey>> _goTags = new Dictionary<GameObject, HashSet<StringKey>>();

		private static readonly Dictionary<ScriptableObject, HashSet<StringKey>> _soTags = new Dictionary<ScriptableObject, HashSet<StringKey>>();

		private static readonly HashSet<GameObject> _goTemp = new HashSet<GameObject>();

		private static readonly HashSet<ScriptableObject> _soTemp = new HashSet<ScriptableObject>();

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			_goTags.Clear();
			_soTags.Clear();
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
			Application.quitting -= OnApplicationQuit;
			Application.quitting += OnApplicationQuit;
		}

		private static void OnApplicationQuit()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			Application.quitting -= OnApplicationQuit;
		}

		private static void OnSceneUnloaded(Scene scene)
		{
			Clear<ScriptableObject>(_soTemp, _soTags);
			Clear<GameObject>(_goTemp, _goTags);
			static void Clear<T>(HashSet<T> tempSet, Dictionary<T, HashSet<StringKey>> tags) where T : Object
			{
				tempSet.Clear();
				foreach (T key in tags.Keys)
				{
					if (key == null)
					{
						tempSet.Add(key);
					}
				}
				foreach (T item in tempSet)
				{
					RemoveAllTags(item, tags);
				}
			}
		}

		public static void AddTag(this GameObject obj, StringKey tag)
		{
			AddTag(obj, tag, _goTags);
		}

		public static void AddTag(this Component obj, StringKey tag)
		{
			obj.gameObject.AddTag(tag);
		}

		public static void AddTag(this ScriptableObject so, StringKey tag)
		{
			AddTag(so, tag, _soTags);
		}

		public static void AddTags<TSet>(this GameObject obj, TSet set) where TSet : IEnumerable<StringKey>
		{
			AddTags(obj, set, _goTags);
		}

		public static void AddTags<TSet>(this Component obj, TSet set) where TSet : IEnumerable<StringKey>
		{
			obj.gameObject.AddTags(set);
		}

		public static void AddTags<TSet>(this ScriptableObject obj, TSet set) where TSet : IEnumerable<StringKey>
		{
			AddTags(obj, set, _soTags);
		}

		public static void RemoveTag(this GameObject obj, StringKey tag)
		{
			RemoveTag(obj, tag, _goTags);
		}

		public static void RemoveTag(this Component obj, StringKey tag)
		{
			obj.gameObject.RemoveTag(tag);
		}

		public static void RemoveTag(this ScriptableObject so, StringKey tag)
		{
			RemoveTag(so, tag, _soTags);
		}

		public static bool HasTag(this GameObject obj, StringKey tag)
		{
			return HasTag(obj, tag, _goTags);
		}

		public static bool HasTag(this Component obj, StringKey tag)
		{
			return obj.gameObject.HasTag(tag);
		}

		public static bool HasTag(this ScriptableObject so, StringKey tag)
		{
			return HasTag(so, tag, _soTags);
		}

		public static void RemoveAllTags(this GameObject obj)
		{
			RemoveAllTags(obj, _goTags);
		}

		public static void RemoveAllTags(this Component obj)
		{
			obj.gameObject.RemoveAllTags();
		}

		public static void RemoveAllTags(this ScriptableObject so)
		{
			RemoveAllTags(so, _soTags);
		}

		public static List<StringKey> GetTags(this GameObject obj)
		{
			return GetTags(obj, _goTags);
		}

		public static List<StringKey> GetTags(this Component obj)
		{
			return obj.gameObject.GetTags();
		}

		public static List<StringKey> GetTags(this ScriptableObject obj)
		{
			return GetTags(obj, _soTags);
		}

		public static void GetTags(this GameObject obj, List<StringKey> outTags)
		{
			GetTags(obj, outTags, _goTags);
		}

		public static void GetTags(this Component obj, List<StringKey> outTags)
		{
			obj.gameObject.GetTags(outTags);
		}

		public static void GetTags(this ScriptableObject obj, List<StringKey> outTags)
		{
			GetTags(obj, outTags, _soTags);
		}

		private static HashSet<StringKey> GetSet()
		{
			if (_hashSetPool.Count > 0)
			{
				HashSet<StringKey> hashSet = _hashSetPool.Pop();
				hashSet.Clear();
				return hashSet;
			}
			return new HashSet<StringKey>();
		}

		private static void AddTag<T>(T obj, StringKey tag, Dictionary<T, HashSet<StringKey>> tags) where T : Object
		{
			if (!tags.ContainsKey(obj))
			{
				tags.Add(obj, GetSet());
			}
			tags[obj].Add(tag);
		}

		private static void AddTags<T, TSet>(T obj, TSet set, Dictionary<T, HashSet<StringKey>> tags) where T : Object where TSet : IEnumerable<StringKey>
		{
			foreach (StringKey item in set)
			{
				AddTag(obj, item, tags);
			}
		}

		private static void RemoveTag<T>(T obj, StringKey tag, Dictionary<T, HashSet<StringKey>> tags) where T : Object
		{
			if (tags.TryGetValue(obj, out var value))
			{
				value.Remove(tag);
				if (value.Count <= 0)
				{
					tags.Remove(obj);
					_hashSetPool.Push(value);
				}
			}
		}

		private static bool HasTag<T>(T obj, StringKey tag, Dictionary<T, HashSet<StringKey>> tags) where T : Object
		{
			if (!tags.TryGetValue(obj, out var value))
			{
				return false;
			}
			return value.Contains(tag);
		}

		private static void RemoveAllTags<T>(T obj, Dictionary<T, HashSet<StringKey>> dict) where T : Object
		{
			if (dict.Remove(obj, out var value))
			{
				_hashSetPool.Push(value);
			}
		}

		private static List<StringKey> GetTags<T>(T obj, Dictionary<T, HashSet<StringKey>> tags) where T : Object
		{
			List<StringKey> list = new List<StringKey>();
			GetTags(obj, list, tags);
			return list;
		}

		private static void GetTags<T>(T obj, List<StringKey> outTags, Dictionary<T, HashSet<StringKey>> tags) where T : Object
		{
			if (tags.TryGetValue(obj, out var value))
			{
				outTags.AddRange(value);
			}
		}
	}
}
