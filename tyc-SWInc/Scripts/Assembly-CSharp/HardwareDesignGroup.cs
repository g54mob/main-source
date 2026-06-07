using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HardwareDesignGroup : MonoBehaviour
{
	public Text Header;

	public Text List;

	[NonSerialized]
	public HashSet<object> Content = new HashSet<object>();

	[NonSerialized]
	public int Group;

	public bool ControlOnlyEmpty;

	public HardwareGroupWindow.GroupType Type;

	public HardwareGroupWindow Parent;

	public void UpdateList(Func<object, string> label)
	{
		List.text = string.Join("\n", Content.Select(label));
	}

	public void Edit()
	{
		Transform parent = base.transform.parent;
		IEnumerable elligable;
		switch (Type)
		{
		default:
			return;
		case HardwareGroupWindow.GroupType.MeshObject:
			elligable = HardwareGroupWindow.GetElligable(Parent.Design.Objects, parent, Group);
			break;
		case HardwareGroupWindow.GroupType.AttachmentPoint:
			elligable = HardwareGroupWindow.GetElligable(Parent.Design.Attachments, parent, Group);
			break;
		case HardwareGroupWindow.GroupType.Attachment:
			elligable = HardwareGroupWindow.GetElligable(Parent.Design.Attachments.SelectMany((HardwareDesign.AttachmentPoint x) => x.Attachments), parent, Group);
			break;
		case HardwareGroupWindow.GroupType.Morph:
			elligable = HardwareGroupWindow.GetElligable(Parent.Design.Objects.SelectMany((HardwareDesign.MeshObject x) => x.MorphTargets), parent, Group);
			break;
		}
		List<object> objects = new List<object>();
		List<string> list = new List<string>();
		List<bool> list2 = new List<bool>();
		if (Type == HardwareGroupWindow.GroupType.AttachmentPoint)
		{
			objects.Add(null);
			list.Add("Control only whether empty");
			list2.Add(ControlOnlyEmpty);
		}
		foreach (object item in elligable)
		{
			objects.Add(item);
			list.Add(HardwareGroupWindow.GetLabel(item, Parent.Design, Type));
			list2.Add(Content.Contains(item));
		}
		WindowManager.Instance.MultiWindow.ShowMulti("Pick", list, list2.ToArray(), delegate(int[] x)
		{
			int num = ((Type == HardwareGroupWindow.GroupType.AttachmentPoint && x.Length != 0 && x[0] == 0) ? 1 : 0);
			int num2 = ((Type != HardwareGroupWindow.GroupType.Morph) ? 1 : 0);
			if (x.Length > num + num2)
			{
				Content.Clear();
				Content.AddRange(from z in x.Skip(num)
					select objects[z]);
				UpdateList((object z) => HardwareGroupWindow.GetLabel(z, Parent.Design, Type));
				if (Type == HardwareGroupWindow.GroupType.AttachmentPoint)
				{
					ControlOnlyEmpty = x[0] == 0;
				}
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		});
	}
}
