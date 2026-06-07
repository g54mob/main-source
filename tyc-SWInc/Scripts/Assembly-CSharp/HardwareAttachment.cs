using UnityEngine;
using UnityEngine.UI;

public class HardwareAttachment : MonoBehaviour
{
	public HardwareDesignEditor Editor;

	public HardwareAttachmentPoint Parent;

	public HardwareDesign.Attachment Attachment;

	public Text MainLabel;

	public Toggle UseToggle;

	public Toggle RollToggle;

	public void CopyPrevious()
	{
		Parent.ChildCopyPrevious(this);
	}

	public void Delete()
	{
		Parent.AttachmentPoint.Attachments.Remove(Attachment);
		Parent.Children.Remove(this);
		HardwareDesignEditor.Instance.MarkAsChanged();
		Object.Destroy(base.gameObject);
	}

	public void Move()
	{
		Editor.BeginMove(Parent.AttachmentPoint, Attachment);
	}

	public void ChangeUse(bool en)
	{
		if (Attachment.UseForGeneration != en)
		{
			HardwareDesignEditor.Instance.MarkAsChanged();
		}
		Attachment.UseForGeneration = en;
	}

	public void ChangeRoll(bool en)
	{
		if (Attachment.Roll != en)
		{
			HardwareDesignEditor.Instance.MarkAsChanged();
		}
		Attachment.Roll = en;
	}

	public void Init(HardwareDesignEditor editor, HardwareAttachmentPoint parent, HardwareDesign.Attachment at)
	{
		Editor = editor;
		Parent = parent;
		Attachment = at;
		MainLabel.text = at.Object;
		UseToggle.isOn = at.UseForGeneration;
		RollToggle.isOn = at.Roll;
	}
}
