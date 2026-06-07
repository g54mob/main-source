using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IPlayer
	{
		[Obsolete("Use Identifier if you are using this value for the first time. If you used it earlier in V2 and still want to use the same identifier as in v2 you need to use LegacyIdentifier instead.", true)]
		string Id { get; }

		[Obsolete("Use DeveloperScopeIdentifier instead.")]
		string DeveloperScopeId { get; }

		[Obsolete("Use LegacyIdentifier instead.")]
		string LegacyId { get; }

		string Identifier { get; }

		string DeveloperScopeIdentifier { get; }

		string LegacyIdentifier { get; }

		string Alias { get; }

		string DisplayName { get; }

		void LoadImage(EventCallback<TextureData> callback);
	}
}
