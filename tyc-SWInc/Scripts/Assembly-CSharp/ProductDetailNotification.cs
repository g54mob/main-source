using System;
using System.IO;

[Serializable]
public class ProductDetailNotification : NotificationMessage
{
	public SoftwareProduct Product;

	public ProductDetailNotification()
	{
	}

	public ProductDetailNotification(SoftwareProduct p, string msg, string icon, NotificationManager.NotificationType type, string hint = null)
		: base(msg, icon, type)
	{
		Product = p;
		Details = hint;
	}

	public ProductDetailNotification(SoftwareProduct p, string msg, string icon, SDateTime date, NotificationManager.NotificationType type, string hint = null)
		: base(msg, icon, date, type)
	{
		Product = p;
		Details = hint;
	}

	public override int GetCount()
	{
		return 1;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.GetProductWindow(null).ShowProductDetails(Product);
	}

	public override int GetTypeID()
	{
		return 5;
	}

	public override bool WriteDerivedData(Stream st)
	{
		st.WriteUInt(Product.ID);
		return true;
	}

	public override bool HasGoto()
	{
		return true;
	}
}
