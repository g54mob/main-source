using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HardwareGroupWindow : MonoBehaviour
{
	public enum GroupType
	{
		MeshObject = 0,
		AttachmentPoint = 1,
		Attachment = 2,
		Morph = 3
	}

	public GUIWindow Window;

	public HardwareDesignGroup GroupPrefab;

	public Transform[] GroupPanels;

	[NonSerialized]
	public HardwareDesign Design;

	public void Save()
	{
		ApplyGroups(Design.Objects, GroupType.MeshObject, delegate(HardwareDesign.MeshObject x, int i)
		{
			x.GroupID = i;
		});
		ApplyGroups(Design.Attachments, GroupType.AttachmentPoint, delegate(HardwareDesign.AttachmentPoint x, int i)
		{
			x.GroupID = i;
		});
		ApplyGroups(Design.Attachments.SelectMany((HardwareDesign.AttachmentPoint x) => x.Attachments), GroupType.Attachment, delegate(HardwareDesign.Attachment x, int i)
		{
			x.GroupID = i;
		});
		ApplyGroups(Design.Objects.SelectMany((HardwareDesign.MeshObject x) => x.MorphTargets), GroupType.Morph, delegate(HardwareDesign.MorphInfo x, int i)
		{
			x.GroupID = i;
		});
		foreach (HardwareDesign.AttachmentPoint attachment in Design.Attachments)
		{
			attachment.ControlOnlyEmpty = false;
		}
		foreach (HardwareDesignGroup group in GetGroups(GroupPanels[1]))
		{
			foreach (HardwareDesign.AttachmentPoint item in group.Content.OfType<HardwareDesign.AttachmentPoint>())
			{
				item.ControlOnlyEmpty = group.ControlOnlyEmpty;
			}
		}
		HardwareDesignEditor.Instance.MarkAsChanged();
		Window.Close();
	}

	private void ApplyGroups<T>(IEnumerable<T> elements, GroupType t, Action<T, int> SetGroup) where T : class
	{
		Dictionary<T, int> grouped = GetGrouped<T>(GroupPanels[(int)t]);
		foreach (T element in elements)
		{
			SetGroup(element, grouped.GetOrDefault(element, -1));
		}
	}

	public void AddGroup(int type)
	{
		GroupType t = (GroupType)type;
		Transform panel = GroupPanels[type];
		IEnumerable elligable;
		switch (t)
		{
		default:
			return;
		case GroupType.MeshObject:
			elligable = GetElligable(Design.Objects, panel, -1);
			break;
		case GroupType.AttachmentPoint:
			elligable = GetElligable(Design.Attachments, panel, -1);
			break;
		case GroupType.Attachment:
			elligable = GetElligable(Design.Attachments.SelectMany((HardwareDesign.AttachmentPoint x) => x.Attachments), panel, -1);
			break;
		case GroupType.Morph:
			elligable = GetElligable(Design.Objects.SelectMany((HardwareDesign.MeshObject x) => x.MorphTargets), panel, -1);
			break;
		}
		List<object> objects = new List<object>();
		List<string> list = new List<string>();
		if (t == GroupType.AttachmentPoint)
		{
			objects.Add(null);
			list.Add("Control only whether empty");
		}
		foreach (object item in elligable)
		{
			objects.Add(item);
			list.Add(GetLabel(item, Design, t));
		}
		WindowManager.Instance.MultiWindow.ShowMulti("Pick", list, null, delegate(int[] x)
		{
			int num = ((t == GroupType.AttachmentPoint && x.Length != 0 && x[0] == 0) ? 1 : 0);
			int num2 = ((t != GroupType.Morph) ? 1 : 0);
			if (x.Length > num + num2)
			{
				int availableGroup = GetAvailableGroup(panel);
				HardwareDesignGroup hardwareDesignGroup = CreateGroup(from z in x.Skip(num)
					select objects[z], t, panel, availableGroup);
				if (t == GroupType.AttachmentPoint)
				{
					hardwareDesignGroup.ControlOnlyEmpty = x[0] == 0;
				}
			}
		});
	}

	public static IEnumerable<HardwareDesignGroup> GetGroups(Transform panel)
	{
		for (int i = 0; i < panel.childCount; i++)
		{
			HardwareDesignGroup component = panel.GetChild(i).GetComponent<HardwareDesignGroup>();
			if (component != null)
			{
				yield return component;
			}
		}
	}

	public static int GetAvailableGroup(Transform panel)
	{
		int i = 1;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (HardwareDesignGroup group in GetGroups(panel))
		{
			hashSet.Add(group.Group);
		}
		for (; hashSet.Contains(i); i++)
		{
		}
		return i;
	}

	public static string GetLabel(object e, HardwareDesign d, GroupType t)
	{
		switch (t)
		{
		case GroupType.MeshObject:
			return ((HardwareDesign.MeshObject)e).Name;
		case GroupType.AttachmentPoint:
			return ((HardwareDesign.AttachmentPoint)e).Name;
		case GroupType.Attachment:
		{
			HardwareDesign.Attachment at = (HardwareDesign.Attachment)e;
			HardwareDesign.AttachmentPoint attachmentPoint = d.Attachments.FirstOrDefault((HardwareDesign.AttachmentPoint x) => x.Attachments.Contains(at));
			if (attachmentPoint != null)
			{
				return attachmentPoint.Name + "." + d.GetObject(at.Object).Name;
			}
			return d.GetObject(at.Object).Name;
		}
		case GroupType.Morph:
		{
			HardwareDesign.MorphInfo m = (HardwareDesign.MorphInfo)e;
			HardwareDesign.MeshObject meshObject = d.Objects.FirstOrDefault((HardwareDesign.MeshObject x) => x.MorphTargets != null && x.MorphTargets.Contains(m));
			if (meshObject != null)
			{
				return meshObject.Name + "." + m.Label;
			}
			return m.Label;
		}
		default:
			return e.ToString();
		}
	}

	public static Dictionary<T, int> GetGrouped<T>(Transform panel) where T : class
	{
		Dictionary<T, int> dictionary = new Dictionary<T, int>();
		foreach (HardwareDesignGroup group in GetGroups(panel))
		{
			foreach (object item in group.Content)
			{
				T val = item as T;
				if (val != null)
				{
					dictionary[val] = group.Group;
				}
			}
		}
		return dictionary;
	}

	public static IEnumerable GetElligable<T>(IEnumerable<T> elements, Transform panel, int from) where T : class
	{
		Dictionary<T, int> groups = GetGrouped<T>(panel);
		foreach (T element in elements)
		{
			int orDefault = groups.GetOrDefault(element, -1);
			if (orDefault < 0 || orDefault == from)
			{
				yield return element;
			}
		}
	}

	public void Show(HardwareDesign d)
	{
		Design = d;
		Window.Show();
		for (int i = 0; i < GroupPanels.Length; i++)
		{
			ClearGroup(GroupPanels[i]);
		}
		LoadGroups(d.Objects, (HardwareDesign.MeshObject x) => x.GroupID, GroupType.MeshObject);
		LoadGroups(d.Attachments, (HardwareDesign.AttachmentPoint x) => x.GroupID, GroupType.AttachmentPoint);
		LoadGroups(d.Attachments.SelectMany((HardwareDesign.AttachmentPoint x) => x.Attachments), (HardwareDesign.Attachment x) => x.GroupID, GroupType.Attachment);
		LoadGroups(d.Objects.SelectMany((HardwareDesign.MeshObject x) => x.MorphTargets), (HardwareDesign.MorphInfo x) => x.GroupID, GroupType.Morph);
		foreach (HardwareDesignGroup group in GetGroups(GroupPanels[1]))
		{
			group.ControlOnlyEmpty = group.Content.OfType<HardwareDesign.AttachmentPoint>().Mode((HardwareDesign.AttachmentPoint x) => x.ControlOnlyEmpty, false);
		}
	}

	private HardwareDesignGroup CreateGroup(IEnumerable<object> content, GroupType type, Transform panel, int group)
	{
		HardwareDesignGroup hardwareDesignGroup = UnityEngine.Object.Instantiate(GroupPrefab);
		hardwareDesignGroup.Header.text = "Group " + group;
		hardwareDesignGroup.Group = group;
		hardwareDesignGroup.Content.AddRange(content);
		hardwareDesignGroup.UpdateList((object x) => GetLabel(x, Design, type));
		hardwareDesignGroup.transform.SetParent(panel, false);
		hardwareDesignGroup.transform.SetAsFirstSibling();
		hardwareDesignGroup.Type = type;
		hardwareDesignGroup.Parent = this;
		return hardwareDesignGroup;
	}

	private void LoadGroups<T>(IEnumerable<T> elements, Func<T, int> getGroup, GroupType type)
	{
		Dictionary<int, List<T>> dictionary = new Dictionary<int, List<T>>();
		foreach (T element in elements)
		{
			int num = getGroup(element);
			if (num > 0)
			{
				dictionary.Append(num, element);
			}
		}
		Transform panel = GroupPanels[(int)type];
		foreach (KeyValuePair<int, List<T>> item in dictionary)
		{
			CreateGroup(item.Value.Cast<object>(), type, panel, item.Key);
		}
	}

	private void ClearGroup(Transform p)
	{
		foreach (HardwareDesignGroup group in GetGroups(p))
		{
			UnityEngine.Object.Destroy(group.gameObject);
		}
	}
}
