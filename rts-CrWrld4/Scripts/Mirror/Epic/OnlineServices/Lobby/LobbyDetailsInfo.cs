namespace Epic.OnlineServices.Lobby
{
	public class LobbyDetailsInfo : ISettable
	{
		public string LobbyId { get; set; }

		public ProductUserId LobbyOwnerUserId { get; set; }

		public LobbyPermissionLevel PermissionLevel { get; set; }

		public uint AvailableSlots { get; set; }

		public uint MaxMembers { get; set; }

		public bool AllowInvites { get; set; }

		public string BucketId { get; set; }

		internal void Set(LobbyDetailsInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
