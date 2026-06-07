using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[Serializable]
public class NoStockNotification : NotificationWithList<IStockable>
{
	public Dictionary<IStockable, KeyValuePair<SDateTime, uint>> Products = new Dictionary<IStockable, KeyValuePair<SDateTime, uint>>();

	public NoStockNotification()
	{
	}

	public NoStockNotification(IStockable p)
		: base("LostSalesPopup".Loc(), "Box", SDateTime.Now(), NotificationManager.NotificationType.Issue, new IStockable[1] { p })
	{
		Products[p] = new KeyValuePair<SDateTime, uint>(SDateTime.Now(), p.PhysicalCopies);
	}

	public NoStockNotification(SoftwareProduct p, uint amount)
		: base("LostSalesPopup".Loc(), "Box", SDateTime.Now(), NotificationManager.NotificationType.Issue, new IStockable[1] { p })
	{
		Products[p] = new KeyValuePair<SDateTime, uint>(SDateTime.Now(), amount);
	}

	public override bool AddItem(object item)
	{
		IStockable stockable = (IStockable)item;
		foreach (AutoDevWorkItem item2 in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			if (item2.AutoDistribution)
			{
				if (item2.PreviousSoftware.Contains(stockable))
				{
					return false;
				}
				if (item2.PastReleases.Contains(stockable))
				{
					return false;
				}
			}
		}
		Products[stockable] = new KeyValuePair<SDateTime, uint>(SDateTime.Now(), stockable.PhysicalCopies);
		return base.AddItem(item);
	}

	public override bool IgnoreNotification()
	{
		HashSet<IStockable> hashSet = new HashSet<IStockable>();
		foreach (AutoDevWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			if (item.AutoDistribution)
			{
				hashSet.AddRange(item.PreviousSoftware);
				hashSet.AddRange(item.PastReleases);
			}
		}
		return Products.Keys.All(hashSet.Contains);
	}

	public override void Goto(int idx = -1)
	{
		IStockable at = Items.GetAt(idx);
		SoftwareProduct product;
		AddOnProduct product2;
		if ((product = at as SoftwareProduct) != null)
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(product);
		}
		else if ((product2 = at as AddOnProduct) != null)
		{
			HUD.Instance.GetProductWindow(null).ShowAddonDetails(product2);
		}
	}

	public override int GetTypeID()
	{
		return 4;
	}

	public override bool WriteDerivedData(Stream st)
	{
		KeyValuePair<IStockable, KeyValuePair<SDateTime, uint>> keyValuePair = Products.Last();
		st.WriteUInt(((SoftwareProduct)keyValuePair.Key).ID);
		st.WriteUInt(keyValuePair.Value.Value);
		return false;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool Refresh()
	{
		List<KeyValuePair<IStockable, KeyValuePair<SDateTime, uint>>> list = Products.ToList();
		SDateTime now = SDateTime.Now();
		for (int i = 0; i < list.Count; i++)
		{
			KeyValuePair<IStockable, KeyValuePair<SDateTime, uint>> keyValuePair = list[i];
			if (keyValuePair.Key.PhysicalCopies != keyValuePair.Value.Value || SDateTime.DayHasPassed(keyValuePair.Value.Key, now))
			{
				RemoveItem(keyValuePair.Key);
			}
		}
		return Items.Count == 0;
	}

	public override void RemoveItem(object item)
	{
		Products.Remove((IStockable)item);
		base.RemoveItem(item);
	}
}
