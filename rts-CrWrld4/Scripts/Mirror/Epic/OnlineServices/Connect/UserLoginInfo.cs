namespace Epic.OnlineServices.Connect
{
	public class UserLoginInfo : ISettable
	{
		public string DisplayName { get; set; }

		internal void Set(UserLoginInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
