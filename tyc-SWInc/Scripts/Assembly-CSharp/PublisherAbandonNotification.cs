using System;

[Serializable]
public class PublisherAbandonNotification : NotificationMessage
{
	public SoftwareProduct Product;

	public SoftwareWorkItem Item;

	public PublisherAbandonNotification()
	{
	}

	public PublisherAbandonNotification(SoftwareProduct p, string publisher)
		: base("PublisherAbandon".Loc(publisher, p.Name), "Deal", NotificationManager.NotificationType.Issue)
	{
		Product = p;
	}

	public PublisherAbandonNotification(SoftwareWorkItem p, string publisher)
		: base("PublisherAbandon".Loc(publisher, p.SoftwareName), "Deal", NotificationManager.NotificationType.Issue)
	{
		Item = p;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool Refresh()
	{
		if (SDateTime.GetDays(Date, SDateTime.Now()) >= 1f)
		{
			return true;
		}
		if (Product != null)
		{
			if (Product.DevCompany.IsLocalPlayer)
			{
				return Product.Publishing != null;
			}
			return true;
		}
		if (Item != null)
		{
			if (!Item.Done)
			{
				return Item.Publishing != null;
			}
			return true;
		}
		return true;
	}

	public override bool IsDismissable()
	{
		return true;
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override int GetCount()
	{
		return 1;
	}

	public override void Goto(int idx = -1)
	{
		if (Product != null && Product.DevCompany.IsLocalPlayer && Product.Publishing == null)
		{
			float devtime = Product.Type.DevTime(Product.Features, Product.Category, Product.DevCompany, Product.TechLevels, Product.OSCount, Product.Framework, false, Product.SequelTo);
			float artRatio = SoftwareType.CodeArtRatio(Product.Features);
			HUD.Instance.docWindow.PubDealWindow.Show(Product.Category, devtime, artRatio, false, false, SDateTime.Now(), delegate(PublisherDeal x)
			{
				x.Affect(Product);
				x.SendNetwork();
			});
		}
		else if (Item != null && !Item.Done && Item.Publishing == null)
		{
			FeatureBase[] features = Item.GetFeatures();
			float devtime2 = Item.Type.DevTime(features, Item.SWCategory, Item.MyCompany, Item.TechLevels, Item.OSs, Item.Framework, false, Item.SequelTo);
			float artRatio2 = SoftwareType.CodeArtRatio(features);
			HUD.Instance.docWindow.PubDealWindow.Show(Item.SWCategory, devtime2, artRatio2, false, true, Item.DevStart, delegate(PublisherDeal x)
			{
				x.Affect(Item);
			});
		}
	}
}
