using System.Collections.Generic;
using UnityEngine;

public static class GameObjectHelper
{
	public static void SetActive<T>(bool value, List<T> components) where T : Component
	{
		if (components != null)
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				components[i].gameObject.SetActive(value);
			}
		}
	}
}
