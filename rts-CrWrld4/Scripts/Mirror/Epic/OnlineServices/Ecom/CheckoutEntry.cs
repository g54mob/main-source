namespace Epic.OnlineServices.Ecom
{
	public class CheckoutEntry : ISettable
	{
		public string OfferId { get; set; }

		internal void Set(CheckoutEntryInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
