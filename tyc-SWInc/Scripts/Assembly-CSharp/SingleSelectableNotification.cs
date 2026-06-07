using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public abstract class SingleSelectableNotification<T> : NotificationMessage where T : Selectable
{
	[NonSerialized]
	private T _select;

	public uint SelectID;

	public T Select
	{
		get
		{
			if (_select == null && SelectID != 0)
			{
				_select = GetSelectables().FirstOrDefault((T x) => x.DID == SelectID);
				if (_select == null)
				{
					SelectID = 0u;
				}
			}
			return _select;
		}
	}

	public SingleSelectableNotification()
	{
	}

	public SingleSelectableNotification(T room, string msg, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(msg, icon, date, type)
	{
		_select = room;
		SelectID = room.DID;
	}

	public SingleSelectableNotification(T room, string msg, string details, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(msg, details, icon, date, type)
	{
		_select = room;
		SelectID = room.DID;
	}

	public override int GetCount()
	{
		return 1;
	}

	public abstract IEnumerable<T> GetSelectables();

	public override bool HasGoto()
	{
		return true;
	}

	public override void Goto(int idx = -1)
	{
		T val = Select;
		if (val != null && val.isActiveAndEnabled)
		{
			CameraScript.Instance.MoveTo(val.GetFlatPos(), val.GetFloor());
			SelectorController.Instance.SetSelection(val);
		}
	}
}
