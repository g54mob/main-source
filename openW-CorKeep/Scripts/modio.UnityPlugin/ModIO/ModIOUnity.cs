using System;
using System.Collections.Generic;
using ModIO.Implementation;
using ModIO.Implementation.API.Objects;
using UnityEngine;

namespace ModIO
{
	public static class ModIOUnity
	{
		public static bool IsInitialized()
		{
			return ModIOUnityImplementation.isInitialized;
		}

		public static void SetLoggingDelegate(LogMessageDelegate loggingDelegate)
		{
			ModIOUnityImplementation.SetLoggingDelegate(loggingDelegate);
		}

		public static Result InitializeForUser(string userProfileIdentifier, ServerSettings serverSettings, BuildSettings buildSettings)
		{
			return ModIOUnityImplementation.InitializeForUser(userProfileIdentifier, serverSettings, buildSettings);
		}

		public static Result InitializeForUser(string userProfileIdentifier)
		{
			return ModIOUnityImplementation.InitializeForUser(userProfileIdentifier);
		}

		public static void Shutdown(Action shutdownComplete)
		{
			ModIOUnityImplementation.Shutdown(shutdownComplete);
		}

		public static void RequestExternalAuthentication(Action<ResultAnd<ExternalAuthenticationToken>> callback)
		{
			ModIOUnityImplementation.BeginWssAuthentication(callback);
		}

		public static void RequestAuthenticationEmail(string emailaddress, Action<Result> callback)
		{
			ModIOUnityImplementation.RequestEmailAuthToken(emailaddress, callback);
		}

		public static void SubmitEmailSecurityCode(string securityCode, Action<Result> callback)
		{
			ModIOUnityImplementation.SubmitEmailSecurityCode(securityCode, callback);
		}

		public static void GetTermsOfUse(Action<ResultAnd<TermsOfUse>> callback)
		{
			ModIOUnityImplementation.GetTermsOfUse(callback);
		}

