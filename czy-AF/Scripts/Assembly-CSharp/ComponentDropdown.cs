using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentDropdown : MonoBehaviour
{
	public static GameObject openDropdown;

	public Text dropdownText;

	public float height = 200f;

	public bool maximumHeight;

	public int index;

	public float scroll = 1f;

	public List<string> items = new List<string>();

	public List<DropdownItem> advancedItems = new List<DropdownItem>();

	[Header("Settings")]
	public Transform target;

	public string function;

	private void Start()
	{
		ComponentBase component = GetComponent<ComponentBase>();
		if (component != null)
		{
			maximumHeight = (bool)component.GetData("maximumHeight", maximumHeight);
		}
		if (dropdownText != null && items.Count > 0)
		{
			dropdownText.text = items[index];
		}
	}

	public void Open()
	{
		if (openDropdown == null)
		{
			GameObject obj = (openDropdown = Object.Instantiate(Resources.Load<GameObject>("Interface/Prefabs/DropdownList"), Vector3.zero, Quaternion.identity));
			obj.transform.SetParent(Global.elements["dynamics"], worldPositionStays: false);
			obj.name = base.transform.name;
			obj.transform.position = new Vector2(base.transform.position.x, base.transform.position.y - GetComponent<RectTransform>().rect.height * Preferences.data.visualsScale);
			float num = GetComponent<RectTransform>().rect.width;
			if (num < 120f)
			{
				num = 200f;
			}
			obj.GetComponent<RectTransform>().sizeDelta = new Vector2(num, height);
			obj.GetComponent<DropdownList>().dropdown = base.gameObject.GetComponent<ComponentDropdown>();
			if (target != null)
			{
				target.SendMessage("Open", SendMessageOptions.DontRequireReceiver);
			}
		}
		else
		{
			openDropdown.GetComponent<DropdownList>().Close();
		}
	}

	public void SetValue(int i)
	{
		index = i;
		if (dropdownText != null && items.Count >= index)
		{
			dropdownText.text = items[index];
		}
	}

	public void SetValue(string s)
	{
		int value = int.Parse(s);
		SetValue(value);
	}

	public void SetList(List<string> list)
	{
		items = list;
	}

	public void SetTarget(Transform t)
	{
		target = t;
	}

	public void SetFunction(string f)
	{
		function = f;
	}
}
