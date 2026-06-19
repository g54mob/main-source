using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ModIO.Implementation.API;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;
using ModIO.Implementation.Platform;
using ModIO.Implementation.Wss;
using UnityEngine;

namespace ModIO.Implementation
{
	internal static class ModIOUnityImplementation
	{
		private static ProgressHandle currentUploadHandle;

		private static Dictionary<TaskCompletionSource<bool>, Task> openCallbacks_dictionary = new Dictionary<TaskCompletionSource<bool>, Task>();

		private static Dictionary<string, Task<ResultAnd<byte[]>>> onGoingImageDownloads = new Dictionary<string, Task<ResultAnd<byte[]>>>();

		private static Task shutdownOperation;

		internal static OpenCallbacks openCallbacks = new OpenCallbacks();

		internal static bool isInitialized;

		public static bool shuttingDown;

		private static bool autoInitializePlugin = false;

		private static bool autoInitializePluginSet = false;

		public static bool AutoInitializePlugin
		{
			get
			{
				if (!autoInitializePluginSet)
				{
					Result result = SettingsAsset.TryLoad(out autoInitializePlugin);
					if (!result.Succeeded())
					{
						Logger.Log(LogLevel.Error, result.message);
					}
					autoInitializePluginSet = true;
				}
				return autoInitializePlugin;
			}
			set
			{
				autoInitializePluginSet = true;
				autoInitializePlugin = value;
			}
		}

		public static bool IsInitialized(out Result result)
		{
			if (isInitialized)
			{
				result = ResultBuilder.Success;
				return true;
			}
			if (AutoInitializePlugin)
			{
				Debug.Log("Auto initialized");
				result = InitializeForUser("Default");
				if (result.Succeeded())
				{
					result = ResultBuilder.Success;
					return true;
				}
			}
			result = ResultBuilder.Create(20000u);
			Logger.Log(LogLevel.Error, "You attempted to use a method but the plugin hasn't been initialized yet. Be sure to use ModIOUnity.InitializeForUser to initialize the plugin before attempting this method again (Or ModIOUnityAsync.InitializeForUser).");
			return false;
		}

		public static bool IsAuthenticatedSessionValid(out Result result)
		{
			if (UserData.instance == null || string.IsNullOrEmpty(UserData.instance.oAuthToken))
			{
				Logger.Log(LogLevel.Verbose, "The current session is not authenticated.");
				result = ResultBuilder.Create(20100u);
				return false;
			}
			if (UserData.instance.oAuthTokenWasRejected)
			{
				Logger.Log(LogLevel.Warning, "The auth token was rejected. This could be because it's old and may need to be re-authenticated.");
				result = ResultBuilder.Create(20101u);
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}

		public static bool IsValidEmail(string emailaddress, out Result result)
		{
			try
			{
				new MailAddress(emailaddress);
			}
			catch
			{
				result = ResultBuilder.Create(20102u);
				Logger.Log(LogLevel.Error, "The Email Address provided was not recognised by .NET as a valid Email Address.");
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}

		private static bool IsSearchFilterValid(SearchFilter filter, out Result result)
		{
			if (filter == null)
			{
				Logger.Log(LogLevel.Error, "The SearchFilter parameter cannot be null. Be sure to assign a valid SearchFilter object before using GetMods method.");
				result = ResultBuilder.Create(20213u);
				return false;
			}
			return filter.IsSearchFilterValid(out result);
		}

		public static bool IsRateLimited(out Result result)
		{
			throw new NotImplementedException();
		}

		public static bool AreSettingsValid(out Result result)
		{
			throw new NotImplementedException();
		}

		public static void SetLoggingDelegate(LogMessageDelegate loggingDelegate)
		{
			Logger.SetLoggingDelegate(loggingDelegate);
		}

		public static Result InitializeForUser(string userProfileIdentifier, ServerSettings serverSettings, BuildSettings buildSettings)
		{
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			openCallbacks_dictionary.Add(taskCompletionSource, null);
			userProfileIdentifier = IOUtil.CleanFileNameForInvalidCharacters(userProfileIdentifier);
			Settings.server = serverSettings;
			Settings.build = buildSettings;
			DataStorage.user = PlatformConfiguration.CreateUserDataService(userProfileIdentifier, serverSettings.gameId, buildSettings).value;
			Result result = DataStorage.LoadUserData();
			DataStorage.persistent = PlatformConfiguration.CreatePersistentDataService(serverSettings.gameId, buildSettings).value;
			DataStorage.temp = PlatformConfiguration.CreateTempDataService(serverSettings.gameId, buildSettings).value;
			if (result.code == 20401 || result.code == 20420)
			{
				UserData.instance = new UserData();
				result = DataStorage.SaveUserData();
			}
			if (!result.Succeeded())
			{
				taskCompletionSource.SetResult(result: true);
				openCallbacks_dictionary.Remove(taskCompletionSource);
				return result;
			}
			Logger.Log(LogLevel.Verbose, "Loading Registry");
			result = ModCollectionManager.LoadRegistry();
			Logger.Log(LogLevel.Verbose, "Finished Loading Registry");
			openCallbacks_dictionary[taskCompletionSource] = null;
			ResponseCache.maxCacheSize = buildSettings.requestCacheLimitKB * 1024;
			isInitialized = true;
			result = ResultBuilder.Success;
			taskCompletionSource.SetResult(result: true);
			openCallbacks_dictionary.Remove(taskCompletionSource);
			Logger.Log(LogLevel.Message, "Initialized User[" + userProfileIdentifier + "]");
			return result;
		}

		public static Result InitializeForUser(string userProfileIdentifier)
		{
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			openCallbacks_dictionary.Add(taskCompletionSource, null);
			ServerSettings serverSettings;
			BuildSettings buildSettings;
			Result result = SettingsAsset.TryLoad(out serverSettings, out buildSettings);
			if (result.Succeeded())
			{
				result = InitializeForUser(userProfileIdentifier, serverSettings, buildSettings);
			}
			taskCompletionSource.SetResult(result: true);
			openCallbacks_dictionary.Remove(taskCompletionSource);
			return result;
		}

		public static async Task Shutdown(Action shutdownComplete)
		{
			if (!IsInitialized(out var _))
			{
				Logger.Log(LogLevel.Verbose, "ALREADY SHUTDOWN");
				return;
			}
			if (shuttingDown && shutdownOperation != null)
			{
				Logger.Log(LogLevel.Verbose, "WAITING FOR SHUTDOWN ");
				await shutdownOperation;
			}
			else
			{
				Logger.Log(LogLevel.Verbose, "SHUTTING DOWN");
				try
				{
					shuttingDown = true;
					shutdownOperation = ShutdownTask();
					await shutdownOperation;
					await openCallbacks.ShutDown();
					shutdownOperation = null;
					shuttingDown = false;
				}
				catch (Exception ex)
				{
					shuttingDown = false;
					Logger.Log(LogLevel.Error, "Exception caught when shutting down plugin: " + ex.Message + " - inner=" + ex.InnerException?.Message + " - stacktrace: " + ex.StackTrace);
				}
				Logger.Log(LogLevel.Verbose, "FINISHED SHUTDOWN");
			}
			shutdownComplete?.Invoke();
		}

		private static async Task ShutdownTask()
		{
			await WebRequestManager.Shutdown();
			await ModManagement.ShutdownOperations();
			await WssHandler.Shutdown();
			isInitialized = false;
			UserData.instance = null;
			ResponseCache.ClearCache();
			ModCollectionManager.ClearRegistry();
			Dictionary<TaskCompletionSource<bool>, Task> dictionary = new Dictionary<TaskCompletionSource<bool>, Task>(openCallbacks_dictionary);
			using (Dictionary<TaskCompletionSource<bool>, Task>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Value == null || !enumerator.Current.Value.IsFaulted)
					{
						await enumerator.Current.Key.Task;
						continue;
					}
					Logger.Log(LogLevel.Error, "An Unhandled Exception was thrown in an awaited task. The corresponding callback will never be invoked.");
					if (openCallbacks_dictionary.ContainsKey(enumerator.Current.Key))
					{
						openCallbacks_dictionary.Remove(enumerator.Current.Key);
					}
				}
			}
			Logger.Log(LogLevel.Verbose, "Shutdown main handlers");
		}

