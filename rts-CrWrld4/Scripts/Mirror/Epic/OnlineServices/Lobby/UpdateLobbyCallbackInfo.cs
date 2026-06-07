namespace Epic.OnlineServices.Lobby
{
	public class UpdateLobbyCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public string LobbyId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(UpdateLobbyCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
