using System;

[Serializable]
public abstract class SelectableNotification<T> : NotificationWithIDList<T> where T : Selectable
{
	public SelectableNotification()
	{
	}

	public SelectableNotification(string msg, string icon, SDateTime date, NotificationManager.NotificationType type, params T[] items)
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

	public override void Goto(int idx = -1)
	{
		if (BuildController.Instance.CanChangeFloor())
		{
			bool flag = MoveIfInactive();
			T at = base.Items.GetAt(idx);
			if (at != null && (flag || at.isActiveAndEnabled))
			{
				CameraScript.Instance.MoveTo(at.GetFlatPos(), at.GetFloor());
			}
			SelectorController.Instance.SetSelection(base.Items);
		}
	}
}
