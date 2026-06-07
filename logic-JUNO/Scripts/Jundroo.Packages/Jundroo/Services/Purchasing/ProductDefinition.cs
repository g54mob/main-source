namespace Jundroo.Services.Purchasing
{
	public class ProductDefinition
	{
		public bool Enabled { get; private set; }

		public string Id { get; private set; }

		public string StoreSpecificId { get; private set; }

		public ProductType Type { get; private set; }

		public ProductDefinition(string id, string storeSpecificId, ProductType type)
			: this(id, storeSpecificId, type, enabled: true)
		{
		}

		public ProductDefinition(string id, string storeSpecificId, ProductType type, bool enabled)
		{
			Id = id;
			StoreSpecificId = storeSpecificId;
			Type = type;
			Enabled = enabled;
		}

		public ProductDefinition(string id, ProductType type)
			: this(id, id, type)
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is ProductDefinition productDefinition))
			{
				return false;
			}
			return Id == productDefinition.Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
