using System.Xml.Serialization;

namespace Origin.Data
{
	public class OfferT
	{
		[XmlAttribute]
		public string Type;

		[XmlAttribute]
		public string OfferId;

		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public string Description;

		[XmlAttribute]
		public string ImageId;

		[XmlAttribute]
		public bool bIsOwned;

		[XmlAttribute]
		public bool bHidden;

		[XmlAttribute]
		public bool bCanPurchase;

		[XmlAttribute]
		public string PurchaseDate;

		[XmlAttribute]
		public string DownloadDate;

		[XmlAttribute]
		public string PlayableDate;

		[XmlAttribute]
		public ulong DownloadSize;

		[XmlAttribute]
		public string Currency;

		[XmlAttribute]
		public bool bIsDiscounted;

		[XmlAttribute]
		public double Price;

		[XmlAttribute]
		public string LocalizedPrice;

		[XmlAttribute]
		public double OriginalPrice;

		[XmlAttribute]
		public string LocalizedOriginalPrice;

		[XmlAttribute]
		public int InventoryCap;

		[XmlAttribute]
		public int InventorySold;

		[XmlAttribute]
		public int InventoryAvailable;
	}
}
