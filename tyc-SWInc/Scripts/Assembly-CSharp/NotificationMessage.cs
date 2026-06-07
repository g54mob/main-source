using System;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;

[Serializable]
public class NotificationMessage : IByteData
{
	public string Message;

	public string Details;

	public string Icon;

	[NonSerialized]
	public float Created = -1f;

	[NonSerialized]
	public float LastBlip = -1f;

	public bool Collapsed;

	public SDateTime Date;

	public NotificationManager.NotificationType Type;

	[NonSerialized]
	public UINotification UIItem;

	public NotificationMessage()
	{
	}

	public NotificationMessage(string msg, string icon, NotificationManager.NotificationType type)
		: this(msg, icon, SDateTime.Now(), type)
	{
	}

	public NotificationMessage(string msg, string icon, SDateTime date, NotificationManager.NotificationType type)
	{
		Message = msg;
		Icon = icon;
		Type = type;
		Date = date;
		LastBlip = (Created = ((Thread.CurrentThread != ModController.MainThread) ? 0f : Time.realtimeSinceStartup));
	}

	public NotificationMessage(string msg, string details, string icon, SDateTime date, NotificationManager.NotificationType type)
	{
		Message = msg;
		Details = details;
		Icon = icon;
		Type = type;
		Date = date;
		LastBlip = (Created = ((Thread.CurrentThread != ModController.MainThread) ? 0f : Time.realtimeSinceStartup));
	}

	public virtual NotificationManager.DropType GetDropType()
	{
		if (Details == null)
		{
			return NotificationManager.DropType.None;
		}
		return NotificationManager.DropType.Simple;
	}

	public virtual bool HasGoto()
	{
		return false;
	}

	public virtual bool ForceList()
	{
		return false;
	}

	public virtual bool IsDismissable()
	{
		return Type != NotificationManager.NotificationType.Issue;
	}

	public virtual void Goto(int idx = -1)
	{
	}

	public virtual IEnumerable GetItems()
	{
		yield break;
	}

	public virtual bool HasRefresh()
	{
		return false;
	}

	public virtual bool Refresh()
	{
		return false;
	}

	public virtual bool IsAggregate()
	{
		return false;
	}

	public virtual uint AggregateID()
	{
		return 0u;
	}

	public virtual int GetCount()
	{
		return 0;
	}

	public virtual bool AddItem(object item)
	{
		return false;
	}

	public virtual bool IgnoreNotification()
	{
		return false;
	}

	public virtual void RemoveItem(object item)
	{
	}

	public virtual void OnDismissed()
	{
	}

	public void WriteData(Stream st)
	{
		int typeID = GetTypeID();
		st.WriteInt(typeID);
		if (typeID == 0)
		{
			Debug.Log("Tried to send non supported notification: " + GetType().Name);
		}
		else if (WriteDerivedData(st))
		{
			st.WriteStringUTF8(Message);
			st.WriteStringUTF8(Details);
			st.WriteStringUTF8(Icon);
			st.WriteByte((byte)Type);
			Date.WriteData(st);
		}
	}

	public virtual bool WriteDerivedData(Stream st)
	{
		return true;
	}

	public virtual int GetTypeID()
	{
		return 0;
	}

	public static void ReadDefault(Stream st, out string msg, out string details, out string icon, out NotificationManager.NotificationType type, out SDateTime date)
	{
		msg = st.ReadStringUTF8();
		details = st.ReadStringUTF8();
		icon = st.ReadStringUTF8();
		type = (NotificationManager.NotificationType)st.ReadByte();
		date = SDateTime.ReadData(st);
	}

	public static NotificationMessage ReadData(Stream st)
	{
		int num = st.ReadInt();
		if (num < 0)
		{
			return null;
		}
		switch (num)
		{
		case 1:
			return new SubsidaryLeadNotification(MarketSimulation.Active.GetCompany(st.ReadUInt()) as SimulatedCompany);
		case 2:
			return new SoftwareSupportWane(MarketSimulation.Active.GetSoftwareType(st.ReadUInt()).GetCategory(st.ReadUInt()));
		case 3:
			return new IncreaseShareNotification(MarketSimulation.Active.GetCompany(st.ReadUInt()));
		case 4:
		{
			SoftwareProduct product2 = MarketSimulation.Active.GetProduct(st.ReadUInt(), false);
			uint amount = st.ReadUInt();
			if (product2.StockNotifications)
			{
				return new NoStockNotification(product2, amount);
			}
			return null;
		}
		case 5:
		{
			SoftwareProduct product = MarketSimulation.Active.GetProduct(st.ReadUInt(), false);
			string msg2;
			string details2;
			string icon2;
			NotificationManager.NotificationType type2;
			SDateTime date2;
			ReadDefault(st, out msg2, out details2, out icon2, out type2, out date2);
			return new ProductDetailNotification(product, msg2, icon2, type2, details2);
		}
		case 6:
			return new ProductListNotification.MultiplayerStockNotification(MarketSimulation.Active.GetCompany(st.ReadUInt()), st.ReadUInt(), st.ReadFloat());
		default:
		{
			string msg;
			string details;
			string icon;
			NotificationManager.NotificationType type;
			SDateTime date;
			ReadDefault(st, out msg, out details, out icon, out type, out date);
			return new NotificationMessage(msg, details, icon, date, type);
		}
		}
	}

	public virtual object AggregateObject()
	{
		return null;
	}

	public void CheckAddAggregate()
	{
		if (!IsAggregate() || !NotificationManager.CheckAggregate(GetType(), AggregateObject(), AggregateID()))
		{
			NotificationManager.AddNotification(this);
		}
	}
}
