using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HardwareAttachmentPoint : MonoBehaviour
{
	public HardwareAttachment ChildPrefab;

	public HardwareDesignEditor Editor;

	public List<HardwareAttachment> Children = new List<HardwareAttachment>();

	public HardwareDesign.AttachmentPoint AttachmentPoint;

	public InputField MainLabel;

	public Toggle CanBeEmpty;

	public Toggle CanRemove;

	public void Move()
	{
		Editor.EditAttachment(AttachmentPoint);
	}

	public void MoveOffset()
	{
		Editor.BeginMoveOffset(AttachmentPoint);
	}

	public void Delete()
	{
		Editor.ActiveDesign.Attachments.Remove(AttachmentPoint);
		Object.Destroy(base.gameObject);
	}

	public void NameChange()
	{
		if (MainLabel.text.Length > 0)
		{
			if (!AttachmentPoint.Name.Equals(MainLabel.text))
			{
				HardwareDesignEditor.Instance.MarkAsChanged();
			}
			AttachmentPoint.Name = MainLabel.text;
		}
	}

	public void EmptyChange(bool value)
	{
		if (AttachmentPoint.CanBeEmpty != value)
		{
			HardwareDesignEditor.Instance.MarkAsChanged();
		}
		AttachmentPoint.CanBeEmpty = value;
	}

	public void RemoveChange(bool value)
	{
		if (AttachmentPoint.CanRemove != value)
		{
			HardwareDesignEditor.Instance.MarkAsChanged();
		}
		AttachmentPoint.CanRemove = value;
	}

	public void Add()
	{
		HashSet<string> existing = AttachmentPoint.Attachments.Select((HardwareDesign.Attachment x) => x.Object).ToHashSet();
		string[] elligible = (from x in Editor.ActiveDesign.Objects
			where !object.Equals(x.ID, Editor.ActiveDesign.BaseMesh) && !existing.Contains(x.ID)
			select x.ID).ToArray();
		if (elligible.Length != 0)
		{
			WindowManager.Instance.MultiWindow.Show("Part", elligible, delegate(int x)
			{
				HardwareDesign.Attachment attachment = new HardwareDesign.Attachment(elligible[x]);
				AttachmentPoint.Attachments.Add(attachment);
				HardwareAttachment hardwareAttachment = Object.Instantiate(ChildPrefab);
				hardwareAttachment.Init(Editor, this, attachment);
				hardwareAttachment.transform.SetParent(base.transform);
				hardwareAttachment.transform.SetSiblingIndex(Children.Count + 3);
				Children.Add(hardwareAttachment);
				Editor.BeginMove(AttachmentPoint, attachment);
				LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform.parent.GetComponent<RectTransform>());
				HardwareDesignEditor.Instance.MarkAsChanged();
			}, false);
		}
	}

	public void ChildCopyPrevious(HardwareAttachment child)
	{
		int num = Children.IndexOf(child);
		if (num > 0)
		{
			HardwareAttachment hardwareAttachment = Children[num - 1];
			child.Attachment.Offset = hardwareAttachment.Attachment.Offset;
			child.Attachment.Rotation = hardwareAttachment.Attachment.Rotation;
			HardwareDesignEditor.Instance.MarkAsChanged();
			Editor.BeginMove(AttachmentPoint, child.Attachment);
		}
	}

	public void Init(HardwareDesignEditor editor, HardwareDesign.AttachmentPoint ap)
	{
		AttachmentPoint = ap;
		Editor = editor;
		MainLabel.text = ap.Name;
		CanBeEmpty.isOn = ap.CanBeEmpty;
		CanRemove.isOn = ap.CanRemove;
		foreach (HardwareDesign.Attachment attachment in ap.Attachments)
		{
			HardwareAttachment hardwareAttachment = Object.Instantiate(ChildPrefab);
			hardwareAttachment.Init(Editor, this, attachment);
			hardwareAttachment.transform.SetParent(base.transform);
			hardwareAttachment.transform.SetSiblingIndex(Children.Count + 3);
			Children.Add(hardwareAttachment);
		}
	}
}
