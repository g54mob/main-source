using System;
using System.Reflection;
using UnityEngine;

public static class Extensions
{
	public static void SetLayerRecursively(this GameObject gameObject, int layer)
	{
		gameObject.layer = layer;
		foreach (Transform item in gameObject.transform)
		{
			item.gameObject.SetLayerRecursively(layer);
		}
	}

	public static void SetLayerRecursively(this GameObject gameObject, string layer)
	{
		gameObject.layer = LayerMask.NameToLayer(layer);
		foreach (Transform item in gameObject.transform)
		{
			item.gameObject.SetLayerRecursively(LayerMask.NameToLayer(layer));
		}
	}

	public static void SetCollisionRecursively(this GameObject gameObject, bool collide)
	{
		Collider[] componentsInChildren = gameObject.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = collide;
		}
	}

	public static void SetColor(this GameObject gameObject, Color color)
	{
		Material[] materials = gameObject.GetComponent<Renderer>().materials;
		for (int i = 0; i < materials.Length; i++)
		{
			materials[i].SetColor("_Color", color);
		}
	}

	public static Color Hex(this Color color, string h)
	{
		ColorUtility.TryParseHtmlString(h, out var color2);
		return color2;
	}

	public static Color SetAlpha(this Color color, float alpha)
	{
		return new Color(color.r, color.g, color.b, alpha);
	}

	public static Component CopyComponent(this GameObject destination, Component original)
	{
		Type type = original.GetType();
		Component component = destination.AddComponent(type);
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.IsDefined(typeof(SerializeField), inherit: false))
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(original));
			}
		}
		return component;
	}

	public static string UppercaseFirst(this string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		return char.ToUpper(s[0]) + s.Substring(1);
	}

	public static Vector3 RoundVector(this Vector2 v, float grid)
	{
		Vector2 zero = Vector2.zero;
		zero.x = grid * Mathf.Round(v.x / grid);
		zero.y = grid * Mathf.Round(v.y / grid);
		return zero;
	}

	public static Vector3 RoundVector(this Vector3 v, float grid)
	{
		Vector3 zero = Vector3.zero;
		zero.x = grid * Mathf.Round(v.x / grid);
		zero.y = grid * Mathf.Round(v.y / grid);
		zero.z = grid * Mathf.Round(v.z / grid);
		return zero;
	}

	public static bool Equals(this Vector2 vector2, Vector2 otherVector2)
	{
		if (vector2.x == otherVector2.x)
		{
			return vector2.y == otherVector2.y;
		}
		return false;
	}

	public static bool Equals(this Vector3 vector3, Vector3 otherVector3)
	{
		if (vector3.x == otherVector3.x && vector3.y == otherVector3.y)
		{
			return vector3.z == otherVector3.z;
		}
		return false;
	}
}
