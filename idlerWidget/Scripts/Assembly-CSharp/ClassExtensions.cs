using System.Collections.Generic;
using LightJson;
using UnityEngine;

public static class ClassExtensions
{
	public delegate T ParseJsonValue<T>(JsonValue data);

	public static void DestroyChildren(this Transform t)
	{
		foreach (Transform item in t)
		{
			Object.Destroy(item.gameObject);
		}
	}

	public static void DestroyActiveChildren(this Transform t)
	{
		foreach (Transform item in t)
		{
			if (item.gameObject.activeSelf)
			{
				Object.Destroy(item.gameObject);
			}
		}
	}

	public static void SetLayerRecursively(this GameObject o, int layer)
	{
		o.layer = layer;
		foreach (Transform item in o.transform)
		{
			item.gameObject.SetLayerRecursively(layer);
		}
	}

	public static JsonArray ToJsonArray<T>(this List<T> list) where T : IJsonSource
	{
		JsonArray jsonArray = new JsonArray();
		foreach (T item in list)
		{
			jsonArray.Add(item.ToJson());
		}
		return jsonArray;
	}

	public static void FromJsonArray<T>(this List<T> list, JsonArray data, ParseJsonValue<T> parser)
	{
		if (data == null)
		{
			return;
		}
		foreach (JsonValue datum in data)
		{
			list.Add(parser(datum));
		}
	}
}
