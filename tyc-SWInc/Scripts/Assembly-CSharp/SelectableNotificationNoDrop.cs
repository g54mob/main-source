using System;

[Serializable]
public abstract class SelectableNotificationNoDrop<T> : NotificationWithIDList<T> where T : Selectable
{
	public int SelectOffset;

	public SelectableNotificationNoDrop()
	{
	}

	public SelectableNotificationNoDrop(string msg, string icon, SDateTime date, NotificationManager.NotificationType type, params T[] items)
		: base(msg, icon, date, type, items)
	{
	}

	public override uint GetID(T item)
	{
		return item.DID;
	}

	public virtual bool MoveIfInactive()
	{
		return false;
	}

	public override NotificationManager.DropType GetDropType()
	{
		if (Details == null)
		{
			return NotificationManager.DropType.None;
		}
		return NotificationManager.DropType.Simple;
	}

	public override void Goto(int idx = -1)
	{
		if (!BuildController.Instance.CanChangeFloor() || base.Items.Count == 0)
		{
			return;
		}
		bool flag = MoveIfInactive();
		T val = null;
		int num = 0;
		SelectOffset %= base.Items.Count;
		int num2 = 0;
		bool flag2 = false;
		foreach (T item in base.Items)
		{
			if (item != null && (flag || item.isActiveAndEnabled))
			{
				if (num2 >= SelectOffset)
				{
					CameraScript.Instance.MoveTo(item.GetFlatPos(), item.GetFloor());
					SelectOffset = num2 + 1;
					flag2 = true;
					break;
				}
				if (val == null)
				{
					val = item;
					num = num2;
				}
			}
			num2++;
		}
		if (!flag2 && val != null)
		{
			CameraScript.Instance.MoveTo(val.GetFlatPos(), val.GetFloor());
			SelectOffset = num + 1;
		}
		SelectorController.Instance.SetSelection(base.Items);
	}
}
