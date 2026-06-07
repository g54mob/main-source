using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UINotificationDropdownList : UINotificationDropdown, ICursorOverride
{
	public bool CloseOnAction;

	public DropPanelGraphics DropPanel;

	public int Offset;

	public int MaxItems = 10;

	public Scrollbar Scroll;

	[NonSerialized]
	private NotificationMessage _message;

	public string CursorOverrideName
	{
		get
		{
			return "Finger";
		}
	}

	public void DoAction(int idx)
	{
		int num = idx + Offset;
		if (num >= 0 && num < _message.GetCount())
		{
			UISoundFX.PlaySFX("ButtonClick");
			_message.Goto(num);
		}
		if (CloseOnAction)
		{
			Close();
		}
	}

	public void OnScroll(int delta)
	{
		Offset = Mathf.Clamp(Offset + delta, 0, Mathf.Max(0, _message.GetCount() - MaxItems));
		FillLabel();
	}

	public override void SetContent(NotificationMessage msg)
	{
		Offset = 0;
		_message = msg;
		FillLabel();
	}

	private void UpdateScroll()
	{
		if (Scroll.gameObject.activeSelf)
		{
			Scroll.size = (float)MaxItems / (float)_message.GetCount();
			Scroll.value = (float)Offset / (float)(_message.GetCount() - MaxItems);
		}
	}

	private void FillLabel()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = 0;
		foreach (object item in _message.GetItems())
		{
			UnityEngine.Object obj;
			if (item == null || ((object)(obj = item as UnityEngine.Object) != null && obj == null))
			{
				continue;
			}
			if (num >= Offset)
			{
				IFormatColorObject formatColorObject;
				stringBuilder.AppendLine(((formatColorObject = item as IFormatColorObject) != null) ? formatColorObject.GetActualString() : item.ToString());
				num2++;
				if (num2 > MaxItems)
				{
					break;
				}
			}
			num++;
		}
		Scroll.gameObject.SetActive(_message.GetCount() > MaxItems);
		DropPanel.Label.text = stringBuilder.ToString().TrimEnd();
		UpdateScroll();
	}

	public override float GetHeight()
	{
		return (float)Mathf.Min(MaxItems, _message.GetCount()) * DropPanel.LineHeight;
	}
}
