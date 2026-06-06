using System.Collections.Generic;
using UnityEngine;

public class GameObjectTreeElement
{
	public GameObject GameObject;

	public int HierarchyLevel;

	public bool Combine;

	public GameObjectTreeElement Parent;

	public GameObjectTreeElement(GameObject gameObject, int hierarchyLevel, GameObjectTreeElement parent = null)
	{
		GameObject = gameObject;
		HierarchyLevel = hierarchyLevel;
		Combine = true;
		Parent = parent;
	}

	public static GameObjectTreeElement GetElement(List<GameObjectTreeElement> list, int id)
	{
		foreach (GameObjectTreeElement item in list)
		{
			if (item.GameObject.GetInstanceID() == id)
			{
				return item;
			}
		}
		return null;
	}
}
