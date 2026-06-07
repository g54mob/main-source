using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Jundroo.SocialPlatforms.Steam.Events;
using Jundroo.SocialPlatforms.Steam.Multiplayer;
using UnityEngine;

namespace Jundroo.SocialPlatforms.Steam
{
	public interface ISteamPlatform : ISocialPlatformExt, ISocialPlatform
	{
		string LocalUserDisplayName { get; }

		ulong LocalUserId { get; }

		ISteamPlatformMultiplayer Multiplayer { get; }

		ReadOnlyCollection<WorkshopItemInfo> UserPublishedWorkshopItems { get; }

		event EventHandler<GameWebCallbackEventArgs> GameWebCallback;

		event EventHandler<NewLaunchParametersEventArgs> NewLaunchParameters;

		event EventHandler<RemoteStorageLocalFileChangeEventArgs> RemoteStorageLocalFileChange;

		void ActivateGameOverlayToWebPage(string url);

		bool BeginFileWriteBatch();

		bool EndFileWriteBatch();

		string GetLaunchQueryParam(string paramName);

		List<SubscribedWorkshopItemInfo> GetSubscribedWorkshopItems();

		bool IsOverlayEnabled();

		bool IsRunningInBigPicture();

		bool IsRunningOnSteamDeck();

		IPublishWorkshopItemOperation PublishWorkshopItem(string modName, string folderPath, string previewImagePath, string title, SteamVisibility visibility, string language, IList<string> tags, string description);

		void QueryUserPublishedWorkshopItems();

		bool ShowFloatingGamepadTextInput(FloatingGamepadTextInputMode mode, Rect inputFieldPosition);
	}
}
