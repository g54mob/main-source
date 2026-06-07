namespace Epic.OnlineServices.Sessions
{
	public class ActiveSessionInfo : ISettable
	{
		public string SessionName { get; set; }

		public ProductUserId LocalUserId { get; set; }

		public OnlineSessionState State { get; set; }

		public SessionDetailsInfo SessionDetails { get; set; }

		internal void Set(ActiveSessionInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
