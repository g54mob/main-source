using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
	public List<GameObject> items;

	private void Start()
	{
		items = new List<GameObject>();
	}

	public void ClearShelf()
	{
		foreach (GameObject item in items)
		{
			Object.Destroy(item);
		}
		items.Clear();
	}
}
