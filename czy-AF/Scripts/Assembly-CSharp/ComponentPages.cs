using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentPages : MonoBehaviour
{
	public Transform holder;

	public GameObject template;

	public Vector2 templateSize = new Vector2(44f, 44f);

	public Vector2 templatePadding = new Vector2(5f, 5f);

	public List<Hashtable> data = new List<Hashtable>();

	public Button buttonPrevious;

	public Button buttonNext;

	public Text displayPage;

	public int page;

	private float pageElements;

	private float pageTotal = 1f;

	public Vector2 panelSize = new Vector2(-1f, -1f);

	public void UpdateDisplay()
	{
		RectTransform component = holder.GetComponent<RectTransform>();
		int num = (int)component.rect.width;
		int num2 = (int)component.rect.height;
		int num3 = (int)Mathf.Ceil((float)num / (templateSize.x + templatePadding.x));
		int num4 = (int)Mathf.Floor((float)num2 / (templateSize.y + templatePadding.y));
		if (num4 < 1)
		{
			num4 = 1;
		}
		if (pageElements != (float)(num3 * num4))
		{
			page = 0;
		}
		pageElements = num3 * num4;
		List<Hashtable> list = new List<Hashtable>();
		foreach (Hashtable datum in data)
		{
			if ((bool)datum["enabled"])
			{
				list.Add(datum);
			}
		}
		foreach (Transform item in holder)
		{
			Object.Destroy(item.gameObject);
		}
		pageTotal = Mathf.Ceil((float)list.Count / pageElements);
		if (pageTotal == 0f)
		{
			pageTotal = 1f;
		}
		displayPage.text = "Page " + (page + 1) + " / " + pageTotal;
		buttonPrevious.interactable = page != 0;
		buttonNext.interactable = (float)page < pageTotal - 1f;
		if (list.Count == 0)
		{
			return;
		}
		if (pageTotal == 1f)
		{
			displayPage.text = "";
			buttonPrevious.gameObject.SetActive(value: false);
			buttonNext.gameObject.SetActive(value: false);
		}
		else
		{
			buttonPrevious.gameObject.SetActive(value: true);
			buttonNext.gameObject.SetActive(value: true);
		}
		int num5 = page * (int)pageElements;
		for (int i = 0; (float)i < pageElements; i++)
		{
			GameObject obj = Object.Instantiate(template, holder);
			obj.SetActive(value: true);
			obj.SendMessage("SetData", list[num5], SendMessageOptions.DontRequireReceiver);
			num5++;
			if (num5 >= list.Count)
			{
				break;
			}
		}
	}

	public void OnEnable()
	{
		Global.onWindowResize += UpdateDisplay;
		if (template != null)
		{
			UpdateDisplay();
		}
	}

	public void OnDisable()
	{
		Global.onWindowResize -= UpdateDisplay;
	}

	public void NextPage()
	{
		if ((float)page < pageTotal - 1f)
		{
			page++;
			UpdateDisplay();
		}
	}

	public void PreviousPage()
	{
		if (page > 0)
		{
			page--;
			UpdateDisplay();
		}
	}

	public void AddData(Hashtable h)
	{
		h["enabled"] = true;
		data.Add(h);
	}

	public void Clear()
	{
		data.Clear();
		page = 0;
	}

	public void SetTemplate(Transform t)
	{
		template = t.gameObject;
		UpdateDisplay();
	}

	public void SetSize(float s)
	{
		templateSize = new Vector2(s, s);
		GetComponentInChildren<GridLayoutGroup>().cellSize = templateSize;
		UpdateDisplay();
	}

	public void SetSize(Vector2 v)
	{
		templateSize = new Vector2(v.x, v.y);
		GetComponentInChildren<GridLayoutGroup>().cellSize = templateSize;
		UpdateDisplay();
	}
}
