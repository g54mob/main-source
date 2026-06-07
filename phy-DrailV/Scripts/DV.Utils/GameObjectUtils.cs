using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameObjectUtils
{
	public static string GetPath(this GameObject obj)
	{
		string text = obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			text = obj.name + "/" + text;
		}
		return text;
	}

	public static void SetLayersRecursive(this GameObject go, int layer)
	{
		go.layer = layer;
		Transform[] componentsInChildren = go.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = layer;
		}
	}

	public static void SetLayersRecursive(this GameObject go, string layerName)
	{
		go.SetLayersRecursive(LayerMask.NameToLayer(layerName));
	}

	public static IReadOnlyCollection<int> GetLayersRecursive(this GameObject go)
	{
		HashSet<int> hashSet = new HashSet<int>();
		Transform[] componentsInChildren = go.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			hashSet.Add(transform.gameObject.layer);
		}
		return hashSet;
	}

	public static void SetLayer(this List<GameObject> gameObjects, string layerName)
	{
		int layer = LayerMask.NameToLayer(layerName);
		foreach (GameObject item in gameObjects.Where((GameObject go) => go != null))
		{
			item.layer = layer;
		}
	}

	public static List<GameObject> ReplaceLayersRecursive(this GameObject go, string layerNameFrom, string layerNameTo)
	{
		int layerFrom = LayerMask.NameToLayer(layerNameFrom);
		List<GameObject> list = (from t in go.GetComponentsInChildren<Transform>()
			select t.gameObject into t
			where t.layer == layerFrom
			select t).ToList();
		list.SetLayer(layerNameTo);
		return list;
	}

	public static T GetComponentInParentIncludingInactive<T>(this GameObject go)
	{
		return go.transform.GetComponentInParentIncludingInactive<T>();
	}

	public static T GetComponentInParentIncludingInactive<T>(this Transform t)
	{
		Transform transform = t;
		while ((object)transform != null)
		{
			if (transform.TryGetComponent<T>(out var component))
			{
				return component;
			}
			transform = transform.parent;
		}
		return default(T);
	}
}
