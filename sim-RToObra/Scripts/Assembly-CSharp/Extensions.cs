using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
	public static Transform FindDescendant(this Transform target, string name, bool showError = true)
	{
		Transform transform = FindDescendantInternal(target, name);
		if (transform == null && showError)
		{
			Debug.LogError("Descendant of <" + Util.GetObjectPath(target.gameObject) + "> not found: \"" + name + "\"");
		}
		return transform;
	}

	public static Transform FindDescendantInternal(Transform target, string name)
	{
		if (target.name == name)
		{
			return target;
		}
		for (int i = 0; i < target.childCount; i++)
		{
			Transform transform = FindDescendantInternal(target.GetChild(i), name);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}

	public static Transform FindChildWithPrefix(this Transform t, string prefix)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			if (child.name.StartsWith(prefix))
			{
				return child;
			}
		}
		return null;
	}

	public static Matrix4x4 GetLocalMatrix(this Transform t)
	{
		return Matrix4x4.TRS(t.localPosition, t.localRotation, t.localScale);
	}

	public static void SetLocalMatrix(this Transform t, Matrix4x4 m)
	{
		t.localPosition = m.GetT();
		t.localRotation = Util.QuaternionFromMatrix(m);
		t.localScale = m.GetScale();
	}

	public static float SetPositionY(this Transform t, float y)
	{
		t.position = new Vector3(t.position.x, y, t.position.z);
		return y;
	}

	public static Vector3 GetX(this Matrix4x4 m)
	{
		return m.GetColumn(0);
	}

	public static Vector3 GetY(this Matrix4x4 m)
	{
		return m.GetColumn(1);
	}

	public static Vector3 GetZ(this Matrix4x4 m)
	{
		return m.GetColumn(2);
	}

	public static Vector3 GetT(this Matrix4x4 m)
	{
		return m.GetColumn(3);
	}

	public static Vector3 GetScale(this Matrix4x4 m)
	{
		return new Vector3(m.GetX().magnitude, m.GetY().magnitude, m.GetZ().magnitude);
	}

	public static Vector3 ToVector3XZ(this Vector2 v, float y)
	{
		return new Vector3(v.x, y, v.y);
	}

	public static Vector3 ToVector3XY(this Vector2 v, float z)
	{
		return new Vector3(v.x, v.y, z);
	}

	public static Vector4 ToVector4(this Vector2 v, float z, float w)
	{
		return new Vector4(v.x, v.y, z, w);
	}

	public static Vector3 ToVector3(this Vector4 v)
	{
		return new Vector3(v.x, v.y, v.z);
	}

	public static Vector4 ToVector4(this Vector3 v, float w = 0f)
	{
		return new Vector4(v.x, v.y, v.z, w);
	}

	public static Vector2 ToVector2XZ(this Vector3 v)
	{
		return new Vector2(v.x, v.z);
	}

	public static Vector2 ToVector2XY(this Vector3 v)
	{
		return new Vector2(v.x, v.y);
	}

	public static IEnumerable<GameObject> AllDescendents(this GameObject go, bool includeSelf = true)
	{
		if (includeSelf)
		{
			yield return go;
		}
		IEnumerator enumerator = go.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform child = (Transform)enumerator.Current;
				foreach (GameObject item in child.gameObject.AllDescendents())
				{
					yield return item;
				}
			}
		}
		finally
		{
			IDisposable disposable2;
			IDisposable disposable = (disposable2 = enumerator as IDisposable);
			if (disposable2 != null)
			{
				disposable.Dispose();
			}
		}
	}

	public static IEnumerable<GameObject> AllAntecedents(this GameObject go, bool includeSelf = true)
	{
		if (includeSelf)
		{
			yield return go;
		}
		Transform parent = go.transform.parent;
		while (parent != null)
		{
			yield return parent.gameObject;
			parent = parent.parent;
		}
	}

	public static IEnumerable<GameObject> AllChildren(this GameObject go)
	{
		IEnumerator enumerator = go.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform child = (Transform)enumerator.Current;
				yield return child.gameObject;
			}
		}
		finally
		{
			IDisposable disposable2;
			IDisposable disposable = (disposable2 = enumerator as IDisposable);
			if (disposable2 != null)
			{
				disposable.Dispose();
			}
		}
	}

	public static void MakeIdentity(this Transform t)
	{
		t.localPosition = Vector3.zero;
		t.localRotation = Quaternion.identity;
		t.localScale = Vector3.one;
	}

	public static GameObject AddChild(this GameObject parent, GameObject child)
	{
		child.transform.parent = parent.transform;
		return child;
	}

	public static T[] Sub<T>(this T[] data, int index, int length)
	{
		T[] array = new T[length];
		Array.Copy(data, index, array, 0, length);
		return array;
	}

	public static T GetComponentInParentAnyActive<T>(this Component component)
	{
		return component.gameObject.GetComponentInParentAnyActive<T>();
	}

	public static T GetComponentInParentAnyActive<T>(this GameObject gameObject)
	{
		foreach (GameObject item in gameObject.AllAntecedents())
		{
			T component = item.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
		}
		return default(T);
	}

	public static int GetStableHashCode(this string str)
	{
		int num = 352654597;
		int num2 = num;
		for (int i = 0; i < str.Length; i += 2)
		{
			num = ((num << 5) + num) ^ str[i];
			if (i == str.Length - 1)
			{
				break;
			}
			num2 = ((num2 << 5) + num2) ^ str[i + 1];
		}
		return num + num2 * 1566083941;
	}

	public static bool HasValue(this string str)
	{
		return !string.IsNullOrEmpty(str);
	}
}