		public static void AuthenticateUserViaSteam(string steamToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(steamToken, AuthenticationServiceProvider.Steam, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaEpic(string epicToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(epicToken, AuthenticationServiceProvider.Epic, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaGOG(string gogToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(gogToken, AuthenticationServiceProvider.GOG, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaPlayStation(string authCode, string emailAddress, TermsHash? hash, PlayStationEnvironment environment, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(authCode, AuthenticationServiceProvider.PlayStation, emailAddress, hash, null, null, null, environment, callback);
		}

		public static void AuthenticateUserViaItch(string itchioToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(itchioToken, AuthenticationServiceProvider.Itchio, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaXbox(string xboxToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(xboxToken, AuthenticationServiceProvider.Xbox, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaSwitch(string SwitchNsaId, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(SwitchNsaId, AuthenticationServiceProvider.Switch, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaDiscord(string discordToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(discordToken, AuthenticationServiceProvider.Discord, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaGoogle(string googleToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(googleToken, AuthenticationServiceProvider.Google, emailAddress, hash, null, null, null, (PlayStationEnvironment)0, callback);
		}

		public static void AuthenticateUserViaOculus(OculusDevice oculusDevice, string nonce, long userId, string oculusToken, string emailAddress, TermsHash? hash, Action<Result> callback)
		{
			ModIOUnityImplementation.AuthenticateUser(oculusToken, AuthenticationServiceProvider.Oculus, emailAddress, hash, nonce, oculusDevice, userId.ToString(), (PlayStationEnvironment)0, callback);
		}

		public static void IsAuthenticated(Action<Result> callback)
		{
			ModIOUnityImplementation.IsAuthenticated(callback);
		}

		public static Result LogOutCurrentUser()
		{
			return ModIOUnityImplementation.RemoveUserData();
		}

		public static void GetTagCategories(Action<ResultAnd<TagCategory[]>> callback)
		{
			ModIOUnityImplementation.GetGameTags(callback);
		}

		public static void GetMods(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
			ModIOUnityImplementation.GetMods(filter, callback);
		}

		public static void GetMod(ModId modId, Action<ResultAnd<ModProfile>> callback)
		{
			ModIOUnityImplementation.GetMod(modId.id, callback);
		}

		public static void GetModComments(ModId modId, SearchFilter filter, Action<ResultAnd<CommentPage>> callback)
		{
			ModIOUnityImplementation.GetModComments(modId, filter, callback);
		}

		public static void GetModDependencies(ModId modId, Action<ResultAnd<ModDependencies[]>> callback)
		{
			ModIOUnityImplementation.GetModDependencies(modId, callback);
		}

		public static void GetCurrentUserRatings(Action<ResultAnd<Rating[]>> callback)
		{
			ModIOUnityImplementation.GetCurrentUserRatings(callback);
		}

		public static void GetCurrentUserRatingFor(ModId modId, Action<ResultAnd<ModRating>> callback)
		{
			ModIOUnityImplementation.GetCurrentUserRatingFor(modId, callback);
		}

		public static void RateMod(ModId modId, ModRating rating, Action<Result> callback)
		{
			ModIOUnityImplementation.AddModRating(modId, rating, callback);
		}

		public static void SubscribeToMod(ModId modId, Action<Result> callback)
		{
			ModIOUnityImplementation.SubscribeTo(modId, callback);
		}

		public static void UnsubscribeFromMod(ModId modId, Action<Result> callback)
		{
			ModIOUnityImplementation.UnsubscribeFrom(modId, callback);
		}

		public static SubscribedMod[] GetSubscribedMods(out Result result)
		{
			return ModIOUnityImplementation.GetSubscribedMods(out result);
		}

		public static void GetCurrentUser(Action<ResultAnd<UserProfile>> callback)
		{
			ModIOUnityImplementation.GetCurrentUser(callback);
		}

		public static void MuteUser(long userId, Action<Result> callback)
		{
			ModIOUnityImplementation.MuteUser(userId, callback);
		}

		public static void UnmuteUser(long userId, Action<Result> callback)
		{
			ModIOUnityImplementation.UnmuteUser(userId, callback);
		}

		public static void FetchUpdates(Action<Result> callback)
		{
			ModIOUnityImplementation.FetchUpdates(callback);
		}

		public static Result EnableModManagement(ModManagementEventDelegate modManagementEventDelegate)
		{
			return ModIOUnityImplementation.EnableModManagement(modManagementEventDelegate);
		}

		public static Result DisableModManagement()
		{
			return ModIOUnityImplementation.DisableModManagement();
		}

		public static ProgressHandle GetCurrentModManagementOperation()
		{
			return ModIOUnityImplementation.GetCurrentModManagementOperation();
		}

		public static InstalledMod[] GetSystemInstalledMods(out Result result)
		{
			return ModIOUnityImplementation.GetInstalledMods(out result);
		}

		public static UserInstalledMod[] GetInstalledModsForUser(out Result result, bool includeDisabledMods = false)
		{
			return ModIOUnityImplementation.GetInstalledModsForUser(out result, includeDisabledMods);
		}

		public static Result ForceUninstallMod(ModId modId)
		{
			return ModIOUnityImplementation.ForceUninstallMod(modId);
		}

		public static bool IsModManagementBusy()
		{
			return ModIOUnityImplementation.IsModManagementBusy();
		}

		public static bool EnableMod(ModId modId)
		{
			return ModIOUnityImplementation.EnableMod(modId);
		}

		public static bool DisableMod(ModId modId)
		{
			return ModIOUnityImplementation.DisableMod(modId);
		}

		public static void AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
			ModIOUnityImplementation.AddDependenciesToMod(modId, dependencies, callback);
		}

		public static void RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
			ModIOUnityImplementation.RemoveDependenciesFromMod(modId, dependencies, callback);
		}

		public static CreationToken GenerateCreationToken()
		{
			return ModIOUnityImplementation.GenerateCreationToken();
		}

		public static void CreateModProfile(CreationToken token, ModProfileDetails modProfileDetails, Action<ResultAnd<ModId>> callback)
		{
			ModIOUnityImplementation.CreateModProfile(token, modProfileDetails, callback);
		}

		public static void EditModProfile(ModProfileDetails modProfile, Action<Result> callback)
		{
			ModIOUnityImplementation.EditModProfile(modProfile, callback);
		}

		public static ProgressHandle GetCurrentUploadHandle()
		{
			return ModIOUnityImplementation.GetCurrentUploadHandle();
		}

		public static void UploadModfile(ModfileDetails modfile, Action<Result> callback)
		{
			ModIOUnityImplementation.UploadModfile(modfile, callback);
		}

		public static void UploadModMedia(ModProfileDetails modProfileDetails, Action<Result> callback)
		{
			ModIOUnityImplementation.UploadModMedia(modProfileDetails, callback);
		}

		public static void ArchiveModProfile(ModId modId, Action<Result> callback)
		{
			ModIOUnityImplementation.ArchiveModProfile(modId, callback);
		}

		public static void GetCurrentUserCreations(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
			ModIOUnityImplementation.GetCurrentUserCreations(filter, callback);
		}

		public static void AddTags(ModId modId, string[] tags, Action<Result> callback)
		{
			ModIOUnityImplementation.AddTags(modId, tags, callback);
		}

		public static void AddModComment(ModId modId, CommentDetails commentDetails, Action<ResultAnd<ModComment>> callback)
		{
			ModIOUnityImplementation.AddModComment(modId, commentDetails, callback);
		}

		public static void DeleteModComment(ModId modId, long commentId, Action<Result> callback)
		{
			ModIOUnityImplementation.DeleteModComment(modId, commentId, callback);
		}

		public static void UpdateModComment(ModId modId, string content, long commentId, Action<ResultAnd<ModComment>> callback)
		{
			ModIOUnityImplementation.UpdateModComment(modId, content, commentId, callback);
		}

		public static void DeleteTags(ModId modId, string[] tags, Action<Result> callback)
		{
			ModIOUnityImplementation.DeleteTags(modId, tags, callback);
		}

		public static void DownloadTexture(DownloadReference downloadReference, Action<ResultAnd<Texture2D>> callback)
		{
			ModIOUnityImplementation.DownloadTexture(downloadReference, callback);
		}

		public static void DownloadImage(DownloadReference downloadReference, Action<ResultAnd<byte[]>> callback)
		{
			ModIOUnityImplementation.DownloadImage(downloadReference, callback);
		}

		public static void Report(Report report, Action<Result> callback)
		{
			ModIOUnityImplementation.Report(report, callback);
		}
	}
}
