using System;
using System.Collections.Generic;
using ModIO.Implementation.API.Objects;
using UnityEngine;

namespace ModIO
{
	public static class ModIOUnity
	{
		public static bool IsInitialized()
		{
			return false;
		}

		public static void SetLoggingDelegate(LogMessageDelegate loggingDelegate)
		{
		}

		public static Result InitializeForUser(string userProfileIdentifier, ServerSettings serverSettings, BuildSettings buildSettings)
		{
			return default(Result);
		}

		public static Result InitializeForUser(string userProfileIdentifier)
		{
			return default(Result);
		}

		public static void Shutdown(Action shutdownComplete)
		{
		}

		public static void RequestExternalAuthentication(Action<ResultAnd<ExternalAuthenticationToken>> callback)
		{
		}

		public static void RequestAuthenticationEmail(string emailaddress, Action<Result> callback)
		{
		}

		public static void SubmitEmailSecurityCode(string securityCode, Action<Result> callback)
		{
		}

		public static void GetTermsOfUse(Action<ResultAnd<TermsOfUse>> callback)
		{
		}

		public static void AuthenticateUserViaSteam(string steamToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaEpic(string epicToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaGOG(string gogToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaPlayStation(string authCode, string emailAddress, TermsHash? hash, PlayStationEnvironment environment, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaItch(string itchioToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaXbox(string xboxToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaSwitch(string SwitchNsaId, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaDiscord(string discordToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaGoogle(string googleToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void AuthenticateUserViaOculus(OculusDevice oculusDevice, string nonce, long userId, string oculusToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
		}

		public static void IsAuthenticated(Action<Result> callback)
		{
		}

		public static Result LogOutCurrentUser()
		{
			return default(Result);
		}

		public static void GetTagCategories(Action<ResultAnd<TagCategory[]>> callback)
		{
		}

		public static void GetMods(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
		}

		public static void GetMod(ModId modId, Action<ResultAnd<ModProfile>> callback)
		{
		}

		public static void GetModComments(ModId modId, SearchFilter filter, Action<ResultAnd<CommentPage>> callback)
		{
		}

		public static void GetModDependencies(ModId modId, Action<ResultAnd<ModDependencies[]>> callback)
		{
		}

		public static void GetCurrentUserRatings(Action<ResultAnd<Rating[]>> callback)
		{
		}

		public static void GetCurrentUserRatingFor(ModId modId, Action<ResultAnd<ModRating>> callback)
		{
		}

		public static void RateMod(ModId modId, ModRating rating, Action<Result> callback)
		{
		}

		public static void SubscribeToMod(ModId modId, Action<Result> callback)
		{
		}

		public static void UnsubscribeFromMod(ModId modId, Action<Result> callback)
		{
		}

		public static SubscribedMod[] GetSubscribedMods(out Result result)
		{
			result = default(Result);
			return null;
		}

		public static void GetCurrentUser(Action<ResultAnd<UserProfile>> callback)
		{
		}

		public static void MuteUser(long userId, Action<Result> callback)
		{
		}

		public static void UnmuteUser(long userId, Action<Result> callback)
		{
		}

		public static void FetchUpdates(Action<Result> callback)
		{
		}

		public static Result EnableModManagement(ModManagementEventDelegate modManagementEventDelegate)
		{
			return default(Result);
		}

		public static Result DisableModManagement()
		{
			return default(Result);
		}

		public static ProgressHandle GetCurrentModManagementOperation()
		{
			return null;
		}

		public static InstalledMod[] GetSystemInstalledMods(out Result result)
		{
			result = default(Result);
			return null;
		}

		public static UserInstalledMod[] GetInstalledModsForUser(out Result result, bool includeDisabledMods = false)
		{
			result = default(Result);
			return null;
		}

		public static Result ForceUninstallMod(ModId modId)
		{
			return default(Result);
		}

		public static bool IsModManagementBusy()
		{
			return false;
		}

		public static bool EnableMod(ModId modId)
		{
			return false;
		}

		public static bool DisableMod(ModId modId)
		{
			return false;
		}

		public static void AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
		}

		public static void RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
		}

		public static CreationToken GenerateCreationToken()
		{
			return null;
		}

		public static void CreateModProfile(CreationToken token, ModProfileDetails modProfileDetails, Action<ResultAnd<ModId>> callback)
		{
		}

		public static void EditModProfile(ModProfileDetails modProfile, Action<Result> callback)
		{
		}

		public static ProgressHandle GetCurrentUploadHandle()
		{
			return null;
		}

		public static void UploadModfile(ModfileDetails modfile, Action<Result> callback)
		{
		}

		public static void UploadModMedia(ModProfileDetails modProfileDetails, Action<Result> callback)
		{
		}

		public static void ArchiveModProfile(ModId modId, Action<Result> callback)
		{
		}

		public static void GetCurrentUserCreations(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
		}

		public static void AddTags(ModId modId, string[] tags, Action<Result> callback)
		{
		}

		public static void AddModComment(ModId modId, CommentDetails commentDetails, Action<ResultAnd<ModComment>> callback)
		{
		}

		public static void DeleteModComment(ModId modId, long commentId, Action<Result> callback)
		{
		}

		public static void UpdateModComment(ModId modId, string content, long commentId, Action<ResultAnd<ModComment>> callback)
		{
		}

		public static void DeleteTags(ModId modId, string[] tags, Action<Result> callback)
		{
		}

		public static void DownloadTexture(DownloadReference downloadReference, Action<ResultAnd<Texture2D>> callback)
		{
		}

		public static void DownloadImage(DownloadReference downloadReference, Action<ResultAnd<byte[]>> callback)
		{
		}

		public static void Report(Report report, Action<Result> callback)
		{
		}
	}
}
