using System.Collections.Generic;
using UnityEngine;

public class UIList : MonoBehaviour
{
	[SerializeField]
	private UIListElement elementPrefab;

	[SerializeField]
	private RectTransform listTransform;

	[SerializeField]
	private bool fillWithEmptyElements;

	[SerializeField]
	private GameObject emptyElementPrefab;

	[SerializeField]
	[Tooltip("Fill with empty elements until this size is reached")]
	private int fillWithEmptiesSize = 1;

	private List<UIListElement> elements;

	private List<GameObject> emptyElements;

	public List<UIListElement> Elements => elements;

	private void Awake()
	{
		if (elements == null)
		{
			elements = new List<UIListElement>();
		}
		if (emptyElements == null)
		{
			emptyElements = new List<GameObject>();
		}
	}

	private void AddElement(object elementData)
	{
		UIListElement component = Object.Instantiate(elementPrefab.gameObject, listTransform).GetComponent<UIListElement>();
		elements.Add(component);
		component.Index = elements.Count - 1;
		component.Data = elementData;
	}

	public void LoadList(IEnumerable<object> elementsData)
	{
		ClearList();
		if (elementsData != null)
		{
			foreach (object elementsDatum in elementsData)
			{
				AddElement(elementsDatum);
			}
		}
		if (fillWithEmptyElements)
		{
			UpdateEmptyElements();
		}
	}

	public void ClearList()
	{
		elements = new List<UIListElement>();
		emptyElements = new List<GameObject>();
		listTransform.DeleteAllChildren();
	}

	private void UpdateEmptyElements()
	{
		if (elements.Count + emptyElements.Count < fillWithEmptiesSize)
		{
			while (fillWithEmptiesSize - (elements.Count + emptyElements.Count) > 0)
			{
				emptyElements.Add(Object.Instantiate(emptyElementPrefab, listTransform));
			}
			return;
		}
		for (int i = 0; i < elements.Count + emptyElements.Count - fillWithEmptiesSize; i++)
		{
			if (emptyElements.Count <= 0)
			{
				break;
			}
			Object.Destroy(emptyElements[0]);
			emptyElements.RemoveAt(0);
		}
	}
}
