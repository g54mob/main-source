namespace Jundroo.Services.Purchasing
{
	public class ProductMetadata
	{
		public string IsoCurrencyCode { get; private set; }

		public string LocalizedDescription { get; private set; }

		public decimal LocalizedPrice { get; private set; }

		public string LocalizedPriceString { get; private set; }

		public string LocalizedTitle { get; private set; }

		public ProductMetadata(string priceString, string title, string description, string currencyCode, decimal localizedPrice)
		{
			LocalizedPriceString = priceString;
			LocalizedTitle = title;
			LocalizedDescription = description;
			IsoCurrencyCode = currencyCode;
			LocalizedPrice = localizedPrice;
		}

		public ProductMetadata(ProductMetadata productMetadata)
		{
			LocalizedPriceString = productMetadata.LocalizedPriceString;
			LocalizedTitle = productMetadata.LocalizedTitle;
			LocalizedDescription = productMetadata.LocalizedDescription;
			IsoCurrencyCode = productMetadata.IsoCurrencyCode;
			LocalizedPrice = productMetadata.LocalizedPrice;
		}
	}
}
