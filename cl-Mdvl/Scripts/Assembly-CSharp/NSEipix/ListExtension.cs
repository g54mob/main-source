using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NSMedieval.UI;
using UnityEngine;

namespace NSEipix
{
	public static class ListExtension
	{
		public delegate T GetElementToAddToList<T>();

		private static readonly ThreadLocal<System.Random> ThreadLocalRandom = new ThreadLocal<System.Random>(() => new System.Random());

		private static System.Random Random => ThreadLocalRandom.Value;

		public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
		{
			T value = list[indexA];
			list[indexA] = list[indexB];
			list[indexB] = value;
			return list;
		}

		public static bool AddUnique<T>(this IList<T> source, T member)
		{
			if (source.Contains(member))
			{
				return false;
			}
			source.Add(member);
			return true;
		}

		public static void AddRangeUnique<T>(this IList<T> source, IEnumerable<T> members)
		{
			foreach (T member in members)
			{
				source.AddUnique(member);
			}
		}

		public static void RemoveWhere<T>(this IList<T> list, Func<T, bool> condition)
		{
			foreach (T item in list)
			{
				if (condition(item))
				{
					list.Remove(item);
					break;
				}
			}
		}

		public static void RemoveMultiple<T>(this List<T> list, params T[] items)
		{
			foreach (T item in items)
			{
				list.Remove(item);
			}
		}

		public static void RemoveMultiple<T>(this List<T> list, IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				list.Remove(item);
			}
		}

