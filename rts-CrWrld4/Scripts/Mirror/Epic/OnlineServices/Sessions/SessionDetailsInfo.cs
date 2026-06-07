namespace Epic.OnlineServices.Sessions
{
	public class SessionDetailsInfo : ISettable
	{
		public string SessionId { get; set; }

		public string HostAddress { get; set; }

		public uint NumOpenPublicConnections { get; set; }

		public SessionDetailsSettings Settings { get; set; }

		internal void Set(SessionDetailsInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
