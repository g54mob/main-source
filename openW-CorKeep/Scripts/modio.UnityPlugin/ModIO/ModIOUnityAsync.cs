using System.Collections.Generic;
using System.Threading.Tasks;
using ModIO.Implementation;
using ModIO.Implementation.API.Objects;
using UnityEngine;

namespace ModIO
{
	public static class ModIOUnityAsync
	{
		public static async Task Shutdown()
		{
			await ModIOUnityImplementation.Shutdown(delegate
			{
			});
		}

		public static async Task<ResultAnd<ExternalAuthenticationToken>> RequestExternalAuthentication()
		{
			return await ModIOUnityImplementation.BeginWssAuthentication();
		}

		public static async Task<Result> RequestAuthenticationEmail(string emailaddress)
		{
			return await ModIOUnityImplementation.RequestEmailAuthToken(emailaddress);
		}

		public static async Task<Result> SubmitEmailSecurityCode(string securityCode)
		{
			return await ModIOUnityImplementation.SubmitEmailSecurityCode(securityCode);
		}

		public static async Task<ResultAnd<TermsOfUse>> GetTermsOfUse()
		{
			return await ModIOUnityImplementation.GetTermsOfUse();
		}

		public static async Task<Result> AuthenticateUserViaSteam(string steamToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(steamToken, AuthenticationServiceProvider.Steam, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaEpic(string epicToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(epicToken, AuthenticationServiceProvider.Steam, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaPlayStation(string authCode, string emailAddress, TermsHash? hash, PlayStationEnvironment environment)
		{
			return await ModIOUnityImplementation.AuthenticateUser(authCode, AuthenticationServiceProvider.PlayStation, emailAddress, hash, null, null, null, environment);
		}

		public static async Task<Result> AuthenticateUserViaGOG(string gogToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(gogToken, AuthenticationServiceProvider.GOG, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaItch(string itchioToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(itchioToken, AuthenticationServiceProvider.Itchio, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaXbox(string xboxToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(xboxToken, AuthenticationServiceProvider.Xbox, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaSwitch(string switchToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(switchToken, AuthenticationServiceProvider.Switch, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaDiscord(string discordToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(discordToken, AuthenticationServiceProvider.Discord, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaGoogle(string googleToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(googleToken, AuthenticationServiceProvider.Google, emailAddress, hash, null, null, null, (PlayStationEnvironment)0);
		}

		public static async Task<Result> AuthenticateUserViaOculus(OculusDevice oculusDevice, string nonce, long userId, string oculusToken, string emailAddress, TermsHash? hash)
		{
			return await ModIOUnityImplementation.AuthenticateUser(oculusToken, AuthenticationServiceProvider.Oculus, emailAddress, hash, nonce, oculusDevice, userId.ToString(), (PlayStationEnvironment)0);
		}

		public static async Task<Result> IsAuthenticated()
		{
			return await ModIOUnityImplementation.IsAuthenticated();
		}

		public static async Task<ResultAnd<TagCategory[]>> GetTagCategories()
		{
			return await ModIOUnityImplementation.GetGameTags();
		}

		public static async Task<ResultAnd<ModPage>> GetMods(SearchFilter filter)
		{
			return await ModIOUnityImplementation.GetMods(filter);
		}

		public static async Task<ResultAnd<ModProfile>> GetMod(ModId modId)
		{
			return await ModIOUnityImplementation.GetMod(modId.id);
		}

		public static async Task<ResultAnd<CommentPage>> GetModComments(ModId modId, SearchFilter filter)
		{
			return await ModIOUnityImplementation.GetModComments(modId, filter);
		}

		public static async Task<ResultAnd<ModComment>> AddModComment(ModId modId, CommentDetails commentDetails)
		{
			return await ModIOUnityImplementation.AddModComment(modId, commentDetails);
		}

		public static async Task<Result> DeleteModComment(ModId modId, long commentId)
		{
			return await ModIOUnityImplementation.DeleteModComment(modId, commentId);
		}

		public static async Task<ResultAnd<ModComment>> UpdateModComment(ModId modId, string content, long commentId)
		{
			return await ModIOUnityImplementation.UpdateModComment(modId, content, commentId);
		}

		public static async Task<ResultAnd<ModDependencies[]>> GetModDependencies(ModId modId)
		{
			return await ModIOUnityImplementation.GetModDependencies(modId);
		}

		public static async Task<ResultAnd<Rating[]>> GetCurrentUserRatings()
		{
			return await ModIOUnityImplementation.GetCurrentUserRatings();
		}

		public static async Task<ResultAnd<ModRating>> GetCurrentUserRatingFor(ModId modId)
		{
			return await ModIOUnityImplementation.GetCurrentUserRatingFor(modId);
		}

		public static async Task<Result> RateMod(ModId modId, ModRating rating)
		{
			return await ModIOUnityImplementation.AddModRating(modId, rating);
		}

		public static async Task<Result> SubscribeToMod(ModId modId)
		{
			return await ModIOUnityImplementation.SubscribeTo(modId);
		}

		public static async Task<Result> UnsubscribeFromMod(ModId modId)
		{
			return await ModIOUnityImplementation.UnsubscribeFrom(modId);
		}

		public static async Task<ResultAnd<UserProfile>> GetCurrentUser()
		{
			return await ModIOUnityImplementation.GetCurrentUser();
		}

		public static void MuteUser(long userId)
		{
			ModIOUnityImplementation.MuteUser(userId);
		}

		public static void UnmuteUser(long userId)
		{
			ModIOUnityImplementation.UnmuteUser(userId);
		}

		public static async Task<Result> FetchUpdates()
		{
			return await ModIOUnityImplementation.FetchUpdates();
		}

		public static async Task<Result> AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies)
		{
			return await ModIOUnityImplementation.AddDependenciesToMod(modId, dependencies);
		}

		public static async Task<Result> RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies)
		{
			return await ModIOUnityImplementation.RemoveDependenciesFromMod(modId, dependencies);
		}

		public static async Task<ResultAnd<ModId>> CreateModProfile(CreationToken token, ModProfileDetails modProfileDetails)
		{
			return await ModIOUnityImplementation.CreateModProfile(token, modProfileDetails);
		}

		public static async Task<Result> EditModProfile(ModProfileDetails modprofile)
		{
			return await ModIOUnityImplementation.EditModProfile(modprofile);
		}

		public static async Task<Result> UploadModfile(ModfileDetails modfile)
		{
			return await ModIOUnityImplementation.UploadModfile(modfile);
		}

		public static async Task<Result> UploadModMedia(ModProfileDetails modProfileDetails)
		{
			return await ModIOUnityImplementation.UploadModMedia(modProfileDetails);
		}

		public static async Task<Result> ArchiveModProfile(ModId modId)
		{
			return await ModIOUnityImplementation.ArchiveModProfile(modId);
		}

		public static async Task<ResultAnd<ModPage>> GetCurrentUserCreations(SearchFilter filter)
		{
			return await ModIOUnityImplementation.GetCurrentUserCreations(filter);
		}

		public static async Task<Result> AddTags(ModId modId, string[] tags)
		{
			return await ModIOUnityImplementation.AddTags(modId, tags);
		}

		public static async Task<Result> DeleteTags(ModId modId, string[] tags)
		{
			return await ModIOUnityImplementation.DeleteTags(modId, tags);
		}

		public static async Task<ResultAnd<Texture2D>> DownloadTexture(DownloadReference downloadReference)
		{
			return await ModIOUnityImplementation.DownloadTexture(downloadReference);
		}

		public static async Task<ResultAnd<byte[]>> DownloadImage(DownloadReference downloadReference)
		{
			return await ModIOUnityImplementation.GetImage(downloadReference);
		}

		public static async Task<Result> Report(Report report)
		{
			return await ModIOUnityImplementation.Report(report);
		}
	}
}
