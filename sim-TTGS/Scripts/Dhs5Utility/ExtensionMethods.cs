using System;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
	public static Vector2 ToVector2(this Vector3 vector3)
	{
		return new Vector2(vector3.x, vector3.y);
	}

	public static Vector2 BrutMoveTowards(this Vector2 current, Vector2 target, float speed)
	{
		float num = target.x - current.x;
		float num2 = target.y - current.y;
		float num3 = num * num + num2 * num2;
		if (num3 == 0f)
		{
			return target;
		}
		float num4 = (float)Math.Sqrt(num3);
		return new Vector2(current.x + num / num4 * speed, current.y + num2 / num4 * speed);
	}

	public static bool Contains(this Vector2 vector, float value)
	{
		if (value >= Mathf.Min(vector.x, vector.y))
		{
			return value <= Mathf.Max(vector.x, vector.y);
		}
		return false;
	}

	public static bool Contains(this Vector2Int vector, float value)
	{
		if (value >= (float)Mathf.Min(vector.x, vector.y))
		{
			return value <= (float)Mathf.Max(vector.x, vector.y);
		}
		return false;
	}

	public static bool IsValid<T>(this ICollection<T> collection)
	{
		if (collection != null)
		{
			return collection.Count > 0;
		}
		return false;
	}

	public static bool IsIndexValid<T>(this ICollection<T> collection, int index)
	{
		if (collection.IsValid() && index >= 0)
		{
			return index < collection.Count;
		}
		return false;
	}

	public static void Swap<T>(this IList<T> list, int indexA, int indexB)
	{
		T value = list[indexA];
		list[indexA] = list[indexB];
		list[indexB] = value;
	}

	public static List<T> Copy<T>(this List<T> list)
	{
		return new List<T>(list);
	}

	public static Dictionary<T, U> Copy<T, U>(this Dictionary<T, U> dico)
	{
		return new Dictionary<T, U>(dico);
	}

	public static float Sum(this ICollection<float> collection)
	{
		float num = 0f;
		foreach (float item in collection)
		{
			num += item;
		}
		return num;
	}

	public static int Sum(this ICollection<int> collection)
	{
		int num = 0;
		foreach (int item in collection)
		{
			num += item;
		}
		return num;
	}

	public static Vector2 Sum(this ICollection<Vector2> collection)
	{
		Vector2 zero = Vector2.zero;
		foreach (Vector2 item in collection)
		{
			zero += item;
		}
		return zero;
	}

	public static Vector3 Sum(this ICollection<Vector3> collection)
	{
		Vector3 zero = Vector3.zero;
		foreach (Vector3 item in collection)
		{
			zero += item;
		}
		return zero;
	}

	public static float Average(this ICollection<float> collection)
	{
		return collection.Sum() / (float)collection.Count;
	}

	public static float Average(this ICollection<int> collection)
	{
		return (float)collection.Sum() / (float)collection.Count;
	}

	public static Vector2 Average(this ICollection<Vector2> collection)
	{
		return collection.Sum() / collection.Count;
	}

	public static Vector3 Average(this ICollection<Vector3> collection)
	{
		return collection.Sum() / collection.Count;
	}

	public static IEnumerable<T> GetFlags<T>(this Enum input) where T : Enum
	{
		foreach (Enum value in Enum.GetValues(input.GetType()))
		{
			if (input.HasFlag(value))
			{
				yield return (T)value;
			}
		}
	}

	public static IEnumerable<int> GetFlagsIndex(this Enum input)
	{
		foreach (Enum value in Enum.GetValues(input.GetType()))
		{
			if (input.HasFlag(value))
			{
				yield return 1 >> Convert.ToInt32(value);
			}
		}
	}

	public static bool Contains(this LayerMask mask, int layer)
	{
		return ((int)mask & (1 << layer)) != 0;
	}

	public static void CopyToClipboard(this string str)
	{
		GUIUtility.systemCopyBuffer = str;
	}

	public static float GetRandomInRange(this Vector2 vector)
	{
		return UnityEngine.Random.Range(Mathf.Min(vector.x), Mathf.Max(vector.y));
	}

	public static int GetRandomInRange(this Vector2Int vector, bool maxInclusive)
	{
		return UnityEngine.Random.Range(Mathf.Min(vector.x), Mathf.Max(vector.y) + (maxInclusive ? 1 : 0));
	}

	public static T GetRandom<T>(this IList<T> collection)
	{
		return collection[UnityEngine.Random.Range(0, collection.Count)];
	}

	public static T GetRandom<T>(this T[] collection)
	{
		return collection[UnityEngine.Random.Range(0, collection.Length)];
	}
}
