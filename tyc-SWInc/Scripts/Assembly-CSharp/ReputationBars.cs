using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ReputationBars : DropDownPanel
{
	public GameObject RepItemPrefab;

	public GameObject LabelPrefab;

	public GameObject contentPanel;

	public RectTransform contentRect;

	private Dictionary<SoftwareType, Dictionary<SoftwareCategory, ReputationItem>> bars = new Dictionary<SoftwareType, Dictionary<SoftwareCategory, ReputationItem>>();

	private float _height = 24f;

	public Company MyCompany
	{
		get
		{
			return GameSettings.Instance.MyCompany;
		}
	}

	protected override float GetHeight()
	{
		return _height;
	}

	protected override void Refresh()
	{
		UpdateBars();
	}

	public void UpdateBars()
	{
		if (MyCompany == null)
		{
			return;
		}
		Dictionary<SoftwareType, Dictionary<SoftwareCategory, float>> dictionary = (from x in MyCompany.GetSoftwareRep()
			group x by x.Key.Parent).ToDictionary((IGrouping<SoftwareType, KeyValuePair<SoftwareCategory, float>> x) => x.Key, (IGrouping<SoftwareType, KeyValuePair<SoftwareCategory, float>> x) => x.ToDictionary((KeyValuePair<SoftwareCategory, float> y) => y.Key, (KeyValuePair<SoftwareCategory, float> y) => y.Value));
		Dictionary<SoftwareCategory, uint> softwarePop = MyCompany.GetSoftwarePop();
		if (dictionary.Sum((KeyValuePair<SoftwareType, Dictionary<SoftwareCategory, float>> x) => x.Value.Count) != bars.Sum((KeyValuePair<SoftwareType, Dictionary<SoftwareCategory, ReputationItem>> x) => x.Value.Count))
		{
			int num = 1;
			foreach (KeyValuePair<SoftwareType, Dictionary<SoftwareCategory, float>> item in dictionary.OrderBy((KeyValuePair<SoftwareType, Dictionary<SoftwareCategory, float>> x) => x.Key.GetActualString()))
			{
				int num2 = item.Key.Categories.Values.Count((SoftwareCategory x) => !x.Hidden);
				Dictionary<SoftwareCategory, ReputationItem> value;
				if (!bars.TryGetValue(item.Key, out value))
				{
					value = new Dictionary<SoftwareCategory, ReputationItem>();
					bars[item.Key] = value;
					GameObject gameObject = MakeBar(item.Key.GetActualString(), num, num2 == 1);
					if (num2 == 1)
					{
						ReputationItem component = gameObject.GetComponent<ReputationItem>();
						component.SetFull();
						value[item.Key.Categories.Values.First((SoftwareCategory x) => !x.Hidden)] = component;
					}
				}
				num++;
				if (num2 == 1)
				{
					KeyValuePair<SoftwareCategory, float> keyValuePair = item.Value.First();
					value[keyValuePair.Key].SetRep(keyValuePair.Value, softwarePop[keyValuePair.Key]);
					continue;
				}
				ReputationItem reputationItem = null;
				foreach (KeyValuePair<SoftwareCategory, float> item2 in item.Value.OrderBy((KeyValuePair<SoftwareCategory, float> x) => x.Key.GetActualString()))
				{
					ReputationItem value2;
					if (!value.TryGetValue(item2.Key, out value2))
					{
						value2 = MakeBar(item2.Key.Name.LocSWC(item.Key.Name), num, true).GetComponent<ReputationItem>();
						value[item2.Key] = value2;
					}
					value2.SetRep(item2.Value, softwarePop[item2.Key]);
					num++;
					value2.SetMiddle();
					reputationItem = value2;
				}
				if (reputationItem != null)
				{
					reputationItem.SetBottom();
				}
			}
		}
		else
		{
			foreach (KeyValuePair<SoftwareType, Dictionary<SoftwareCategory, ReputationItem>> bar in bars)
			{
				foreach (KeyValuePair<SoftwareCategory, ReputationItem> item3 in bar.Value)
				{
					item3.Value.SetRep(dictionary[bar.Key][item3.Key], softwarePop[item3.Key]);
				}
			}
		}
		_height = 28f;
		foreach (KeyValuePair<SoftwareType, Dictionary<SoftwareCategory, ReputationItem>> bar2 in bars)
		{
			if (bar2.Key.Categories.Values.Count((SoftwareCategory x) => !x.Hidden) == 1)
			{
				_height += 38f;
			}
			else
			{
				_height += 38 * bar2.Value.Count + 18;
			}
		}
		_height = Mathf.Min(_height, Screen.height - 128);
	}

	private GameObject MakeBar(string name, int i, bool data)
	{
		if (data)
		{
			GameObject obj = Object.Instantiate(RepItemPrefab);
			obj.GetComponent<ReputationItem>().Label.text = name;
			obj.transform.SetParent(contentPanel.transform, false);
			obj.transform.SetSiblingIndex(i);
			return obj;
		}
		GameObject obj2 = Object.Instantiate(LabelPrefab);
		obj2.transform.SetParent(contentPanel.transform, false);
		obj2.transform.SetSiblingIndex(i);
		obj2.GetComponentInChildren<Text>().text = name;
		return obj2;
	}
}
