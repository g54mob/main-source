using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

public static class Extensions
{
	public static void Shuffle<T>(this IList<T> items)
	{
		int count = items.Count;
		while (0 < count--)
		{
			int index = UnityEngine.Random.Range(0, count + 1);
			T value = items[index];
			items[index] = items[count];
			items[count] = value;
		}
	}

	public static bool RemoveSafely<T>(this IList<T> items, T itemToRemove)
	{
		return items.Remove(itemToRemove);
	}

	public static bool AddUnique<T>(this IList<T> items, T itemToAdd)
	{
		if (items.Contains(itemToAdd))
		{
			return false;
		}
		items.Add(itemToAdd);
		return true;
	}

	public static bool AddUniqueRange<T>(this IList<T> items, IEnumerable<T> itemsToAdd)
	{
		int num = 0;
		foreach (T item in itemsToAdd)
		{
			if (!items.Contains(item))
			{
				items.Add(item);
				num++;
			}
		}
		return 0 < num;
	}

	public static void AddRangeWhere<T>(this IList<T> list, IEnumerable<T> itemsToAdd, Predicate<T> predicate)
	{
		foreach (T item in itemsToAdd)
		{
			if (predicate(item))
			{
				list.Add(item);
			}
		}
	}

	public static void RemoveRange<T>(this IList<T> items, IEnumerable<T> itemsToRemove)
	{
		foreach (T item in itemsToRemove)
		{
			items.Remove(item);
		}
	}

	public static bool TryGetValueAtIndex<T>(this IList<T> items, int index, out T item)
	{
		if (-1 < index && index < items.Count)
		{
			item = items[index];
			return true;
		}
		item = default(T);
		return false;
	}

