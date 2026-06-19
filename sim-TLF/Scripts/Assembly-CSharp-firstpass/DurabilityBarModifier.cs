using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniversalInventorySystem;

public class DurabilityBarModifier : BaseUIModifier
{
	public Gradient gradient;

	public Color BackgroundColor;

	public Material mat;

	[Range(0f, 100f)]
	public float percentageX;

	[Range(0f, 100f)]
	public float percentageY;

	public Vector2 offset;

	private List<(int index, GameObject go)> gos = new List<(int, GameObject)>();

	public void LateUpdate()
	{
		for (int i = 0; i < target.slots.Count; i++)
		{
			if (!target.GetInventory()[i] || !target.GetInventory()[i].item.hasDurability)
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < gos.Count; j++)
			{
				if (gos[j].index == i)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				GameObject gameObject = new GameObject();
				gameObject.transform.SetParent(target.slots[i].transform);
				gameObject.name = "DurabilityBar";
				Image image = gameObject.AddComponent<Image>();
				image.sprite = null;
				image.raycastTarget = false;
				image.material = new Material(mat);
				Vector2 sizeDelta = new Vector2((target.slots[i].transform as RectTransform).sizeDelta.x * (percentageX / 100f), (target.slots[i].transform as RectTransform).sizeDelta.y * (percentageY / 100f));
				(gameObject.transform as RectTransform).sizeDelta = sizeDelta;
				(gameObject.transform as RectTransform).localScale = (target.slots[i].transform as RectTransform).localScale;
				Vector2 vector = new Vector2((target.slots[i].transform as RectTransform).position.x + offset.x, (target.slots[i].transform as RectTransform).position.y + offset.y);
				(gameObject.transform as RectTransform).position = vector;
				gos.Add((i, gameObject));
			}
		}
		while (true)
		{
			int num = 0;
			while (true)
			{
				if (num < gos.Count)
				{
					if (!target.GetInventory()[gos[num].index].hasItem)
					{
						Object.Destroy(gos[num].go, 1E-11f);
						gos.RemoveAt(num);
						break;
					}
					if (!target.GetInventory()[gos[num].index].item.hasDurability)
					{
						Object.Destroy(gos[num].go, 1E-11f);
						gos.RemoveAt(num);
						break;
					}
					float num2 = (float)target.GetInventory()[gos[num].index].durability / (float)target.GetInventory()[gos[num].index].item.maxDurability;
					Image component = gos[num].go.GetComponent<Image>();
					component.sprite = null;
					component.material.SetFloat("_FillAmount", num2);
					component.material.SetColor("_Color", gradient.Evaluate(num2));
					component.material.SetColor("_BackGroundColor", BackgroundColor);
					Vector2 sizeDelta2 = new Vector2((target.slots[gos[num].index].transform as RectTransform).sizeDelta.x * (percentageX / 100f), (target.slots[gos[num].index].transform as RectTransform).sizeDelta.y * (percentageY / 100f));
					(gos[num].go.transform as RectTransform).sizeDelta = sizeDelta2;
					Vector2 vector2 = new Vector2((target.slots[gos[num].index].transform as RectTransform).position.x + offset.x, (target.slots[gos[num].index].transform as RectTransform).position.y + offset.y);
					(gos[num].go.transform as RectTransform).position = vector2;
					num++;
					continue;
				}
				return;
			}
		}
	}
}
