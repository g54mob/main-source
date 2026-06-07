namespace Epic.OnlineServices.Lobby
{
	public class LobbyInviteAcceptedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public string InviteId { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public ProductUserId TargetUserId { get; private set; }

		public string LobbyId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(LobbyInviteAcceptedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