	public static int IndexOf<T>(this T[] array, T obj) where T : class
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == obj)
			{
				return i;
			}
		}
		return -1;
	}

	public static int IndexOf<T>(this IReadOnlyList<T> list, T obj) where T : class
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == obj)
			{
				return i;
			}
		}
		return -1;
	}

	public static void Dispose<T>(this IList<T> listToRelease)
	{
		if (listToRelease is ListPool<T>.List list)
		{
			list.Dispose();
		}
	}

	public static List<T> Clone<T>(this IReadOnlyList<T> list) where T : ICloneable
	{
		List<T> list2 = new List<T>(list.Count);
		foreach (T item in list)
		{
			list2.Add((T)item.Clone());
		}
		return list2;
	}

	public static void AddRange<T>(this HashSet<T> items, IReadOnlyList<T> itemsToAdd)
	{
		foreach (T item in itemsToAdd)
		{
			items.Add(item);
		}
	}

	public static void SetLayerRecursively(this GameObject gameObject, int layer)
	{
		gameObject.layer = layer;
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetLayerRecursively(layer);
		}
	}

	public static string RetrieveHierarchyString(this Transform transform)
	{
		StringBuilder stringBuilder = new StringBuilder(transform.name);
		string text = " < ";
		stringBuilder.Append(text);
		Transform parent = transform.parent;
		while (parent != null)
		{
			stringBuilder.Append(parent.name);
			stringBuilder.Append(text);
			parent = parent.parent;
		}
		stringBuilder.Remove(stringBuilder.Length - text.Length, text.Length);
		return stringBuilder.ToString();
	}

	public static string RetrieveHierarchyString(this GameObject gameObject)
	{
		return gameObject.transform.RetrieveHierarchyString();
	}

	public static bool IsNull(this UnityEngine.Object unityObject)
	{
		return (object)unityObject == null;
	}

	public static bool IsEqual(this UnityEngine.Object unityObject, UnityEngine.Object other)
	{
		return (object)unityObject == other;
	}

	public static bool TryParse(this string value, out GameVersion version)
	{
		version = default(GameVersion);
		string[] array = value.Split(new char[1] { '.' }, 3, StringSplitOptions.None);
		if (array.Length != 0 && int.TryParse(array[0], out var result))
		{
			version.Major = result;
			if (array.Length > 1 && int.TryParse(array[1], out var result2))
			{
				version.Minor = result2;
				if (array.Length > 2)
				{
					string text = array[2];
					string text2 = "";
					int num = 0;
					for (int i = 0; i < text.Length && char.IsDigit(text[i]); i++)
					{
						text2 += text[i];
						num++;
					}
					text = text.Remove(0, num);
					if (int.TryParse(text2, out var result3))
					{
						version.Patch = result3;
					}
					version.AdditionalModifiers = text;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static void ShowExplorer(string path)
	{
		if (Directory.Exists(path))
		{
			path = path.Replace("/", "\\");
			Process.Start(new ProcessStartInfo
			{
				Arguments = path,
				FileName = "explorer.exe"
			});
		}
	}

	public static bool TryDeleteDirectory(string path)
	{
		if (Directory.Exists(path) && Directory.GetFiles(path).Length == 0)
		{
			try
			{
				Directory.Delete(path);
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public static bool Compare(this IComparable left, ComparisonType comparisonType, IComparable right)
	{
		return comparisonType switch
		{
			ComparisonType.Equal => left.CompareTo(right) == 0, 
			ComparisonType.NotEqual => left.CompareTo(right) != 0, 
			ComparisonType.LessThan => left.CompareTo(right) <= 0, 
			ComparisonType.EqualOrLessThan => left.CompareTo(right) <= 0, 
			ComparisonType.EqualOrGreaterThan => left.CompareTo(right) >= 0, 
			ComparisonType.GreaterThan => left.CompareTo(right) > 0, 
			_ => throw new NotImplementedException($"Comparison type {comparisonType} not implemented!"), 
		};
	}

	public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
	{
		if (!dictionary.TryGetValue(key, out var value))
		{
			value = new TValue();
			dictionary.Add(key, value);
		}
		return value;
	}

	public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> collection)
	{
		if (collection != null)
		{
			return collection.Count == 0;
		}
		return true;
	}

	public static T Find<T>(this T[] array, Predicate<T> predicate)
	{
		return Array.Find(array, predicate);
	}

	public static T Find<T>(this IReadOnlyList<T> list, Predicate<T> predicate)
	{
		foreach (T item in list)
		{
			if (predicate(item))
			{
				return item;
			}
		}
		return default(T);
	}

	public static int FindCount<T>(this IReadOnlyList<T> list, Predicate<T> predicate)
	{
		int num = 0;
		foreach (T item in list)
		{
			if (predicate(item))
			{
				num++;
			}
		}
		return num;
	}

	public static bool TryFind<T>(this T[] array, out T foundItem, Predicate<T> predicate)
	{
		foreach (T val in array)
		{
			if (predicate(val))
			{
				foundItem = val;
				return true;
			}
		}
		foundItem = default(T);
		return false;
	}

	public static bool TryFind<T>(this IReadOnlyList<T> list, out T foundItem, Predicate<T> predicate)
	{
		foreach (T item in list)
		{
			if (predicate(item))
			{
				foundItem = item;
				return true;
			}
		}
		foundItem = default(T);
		return false;
	}

	public static bool Contains<T>(this IReadOnlyList<T> collection, T element)
	{
		if (collection == null)
		{
			return false;
		}
		if (typeof(T).IsValueType)
		{
			foreach (T item in collection)
			{
				if (object.Equals(item, element))
				{
					return true;
				}
			}
		}
		else
		{
			foreach (T item2 in collection)
			{
				if ((object)item2 == (object)element)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void CopyTo<T>(this IReadOnlyList<T> list, ref List<T> destination)
	{
		if (destination == null)
		{
			destination = new List<T>(list.Count);
		}
		destination.Clear();
		foreach (T item in list)
		{
			destination.Add(item);
		}
	}

	public static bool IsEqual<T>(this IReadOnlyList<T> a, IReadOnlyList<T> b) where T : IComparable
	{
		if (a.IsNullOrEmpty() != b.IsNullOrEmpty())
		{
			return false;
		}
		for (int i = 0; i < a.Count; i++)
		{
			if (a[i].Compare(ComparisonType.NotEqual, b[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static T GetRandom<T>(this IReadOnlyList<T> list)
	{
		int index;
		return list.GetRandom(out index);
	}

	public static T GetRandom<T>(this IReadOnlyList<T> list, out int index)
	{
		index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public static bool TryGetRandom<T>(this IReadOnlyList<T> list, out T item)
	{
		int index;
		return list.TryGetRandom(out item, out index);
	}

	public static bool TryGetRandom<T>(this IReadOnlyList<T> list, out T item, out int index)
	{
		if (list.IsNullOrEmpty())
		{
			item = default(T);
			index = -1;
			return false;
		}
		item = list.GetRandom(out index);
		return true;
	}

	public static int GetRandomIndex<T>(this IReadOnlyList<T> list)
	{
		list.GetRandom(out var index);
		return index;
	}

	public static bool TryGetRandomIndex<T>(this IReadOnlyList<T> list, out int index)
	{
		T item;
		return list.TryGetRandom(out item, out index);
	}

	public static int GetPreviousIndex<T>(this IReadOnlyList<T> list, int currentIndex)
	{
		if (currentIndex <= 0)
		{
			return 0;
		}
		return currentIndex - 1;
	}

	public static int GetNextIndex<T>(this IReadOnlyList<T> list, int currentIndex)
	{
		int num = list.Count - 1;
		if (num <= currentIndex)
		{
			return num;
		}
		return currentIndex + 1;
	}

	public static int ClampIndex<T>(this IReadOnlyList<T> list, int index)
	{
		if (list == null || list.Count == 0)
		{
			throw new ArgumentException();
		}
		if (index < 0)
		{
			return 0;
		}
		if (index < list.Count)
		{
			return index;
		}
		return list.Count - 1;
	}

	public static T GetValueOrNull<T>(this IReadOnlyList<T> list, int index) where T : class
	{
		if (list == null || list.Count == 0 || index < 0 || index >= list.Count)
		{
			return null;
		}
		return list[index];
	}

	public static T GetValueClamped<T>(this IReadOnlyList<T> list, int index)
	{
		if (list == null || list.Count == 0)
		{
			throw new ArgumentException();
		}
		if (index < 0)
		{
			return list[0];
		}
		if (index < list.Count)
		{
			return list[index];
		}
		return list[list.Count - 1];
	}

	public static T GetValueWrapped<T>(this IReadOnlyList<T> list, int index)
	{
		if (list == null || list.Count == 0)
		{
			throw new ArgumentException();
		}
		if (index < 0)
		{
			while (index < -list.Count)
			{
				index += list.Count;
			}
			index += list.Count;
		}
		else
		{
			index %= list.Count;
		}
		return list[index];
	}

	public static bool IsValidIndex<T>(this IReadOnlyList<T> list, int index)
	{
		if (list != null && 0 < list.Count && 0 <= index)
		{
			return index < list.Count;
		}
		return false;
	}

	public static bool TryGetValue<T>(this IReadOnlyList<T> list, int index, out T value)
	{
		if (list != null && 0 < list.Count && 0 <= index && index < list.Count)
		{
			value = list[index];
			return true;
		}
		value = default(T);
		return false;
	}

	public static int ToWrappedIndex(this int index, int count)
	{
		if (index < 0)
		{
			while (index < -count)
			{
				index += count;
			}
			index += count;
		}
		else
		{
			index %= count;
		}
		return index;
	}

	public static bool Remove<T>(this Queue<T> queue, T itemToRemove)
	{
		int num = 0;
		int i = 0;
		for (int count = queue.Count; i < count; i++)
		{
			T item = queue.Dequeue();
			if (item.Equals(itemToRemove))
			{
				num++;
			}
			else
			{
				queue.Enqueue(item);
			}
		}
		return num > 0;
	}

	public static bool Contains(this string source, string toCheck, StringComparison comp)
	{
		if (source != null && toCheck != null)
		{
			return source.IndexOf(toCheck, comp) >= 0;
		}
		return false;
	}

	public static string ToByteString(this ulong bytes)
	{
		string[] array = new string[5] { "B", "KB", "MB", "GB", "TB" };
		int num = 0;
		while (bytes >= 1024 && num < array.Length - 1)
		{
			num++;
			bytes /= 1024;
		}
		return $"{bytes:0.##} {array[num]}";
	}

	public static string ToByteString(this long bytes)
	{
		return ((ulong)bytes).ToByteString();
	}

	public static string SanitizePath(this string text)
	{
		string str = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()) + ".";
		return new Regex($"[{Regex.Escape(str)}]").Replace(text, "");
	}

	public static string AddSign(this string text, float modifier)
	{
		if (!(modifier >= 0f))
		{
			return text;
		}
		return "+" + text;
	}

	public static void SplitInt(this string str, char sepparatorChar, List<int> integers)
	{
		int num = 0;
		while (num < str.Length)
		{
			bool flag = true;
			int i;
			for (i = num; i < str.Length; i++)
			{
				if (str[i] == sepparatorChar)
				{
					flag = false;
					break;
				}
			}
			if (int.TryParse(flag ? str.Substring(num) : str.Substring(num, i - num), out var result))
			{
				integers.Add(result);
			}
			num = ++i;
		}
	}

	public static bool IsNullOrEmpty(this string str)
	{
		return string.IsNullOrEmpty(str);
	}

	public static string GetOrDefault(this string str, string defaultValue)
	{
		if (!str.IsNullOrEmpty())
		{
			return str;
		}
		return defaultValue;
	}

	public static string GetOrDefault(this LocalizedString str, string fallback)
	{
		if ((string)str != null && !str.mTerm.IsNullOrEmpty())
		{
			return str;
		}
		LocalizationManager.ApplyLocalizationParams(ref fallback);
		if (!GameSettings.Instance.UISettings.ShowMissingLocalizationWarnings)
		{
			return fallback;
		}
		return fallback + " (MISSING LOCALIZATION)";
	}

	public static string GetOrDefault(this ConcatenatedLocalizedString str, string fallback)
	{
		if (str.HasText())
		{
			return str;
		}
		LocalizationManager.ApplyLocalizationParams(ref fallback);
		if (!GameSettings.Instance.UISettings.ShowMissingLocalizationWarnings)
		{
			return fallback;
		}
		return fallback + " (MISSING LOCALIZATION)";
	}

	public static string SplitCamelCase(this string str)
	{
		return Regex.Replace(Regex.Replace(str, "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), "(\\p{Ll})(\\P{Ll})", "$1 $2");
	}

	public static string GetPathRoot(this string path)
	{
		while (true)
		{
			string directoryName = Path.GetDirectoryName(path);
			if (directoryName == null)
			{
				break;
			}
			path = directoryName;
		}
		return path;
	}

	public static void SafeInvoke(this Action action)
	{
		action?.Invoke();
	}

	public static void SafeInvoke<T>(this Action<T> action, T arg)
	{
		action?.Invoke(arg);
	}

	public static void SafeInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
	{
		action?.Invoke(arg1, arg2);
	}

	public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
	{
		action?.Invoke(arg1, arg2, arg3);
	}

	public static void SafeInvoke(this UnityAction action)
	{
		action?.Invoke();
	}

	public static void SafeInvoke<T>(this UnityAction<T> action, T arg)
	{
		action?.Invoke(arg);
	}

	public static void SafeInvoke<T1, T2>(this UnityAction<T1, T2> action, T1 arg1, T2 arg2)
	{
		action?.Invoke(arg1, arg2);
	}

	public static void SafeInvoke<T1, T2, T3>(this UnityAction<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
	{
		action?.Invoke(arg1, arg2, arg3);
	}

	public static void DrawTexture(this Sprite sprite, Rect windowRect)
	{
		Rect sourceRect = new Rect(sprite.textureRect.x / (float)sprite.texture.width, sprite.textureRect.y / (float)sprite.texture.height, sprite.textureRect.width / (float)sprite.texture.width, sprite.textureRect.height / (float)sprite.texture.height);
		Graphics.DrawTexture(windowRect, sprite.texture, sourceRect, 0, 0, 0, 0);
	}
}