		public static async Task<Result> IsAuthenticated()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result = ResultBuilder.Unknown;
			if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = GetAuthenticatedUser.Request();
				ResultAnd<UserObject> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<UserObject>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					result = resultAnd.result;
					UserData.instance.SetUserObject(resultAnd.value);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void IsAuthenticated(Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the IsAuthenticated method. This method has been cancelled.");
				return;
			}
			Result obj = await IsAuthenticated();
			callback?.Invoke(obj);
		}

		public static async Task<Result> RequestEmailAuthToken(string emailaddress)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsValidEmail(emailaddress, out result))
			{
				WebRequestConfig config = AuthenticateViaEmail.Request(emailaddress);
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void RequestEmailAuthToken(string emailaddress, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the RequestEmailAuthToken method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await RequestEmailAuthToken(emailaddress);
			callback?.Invoke(obj);
		}

		public static async Task<Result> SubmitEmailSecurityCode(string securityCode)
		{
			TaskCompletionSource<bool> callbackConfirmation = new TaskCompletionSource<bool>();
			openCallbacks_dictionary.Add(callbackConfirmation, null);
			Result result = ResultBuilder.Unknown;
			if (string.IsNullOrWhiteSpace(securityCode))
			{
				Logger.Log(LogLevel.Warning, "The security code provided is null. Be sure to use the 5 digit code sent to the specified email address when using RequestEmailAuthToken()");
				ResultBuilder.Create(20213u);
			}
			else if (IsInitialized(out result))
			{
				Task<ResultAnd<AccessTokenObject>> task = WebRequestManager.Request<AccessTokenObject>(ModIO.Implementation.API.Requests.AuthenticateUser.InternalRequest(securityCode));
				openCallbacks_dictionary[callbackConfirmation] = task;
				ResultAnd<AccessTokenObject> resultAnd = await task;
				openCallbacks_dictionary[callbackConfirmation] = null;
				result = resultAnd.result;
				if (result.Succeeded())
				{
					UserData.instance.SetOAuthToken(resultAnd.value);
					await GetCurrentUser(delegate
					{
					});
				}
			}
			callbackConfirmation.SetResult(result: true);
			openCallbacks_dictionary.Remove(callbackConfirmation);
			return result;
		}

		public static async void SubmitEmailSecurityCode(string securityCode, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the RequestEmailAuthToken method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await SubmitEmailSecurityCode(securityCode);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<TermsOfUse>> GetTermsOfUse()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			WebRequestConfig config = GetTerms.Request();
			TermsOfUse termsOfUse = default(TermsOfUse);
			if (IsInitialized(out var result) && !ResponseCache.GetTermsFromCache(config.Url, out termsOfUse))
			{
				Task<ResultAnd<TermsObject>> task = WebRequestManager.Request<TermsObject>(config);
				ResultAnd<TermsObject> resultAnd = await openCallbacks.Run(callbackConfirmation, task);
				result = resultAnd.result;
				if (result.Succeeded())
				{
					termsOfUse = ResponseTranslator.ConvertTermsObjectToTermsOfUse(resultAnd.value);
					ResponseCache.AddTermsToCache(config.Url, termsOfUse);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, termsOfUse);
		}

		public static async void GetTermsOfUse(Action<ResultAnd<TermsOfUse>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetTermsOfUse method, any response returned from the server wont be used. This operation has been cancelled.");
				return;
			}
			ResultAnd<TermsOfUse> obj = await GetTermsOfUse();
			callback?.Invoke(obj);
		}

		public static async Task<Result> AuthenticateUser(string data, AuthenticationServiceProvider serviceProvider, string emailAddress, TermsHash? hash, string nonce, OculusDevice? device, string userId, PlayStationEnvironment environment)
		{
			TaskCompletionSource<bool> callbackConfirmation = new TaskCompletionSource<bool>();
			openCallbacks_dictionary.Add(callbackConfirmation, null);
			if (IsInitialized(out var result) && (emailAddress == null || IsValidEmail(emailAddress, out result)))
			{
				Task<ResultAnd<AccessTokenObject>> task = WebRequestManager.Request<AccessTokenObject>(ModIO.Implementation.API.Requests.AuthenticateUser.ExternalRequest(serviceProvider, data, hash, emailAddress, nonce, device, userId, environment));
				openCallbacks_dictionary[callbackConfirmation] = task;
				ResultAnd<AccessTokenObject> resultAnd = await task;
				openCallbacks_dictionary[callbackConfirmation] = null;
				result = resultAnd.result;
				if (result.Succeeded())
				{
					UserData.instance.SetOAuthToken(resultAnd.value);
					await GetCurrentUser(delegate
					{
					});
				}
				else
				{
					Settings.build.SetDefaultPortal();
				}
			}
			SetUserPortal(serviceProvider);
			callbackConfirmation.SetResult(result: true);
			openCallbacks_dictionary.Remove(callbackConfirmation);
			return result;
		}

		private static void SetUserPortal(AuthenticationServiceProvider serviceProvider)
		{
			switch (serviceProvider)
			{
			case AuthenticationServiceProvider.Epic:
				Settings.build.userPortal = UserPortal.EpicGamesStore;
				break;
			case AuthenticationServiceProvider.Discord:
				Settings.build.userPortal = UserPortal.Discord;
				break;
			case AuthenticationServiceProvider.Google:
				Settings.build.userPortal = UserPortal.Google;
				break;
			case AuthenticationServiceProvider.Itchio:
				Settings.build.userPortal = UserPortal.itchio;
				break;
			case AuthenticationServiceProvider.Oculus:
				Settings.build.userPortal = UserPortal.Oculus;
				break;
			case AuthenticationServiceProvider.Steam:
				Settings.build.userPortal = UserPortal.Steam;
				break;
			case AuthenticationServiceProvider.Switch:
				Settings.build.userPortal = UserPortal.Nintendo;
				break;
			case AuthenticationServiceProvider.Xbox:
				Settings.build.userPortal = UserPortal.XboxLive;
				break;
			case AuthenticationServiceProvider.PlayStation:
				Settings.build.userPortal = UserPortal.PlayStationNetwork;
				break;
			case AuthenticationServiceProvider.GOG:
				Settings.build.userPortal = UserPortal.GOG;
				break;
			}
		}

		public static async void AuthenticateUser(string data, AuthenticationServiceProvider serviceProvider, string emailAddress, TermsHash? hash, string nonce, OculusDevice? device, string userId, PlayStationEnvironment environment, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the AuthenticateUser method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await AuthenticateUser(data, serviceProvider, emailAddress, hash, nonce, device, userId, environment);
			callback?.Invoke(obj);
		}

		public static async void BeginWssAuthentication(Action<ResultAnd<ExternalAuthenticationToken>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the BeginWssAuthentication method, any response returned from the server wont be used. This operation has been cancelled.");
				return;
			}
			ResultAnd<ExternalAuthenticationToken> obj = await BeginWssAuthentication();
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ExternalAuthenticationToken>> BeginWssAuthentication()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ResultAnd<ExternalAuthenticationToken> result = await openCallbacks.Run(callbackConfirmation, ModIO.Implementation.Wss.Wss.BeginAuthenticationProcess());
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task<ResultAnd<TagCategory[]>> GetGameTags()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			TagCategory[] tags = new TagCategory[0];
			if (IsInitialized(out var result) && !ResponseCache.GetTagsFromCache(out tags))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.GetGameTags.Request();
				ResultAnd<GetGameTags.ResponseSchema> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<GetGameTags.ResponseSchema>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					tags = ResponseTranslator.ConvertGameTagOptionsObjectToTagCategories(resultAnd.value.data);
					ResponseCache.AddTagsToCache(tags);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, tags);
		}

		public static async void GetGameTags(Action<ResultAnd<TagCategory[]>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetGameTags method, any response returned from the server wont be used. This operation has been cancelled.");
				return;
			}
			ResultAnd<TagCategory[]> obj = await GetGameTags();
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ModPage>> GetMods(SearchFilter filter)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModPage page = default(ModPage);
			string url = ModIO.Implementation.API.Requests.GetMods.UnpaginatedURL(filter);
			int offset = filter.pageIndex * filter.pageSize;
			if (IsInitialized(out var result) && IsSearchFilterValid(filter, out result) && !ResponseCache.GetModsFromCache(url, offset, filter.pageSize, out page))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.GetMods.RequestPaginated(filter);
				ResultAnd<GetMods.ResponseSchema> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<GetMods.ResponseSchema>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					page = ResponseTranslator.ConvertResponseSchemaToModPage(resultAnd.value, filter);
					if (page.modProfiles.Length > filter.pageSize)
					{
						Array.Copy(page.modProfiles, page.modProfiles, filter.pageSize);
					}
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, page);
		}

		public static async void GetMods(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetMods method, any response returned from the server wont be used. This operation  has been cancelled.");
				return;
			}
			ResultAnd<ModPage> obj = await GetMods(filter);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<CommentPage>> GetModComments(ModId modId, SearchFilter filter)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			CommentPage page = default(CommentPage);
			WebRequestConfig config = ModIO.Implementation.API.Requests.GetModComments.RequestPaginated(modId, filter);
			if (IsInitialized(out var result) && IsSearchFilterValid(filter, out result) && !ResponseCache.GetModCommentsFromCache(config.Url, out page))
			{
				ResultAnd<GetModComments.ResponseSchema> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<GetModComments.ResponseSchema>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					page = ResponseTranslator.ConvertModCommentObjectsToCommentPage(resultAnd.value);
					ResponseCache.AddModCommentsToCache(config.Url, page);
					if (page.CommentObjects.Length > filter.pageSize)
					{
						Array.Copy(page.CommentObjects, page.CommentObjects, filter.pageSize);
					}
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, page);
		}

		public static async void GetModComments(ModId modId, SearchFilter filter, Action<ResultAnd<CommentPage>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetModComments method, any response returned from the server wont be used. This operation  has been cancelled.");
				return;
			}
			ResultAnd<CommentPage> obj = await GetModComments(modId, filter);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ModProfile>> GetMod(long id)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModProfile profile = default(ModProfile);
			if (IsInitialized(out var result) && !ResponseCache.GetModFromCache((ModId)id, out profile))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.GetMod.Request((ModId)id);
				ResultAnd<ModObject> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModObject>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					profile = ResponseTranslator.ConvertModObjectToModProfile(resultAnd.value);
					ResponseCache.AddModToCache(profile);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, profile);
		}

		public static async Task GetMod(long id, Action<ResultAnd<ModProfile>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetMod method, any response returned from the server wont be used. This operation  has been cancelled.");
				return;
			}
			ResultAnd<ModProfile> obj = await GetMod(id);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ModDependencies[]>> GetModDependencies(ModId modId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModDependencies[] modDependencies = null;
			if (IsInitialized(out var result) && !ResponseCache.GetModDependenciesCache(modId, out modDependencies))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.GetModDependencies.Request(modId);
				ResultAnd<GetModDependencies.ResponseSchema> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<GetModDependencies.ResponseSchema>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					modDependencies = ResponseTranslator.ConvertModDependenciesObjectToModDependencies(resultAnd.value.data);
					ResponseCache.AddModDependenciesToCache(modId, modDependencies);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, modDependencies);
		}

		public static async void GetModDependencies(ModId modId, Action<ResultAnd<ModDependencies[]>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetModDependencies method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			ResultAnd<ModDependencies[]> obj = await GetModDependencies(modId);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<Rating[]>> GetCurrentUserRatings()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result = default(Result);
			Rating[] ratings = null;
			if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result) && !ResponseCache.GetCurrentUserRatingsCache(out ratings))
			{
				Task<ResultAnd<RatingObject[]>> task = ModCollectionManager.TryRequestAllResults<RatingObject>(ModIO.Implementation.API.Requests.GetCurrentUserRatings.Request().Url, ModIO.Implementation.API.Requests.GetCurrentUserRatings.Request);
				ResultAnd<RatingObject[]> resultAnd = await openCallbacks.Run(callbackConfirmation, task);
				result = resultAnd.result;
				if (result.Succeeded())
				{
					ratings = ResponseTranslator.ConvertModRatingsObjectToRatings(resultAnd.value);
					ResponseCache.ReplaceCurrentUserRatings(ratings);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, ratings);
		}

		public static async void GetCurrentUserRatings(Action<ResultAnd<Rating[]>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetCurrentUserRatings method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			ResultAnd<Rating[]> obj = await GetCurrentUserRatings();
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ModRating>> GetCurrentUserRatingFor(ModId modId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result = ResultBuilder.Unknown;
			ModRating rating = ModRating.None;
			if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				if (!ResponseCache.HaveRatingsBeenCachedThisSession())
				{
					Task<ResultAnd<Rating[]>> currentUserRatings = GetCurrentUserRatings();
					ResultAnd<Rating[]> resultAnd = await openCallbacks.Run(callbackConfirmation, currentUserRatings);
					if (!resultAnd.result.Succeeded())
					{
						result = resultAnd.result;
						goto IL_0102;
					}
				}
				if (ResponseCache.GetCurrentUserRatingFromCache(modId, out rating))
				{
					result = ResultBuilder.Success;
				}
			}
			goto IL_0102;
			IL_0102:
			callbackConfirmation.SetResult(result: true);
			openCallbacks.Remove(callbackConfirmation);
			return ResultAnd.Create(result, rating);
		}

		public static async void GetCurrentUserRatingFor(ModId modId, Action<ResultAnd<ModRating>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetCurrentUserRatingFor method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			ResultAnd<ModRating> obj = await GetCurrentUserRatingFor(modId);
			callback?.Invoke(obj);
		}

		public static Result EnableModManagement(ModManagementEventDelegate modManagementEventDelegate)
		{
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				ModManagement.modManagementEventDelegate = modManagementEventDelegate;
				ModManagement.EnableModManagement();
			}
			return result;
		}

		public static Result DisableModManagement()
		{
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				ModManagement.DisableModManagement();
				ModManagement.ShutdownOperations();
			}
			return result;
		}

		public static async Task<Result> FetchUpdates()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				result = await openCallbacks.Run(callbackConfirmation, ModCollectionManager.FetchUpdates());
				if (result.Succeeded())
				{
					ModManagement.WakeUp();
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task FetchUpdates(Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given for the FetchUpdates method. This is not recommended because you will not know if the fetch was successful.");
			}
			Result obj = await FetchUpdates();
			callback?.Invoke(obj);
		}

		public static bool IsModManagementBusy()
		{
			return ModManagement.GetCurrentOperationProgress() != null;
		}

		public static Result ForceUninstallMod(ModId modId)
		{
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				result = ModCollectionManager.MarkModForUninstallIfNotSubscribedToCurrentSession(modId);
				ModManagement.WakeUp();
			}
			return result;
		}

		public static ProgressHandle GetCurrentModManagementOperation()
		{
			return ModManagement.GetCurrentOperationProgress();
		}

		public static bool EnableMod(ModId modId)
		{
			if (!IsInitialized(out var _))
			{
				return false;
			}
			return ModCollectionManager.EnableModForCurrentUser(modId);
		}

		public static bool DisableMod(ModId modId)
		{
			if (!IsInitialized(out var _))
			{
				return false;
			}
			return ModCollectionManager.DisableModForCurrentUser(modId);
		}

		public static async void AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the AddDependenciesToMod method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await AddDependenciesToMod(modId, dependencies);
			callback?.Invoke(obj);
		}

		public static async Task<Result> AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result;
			if (dependencies.Count > 5)
			{
				result = ResultBuilder.Create(20215u);
				Logger.Log(LogLevel.Warning, "You can only change a maximum of 5 dependencies in a single request. If you need to add more than 5 dependencies consider doing it over multiple requests instead.");
			}
			else if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = AddDependency.Request(modId, dependencies);
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
				result.Succeeded();
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the RemoveDependenciesFromMod method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await RemoveDependenciesFromMod(modId, dependencies);
			callback?.Invoke(obj);
		}

		public static async Task<Result> RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result;
			if (dependencies.Count > 5)
			{
				result = ResultBuilder.Create(20215u);
				Logger.Log(LogLevel.Warning, "You can only change a maximum of 5 dependencies in a single request. If you need to remove more than 5 dependencies consider doing it over multiple requests instead.");
			}
			else if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = DeleteDependency.Request(modId, dependencies);
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
				result.Succeeded();
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task<Result> AddModRating(ModId modId, ModRating modRating)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.AddModRating.Request(modId, modRating);
				result = (await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<MessageObject>(config))).result;
				Rating rating = new Rating
				{
					dateAdded = DateTime.Now,
					rating = modRating,
					modId = modId
				};
				ResponseCache.AddCurrentUserRating(modId, rating);
				if (result.code_api == 15028 || result.code_api == 15043)
				{
					result = ResultBuilder.Success;
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void AddModRating(ModId modId, ModRating rating, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the AddModRating method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await AddModRating(modId, rating);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<UserProfile>> GetCurrentUser()
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			UserProfile userProfile = default(UserProfile);
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result) && !ResponseCache.GetUserProfileFromCache(out userProfile))
			{
				WebRequestConfig config = GetAuthenticatedUser.Request();
				ResultAnd<UserObject> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<UserObject>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					UserData.instance.SetUserObject(resultAnd.value);
					userProfile = ResponseTranslator.ConvertUserObjectToUserProfile(resultAnd.value);
					ResponseCache.AddUserToCache(userProfile);
				}
			}
			callbackConfirmation.SetResult(result: true);
			openCallbacks_dictionary.Remove(callbackConfirmation);
			return ResultAnd.Create(result, userProfile);
		}

		public static async Task GetCurrentUser(Action<ResultAnd<UserProfile>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetCurrentUser method, any response returned from the server wont be used. This operation  has been cancelled.");
			}
			else
			{
				callback(await GetCurrentUser());
			}
		}

		public static async Task<Result> UnsubscribeFrom(ModId modId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = UnsubscribeFromMod.Request(modId);
				result = (await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<MessageObject>(config)))?.result ?? new Result
				{
					code = 1u
				};
				bool flag = result.Succeeded() || result.code_api == 15005;
				if (flag)
				{
					result = ResultBuilder.Success;
					ModCollectionManager.RemoveModFromUserSubscriptions(modId, offline: false);
					if (ShouldAbortDueToDownloading(modId))
					{
						ModManagement.AbortCurrentDownloadJob();
					}
					else if (ShouldAbortDueToInstalling(modId))
					{
						ModManagement.AbortCurrentInstallJob();
					}
					ModManagement.WakeUp();
				}
				ModCollectionManager.RemoveModFromUserSubscriptions(modId, flag);
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		private static bool ShouldAbortDueToDownloading(ModId modId)
		{
			if (ModManagement.currentJob != null && ModManagement.currentJob.mod.modObject.id == (long)modId)
			{
				return ModManagement.currentJob.type == ModManagementOperationType.Download;
			}
			return false;
		}

		private static bool ShouldAbortDueToInstalling(ModId modId)
		{
			if (ModManagement.currentJob != null && ModManagement.currentJob.mod.modObject.id == (long)modId && ModManagement.currentJob.type == ModManagementOperationType.Install)
			{
				return ModManagement.currentJob.zipOperation != null;
			}
			return false;
		}

		public static async void UnsubscribeFrom(ModId modId, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the UnsubscribeFrom method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await UnsubscribeFrom(modId);
			callback?.Invoke(obj);
		}

		public static async Task<Result> SubscribeTo(ModId modId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = SubscribeToMod.Request(modId);
				ResultAnd<ModObject> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModObject>(config));
				result = resultAnd?.result ?? new Result
				{
					code = 1u
				};
				if (result.Succeeded())
				{
					ModCollectionManager.UpdateModCollectionEntry(modId, resultAnd.value);
					ModCollectionManager.AddModToUserSubscriptions(modId);
					ModManagement.WakeUp();
				}
				else if (result.code_api == 15004)
				{
					ModCollectionManager.AddModToUserSubscriptions(modId);
					WebRequestConfig config2 = ModIO.Implementation.API.Requests.GetMod.Request(modId);
					ResultAnd<ModObject> resultAnd2 = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModObject>(config2));
					if (resultAnd2.result.Succeeded())
					{
						ModCollectionManager.UpdateModCollectionEntry(modId, resultAnd2.value);
						ModManagement.WakeUp();
					}
					result = resultAnd2.result;
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void SubscribeTo(ModId modId, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the SubscribeTo method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await SubscribeTo(modId);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ModPage>> GetUserSubscriptions(SearchFilter filter)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModPage page = default(ModPage);
			if (IsInitialized(out var result) && IsSearchFilterValid(filter, out result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.GetUserSubscriptions.Request(filter);
				ResultAnd<GetUserSubscriptions.ResponseSchema> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<GetUserSubscriptions.ResponseSchema>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					page = ResponseTranslator.ConvertResponseSchemaToModPage(resultAnd.value, filter);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, page);
		}

		public static SubscribedMod[] GetSubscribedMods(out Result result)
		{
			if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				return ModCollectionManager.GetSubscribedModsForUser(out result);
			}
			return null;
		}

		public static InstalledMod[] GetInstalledMods(out Result result)
		{
			if (IsInitialized(out result))
			{
				return ModCollectionManager.GetInstalledMods(out result, excludeSubscribedModsForCurrentUser: true);
			}
			return null;
		}

		public static UserInstalledMod[] GetInstalledModsForUser(out Result result, bool includeDisabledMods)
		{
			if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				InstalledMod[] installedMods = ModCollectionManager.GetInstalledMods(out result, excludeSubscribedModsForCurrentUser: false);
				return FilterInstalledModsIntoUserInstalledMods(UserData.instance.userObject.id, includeDisabledMods, installedMods);
			}
			return null;
		}

		internal static UserInstalledMod[] FilterInstalledModsIntoUserInstalledMods(long userId, bool includeDisabledMods, params InstalledMod[] mods)
		{
			return (from x in mods
				select x.AsInstalledModsUser(userId) into x
				where !x.Equals(default(UserInstalledMod))
				where x.enabled || includeDisabledMods
				select x).ToArray();
		}

		public static Result RemoveUserData()
		{
			ModManagement.ShutdownOperations();
			DisableModManagement();
			ModCollectionManager.ClearUserData();
			UserData.instance?.ClearUser();
			ResponseCache.ClearUserFromCache();
			if (!ModCollectionManager.DoesUserExist(0L))
			{
				return ResultBuilder.Success;
			}
			return ResultBuilder.Create(20104u);
		}

		public static async void MuteUser(long userId, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the MuteUser method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await MuteUser(userId);
			callback?.Invoke(obj);
		}

		public static async void UnmuteUser(long userId, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the UnmuteUser method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await UnmuteUser(userId);
			callback?.Invoke(obj);
		}

		public static async Task<Result> MuteUser(long userId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = UserMute.Request(userId);
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task<Result> UnmuteUser(long userId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = UserUnmute.Request(userId);
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task<ResultAnd<Texture2D>> DownloadTexture(DownloadReference downloadReference)
		{
			Texture2D texture = null;
			ResultAnd<byte[]> resultAnd = await GetImage(downloadReference);
			Result result = resultAnd.result;
			if (result.Succeeded())
			{
				IOUtil.TryParseImageData(resultAnd.value, out texture, out result);
			}
			return ResultAnd.Create(result, texture);
		}

		public static async Task<ResultAnd<byte[]>> GetImage(DownloadReference downloadReference)
		{
			if (!downloadReference.IsValid())
			{
				Logger.Log(LogLevel.Warning, "The DownloadReference provided for the DownloadImage method was not valid. Consider using the DownloadReference.IsValid() method to check if theDownloadReference has an existing URL before using this method.");
				return ResultAnd.Create<byte[]>(20220u, null);
			}
			if (onGoingImageDownloads.ContainsKey(downloadReference.url))
			{
				Logger.Log(LogLevel.Verbose, "The image (" + downloadReference.filename + ") is already being download. Waiting for duplicate request's result.");
				return await onGoingImageDownloads[downloadReference.url];
			}
			Task<ResultAnd<byte[]>> task = DownloadImage(downloadReference);
			onGoingImageDownloads.Add(downloadReference.url, task);
			ResultAnd<byte[]> result = await task;
			onGoingImageDownloads.Remove(downloadReference.url);
			return result;
		}

		private static async Task<ResultAnd<byte[]>> DownloadImage(DownloadReference downloadReference)
		{
			TaskCompletionSource<bool> callbackConfirmation = new TaskCompletionSource<bool>();
			openCallbacks_dictionary.Add(callbackConfirmation, null);
			byte[] image = null;
			if (IsInitialized(out var result))
			{
				Task<ResultAnd<byte[]>> imageFromCache = ResponseCache.GetImageFromCache(downloadReference);
				openCallbacks_dictionary[callbackConfirmation] = imageFromCache;
				ResultAnd<byte[]> resultAnd = await imageFromCache;
				openCallbacks_dictionary[callbackConfirmation] = null;
				result = resultAnd.result;
				if (result.Succeeded())
				{
					result = resultAnd.result;
					image = resultAnd.value;
				}
				else
				{
					ResultAnd<ModIOFileStream> imageFileWriteStream = DataStorage.GetImageFileWriteStream(downloadReference.url);
					result = imageFileWriteStream.result;
					if (result.Succeeded())
					{
						using (imageFileWriteStream.value)
						{
							result = await WebRequestManager.Download(downloadReference.url, imageFileWriteStream.value, null).task;
						}
						if (result.Succeeded())
						{
							ResultAnd<ModIOFileStream> imageFileReadStream = DataStorage.GetImageFileReadStream(downloadReference.url);
							result = imageFileReadStream.result;
							if (result.Succeeded())
							{
								using (imageFileReadStream.value)
								{
									ResultAnd<byte[]> resultAnd2 = await imageFileReadStream.value.ReadAllBytesAsync();
									result = resultAnd2.result;
									if (result.Succeeded())
									{
										image = resultAnd2.value;
									}
								}
							}
						}
						if (!result.Succeeded() && !DataStorage.DeleteStoredImage(downloadReference.url).Succeeded())
						{
							Logger.Log(LogLevel.Error, "[Internal] Failed to cleanup downloaded image. This may result in a corrupt or invalid image being" + $" loaded for modId {downloadReference.modId}");
						}
					}
				}
			}
			callbackConfirmation.SetResult(result: true);
			openCallbacks_dictionary.Remove(callbackConfirmation);
			return ResultAnd.Create(result, image);
		}

		public static async void DownloadTexture(DownloadReference downloadReference, Action<ResultAnd<Texture2D>> callback)
		{
			Result result;
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the DownloadTexture method. This operation has been cancelled.");
			}
			else if (!IsInitialized(out result))
			{
				ResultAnd<Texture2D> obj = ResultAnd.Create<Texture2D>(result, null);
				callback?.Invoke(obj);
			}
			else
			{
				ResultAnd<Texture2D> obj2 = await DownloadTexture(downloadReference);
				callback?.Invoke(obj2);
			}
		}

		public static async void DownloadImage(DownloadReference downloadReference, Action<ResultAnd<byte[]>> callback)
		{
			Result result;
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the DownloadImage method. This operation has been cancelled.");
			}
			else if (!IsInitialized(out result))
			{
				ResultAnd<byte[]> obj = ResultAnd.Create<byte[]>(result, null);
				callback?.Invoke(obj);
			}
			else
			{
				ResultAnd<byte[]> obj2 = await GetImage(downloadReference);
				callback?.Invoke(obj2);
			}
		}

		public static async Task<Result> Report(Report report)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result = ResultBuilder.Unknown;
			if (report == null || !report.CanSend())
			{
				Logger.Log(LogLevel.Error, "The Report instance provided to the Reporting method is not setup correctly and cannot be sent as a valid report to mod.io");
				result = ((report == null) ? ResultBuilder.Create(20213u) : ResultBuilder.Create(20202u));
			}
			else if (IsInitialized(out result))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.Report.Request(report);
				result = (await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<MessageObject>(config))).result;
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void Report(Report report, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the Report method. It is possible that this operation will not resolve successfully and should be checked with a proper callback.");
			}
			Result obj = await Report(report);
			callback?.Invoke(obj);
		}

		public static CreationToken GenerateCreationToken()
		{
			return ModManagement.GenerateNewCreationToken();
		}

		public static async Task<ResultAnd<ModId>> CreateModProfile(CreationToken token, ModProfileDetails modDetails)
		{
			if (Settings.server.disableUploads)
			{
				Logger.Log(LogLevel.Error, "The current plugin configuration has uploading disabled.");
				return ResultAnd.Create(ResultBuilder.Create(20054u), ModId.Null);
			}
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModId modId = (ModId)0L;
			Result result;
			if (!ModManagement.IsCreationTokenValid(token))
			{
				Logger.Log(LogLevel.Error, "The provided CreationToken is not valid and cannot be used to create a new mod profile. Be sure to use GenerateCreationToken() before attempting to create a new Mod Profile");
				result = ResultBuilder.Create(20204u);
			}
			else if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result) && IsModProfileDetailsValid(modDetails, out result))
			{
				WebRequestConfig config = AddMod.Request(modDetails);
				ResultAnd<ModObject> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModObject>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					modId = (ModId)resultAnd.value.id;
					ModManagement.InvalidateCreationToken(token);
					ResponseCache.ClearCache();
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, modId);
		}

		public static async void CreateModProfile(CreationToken token, ModProfileDetails modDetails, Action<ResultAnd<ModId>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Error, "No callback was given to the CreateModProfile method. You needto retain the ModId returned by the callback in order to further apply changesor edits to the newly created mod profile. The operation has been cancelled.");
				return;
			}
			ResultAnd<ModId> obj = await CreateModProfile(token, modDetails);
			callback?.Invoke(obj);
		}

		public static async Task<Result> EditModProfile(ModProfileDetails modDetails)
		{
			if (Settings.server.disableUploads)
			{
				Logger.Log(LogLevel.Error, "The current plugin configuration has uploading disabled.");
				return ResultBuilder.Create(20054u);
			}
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result;
			if (modDetails == null)
			{
				Logger.Log(LogLevel.Error, "The ModProfileDetails provided is null. You cannot update a mod without providing a valid ModProfileDetails object.");
				result = ResultBuilder.Create(20213u);
			}
			else if (!modDetails.modId.HasValue)
			{
				Logger.Log(LogLevel.Error, "The provided ModProfileDetails has not been assigned a ModId. Ensure you assign the Id of the mod you intend to edit to the ModProfileDetails.modId field.");
				result = ResultBuilder.Create(20210u);
			}
			else if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result) && IsModProfileDetailsValidForEdit(modDetails, out result))
			{
				if (modDetails.tags != null && modDetails.tags.Length != 0)
				{
					Logger.Log(LogLevel.Warning, "The EditMod method cannot be used to change a ModProfile's tags. Use the ModIOUnity.AddTags and ModIOUnity.DeleteTags methods instead. The 'tags' array in the ModProfileDetails will be ignored.");
				}
				WebRequestConfig config = ((modDetails.logo != null) ? EditMod.RequestPOST(modDetails) : EditMod.RequestPUT(modDetails));
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
				result.Succeeded();
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void EditModProfile(ModProfileDetails modDetails, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the EditModProfile method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			Result obj = await EditModProfile(modDetails);
			callback?.Invoke(obj);
		}

		public static async void DeleteTags(ModId modId, string[] tags, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the DeleteTags method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			Result obj = await DeleteTags(modId, tags);
			callback?.Invoke(obj);
		}

		public static async Task<Result> DeleteTags(ModId modId, string[] tags)
		{
			if (Settings.server.disableUploads)
			{
				Logger.Log(LogLevel.Error, "The current plugin configuration has uploading disabled.");
				return ResultBuilder.Create(20054u);
			}
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result;
			if ((long)modId == 0L)
			{
				Logger.Log(LogLevel.Error, "You must provide a valid mod id to delete tags.");
				result = ResultBuilder.Create(20214u);
			}
			else if (tags == null || tags.Length == 0)
			{
				Logger.Log(LogLevel.Error, "You must provide tags to be deleted from the mod");
				result = ResultBuilder.Create(20213u);
			}
			else if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = DeleteModTags.Request(modId, tags);
				result = (await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<MessageObject>(config))).result;
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task<ResultAnd<ModComment>> AddModComment(ModId modId, CommentDetails commentDetails)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModComment value = default(ModComment);
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.AddModComment.Request(modId, commentDetails);
				ResultAnd<ModCommentObject> obj = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModCommentObject>(config));
				result = obj.result;
				value = ResponseTranslator.ConvertModCommentObjectsToModComment(obj.value);
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, value);
		}

		public static async void AddModComment(ModId modId, CommentDetails commentDetails, Action<ResultAnd<ModComment>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the AddModComment method, any response returned from the server wont be used. This operation  has been cancelled.");
				return;
			}
			ResultAnd<ModComment> obj = await AddModComment(modId, commentDetails);
			callback?.Invoke(obj);
		}

		public static async Task<ResultAnd<ModComment>> UpdateModComment(ModId modId, string content, long commentId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModComment value = default(ModComment);
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.UpdateModComment.Request(modId, content, commentId);
				ResultAnd<ModCommentObject> obj = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModCommentObject>(config));
				result = obj.result;
				value = ResponseTranslator.ConvertModCommentObjectsToModComment(obj.value);
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, value);
		}

		public static async void UpdateModComment(ModId modId, string content, long commentId, Action<ResultAnd<ModComment>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the UpdateModComment method, any response returned from the server wont be used. This operation  has been cancelled.");
				return;
			}
			ResultAnd<ModComment> obj = await UpdateModComment(modId, content, commentId);
			callback?.Invoke(obj);
		}

		public static async Task<Result> DeleteModComment(ModId modId, long commentId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = ModIO.Implementation.API.Requests.DeleteModComment.Request(modId, commentId);
				result = (await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<ModCommentObject>(config))).result;
				if (result.Succeeded())
				{
					ResponseCache.RemoveModCommentFromCache(commentId);
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void DeleteModComment(ModId modId, long commentId, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the DeleteModComment method, any response returned from the server wont be used. This operation  has been cancelled.");
				return;
			}
			Result obj = await DeleteModComment(modId, commentId);
			callback?.Invoke(obj);
		}

		public static async void AddTags(ModId modId, string[] tags, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the AddTags method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			Result obj = await AddTags(modId, tags);
			callback?.Invoke(obj);
		}

		public static async Task<Result> AddTags(ModId modId, string[] tags)
		{
			if (Settings.server.disableUploads)
			{
				Logger.Log(LogLevel.Error, "The current plugin configuration has uploading disabled.");
				return ResultBuilder.Create(20054u);
			}
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			Result result;
			if ((long)modId == 0L)
			{
				Logger.Log(LogLevel.Error, "You must provide a valid mod id to add tags.");
				result = ResultBuilder.Create(20214u);
			}
			else if (tags == null || tags.Length == 0)
			{
				Logger.Log(LogLevel.Error, "You must provide tags to be added to the mod");
				result = ResultBuilder.Create(20213u);
			}
			else if (IsInitialized(out result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = AddModTags.Request(modId, tags);
				result = (await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<MessageObject>(config))).result;
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static ProgressHandle GetCurrentUploadHandle()
		{
			return currentUploadHandle;
		}

		public static async Task<Result> UploadModMedia(ModProfileDetails modProfileDetails)
		{
			if (modProfileDetails == null)
			{
				Logger.Log(LogLevel.Error, "ModfileDetails parameter cannot be null.");
				return ResultBuilder.Create(20213u);
			}
			if (!modProfileDetails.modId.HasValue)
			{
				Logger.Log(LogLevel.Error, "The provided ModfileDetails has not been assigned a ModId. Ensure you assign the Id of the mod you intend to edit to the ModProfileDetails.modId field.");
				return ResultBuilder.Create(20214u);
			}
			if (Settings.server.disableUploads)
			{
				Logger.Log(LogLevel.Error, "The current plugin configuration has uploading disabled.");
				return ResultBuilder.Create(20054u);
			}
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result) && IsModProfileDetailsValidForEdit(modProfileDetails, out result))
			{
				ResultAnd<WebRequestConfig> resultAnd = await AddModMedia.Request(modProfileDetails);
				result = resultAnd.result;
				if (result.Succeeded())
				{
					Task<ResultAnd<ModMediaObject>> task = WebRequestManager.Request<ModMediaObject>(resultAnd.value);
					result = (await openCallbacks.Run(callbackConfirmation, task)).result;
					if (!result.Succeeded())
					{
						currentUploadHandle.Failed = true;
					}
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async Task<Result> UploadModfile(ModfileDetails modfile)
		{
			if (modfile == null)
			{
				Logger.Log(LogLevel.Error, "ModfileDetails parameter cannot be null.");
				return ResultBuilder.Create(20213u);
			}
			if (!modfile.modId.HasValue)
			{
				Logger.Log(LogLevel.Error, "The provided ModfileDetails has not been assigned a ModId. Ensure you assign the Id of the mod you intend to edit to the ModProfileDetails.modId field.");
				return ResultBuilder.Create(20214u);
			}
			if (Settings.server.disableUploads)
			{
				Logger.Log(LogLevel.Error, "The current plugin configuration has uploading disabled.");
				return ResultBuilder.Create(20054u);
			}
			currentUploadHandle = new ProgressHandle();
			currentUploadHandle.OperationType = ModManagementOperationType.Upload;
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result) && IsModfileDetailsValid(modfile, out result))
			{
				Task<ResultAnd<MemoryStream>> task = new CompressOperationDirectory(modfile.directory).Compress();
				ResultAnd<MemoryStream> resultAnd = await openCallbacks.Run(callbackConfirmation, task);
				result = resultAnd.result;
				if (!result.Succeeded())
				{
					currentUploadHandle.Failed = true;
					Logger.Log(LogLevel.Error, "Failed to compress the files at the given directory (" + modfile.directory + ").");
				}
				else
				{
					Logger.Log(LogLevel.Verbose, "Compressed file (" + modfile.directory + ")" + $"\nstream length: {resultAnd.value.Length}");
					callbackConfirmation = openCallbacks.New();
					Task<ResultAnd<ModfileObject>> task2 = WebRequestManager.Request<ModfileObject>(await AddModFile.Request(modfile, resultAnd.value), currentUploadHandle);
					ResultAnd<ModfileObject> resultAnd2 = await openCallbacks.Run(callbackConfirmation, task2);
					result = resultAnd2.result;
					if (!result.Succeeded())
					{
						currentUploadHandle.Failed = true;
					}
					else
					{
						ResponseCache.ClearCache();
						Logger.Log(LogLevel.Verbose, $"UPLOAD SUCCEEDED [{modfile.modId}_{resultAnd2.value.id}]");
					}
				}
			}
			currentUploadHandle.Completed = true;
			currentUploadHandle = null;
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void UploadModMedia(ModProfileDetails modProfileDetails, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the UploadModMedia method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			Result obj = await UploadModMedia(modProfileDetails);
			callback?.Invoke(obj);
		}

		public static async void UploadModfile(ModfileDetails modfile, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the UploadModfile method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			Result obj = await UploadModfile(modfile);
			callback?.Invoke(obj);
		}

		public static async Task<Result> ArchiveModProfile(ModId modId)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			if (IsInitialized(out var result) && IsAuthenticatedSessionValid(out result))
			{
				WebRequestConfig config = DeleteMod.Request(modId);
				result = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request(config));
			}
			openCallbacks.Complete(callbackConfirmation);
			return result;
		}

		public static async void ArchiveModProfile(ModId modId, Action<Result> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the ArchiveModProfile method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			Result obj = await ArchiveModProfile(modId);
			callback?.Invoke(obj);
		}

		private static bool IsModfileDetailsValid(ModfileDetails modfile, out Result result)
		{
			if (!DataStorage.TryGetModfileDetailsDirectory(modfile.directory, out var _))
			{
				Logger.Log(LogLevel.Error, "The provided directory in ModfileDetails could not be found or does not exist (" + modfile.directory + ").");
				result = ResultBuilder.Create(20420u);
				return false;
			}
			string metadata = modfile.metadata;
			if (metadata != null && metadata.Length > 50000)
			{
				Logger.Log(LogLevel.Error, "The provided metadata in ModProfileDetails exceeds 50,000 characters" + $"\n(Was given {modfile.metadata.Length} characters)");
				result = ResultBuilder.Create(20203u);
				return false;
			}
			string changelog = modfile.changelog;
			if (changelog != null && changelog.Length > 50000)
			{
				Logger.Log(LogLevel.Error, "The provided changelog in ModProfileDetails exceeds 50,000 characters(Was given " + modfile.changelog + ")");
				result = ResultBuilder.Create(20206u);
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}

		private static bool IsModProfileDetailsValid(ModProfileDetails modDetails, out Result result)
		{
			if (modDetails.logo == null || string.IsNullOrWhiteSpace(modDetails.summary) || string.IsNullOrWhiteSpace(modDetails.name))
			{
				Logger.Log(LogLevel.Error, "The required fields in ModProfileDetails have not been set. Make sure the Name, Logo and Summary have been assigned before attemptingto submit a new Mod Profile");
				result = ResultBuilder.Create(20210u);
				return false;
			}
			return IsModProfileDetailsValidForEdit(modDetails, out result);
		}

		private static bool IsModProfileDetailsValidForEdit(ModProfileDetails modDetails, out Result result)
		{
			string summary = modDetails.summary;
			if (summary != null && summary.Length > 250)
			{
				Logger.Log(LogLevel.Error, "The provided summary in ModProfileDetails exceeds 250 characters");
				result = ResultBuilder.Create(20211u);
				return false;
			}
			if (modDetails.logo != null && modDetails.logo.EncodeToPNG().Length > 8388608)
			{
				Logger.Log(LogLevel.Error, "The provided logo in ModProfileDetails exceeds 8 megabytes");
				result = ResultBuilder.Create(20212u);
				return false;
			}
			string metadata = modDetails.metadata;
			if (metadata != null && metadata.Length > 50000)
			{
				Logger.Log(LogLevel.Error, "The provided metadata in ModProfileDetails exceeds 50,000 characters" + $"(Was given {modDetails.metadata.Length})");
				result = ResultBuilder.Create(20203u);
				return false;
			}
			string description = modDetails.description;
			if (description != null && description.Length > 50000)
			{
				Logger.Log(LogLevel.Error, "The provided description in ModProfileDetails exceeds 50,000 characters" + $"(Was given {modDetails.description.Length})");
				result = ResultBuilder.Create(20205u);
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}

		public static async Task<ResultAnd<ModPage>> GetCurrentUserCreations(SearchFilter filter)
		{
			TaskCompletionSource<bool> callbackConfirmation = openCallbacks.New();
			ModPage page = default(ModPage);
			WebRequestConfig config = ModIO.Implementation.API.Requests.GetCurrentUserCreations.Request(filter);
			int offset = filter.pageIndex * filter.pageSize;
			if (IsInitialized(out var result) && IsSearchFilterValid(filter, out result) && IsAuthenticatedSessionValid(out result) && !ResponseCache.GetModsFromCache(config.Url, offset, filter.pageSize, out page))
			{
				ResultAnd<GetCurrentUserCreations.ResponseSchema> resultAnd = await openCallbacks.Run(callbackConfirmation, WebRequestManager.Request<GetCurrentUserCreations.ResponseSchema>(config));
				result = resultAnd.result;
				if (result.Succeeded())
				{
					page = ResponseTranslator.ConvertResponseSchemaToModPage(resultAnd.value, filter);
					ResponseCache.AddModsToCache(config.Url, offset, page);
					if (page.modProfiles.Length > filter.pageSize)
					{
						Array.Copy(page.modProfiles, page.modProfiles, filter.pageSize);
					}
				}
			}
			openCallbacks.Complete(callbackConfirmation);
			return ResultAnd.Create(result, page);
		}

		public static async void GetCurrentUserCreations(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
			if (callback == null)
			{
				Logger.Log(LogLevel.Warning, "No callback was given to the GetCurrentUserCreations method. You will not be informed of the result for this action. It is highly recommended to provide a valid callback.");
			}
			ResultAnd<ModPage> obj = await GetCurrentUserCreations(filter);
			callback?.Invoke(obj);
		}
	}
}
