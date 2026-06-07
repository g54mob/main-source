namespace Epic.OnlineServices.UserInfo
{
	public class UserInfoData : ISettable
	{
		public EpicAccountId UserId { get; set; }

		public string Country { get; set; }

		public string DisplayName { get; set; }

		public string PreferredLanguage { get; set; }

		public string Nickname { get; set; }

		internal void Set(UserInfoDataInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
