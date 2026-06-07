namespace XGamingRuntime.Interop
{
	public struct XblSocialRelationshipChangeEventArgs
	{
		public ulong callerXboxUserId;

		public XblSocialNotificationType socialNotification;

		public unsafe ulong* xboxUserIds;

		public SizeT xboxUserIdsCount;
	}
}
