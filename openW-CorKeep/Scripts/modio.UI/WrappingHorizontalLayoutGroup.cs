using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrappingHorizontalLayoutGroup : MonoBehaviour
{
	public float cellHeight;

	public Vector2 padding;

	private HashSet<GameObject> elements = new HashSet<GameObject>();

	private List<List<GameObject>> rows = new List<List<GameObject>>();

	private float MaxWidth => ((RectTransform)base.transform).sizeDelta.x;

	private float CurrentRowHeight => -1f * (cellHeight * (float)(rows.Count - 1) + padding.y * (float)(rows.Count - 1));

	public void AddGameObjectToLayout(GameObject gameObject)
	{
		if (elements.Contains(gameObject))
		{
			Debug.LogError("Can't add GO to layout group, it already exists.");
			return;
		}
		elements.Add(gameObject);
		gameObject.transform.SetParent(base.transform);
		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)gameObject.transform);
		float num = ((RectTransform)gameObject.transform).sizeDelta.x + padding.x;
		List<GameObject> list = CurrentRow();
		float num2 = RowWidth(list);
		if (num2 + num > MaxWidth)
		{
			list = AddRow();
			num2 = 0f;
		}
		gameObject.transform.localPosition = new Vector2(num2, CurrentRowHeight);
		list.Add(gameObject);
	}

	public void EmptyLayoutGroup()
	{
		elements.Clear();
		rows.Clear();
	}

	private List<GameObject> AddRow()
	{
		rows.Add(new List<GameObject>());
		return rows[rows.Count - 1];
	}

	private List<GameObject> CurrentRow()
	{
		if (rows.Count == 0)
		{
			return AddRow();
		}
		return rows[rows.Count - 1];
	}

	private float RowWidth(List<GameObject> row)
	{
		float num = 0f;
		foreach (GameObject item in row)
		{
			if (item.transform is RectTransform rectTransform)
			{
				num += rectTransform.sizeDelta.x + padding.x;
			}
		}
		return num;
	}
}