		public static T GetRandom<T>(this List<T> list)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			return list[Random.Next(0, list.Count)];
		}

		public static T GetRandomOtherThan<T>(this List<T> list, T otherThan)
		{
			if (list.Count <= 1)
			{
				return default(T);
			}
			if (list.Count == 2)
			{
				return list.FirstOrDefault((T t) => !t.Equals(otherThan));
			}
			T random;
			do
			{
				random = list.GetRandom();
			}
			while (random.Equals(otherThan));
			return random;
		}

		public static bool EqualsItems<T>(this List<T> list, List<T> other) where T : class
		{
			if (list == other)
			{
				return true;
			}
			if (list == null || other == null)
			{
				return false;
			}
			if (list.Count != other.Count)
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != other[i])
				{
					return false;
				}
			}
			return true;
		}

		private static GameObject GetGameObj<T>(T obj)
		{
			if (obj is GameObject result)
			{
				return result;
			}
			if (obj is Component component)
			{
				return component.gameObject;
			}
			return null;
		}

		public static T GetRandomByWeight<T>(this List<T> entryList, Func<T, float> weightSelector)
		{
			float num = entryList.Sum(weightSelector);
			float num2 = (float)Random.NextDouble() * num;
			float num3 = 0f;
			foreach (var item in entryList.Select((T weightedItem) => new
			{
				Value = weightedItem,
				Weight = weightSelector(weightedItem)
			}))
			{
				num3 += item.Weight;
				if (num3 >= num2)
				{
					return item.Value;
				}
			}
			return default(T);
		}

		public static T GetNext<T>(this List<T> entryList)
		{
			try
			{
				T val = entryList.FirstOrDefault((T item) => !GetGameObj(item).activeSelf);
				(val as Component)?.gameObject.SetActive(value: true);
				return val;
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				throw;
			}
		}

		public static T GetNext<T>(this List<T> entryList, LayoutGroupView parent)
		{
			T val = entryList.FirstOrDefault((T item) => !(item as Component).gameObject.activeSelf);
			if (val != null)
			{
				(val as Component)?.gameObject.SetActive(value: true);
				return val;
			}
			val = UnityEngine.Object.Instantiate(parent.Prefab, parent.transform).GetComponent<T>();
			entryList.Add(val);
			(val as Component)?.gameObject.SetActive(value: true);
			return val;
		}

		public static T GetNext<T>(this List<T> entryList, GameObject prefab, Transform parent)
		{
			T val = entryList.FirstOrDefault((T item) => !(item as Component).gameObject.activeSelf);
			if (val != null)
			{
				(val as Component)?.gameObject.SetActive(value: true);
				return val;
			}
			val = UnityEngine.Object.Instantiate(prefab, parent).GetComponent<T>();
			entryList.Add(val);
			return val;
		}

		public static T GetAt<T>(this List<T> entryList, LayoutGroupView parent, int index)
		{
			if (entryList.Count == index)
			{
				return entryList.GetNext(parent);
			}
			if (index > entryList.Count)
			{
				throw new Exception("Requested index should not be > than the list's count.");
			}
			T val = entryList[index];
			if (val == null || !(val is Component { gameObject: var gameObject }))
			{
				throw new Exception("Requested object is null or not a component");
			}
			if ((object)gameObject != null && !gameObject.activeSelf)
			{
				gameObject.SetActive(value: true);
			}
			return val;
		}

		public static T GetAt<T>(this List<T> entryList, GameObject prefab, Transform parent, int index)
		{
			if (entryList.Count == index)
			{
				return entryList.GetNext(prefab, parent);
			}
			if (index > entryList.Count)
			{
				throw new Exception("Requested index should not be > than the list's count.");
			}
			T val = entryList[index];
			Component obj = val as Component;
			if ((object)obj != null)
			{
				obj.gameObject.SetActive(value: true);
				return val;
			}
			return val;
		}

		public static void SetActiveFromIndex<T>(this List<T> entryList, int fromIndex, bool active)
		{
			if (fromIndex >= 0 && fromIndex < entryList.Count)
			{
				for (int i = fromIndex; i < entryList.Count; i++)
				{
					(entryList[i] as Component)?.gameObject.SetActive(active);
				}
			}
		}

		public static void AddIfNotNull<T>(this List<T> list, T listitem, object value)
		{
			if (value != null)
			{
				list.Add(listitem);
			}
		}

		public static void AddIfNotNullAndTrue<T>(this List<T> list, T listitem, bool condition)
		{
			if (listitem != null && condition)
			{
				list.Add(listitem);
			}
		}

		public static void AddIfNotNullOrEmpty(this List<string> list, string item)
		{
			if (!string.IsNullOrEmpty(item))
			{
				list.Add(item);
			}
		}

		public static void AddIfNotNullOrEmpty<T>(this List<T> list, T listitem, object value)
		{
			if (value != null && value.ToString() != string.Empty)
			{
				list.Add(listitem);
			}
		}

		public static void AddIfNotNullOrZero<T>(this List<T> list, T listitem, object value)
		{
			float.TryParse(value.ToString(), out var result);
			if (value != null && result != 0f)
			{
				list.Add(listitem);
			}
		}

		public static void AddIfNotNullOrGreaterThan<T>(this List<T> list, T listItem, object value, float greaterThan)
		{
			float.TryParse(value.ToString(), out var result);
			if (value != null && result > greaterThan)
			{
				list.Add(listItem);
			}
		}

		public static void AddIfNotNullOrGreaterThan<T>(this List<T> list, GetElementToAddToList<T> elementToAddGetter, object value, float greaterThan)
		{
			float.TryParse(value.ToString(), out var result);
			if (result > greaterThan)
			{
				list.Add(elementToAddGetter());
			}
		}

		public static void SetAllActive<T>(this List<T> list, bool active)
		{
			if (list.Count == 0)
			{
				return;
			}
			foreach (T item in list)
			{
				if (item is GameObject gameObject)
				{
					gameObject.SetActive(active);
				}
				else if (item is Component component && !(component == null) && !(component.gameObject == null))
				{
					component.gameObject.SetActive(active);
				}
			}
		}

		public static void ShuffleInPlace<T>(this IList<T> list, System.Random random = null)
		{
			System.Random random2 = random ?? Random;
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int num2 = random2.Next(num + 1);
				int index = num2;
				int index2 = num;
				T val = list[num];
				T val2 = list[num2];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}

		public static IEnumerable<T> OrEmptyIfNull<T>(this List<T> source)
		{
			return source ?? Enumerable.Empty<T>();
		}

		public static T TakeFirst<T>(this IList<T> list)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			T result = list[0];
			list.RemoveAt(0);
			return result;
		}

		public static T TakeRandom<T>(this IList<T> list, System.Random random = null)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			if (random == null)
			{
				random = Random;
			}
			int index = random.Next(list.Count);
			T result = list[index];
			list.RemoveAt(index);
			return result;
		}

		public static T TakeRandom<T>(this IList<T> list, int startIndexInclusive, int endIndexExclusive, System.Random random = null)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			if (random == null)
			{
				random = Random;
			}
			int index = random.Next(startIndexInclusive, endIndexExclusive);
			T result = list[index];
			list.RemoveAt(index);
			return result;
		}

		public static T GetRandom<T>(this IList<T> list, int startIndexInclusive, int endIndexExclusive, System.Random random = null)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			if (random == null)
			{
				random = Random;
			}
			int index = random.Next(startIndexInclusive, endIndexExclusive);
			return list[index];
		}

		public static IEnumerable<T> IterateInReverse<T>(this IList<T> list)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				yield return list[i];
			}
		}

		public static void AddRange<T>(this IList<T> list, IEnumerable<T> items, int maxItems)
		{
			int num = 0;
			foreach (T item in items)
			{
				if (num >= maxItems)
				{
					break;
				}
				list.Add(item);
				num++;
			}
		}
	}
}
