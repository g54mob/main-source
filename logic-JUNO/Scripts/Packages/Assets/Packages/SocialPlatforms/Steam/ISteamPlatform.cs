using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assets.Packages.SocialPlatforms.Steam.Events;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms.Steam
{
	public interface ISteamPlatform : ISocialPlatformExt, ISocialPlatform
	{
		ISteamManager SteamManager { get; }

		ReadOnlyCollection<WorkshopItemInfo> UserPublishedWorkshopItems { get; }

		event EventHandler<GameWebCallbackEventArgs> GameWebCallback;

		event EventHandler<NewLaunchParametersEventArgs> NewLaunchParameters;

		void ActivateGameOverlayToWebPage(string url);

		string GetCurrentBetaName();

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
