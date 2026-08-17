using System.Collections.Generic;
using UnityEngine;

namespace FavoritesTabs;

public class FG_GameObjectGUIDs : MonoBehaviour
{
	public static bool _dirty = true;

	public static HashSet<FG_GameObjectGUIDs> allInstances;

	public List<string> guids;

	public List<Object> objects;

	public static void Test()
	{
	}

	protected FG_GameObjectGUIDs()
	{
		List<string> list = new List<string>();
		guids = list;
		List<Object> list2 = new List<Object>();
		objects = list2;
		_dirty = true;
	}

	protected void Awake()
	{
		bool flag = ((HashSet<object>)(object)allInstances).AddIfNotPresent((object)this) || _dirty;
		bool flag2 = !flag;
		bool dirty = !flag2;
		_dirty = dirty;
	}

	protected void OnEnable()
	{
		bool flag = ((HashSet<object>)(object)allInstances).AddIfNotPresent((object)this) || _dirty;
		bool flag2 = !flag;
		bool dirty = !flag2;
		_dirty = dirty;
	}

	protected void OnDisable()
	{
		_dirty = true;
	}

	protected void OnDestroy()
	{
		bool flag = ((HashSet<object>)(object)allInstances).Remove((object)this) || _dirty;
		bool flag2 = !flag;
		bool dirty = !flag2;
		_dirty = dirty;
	}

	static FG_GameObjectGUIDs()
	{
		HashSet<FG_GameObjectGUIDs> hashSet = (HashSet<FG_GameObjectGUIDs>)(object)new HashSet<object>();
		allInstances = hashSet;
	}
}
