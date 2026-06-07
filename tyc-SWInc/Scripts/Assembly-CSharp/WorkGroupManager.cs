using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorkGroupManager : MonoBehaviour
{
	public enum GroupType
	{
		None = 0,
		Type = 1,
		Project = 2
	}

	public WorkGroupItem WorkGroupPrefab;

	public SubWorkItem SubWorkPrefab;

	public RectTransform GroupPanel;

	public UINotificationDropdownList ActionDropdown;

	public Toggle[] GroupToggles;

	[NonSerialized]
	public GroupType Grouping;

	[NonSerialized]
	private Dictionary<string, WorkGroupItem> _groups = new Dictionary<string, WorkGroupItem>();

	[NonSerialized]
	private List<WorkGroupItem> _groupPool = new List<WorkGroupItem>();

	[NonSerialized]
	private Dictionary<string, HashSet<WorkItem>> _contentCache = new Dictionary<string, HashSet<WorkItem>>();

	[NonSerialized]
	private List<WorkGroupItem> _deleteCache = new List<WorkGroupItem>();

	private bool _disableUpdate;

	public bool HasAny
	{
		get
		{
			return _groups.Count > 0;
		}
	}

	private WorkGroupItem GetGroupItem()
	{
		WorkGroupItem workGroupItem;
		if (_groupPool.Count == 0)
		{
			workGroupItem = UnityEngine.Object.Instantiate(WorkGroupPrefab);
			workGroupItem.transform.SetParent(GroupPanel, false);
		}
		else
		{
			workGroupItem = _groupPool.Last();
			_groupPool.RemoveAt(_groupPool.Count - 1);
			workGroupItem.gameObject.SetActive(true);
		}
		return workGroupItem;
	}

	public void ChangeTypeToggle()
	{
		if (_disableUpdate)
		{
			return;
		}
		for (int i = 0; i < GroupToggles.Length; i++)
		{
			if (GroupToggles[i].isOn)
			{
				ChangeType(i);
				break;
			}
		}
	}

	public void ChangeType(int type)
	{
		_disableUpdate = true;
		for (int i = 0; i < GroupToggles.Length; i++)
		{
			GroupToggles[i].isOn = type == i;
		}
		_disableUpdate = false;
		Grouping = (GroupType)type;
		foreach (WorkGroupItem value in _groups.Values)
		{
			value.Clear();
			value.gameObject.SetActive(false);
		}
		_groupPool.AddRange(_groups.Values);
		_groups.Clear();
		foreach (WorkItem workItem in GameSettings.Instance.MyCompany.WorkItems)
		{
			if (workItem.guiItem != null)
			{
				workItem.guiItem.UpdateActivation();
			}
		}
	}

	private void Update()
	{
		if (Grouping != GroupType.None && !GameSettings.Instance.IsReferenceNull())
		{
			UpdateWithType(Grouping);
		}
	}

	public ValueTuple<WorkGroupItem, SubWorkItem> GetItem(WorkItem item)
	{
		string grouping = GetGrouping(Grouping, item);
		WorkGroupItem value;
		SubWorkItem s;
		if (grouping != null && _groups.TryGetValue(grouping, out value) && value.TryGetItem(item, out s))
		{
			return new ValueTuple<WorkGroupItem, SubWorkItem>(value, s);
		}
		return new ValueTuple<WorkGroupItem, SubWorkItem>(null, null);
	}

	public static string GetGrouping(GroupType type, WorkItem item)
	{
		switch (type)
		{
		case GroupType.Type:
			return item.GetGroupType();
		case GroupType.Project:
			return item.GetGroupProject();
		default:
			return null;
		}
	}

	public static string GetGroupingLabel(GroupType type, WorkItem item)
	{
		switch (type)
		{
		case GroupType.Type:
			return item.GetGroupTypeLabel();
		case GroupType.Project:
			return item.GetGroupProjectLabel();
		default:
			return null;
		}
	}

	public static Sprite GetIcon(GroupType type, WorkItem item)
	{
		switch (type)
		{
		case GroupType.Type:
			return ObjectDatabase.GetIcon(item.GetIcon());
		case GroupType.Project:
			return ObjectDatabase.GetIcon("Software");
		default:
			return ObjectDatabase.GetIcon("Question");
		}
	}

	public static Color GetColor(GroupType type, WorkItem item)
	{
		switch (type)
		{
		case GroupType.Type:
			return item.BackColor;
		case GroupType.Project:
			if (!item.HasProjectGrouping())
			{
				return item.BackColor;
			}
			break;
		}
		return new Color(0f, 0.75f, 0f);
	}

	private void SortGroups()
	{
		int num = 0;
		foreach (KeyValuePair<string, WorkGroupItem> item in _groups.OrderBy((KeyValuePair<string, WorkGroupItem> x) => x.Key))
		{
			item.Value.transform.SetSiblingIndex(num);
			num++;
		}
	}

	private void UpdateWithType(GroupType type)
	{
		foreach (WorkItem workItem in GameSettings.Instance.MyCompany.WorkItems)
		{
			if (!workItem.Hidden && !workItem.Done && workItem.guiItem != null && workItem.guiItem.IsUnfiltered())
			{
				string grouping = GetGrouping(type, workItem);
				if (grouping != null)
				{
					_contentCache.Append(grouping, workItem);
				}
			}
		}
		bool flag = false;
		foreach (KeyValuePair<string, HashSet<WorkItem>> item2 in _contentCache)
		{
			WorkGroupItem value;
			if (!_groups.TryGetValue(item2.Key, out value))
			{
				value = GetGroupItem();
				WorkItem item = item2.Value.First();
				value.Init(item2.Key, GetIcon(type, item), GetColor(type, item), type == GroupType.Type);
				_groups[item2.Key] = value;
				flag = true;
			}
			value.UpdateContent(item2.Value);
		}
		if (flag)
		{
			SortGroups();
		}
		foreach (KeyValuePair<string, WorkGroupItem> group in _groups)
		{
			if (!_contentCache.ContainsKey(group.Key))
			{
				_deleteCache.Add(group.Value);
			}
		}
		if (_deleteCache.Count > 0)
		{
			for (int i = 0; i < _deleteCache.Count; i++)
			{
				WorkGroupItem workGroupItem = _deleteCache[i];
				_groups.Remove(workGroupItem.Key);
				workGroupItem.Clear();
				workGroupItem.gameObject.SetActive(false);
				_groupPool.Add(workGroupItem);
			}
			_deleteCache.Clear();
		}
		_contentCache.Clear();
	}
}
