namespace Jundroo.Services.Purchasing
{
	public class Product
	{
		public string AppleOriginalTransactionID { get; private set; }

		public bool AppleProductIsRestored { get; private set; }

		public bool AvailableToPurchase { get; private set; }

		public ProductDefinition Definition { get; private set; }

		public bool HasReceipt => !string.IsNullOrEmpty(Receipt);

		public ProductMetadata Metadata { get; private set; }

		public string Receipt { get; private set; }

		public string TransactionID { get; private set; }

		internal Product(ProductDefinition definition, ProductMetadata metadata, string receipt)
		{
			Definition = definition;
			Metadata = metadata;
			Receipt = receipt;
		}

		internal Product(ProductDefinition definition, ProductMetadata metadata)
			: this(definition, metadata, null)
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is Product product))
			{
				return false;
			}
			return Definition.Equals(product.Definition);
		}

		public override int GetHashCode()
		{
			return Definition.GetHashCode();
		}
	}
}
