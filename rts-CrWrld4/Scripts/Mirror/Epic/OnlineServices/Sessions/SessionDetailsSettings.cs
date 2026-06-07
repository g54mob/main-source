namespace Epic.OnlineServices.Sessions
{
	public class SessionDetailsSettings : ISettable
	{
		public string BucketId { get; set; }

		public uint NumPublicConnections { get; set; }

		public bool AllowJoinInProgress { get; set; }

		public OnlineSessionPermissionLevel PermissionLevel { get; set; }

		public bool InvitesAllowed { get; set; }

		internal void Set(SessionDetailsSettingsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
