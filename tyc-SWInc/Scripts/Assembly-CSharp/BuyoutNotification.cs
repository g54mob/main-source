using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class BuyoutNotification : NotificationMessage
{
	public int Stocks;

	public int Patents;

	public SoftwareProduct[] Products;

	public SoftwareFramework[] Frameworks;

	public AddOnProduct[] Addons;

	public static string GetMessage(int stocks, int patents, List<SoftwareProduct> products, List<SoftwareFramework> frameworks, List<AddOnProduct> addons, Company c, bool bankrupt)
	{
		return (bankrupt ? "BankruptcyInfo" : "BoughtOutInfo").LocColor(Newspaper.MakeList(GetBuyoutItems(stocks, patents, products, frameworks, addons).Cast<string>().ToList()), c);
	}

	public BuyoutNotification()
	{
	}

	public BuyoutNotification(Company c, int stocks, int patents, List<SoftwareProduct> products, List<SoftwareFramework> frameworks, List<AddOnProduct> addons, bool bankrupt)
		: base(GetMessage(stocks, patents, products, frameworks, addons, c, bankrupt), "Skyskraper", NotificationManager.NotificationType.Neutral)
	{
		Stocks = stocks;
		Patents = patents;
		Products = products.ToArray();
		Frameworks = frameworks.ToArray();
		Addons = addons.ToArray();
	}

	public override bool ForceList()
	{
		return true;
	}

	public override int GetCount()
	{
		int num = ((Stocks > 0) ? 1 : 0);
		if (Patents > 0)
		{
			num++;
		}
		if (Products.Length != 0)
		{
			num++;
		}
		if (Frameworks.Length != 0)
		{
			num++;
		}
		if (Addons.Length != 0)
		{
			num++;
		}
		return num;
	}

	public override NotificationManager.DropType GetDropType()
	{
		return NotificationManager.DropType.List;
	}

	public static IEnumerable GetBuyoutItems(int Stocks, int Patents, IList<SoftwareProduct> Products, IList<SoftwareFramework> Frameworks, IList<AddOnProduct> addons)
	{
		if (Stocks > 0)
		{
			yield return "Stock".LocPlural(Stocks);
		}
		if (Patents > 0)
		{
			yield return "Patent".LocPlural(Patents);
		}
		if (Products.Count > 0)
		{
			yield return "Product".LocPlural(Products.Count);
		}
		if (Frameworks.Count > 0)
		{
			yield return "Framework".LocPlural(Frameworks.Count);
		}
		if (addons.Count > 0)
		{
			yield return "Addon".LocPlural(addons.Count);
		}
	}

	public override IEnumerable GetItems()
	{
		return GetBuyoutItems(Stocks, Patents, Products, Frameworks, Addons);
	}

	public override void Goto(int idx = -1)
	{
		int num = 0;
		if (Stocks > 0)
		{
			if (idx == num)
			{
				HUD.Instance.companyWindow.ShowCompanyDetails(GameSettings.Instance.MyCompany);
				return;
			}
			num++;
		}
		if (Patents > 0)
		{
			if (idx == num)
			{
				HUD.Instance.researchWindow.Window.Show();
				return;
			}
			num++;
		}
		if (Products.Length != 0)
		{
			if (idx == num)
			{
				HUD.Instance.ShowMyReleases();
				HUD.Instance.PlayerProductWindow.ModeToggles[0].isOn = true;
				HUD.Instance.PlayerProductWindow.InitMode(0);
				HUD.Instance.PlayerProductWindow.SetContent(Products);
				return;
			}
			num++;
		}
		if (Frameworks.Length != 0)
		{
			if (idx == num)
			{
				HUD.Instance.ShowMyReleases();
				HUD.Instance.PlayerProductWindow.ModeToggles[2].isOn = true;
				HUD.Instance.PlayerProductWindow.InitMode(2);
				HUD.Instance.PlayerProductWindow.ProductList.Items.Clear();
				HUD.Instance.PlayerProductWindow.ProductList.Items.AddRange(Frameworks.Cast<object>());
				return;
			}
			num++;
		}
		if (Addons.Length != 0 && idx == num)
		{
			HUD.Instance.ShowMyReleases();
			HUD.Instance.PlayerProductWindow.ModeToggles[1].isOn = true;
			HUD.Instance.PlayerProductWindow.InitMode(1);
			HUD.Instance.PlayerProductWindow.ProductList.Items.Clear();
			HUD.Instance.PlayerProductWindow.ProductList.Items.AddRange(Addons.Cast<object>());
		}
	}

	public override bool HasGoto()
	{
		return true;
	}
}
