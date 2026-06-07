namespace Epic.OnlineServices.Friends
{
	public class OnFriendsUpdateInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public EpicAccountId TargetUserId { get; private set; }

		public FriendsStatus PreviousStatus { get; private set; }

		public FriendsStatus CurrentStatus { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnFriendsUpdateInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
