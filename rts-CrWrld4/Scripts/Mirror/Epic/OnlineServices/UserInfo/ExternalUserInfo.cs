namespace Epic.OnlineServices.UserInfo
{
	public class ExternalUserInfo : ISettable
	{
		public ExternalAccountType AccountType { get; set; }

		public string AccountId { get; set; }

		public string DisplayName { get; set; }

		internal void Set(ExternalUserInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
