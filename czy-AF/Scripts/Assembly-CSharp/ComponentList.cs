using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentList : MonoBehaviour
{
	public Transform holder;

	public GameObject template;

	public Vector2 templateSize = new Vector2(24f, 24f);

	public Vector2 templatePadding = new Vector2(4f, 4f);

	public Dictionary<Transform, Hashtable> data = new Dictionary<Transform, Hashtable>();

	private void Awake()
	{
		holder.GetComponent<GridLayoutGroup>().cellSize = templateSize;
		holder.GetComponent<GridLayoutGroup>().spacing = templatePadding;
	}

	public GameObject AddElement(Hashtable hashtable)
	{
		GameObject gameObject = Object.Instantiate(template, holder);
		gameObject.SetActive(value: true);
		gameObject.name = (string)hashtable["name"];
		gameObject.SendMessage("SetData", hashtable, SendMessageOptions.DontRequireReceiver);
		data.Add(gameObject.transform, hashtable);
		return gameObject;
	}

	public void RemoveElement(string name)
	{
		foreach (Transform item in holder)
		{
			if (item.name == name)
			{
				data.Remove(item);
				Object.DestroyImmediate(item.gameObject);
			}
		}
	}

	public void SetElement(string name, string hashtableKey, object hashtableValue)
	{
		foreach (Transform item in holder)
		{
			if (item.name == name)
			{
				data[item][hashtableKey] = hashtableValue;
				break;
			}
		}
		UpdateElements();
	}

	public void SetAllElements(string hashtableKey, object hashtableValue)
	{
		foreach (Transform item in holder)
		{
			data[item][hashtableKey] = hashtableValue;
		}
		UpdateElements();
	}

	public void UpdateElements()
	{
		foreach (Transform key in data.Keys)
		{
			key.SendMessage("SetData", data[key], SendMessageOptions.DontRequireReceiver);
		}
	}

	public void Clear()
	{
		data.Clear();
		foreach (Transform item in holder)
		{
			Object.Destroy(item.gameObject);
		}
		ResetScrolling();
	}

	public void SetTemplate(Transform t)
	{
		template = t.gameObject;
	}

	public void ResetScrolling()
	{
		base.transform.GetComponentInChildren<ScrollRect>().verticalNormalizedPosition = 1f;
	}
}
