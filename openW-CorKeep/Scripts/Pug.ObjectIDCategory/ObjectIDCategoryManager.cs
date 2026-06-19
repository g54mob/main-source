using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ObjectIDCategoryManager
{
	private static Dictionary<string, ObjectIDCategory> _parentLookup = new Dictionary<string, ObjectIDCategory>();

	private static Dictionary<string, List<ObjectIDCategory>> _childrenLookup = new Dictionary<string, List<ObjectIDCategory>>();

	public static IEnumerable<ObjectIDCategory> Categories { get; private set; }

	public static IEnumerable<ObjectIDCategory> ParentCategories { get; private set; }

	public static IEnumerable<ObjectIDCategory> SubCategories { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Init()
	{
		_parentLookup.Clear();
		_childrenLookup.Clear();
		ObjectIDCategory[] array = Resources.LoadAll<ObjectIDCategory>("ObjectIDCategories");
		for (int i = 0; i < array.Length; i++)
		{
			_Add(array[i]);
		}
		UpdateLists();
	}

	public static void Add(ObjectIDCategory objectIDCategory)
	{
		_Add(objectIDCategory);
		UpdateLists();
	}

	private static void _Add(ObjectIDCategory objectIDCategory)
	{
		string[] array = objectIDCategory.name.Split('_');
		if (array.Length > 1)
		{
			if (_parentLookup.TryGetValue(array[0], out var value))
			{
				objectIDCategory.SetParentCategory(value);
			}
			if (!_childrenLookup.TryGetValue(array[0], out var value2))
			{
				value2 = new List<ObjectIDCategory>();
				_childrenLookup.Add(array[0], value2);
			}
			value2.Add(objectIDCategory);
			return;
		}
		if (_parentLookup.ContainsKey(array[0]))
		{
			Debug.LogWarning("overriding parent category " + array[0]);
			_parentLookup.Remove(array[0]);
		}
		_parentLookup.Add(array[0], objectIDCategory);
		if (!_childrenLookup.TryGetValue(array[0], out var value3))
		{
			return;
		}
		foreach (ObjectIDCategory item in value3)
		{
			item.SetParentCategory(objectIDCategory);
		}
	}

	private static void UpdateLists()
	{
		ParentCategories = _parentLookup.Values;
		SubCategories = _childrenLookup.Values.SelectMany((List<ObjectIDCategory> x) => x);
		Categories = ParentCategories.Concat(SubCategories);
	}
}
