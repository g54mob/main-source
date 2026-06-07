namespace Epic.OnlineServices.Ecom
{
	public class Entitlement : ISettable
	{
		public string EntitlementName { get; set; }

		public string EntitlementId { get; set; }

		public string CatalogItemId { get; set; }

		public int ServerIndex { get; set; }

		public bool Redeemed { get; set; }

		public long EndTimestamp { get; set; }

		internal void Set(EntitlementInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
