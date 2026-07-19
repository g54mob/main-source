using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownList : MonoBehaviour
{
	public Transform template;

	public Transform holder;

	public ScrollRect scrollRect;

	public ComponentDropdown dropdown;

	public float height;

	private void Start()
	{
		scrollRect = base.transform.GetChild(0).GetComponent<ScrollRect>();
		base.transform.position = new Vector3(Mathf.Round(base.transform.position.x), Mathf.Round(base.transform.position.y - 1f), 0f);
		template.gameObject.SetActive(value: false);
		int num = 0;
		foreach (string item in dropdown.items)
		{
			GameObject gameObject = Object.Instantiate(template.gameObject, holder);
			gameObject.SetActive(value: true);
			gameObject.name = num.ToString() ?? "";
			if (num == dropdown.index && dropdown.dropdownText != null)
			{
				gameObject.transform.GetComponent<Hover>().childDefaultColor = Global.Hex("#EB3B5A");
			}
			if (item.Contains("#") || item.Contains("---"))
			{
				Object.Destroy(gameObject.GetComponent<Button>());
				Object.Destroy(gameObject.GetComponent<Hover>());
				gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.grey;
			}
			string text = item.Replace("#", "");
			if (item.Contains("---"))
			{
				gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.075f);
				gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 2f);
				text = "";
			}
			if (item.Contains(":"))
			{
				text = item.Split(":"[0])[0].Replace("#", "");
				gameObject.transform.GetChild(1).GetComponent<Text>().text = item.Split(":"[0])[1];
			}
			height += (int)gameObject.GetComponent<RectTransform>().rect.height;
			gameObject.transform.GetChild(0).GetComponent<Text>().text = text;
			num++;
		}
		foreach (DropdownItem advancedItem in dropdown.advancedItems)
		{
			GameObject gameObject2 = Object.Instantiate(template.gameObject, holder);
			gameObject2.SetActive(value: true);
			gameObject2.name = advancedItem.id;
			if (num == dropdown.index && dropdown.dropdownText != null)
			{
				gameObject2.transform.GetComponent<Hover>().childDefaultColor = Global.Hex("#EB3B5A");
			}
			if (!advancedItem.enabled || advancedItem.id == "---")
			{
				Object.Destroy(gameObject2.GetComponent<Button>());
				Object.Destroy(gameObject2.GetComponent<Hover>());
				gameObject2.transform.GetChild(0).GetComponent<Text>().color = Color.grey;
			}
			string text2 = advancedItem.name;
			if (advancedItem.id == "---")
			{
				gameObject2.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.075f);
				gameObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 2f);
				text2 = "";
			}
			if (advancedItem.hotkey != "")
			{
				gameObject2.transform.GetChild(1).GetComponent<Text>().text = advancedItem.hotkey;
			}
			height += (int)gameObject2.GetComponent<RectTransform>().rect.height;
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = text2;
			num++;
		}
		if (dropdown.maximumHeight)
		{
			GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, height + 8f);
		}
		scrollRect.verticalNormalizedPosition = dropdown.scroll;
	}

	private void Update()
	{
		EventSystem.current.SetSelectedGameObject(dropdown.gameObject);
		if (Control.hover != null && (bool)Control.hover.GetComponent<ComponentDropdown>() && Control.hover != dropdown.gameObject && Control.hover.transform.parent == dropdown.transform.parent)
		{
			Close();
			Control.hover.GetComponent<ComponentDropdown>().Open();
		}
		if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition, null))
		{
			Close();
		}
	}

	public void Close()
	{
		EventSystem.current.SetSelectedGameObject(null);
		ComponentDropdown.openDropdown = null;
		Object.Destroy(base.gameObject);
	}

	public void Click(Button button)
	{
		if (int.TryParse(button.name, out var _))
		{
			int num = int.Parse(button.name);
			dropdown.transform.GetComponent<ComponentBase>().Callback(base.name + "Select", num, dropdown.transform);
			dropdown.SetValue(num);
			dropdown.scroll = scrollRect.verticalNormalizedPosition;
		}
		else
		{
			dropdown.target.SendMessage("Select", dropdown.name + "/" + button.name, SendMessageOptions.DontRequireReceiver);
		}
		Close();
	}
}
