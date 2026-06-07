using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
	public static Vector2 XZ(this Vector3 vector3)
	{
		return new Vector2(vector3.x, vector3.z);
	}

	public static Vector3 XZ(this Vector2 vector2)
	{
		return new Vector3(vector2.x, 0f, vector2.y);
	}

	public static Vector3 RoundToInt(this Vector3 vector3)
	{
		return new Vector3(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.y), Mathf.RoundToInt(vector3.z));
	}

	public static bool StartCoroutineCheckingVar(this MonoBehaviour context, IEnumerator coroutine, ref Coroutine coroutineVar, bool stopCoroutineIfRunning = false)
	{
		if (coroutineVar != null && stopCoroutineIfRunning)
		{
			context.StopCoroutine(coroutineVar);
			coroutineVar = null;
		}
		if (coroutineVar == null)
		{
			coroutineVar = context.StartCoroutine(coroutine);
			return true;
		}
		return false;
	}

	public static bool StopCoroutineCheckingVar(this MonoBehaviour context, ref Coroutine coroutineVar)
	{
		if (coroutineVar != null)
		{
			context.StopCoroutine(coroutineVar);
			coroutineVar = null;
			return true;
		}
		return false;
	}

	public static bool Contains<T>(this T[] context, T other)
	{
		if (other == null)
		{
			return false;
		}
		for (int i = 0; i < context.Length; i++)
		{
			if (context[i] != null && context[i].Equals(other))
			{
				return true;
			}
		}
		return false;
	}

	public static bool ContainsAll<T>(this T[] context, T[] other)
	{
		if (other.Length > context.Length)
		{
			return false;
		}
		for (int i = 0; i < other.Length; i++)
		{
			bool flag = false;
			for (int j = 0; j < context.Length; j++)
			{
				ref readonly T reference = ref other[i];
				object obj = context[j];
				if (reference.Equals(obj))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	public static T[] PingPongSort<T>(this T[] context)
	{
		T[] array = new T[context.Length];
		for (int i = 0; i < context.Length; i++)
		{
			if (i % 2 == 0)
			{
				array[i] = context[i / 2];
			}
			else
			{
				array[i] = context[context.Length - 1 - i / 2];
			}
		}
		return array;
	}

	public static T[] Shuffle<T>(this T[] context)
	{
		for (int i = 0; i < context.Length; i++)
		{
			T val = context[i];
			int num = UnityEngine.Random.Range(0, context.Length);
			context[i] = context[num];
			context[num] = val;
		}
		return context;
	}

	public static List<T> Shuffle<T>(this List<T> context)
	{
		for (int i = 0; i < context.Count; i++)
		{
			T value = context[i];
			int index = UnityEngine.Random.Range(0, context.Count);
			context[i] = context[index];
			context[index] = value;
		}
		return context;
	}

	public static bool AddUnique<T>(this List<T> context, T element)
	{
		if (!context.Contains(element))
		{
			context.Add(element);
			return true;
		}
		return false;
	}

	public static Transform FirstChildQuery(this Transform parent, Func<Transform, bool> query, bool includeParent = true)
	{
		if (includeParent && query(parent))
		{
			return parent;
		}
		Transform transform = null;
		for (int i = 0; i < parent.childCount; i++)
		{
			transform = null;
			Transform child = parent.GetChild(i);
			if (query(child))
			{
				return child;
			}
			transform = child.FirstChildQuery(query, includeParent: false);
			if ((bool)transform)
			{
				break;
			}
		}
		return transform;
	}

	public static void DeleteAllChildren(this Transform transform)
	{
		for (int num = transform.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(transform.GetChild(num).gameObject);
		}
	}

	public static void DeleteAllChildrenImmediate(this Transform transform)
	{
		for (int num = transform.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.DestroyImmediate(transform.GetChild(num).gameObject);
		}
	}

	public static void SetChildrenActive(this Transform transform, bool active)
	{
		for (int num = transform.childCount - 1; num >= 0; num--)
		{
			transform.GetChild(num).gameObject.SetActive(active);
		}
	}

	public static double GetAccurateLength(this AudioClip context)
	{
		return (double)context.samples / (double)context.frequency;
	}
}
