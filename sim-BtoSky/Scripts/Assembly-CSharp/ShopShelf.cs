using System.Collections.Generic;
using UnityEngine;

public class ShopShelf : MonoBehaviour
{
	public List<GameObject> objs;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public float RefillShelf()
	{
		float num = 0f;
		foreach (GameObject obj in objs)
		{
			if (!obj.activeSelf)
			{
				obj.SetActive(value: true);
				num += obj.GetComponent<ShopShelfItem>().itemPrefab.GetComponent<Item>().value;
			}
		}
		return num;
	}
}
