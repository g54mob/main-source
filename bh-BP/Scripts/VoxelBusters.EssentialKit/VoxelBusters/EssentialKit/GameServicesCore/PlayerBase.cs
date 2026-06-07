using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	public abstract class PlayerBase : NativeObjectBase, IPlayer
	{
		public string Identifier => null;

		public string Alias => null;

		public string DisplayName => null;

		public string DeveloperScopeIdentifier => null;

		public string LegacyIdentifier => null;

		public string Id => null;

		public string DeveloperScopeId => null;

		public string LegacyId => null;

		protected abstract string GetIdentifierInternal();

		protected abstract string GetDeveloperScopeIdentifierInternal();

		protected abstract string GetLegacyIdentifierInternal();

		protected abstract string GetAliasInternal();

		protected abstract string GetDisplayNameInternal();

		protected abstract void LoadImageInternal(LoadImageInternalCallback callback);

		public override string ToString()
		{
			return null;
		}

		public void LoadImage(EventCallback<TextureData> callback)
		{
		}

		protected static void SendLoadPlayerFriendsResult(EventCallback<GameServicesLoadPlayerFriendsResult> callback, IPlayer[] players, Error error)
		{
		}

		protected static void SendViewClosedResult(EventCallback<bool> callback, Error error)
		{
		}
	}
}
