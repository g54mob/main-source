namespace Epic.OnlineServices.Lobby
{
	public class LobbySearchFindCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(LobbySearchFindCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
