using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Components.Logs;
using Unity.Components.Scene;
using UnityEngine;

public class SceneBindContainer
{
	public SceneBindContainer()
	{
		BindObjects(this);
	}

	public static SceneBindAttribute[] GetAttributes(FieldInfo info)
	{
		return info.GetCustomAttributes(typeof(SceneBindAttribute), inherit: true) as SceneBindAttribute[];
	}

	public static List<UnityEngine.Object> BindObjects(object o)
	{
		return BindObjects(o, null);
	}

	public static List<UnityEngine.Object> BindObjects(object o, Transform bindingBase)
	{
		if (o == null)
		{
			return null;
		}
		Type type = o.GetType();
		List<UnityEngine.Object> list = new List<UnityEngine.Object>();
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			SceneBindAttribute[] attributes = GetAttributes(fieldInfo);
			foreach (SceneBindAttribute sceneBindAttribute in attributes)
			{
				Type type2 = sceneBindAttribute.Type;
				if (type2 == null)
				{
					type2 = fieldInfo.FieldType;
				}
				UnityEngine.Object value;
				if (string.IsNullOrEmpty(sceneBindAttribute.Path))
				{
					value = ((!sceneBindAttribute.CreateIfNotExist) ? Scene.Find(type2, bindingBase) : Scene.FindOrCreate(type2, bindingBase));
				}
				else
				{
					Transform transform = ((!(bindingBase == null) && !sceneBindAttribute.ForceToGlobalSearch) ? (Scene.GetChild(bindingBase, sceneBindAttribute.Path, typeof(Transform)) as Transform) : (Scene.GetObject(sceneBindAttribute.Path, typeof(Transform)) as Transform));
					if (transform == null)
					{
						continue;
					}
					GameObject gameObject = transform.gameObject;
					value = ((!sceneBindAttribute.CreateIfNotExist) ? Scene.Get(gameObject, type2) : Scene.GetOrCreate(gameObject, type2));
				}
				fieldInfo.SetValue(o, value);
				UnityEngine.Object obj = fieldInfo.GetValue(o) as UnityEngine.Object;
				if (obj != null)
				{
					list.Add(obj);
					continue;
				}
				Log.Warning("unable to bind '{0}', not found", sceneBindAttribute.Path);
			}
		}
		return list;
	}
}
