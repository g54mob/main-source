namespace Epic.OnlineServices.Ecom
{
	public class ItemOwnership : ISettable
	{
		public string Id { get; set; }

		public OwnershipStatus OwnershipStatus { get; set; }

		internal void Set(ItemOwnershipInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
