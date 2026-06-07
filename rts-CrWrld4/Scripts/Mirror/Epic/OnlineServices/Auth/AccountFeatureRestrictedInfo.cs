namespace Epic.OnlineServices.Auth
{
	public class AccountFeatureRestrictedInfo : ISettable
	{
		public string VerificationURI { get; set; }

		internal void Set(AccountFeatureRestrictedInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
