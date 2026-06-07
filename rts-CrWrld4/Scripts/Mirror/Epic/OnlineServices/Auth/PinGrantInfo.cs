namespace Epic.OnlineServices.Auth
{
	public class PinGrantInfo : ISettable
	{
		public string UserCode { get; set; }

		public string VerificationURI { get; set; }

		public int ExpiresIn { get; set; }

		public string VerificationURIComplete { get; set; }

		internal void Set(PinGrantInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
