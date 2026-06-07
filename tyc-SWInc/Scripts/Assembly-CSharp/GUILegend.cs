using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUILegend : MonoBehaviour
{
	public EventList<string> Items = new EventList<string>();

	public List<Color> Colors = new List<Color>();

	public GameObject ItemPrefab;

	public bool Toggleable;

	[NonSerialized]
	public bool Sheet;

	public bool ChangeOnToggleColor;

	public bool HighlightToggled = true;

	public Action OnToggle;

	[NonSerialized]
	public List<KeyValuePair<string, GameObject>> GUIItems = new List<KeyValuePair<string, GameObject>>();

	public Action<int> HighlightCallback;

	public Color DefColor = new Color32(50, 50, 50, byte.MaxValue);

	private bool DisableTrigger;

	private void Start()
	{
		Items.OnChange = UpdateItems;
	}

	public void Highlight(int j)
	{
		int num = 0;
		for (int i = 0; i < GUIItems.Count; i++)
		{
			GameObject value = GUIItems[i].Value;
			bool isOn = value.GetComponentInChildren<Toggle>().isOn;
			Text componentInChildren = value.GetComponentInChildren<Text>();
			componentInChildren.fontStyle = ((isOn && num == j) ? FontStyle.Bold : FontStyle.Normal);
			bool flag = isOn && num == j;
			Outline component;
			if (componentInChildren.TryGetComponent<Outline>(out component))
			{
				if (!flag)
				{
					UnityEngine.Object.Destroy(component);
				}
			}
			else if (flag)
			{
				component = componentInChildren.gameObject.AddComponent<Outline>();
				component.effectColor = value.GetComponentsInChildren<Image>().FirstOrDefault((Image x) => x.name.Equals("Background")).color.ChangeValue(1f);
			}
			if (!HighlightToggled || isOn)
			{
				num++;
			}
		}
	}

	public int GetIthEnabledIndexReverse(int i)
	{
		int num = i;
		for (int num2 = i; num2 >= 0; num2--)
		{
			if (!IsOn(num2))
			{
				num--;
			}
		}
		return num;
	}

	public int GetIthEnabledIndex(int i)
	{
		int num = 0;
		for (int j = 0; j < Items.Count; j++)
		{
			if (IsOn(j))
			{
				if (i == num)
				{
					return j;
				}
				num++;
			}
		}
		return -1;
	}

	public string GetIthEnabled(int i)
	{
		int num = 0;
		for (int j = 0; j < Items.Count; j++)
		{
			if (IsOn(j))
			{
				if (i == num)
				{
					return Items[j];
				}
				num++;
			}
		}
		return null;
	}

	public bool IsOn(int i)
	{
		if (i < GUIItems.Count)
		{
			return GUIItems[i].Value.GetComponent<Toggle>().isOn;
		}
		return false;
	}

	public void SetOn(int i, bool value)
	{
		if (i < GUIItems.Count)
		{
			GUIItems[i].Value.GetComponent<Toggle>().isOn = value;
		}
	}

	private void OnToggleWrap(Toggle t)
	{
		if (DisableTrigger)
		{
			return;
		}
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			DisableTrigger = true;
			for (int i = 0; i < GUIItems.Count; i++)
			{
				Toggle component = GUIItems[i].Value.GetComponent<Toggle>();
				component.isOn = component == t;
			}
			DisableTrigger = false;
		}
		UpdateColors();
		if (OnToggle != null)
		{
			OnToggle();
		}
	}

	private void UpdateColors()
	{
		if (!ChangeOnToggleColor)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < GUIItems.Count; i++)
		{
			GameObject value = GUIItems[i].Value;
			bool isOn = value.GetComponentInChildren<Toggle>().isOn;
			value.GetComponentsInChildren<Image>().FirstOrDefault((Image x) => x.name.Equals("Background")).color = (isOn ? Colors[num % Colors.Count] : Color.white);
			if (HighlightCallback != null)
			{
				EventTrigger component = value.GetComponent<EventTrigger>();
				if (component != null)
				{
					if (isOn)
					{
						int k1 = num;
						component.AddTrigger(EventTriggerType.PointerEnter, delegate
						{
							Highlight(k1);
							HighlightCallback(k1);
						});
					}
					else
					{
						component.ClearTrigger(EventTriggerType.PointerEnter);
					}
				}
			}
			if (isOn)
			{
				num++;
			}
		}
	}

	public void OrderItemsBy(Func<string, float> order)
	{
		Dictionary<int, int> dict = (from x in Items.Select((string x, int i) => new KeyValuePair<int, string>(i, x))
			orderby order(x.Value)
			select x).Select((KeyValuePair<int, string> x, int i) => new KeyValuePair<int, int>(x.Key, i)).ToDictionary((KeyValuePair<int, int> x) => x.Key, (KeyValuePair<int, int> x) => x.Value);
		for (int num = 0; num < GUIItems.Count; num++)
		{
			GUIItems[num].Value.transform.SetSiblingIndex(dict.GetOrDefault(num, 0));
		}
	}

	public void UpdateItems()
	{
		foreach (KeyValuePair<string, GameObject> item in GUIItems.Where((KeyValuePair<string, GameObject> x) => !Items.Contains(x.Key)).ToList())
		{
			GUIItems.RemoveAll((KeyValuePair<string, GameObject> x) => x.Key.Equals(item.Key));
			UnityEngine.Object.Destroy(item.Value.gameObject);
		}
		int num = GUIItems.Count;
		int num2 = 0;
		foreach (string item2 in Items.Where((string x) => !GUIItems.Any((KeyValuePair<string, GameObject> y) => y.Key.Equals(x))))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(ItemPrefab);
			gameObject.GetComponentsInChildren<Image>().FirstOrDefault((Image x) => x.name.Equals("Background")).color = Colors[num % Colors.Count];
			gameObject.GetComponentInChildren<Text>().text = (Sheet ? ("Sheet" + item2).LocDef(item2.Loc()) : item2);
			Toggle toggle = gameObject.GetComponent<Toggle>();
			if (HighlightCallback != null)
			{
				EventTrigger component = gameObject.GetComponent<EventTrigger>();
				if (component != null)
				{
					int i1 = num2;
					component.AddTrigger(EventTriggerType.PointerEnter, delegate
					{
						Highlight(i1);
						HighlightCallback(i1);
					});
					component.AddTrigger(EventTriggerType.PointerExit, delegate
					{
						Highlight(-1);
						HighlightCallback(-1);
					});
				}
			}
			if (!Toggleable)
			{
				toggle.isOn = false;
				toggle.interactable = false;
			}
			else
			{
				toggle.onValueChanged.AddListener(delegate
				{
					OnToggleWrap(toggle);
				});
			}
			gameObject.transform.SetParent(base.transform, false);
			GUIItems.Add(new KeyValuePair<string, GameObject>(item2, gameObject));
			num++;
			num2++;
		}
		if (OnToggle != null)
		{
			OnToggle();
		}
	}
}
