using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Tags
{
	public static class GameplayTags
	{
		private static Dictionary<int, HashSet<int>> _tags = new Dictionary<int, HashSet<int>>();

		public static void Register(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !tagsList.IsValid())
			{
				return;
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int tags in tagsList)
			{
				hashSet.Add(tags);
			}
			_tags[go.GetInstanceID()] = hashSet;
		}

		public static void Register(Component component, GameplayTagsList tagsList)
		{
			if (!(component == null))
			{
				Register(component.gameObject, tagsList);
			}
		}

		public static void Unregister(GameObject go)
		{
			if (!(go == null))
			{
				_tags.Remove(go.GetInstanceID());
			}
		}

		public static void Unregister(Component component)
		{
			if (!(component == null))
			{
				Unregister(component.gameObject);
			}
		}

		public static GameplayTagsList Get(GameObject go)
		{
			if (go == null || !_tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				return null;
			}
			return new GameplayTagsList(value);
		}

		public static GameplayTagsList Get(Component component)
		{
			if (component == null)
			{
				return null;
			}
			return Get(component.gameObject);
		}

		public static void Get_NoAlloc(GameObject go, GameplayTagsList tagsList)
		{
			if (!(go == null) && _tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				tagsList.Set(value);
			}
		}

		public static void Get_NoAlloc(Component component, GameplayTagsList tagsList)
		{
			if (!(component == null))
			{
				Get_NoAlloc(component.gameObject, tagsList);
			}
		}

		public static void AddTags(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !tagsList.IsValid())
			{
				return;
			}
			if (_tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				foreach (int tags in tagsList)
				{
					value.Add(tags);
				}
				return;
			}
			Register(go, tagsList);
		}

		public static void AddTags(Component component, GameplayTagsList tagsList)
		{
			if (!(component == null))
			{
				AddTags(component.gameObject, tagsList);
			}
		}

		public static void RemoveTags(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !tagsList.IsValid() || !_tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				return;
			}
			foreach (int tags in tagsList)
			{
				value.Remove(tags);
			}
		}

		public static void RemoveTags(Component component, GameplayTagsList tagsList)
		{
			if (!(component == null))
			{
				RemoveTags(component.gameObject, tagsList);
			}
		}

		public static bool Contains(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !tagsList.IsValid() || !_tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				return false;
			}
			foreach (int tags in tagsList)
			{
				if (!value.Contains(tags))
				{
					return false;
				}
			}
			return true;
		}

		public static bool Contains(Component component, GameplayTagsList tagsList)
		{
			if (component == null)
			{
				return false;
			}
			return Contains(component.gameObject, tagsList);
		}

		public static bool ContainsAny(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !tagsList.IsValid() || !_tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				return false;
			}
			foreach (int tags in tagsList)
			{
				if (value.Contains(tags))
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsAny(Component component, GameplayTagsList tagsList)
		{
			if (component == null)
			{
				return false;
			}
			return ContainsAny(component.gameObject, tagsList);
		}

		public static GameplayTagsList Union(GameObject go1, GameObject go2)
		{
			if (go1 == null || !_tags.TryGetValue(go1.GetInstanceID(), out var value))
			{
				return Get(go2);
			}
			if (go2 == null || !_tags.TryGetValue(go2.GetInstanceID(), out var value2))
			{
				return Get(go1);
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in value)
			{
				hashSet.Add(item);
			}
			foreach (int item2 in value2)
			{
				hashSet.Add(item2);
			}
			return new GameplayTagsList(hashSet);
		}

		public static GameplayTagsList Union(Component comp1, Component comp2)
		{
			if (comp1 == null)
			{
				return Get(comp2);
			}
			if (comp2 == null)
			{
				return Get(comp1);
			}
			return Union(comp1.gameObject, comp2.gameObject);
		}

		public static GameplayTagsList Union(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !_tags.TryGetValue(go.GetInstanceID(), out var value))
			{
				return tagsList;
			}
			if (!tagsList.IsValid())
			{
				return Get(go);
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in value)
			{
				hashSet.Add(item);
			}
			foreach (int tags in tagsList)
			{
				hashSet.Add(tags);
			}
			return new GameplayTagsList(hashSet);
		}

		public static GameplayTagsList Union(Component component, GameplayTagsList tagsList)
		{
			if (component == null)
			{
				return tagsList;
			}
			return Union(component.gameObject, tagsList);
		}

		public static GameplayTagsList Intersection(GameObject go1, GameObject go2)
		{
			if (go1 == null || !_tags.TryGetValue(go1.GetInstanceID(), out var value) || go2 == null || !_tags.TryGetValue(go2.GetInstanceID(), out var value2))
			{
				return null;
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in value)
			{
				if (value2.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			return new GameplayTagsList(hashSet);
		}

		public static GameplayTagsList Intersection(Component comp1, Component comp2)
		{
			if (comp1 == null)
			{
				return null;
			}
			if (comp2 == null)
			{
				return null;
			}
			return Intersection(comp1.gameObject, comp2.gameObject);
		}

		public static GameplayTagsList Intersection(GameObject go, GameplayTagsList tagsList)
		{
			if (go == null || !_tags.TryGetValue(go.GetInstanceID(), out var value) || !tagsList.IsValid())
			{
				return null;
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in value)
			{
				if (tagsList.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			return new GameplayTagsList(hashSet);
		}

		public static GameplayTagsList Intersection(Component component, GameplayTagsList tagsList)
		{
			if (component == null)
			{
				return null;
			}
			return Intersection(component.gameObject, tagsList);
		}
	}
}
