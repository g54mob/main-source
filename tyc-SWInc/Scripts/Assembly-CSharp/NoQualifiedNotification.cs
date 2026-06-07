using System;

[Serializable]
public class NoQualifiedNotification : NotificationMessage
{
	public readonly WorkItem Item;

	public bool Fixed;

	public NoQualifiedNotification()
	{
	}

	public NoQualifiedNotification(WorkItem item, FormatColorString feature, string spec)
		: base("NoCompetencyWork".LocColor(item, feature, spec), "MoreEmployees", NotificationManager.NotificationType.Issue)
	{
		Item = item;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool Refresh()
	{
		bool flag = Fixed || !GameSettings.Instance.MyCompany.WorkItems.Contains(Item);
		if (!flag)
		{
			WorkItem item = Item;
			if (item != null)
			{
				SoftwareWorkItem softwareWorkItem;
				if ((softwareWorkItem = item as SoftwareWorkItem) == null)
				{
					AccountingWork accountingWork;
					if ((accountingWork = item as AccountingWork) != null)
					{
						accountingWork.CheckCompetency();
					}
				}
				else
				{
					softwareWorkItem.CheckCompetency();
				}
			}
		}
		return Fixed || flag;
	}

	public override uint AggregateID()
	{
		return Item.ID;
	}

	public override void RemoveItem(object item)
	{
		Fixed = true;
	}

	public override int GetCount()
	{
		return 1;
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override void Goto(int idx = -1)
	{
		if (Item.guiItem != null)
		{
			Item.guiItem.Highlight();
		}
	}
}
