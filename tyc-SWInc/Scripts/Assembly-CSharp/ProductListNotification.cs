using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class ProductListNotification : NotificationWithList<SoftwareProduct>
{
	[Serializable]
	public class MultiplayerStockNotification : NotificationMessage
	{
		public Company Company;

		public uint Shares;

		public float Owns;

		public MultiplayerStockNotification()
		{
		}

		public MultiplayerStockNotification(Company company, uint shares, float owns)
			: base("StockMultiplayerChange".Loc(company.Name, shares, owns.ToPercent()), "Money", NotificationManager.NotificationType.Neutral)
		{
			Company = company;
			Shares = shares;
			Owns = owns;
		}

		public override bool WriteDerivedData(Stream st)
		{
			st.WriteUInt(Company.ID);
			st.WriteUInt(Shares);
			st.WriteFloat(Owns);
			return false;
		}

		public override bool HasGoto()
		{
			return true;
		}

		public override void Goto(int idx = -1)
		{
			HUD.Instance.companyWindow.ShowCompanyDetails(GameSettings.Instance.MyCompany);
		}

		public override int GetCount()
		{
			return 1;
		}

		public override int GetTypeID()
		{
			return 6;
		}
	}

	public List<SoftwareProduct> Products = new List<SoftwareProduct>();

	public ProductListNotification()
	{
	}

	public ProductListNotification(string msg, string icon, NotificationManager.NotificationType type, params SoftwareProduct[] ps)
		: base(msg, icon, SDateTime.Now(), type, ps)
	{
	}

	public override void Goto(int idx = -1)
	{
		SoftwareProduct at = Items.GetAt(idx);
		if (at != null)
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(at);
		}
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}
}
