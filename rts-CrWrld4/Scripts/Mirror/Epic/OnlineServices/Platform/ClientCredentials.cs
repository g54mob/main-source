namespace Epic.OnlineServices.Platform
{
	public class ClientCredentials : ISettable
	{
		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		internal void Set(ClientCredentialsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
