namespace Epic.OnlineServices.Lobby
{
	public class PromoteMemberCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public string LobbyId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(PromoteMemberCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
