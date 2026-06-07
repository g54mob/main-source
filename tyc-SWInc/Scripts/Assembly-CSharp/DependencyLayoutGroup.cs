using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DependencyLayoutGroup : MaskableGraphic
{
	public GameObject DependencyPanel;

	[NonSerialized]
	private Dictionary<RectTransform, HashSet<RectTransform>> Deps = new Dictionary<RectTransform, HashSet<RectTransform>>();

	[NonSerialized]
	public List<GameObject> Containers = new List<GameObject>();

	protected override void OnPopulateMesh(VertexHelper h)
	{
		h.Clear();
		if (Deps == null || Deps.Count <= 0)
		{
			return;
		}
		float spacing = GetComponent<HorizontalLayoutGroup>().spacing;
		float num = base.rectTransform.rect.height / 2f;
		foreach (KeyValuePair<RectTransform, HashSet<RectTransform>> dep in Deps)
		{
			RectTransform component = dep.Key.parent.GetComponent<RectTransform>();
			float x = component.anchoredPosition.x + component.sizeDelta.x;
			float y = component.anchoredPosition.y + component.sizeDelta.y / 2f + dep.Key.anchoredPosition.y + num;
			foreach (RectTransform item in dep.Value)
			{
				RectTransform component2 = item.parent.GetComponent<RectTransform>();
				float x2 = component2.anchoredPosition.x;
				float y2 = component2.anchoredPosition.y + component2.sizeDelta.y / 2f + item.anchoredPosition.y + num;
				float num2 = Mathf.Lerp(0.2f, 0.9f, (0f - dep.Key.anchoredPosition.y) / component.sizeDelta.y);
				float x3 = Mathf.Lerp(x2 - spacing, x2, 1f - num2);
				h.DrawLine(new Vector2(x, y), new Vector2(x3, y), 2f, color);
				h.DrawLine(new Vector2(x3, y), new Vector2(x3, y2), 2f, color);
				h.DrawArrow(new Vector2(x3, y2), new Vector2(x2, y2), color, 8f);
			}
		}
	}

	public void Clear()
	{
		for (int i = 0; i < Containers.Count; i++)
		{
			UnityEngine.Object.Destroy(Containers[i]);
		}
		Containers.Clear();
		Deps.Clear();
		SetVerticesDirty();
	}

	public void InitContent(Dictionary<RectTransform, HashSet<RectTransform>> Dependencies)
	{
		Deps = Dependencies;
		List<List<RectTransform>> list = new List<List<RectTransform>>();
		List<RectTransform> list2 = Dependencies.Keys.Where((RectTransform x) => !Dependencies.Any((KeyValuePair<RectTransform, HashSet<RectTransform>> y) => y.Value.Contains(x))).ToList();
		HashSet<RectTransform> hashSet = new HashSet<RectTransform>(list2);
		while (list2.Count > 0)
		{
			List<RectTransform> list3 = list2.ToList();
			list2.Clear();
			List<RectTransform> list4 = new List<RectTransform>();
			list.Add(list4);
			foreach (RectTransform item in list3)
			{
				list4.Add(item);
				foreach (RectTransform item2 in Dependencies[item])
				{
					if (hashSet.Contains(item2))
					{
						foreach (List<RectTransform> item3 in list)
						{
							item3.Remove(item2);
						}
					}
					hashSet.Add(item2);
					list2.Add(item2);
				}
			}
		}
		for (int num = 0; num < list.Count; num++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(DependencyPanel);
			Containers.Add(gameObject);
			for (int num2 = 0; num2 < list[num].Count; num2++)
			{
				list[num][num2].SetParent(gameObject.transform, false);
			}
			gameObject.transform.SetParent(base.transform, false);
		}
		SetVerticesDirty();
	}
}
