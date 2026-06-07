using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorkGroupItem : MonoBehaviour
{
	public RectTransform SubWorkPanel;

	public Text MainLabel;

	public Image MainSprite;

	public Image TopBar;

	public LayoutElement MainLayout;

	[NonSerialized]
	public string Key;

	[NonSerialized]
	private Dictionary<WorkItem, SubWorkItem> _workItems = new Dictionary<WorkItem, SubWorkItem>();

	[NonSerialized]
	private List<SubWorkItem> _workPool = new List<SubWorkItem>();

	private static List<SubWorkItem> _removePool = new List<SubWorkItem>();

	private bool _wasEnabled = true;

	public bool TryGetItem(WorkItem item, out SubWorkItem s)
	{
		return _workItems.TryGetValue(item, out s);
	}

	public void ToggleSubItems(bool enabled)
	{
		if (enabled != _wasEnabled)
		{
			_workItems.Values.ForEachEnum(delegate(SubWorkItem x)
			{
				x.enabled = enabled;
			});
			_wasEnabled = enabled;
		}
	}

	public void Init(string label, Sprite thumb, Color color, bool translate)
	{
		Key = label;
		TopBar.color = color;
		MainLabel.text = (translate ? label.Loc() : label);
		MainSprite.sprite = thumb;
		_wasEnabled = true;
	}

	public void Clear()
	{
		foreach (SubWorkItem value in _workItems.Values)
		{
			value.Work = null;
			value.gameObject.SetActive(false);
		}
		_workPool.AddRange(_workItems.Values);
		_workItems.Clear();
	}

	private SubWorkItem GetSubItem()
	{
		SubWorkItem subWorkItem;
		if (_workPool.Count == 0)
		{
			subWorkItem = UnityEngine.Object.Instantiate(HUD.Instance.GroupTaskManager.SubWorkPrefab);
			subWorkItem.transform.SetParent(SubWorkPanel, false);
		}
		else
		{
			subWorkItem = _workPool.Last();
			_workPool.RemoveAt(_workPool.Count - 1);
			subWorkItem.gameObject.SetActive(true);
		}
		subWorkItem.enabled = _wasEnabled;
		return subWorkItem;
	}

	public float GetHeight()
	{
		int count = _workItems.Count;
		return 58 + count * 24 + (count - 1);
	}

	private void SortWork()
	{
		int num = 0;
		foreach (SubWorkItem item in _workItems.Values.OrderBy((SubWorkItem x) => x.Label))
		{
			item.transform.SetSiblingIndex(num);
			num++;
		}
	}

	public void UpdateContent(HashSet<WorkItem> items)
	{
		bool flag = false;
		foreach (WorkItem item in items)
		{
			if (!_workItems.ContainsKey(item))
			{
				SubWorkItem subItem = GetSubItem();
				_workItems[item] = subItem;
				subItem.Init(item, HUD.Instance.GroupTaskManager.Grouping);
				flag = true;
			}
		}
		if (flag)
		{
			SortWork();
		}
		foreach (KeyValuePair<WorkItem, SubWorkItem> workItem in _workItems)
		{
			if (!items.Contains(workItem.Key))
			{
				_removePool.Add(workItem.Value);
			}
		}
		if (_removePool.Count > 0)
		{
			for (int i = 0; i < _removePool.Count; i++)
			{
				SubWorkItem subWorkItem = _removePool[i];
				_workItems.Remove(subWorkItem.Work);
				subWorkItem.gameObject.SetActive(false);
				subWorkItem.Work = null;
				_workPool.Add(subWorkItem);
			}
			_removePool.Clear();
		}
		MainLayout.minHeight = GetHeight();
	}
}
