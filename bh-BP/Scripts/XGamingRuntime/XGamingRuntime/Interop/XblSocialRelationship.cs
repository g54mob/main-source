namespace XGamingRuntime.Interop
{
	public struct XblSocialRelationship
	{
		public ulong xboxUserId;

		public bool isFavorite;

		public bool isFollowingCaller;

		public unsafe sbyte** socialNetworks;

		public SizeT socialNetworksCount;
	}
}
