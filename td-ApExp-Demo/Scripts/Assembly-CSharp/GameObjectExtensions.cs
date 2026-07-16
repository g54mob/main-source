using UnityEngine;

public static class GameObjectExtensions
{
	public static void SetActiveRecursive(this GameObject go, bool active)
	{
		go.SetActive(active);
		foreach (Transform item in go.transform)
		{
			item.gameObject.SetActiveRecursive(active);
		}
	}

	public static Transform GetChildByNameRecursive(this Transform tf, string name)
	{
		foreach (Transform item in tf)
		{
			if (item.name == name)
			{
				return item;
			}
			Transform childByNameRecursive = item.GetChildByNameRecursive(name);
			if (childByNameRecursive != null)
			{
				return childByNameRecursive;
			}
		}
		return null;
	}
}
