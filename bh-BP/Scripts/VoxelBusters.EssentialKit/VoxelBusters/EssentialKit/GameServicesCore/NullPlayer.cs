namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal class NullPlayer : PlayerBase
	{
		public static void LoadPlayers(string[] playerIds, LoadPlayersInternalCallback callback)
		{
		}

		private static void LogNotSupported()
		{
		}

		protected override string GetIdentifierInternal()
		{
			return null;
		}

		protected override string GetDeveloperScopeIdentifierInternal()
		{
			return null;
		}

		protected override string GetLegacyIdentifierInternal()
		{
			return null;
		}

		protected override string GetAliasInternal()
		{
			return null;
		}

		protected override string GetDisplayNameInternal()
		{
			return null;
		}

		protected override void LoadImageInternal(LoadImageInternalCallback callback)
		{
		}
	}
}
