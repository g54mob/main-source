using System;
using System.Collections;
using Factory;
using UnityEngine;
using UnityEngine.Networking;

public class SteamworksCloudSyncService : ISteamCloudSyncService
{
	public class CoroutineHost : MonoBehaviour
	{
	}

	[Dependency]
	private IOAuthClient _oauthClient;

	[Dependency]
	private StorableTypeHandlerRegistry _storableTypeHandlerRegistry;

	[Dependency]
	private IScope _scope;

	private CoroutineHost _coroutineHost;

	private const float AccessTokenFetchPeriod = 3f;

	private const string ClientId = "F2FBD1F7";

	private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("SteamworksCloudSync");

	public bool IsSupported
	{
		get
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.SteamCrossSave))
			{
				return true;
			}
			return false;
		}
	}

	public AsyncRequestHandle Authenticate(SteamCloudAuthenticationCompleted authenticationCompleted)
	{
		Guid authenticationGuid = Guid.NewGuid();
		string text = string.Format("https://steamcommunity.com/oauth/login?response_type=token&client_id={0}&state={1}&mobileminimal=1", "F2FBD1F7", authenticationGuid);
		string callbackUrl = "https://api.dinopoloclub.com/1/minimotorways/steam/authorized/";
		AsyncRequestHandle requestHandle = new AsyncRequestHandle();
		Log.Info("Opening Steam OAuth page for the player at {0}.", text);
		_oauthClient.RequestAuthorization(text, callbackUrl, delegate(OAuthAuthorizationResult authorizationResult)
		{
			if (requestHandle.IsActive)
			{
				switch (authorizationResult)
				{
				case OAuthAuthorizationResult.NoConnection:
					authenticationCompleted(null, SteamCloudSyncError.NoConnection);
					break;
				case OAuthAuthorizationResult.Unavailable:
					authenticationCompleted(null, SteamCloudSyncError.NotSupported);
					break;
				case OAuthAuthorizationResult.Denied:
					authenticationCompleted(null, SteamCloudSyncError.AuthorizationDenied);
					break;
				default:
					StartCoroutine(FetchAccessTokenCoroutine(requestHandle, authenticationGuid, authenticationCompleted));
					break;
				}
			}
		});
		return requestHandle;
	}

	public AsyncRequestHandle DownloadProfiles(string accessToken, SteamCloudProfileDownloadCompleted downloadCompleted)
	{
		AsyncRequestHandle asyncRequestHandle = new AsyncRequestHandle();
		StartCoroutine(DownloadProfilesCoroutine(asyncRequestHandle, accessToken, downloadCompleted));
		return asyncRequestHandle;
	}

	private IEnumerator FetchAccessTokenCoroutine(AsyncRequestHandle requestHandle, Guid guid, SteamCloudAuthenticationCompleted authenticationCompleted)
	{
		while (requestHandle.IsActive)
		{
			string text = $"https://api.dinopoloclub.com/1/minimotorways/steam/token/{guid}/";
			Log.Info("Looking up access token at {0}.", text);
			UnityWebRequest accessTokenRequest = UnityWebRequest.Get(text);
			yield return accessTokenRequest.SendWebRequest();
			if (!requestHandle.IsActive)
			{
				break;
			}
			if (accessTokenRequest.result == UnityWebRequest.Result.Success)
			{
				Log.Info("Access token request returned:\n{0}", accessTokenRequest.downloadHandler.text);
				if (JSON.LoadFromString(accessTokenRequest.downloadHandler.text) is JSON.Dictionary dictionary)
				{
					if (dictionary.GetString("result") == "ok")
					{
						string text2 = dictionary.GetString("accessToken");
						string value = dictionary.GetString("steamId");
						if (!string.IsNullOrEmpty(dictionary.GetString("error")))
						{
							authenticationCompleted(null, SteamCloudSyncError.AuthorizationDenied);
							break;
						}
						if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(value))
						{
							authenticationCompleted(text2, SteamCloudSyncError.None);
							break;
						}
					}
				}
				else
				{
					Log.Warn("Failed to parse response as JSON.");
				}
			}
			else
			{
				Log.Warn("Access token request error: {0}.", accessTokenRequest.error);
			}
			yield return new WaitForSeconds(3f);
		}
	}

	private IEnumerator DownloadProfilesCoroutine(AsyncRequestHandle requestHandle, string accessToken, SteamCloudProfileDownloadCompleted downloadCompleted)
	{
		SteamCloudSyncError error = SteamCloudSyncError.None;
		ILegacyUserProfile steamUserProfile = null;
		IExtendedUserProfile steamExtendedUserProfile = null;
		string text = "https://api.steampowered.com/ICloudService/EnumerateUserFiles/v1/?access_token=" + accessToken + "&appid=1127500&extended_details=1";
		Log.Info("Querying Steam Cloud files for the player from {0}.", text);
		UnityWebRequest cloudFileEnumerationRequest = UnityWebRequest.Get(text);
		yield return cloudFileEnumerationRequest.SendWebRequest();
		if (!requestHandle.IsActive)
		{
			yield break;
		}
		if (cloudFileEnumerationRequest.result == UnityWebRequest.Result.Success)
		{
			Log.Info("Cloud file query returned:\n{0}", cloudFileEnumerationRequest.downloadHandler.text);
			if (JSON.LoadFromString(cloudFileEnumerationRequest.downloadHandler.text) is JSON.Dictionary dictionary)
			{
				JSON.Dictionary dictionary2 = dictionary.GetDictionary("response");
				if (dictionary2 != null)
				{
					JSON.Array jsonFiles = dictionary2.GetArray("files");
					if (jsonFiles != null && jsonFiles.Count > 0)
					{
						int fileIndex = 0;
						while (fileIndex < jsonFiles.Count)
						{
							JSON.Dictionary dictionary3 = jsonFiles.GetDictionary(fileIndex);
							if (dictionary3 != null)
							{
								string filename = dictionary3.GetString("filename");
								string text2 = dictionary3.GetString("url");
								if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(text2))
								{
									Log.Warn("Skipping unexpected 'files' entry with no filename or url.");
								}
								else
								{
									string playerId;
									string deviceId;
									IStorableTypeHandler storableTypeHandler = _storableTypeHandlerRegistry.GetHandlerForFilename(filename, out playerId, out deviceId);
									if (storableTypeHandler is UserProfileStorableTypeHandler || storableTypeHandler is ExtendedUserProfileStorableTypeHandler)
									{
										Log.Info("Attempting to download cloud file {0}.", filename);
										UnityWebRequest fileDownloadRequest = UnityWebRequest.Get(text2);
										yield return fileDownloadRequest.SendWebRequest();
										if (!requestHandle.IsActive)
										{
											yield break;
										}
										if (fileDownloadRequest.result == UnityWebRequest.Result.Success)
										{
											IStorable storable = storableTypeHandler.Load(fileDownloadRequest.downloadHandler.data);
											if (!(storable is ILegacyUserProfile legacyUserProfile))
											{
												if (storable is IExtendedUserProfile extendedUserProfile)
												{
													Log.Info("Downloaded {0} as an extended user profile.", filename);
													if (steamExtendedUserProfile == null)
													{
														steamExtendedUserProfile = extendedUserProfile;
													}
													else
													{
														steamExtendedUserProfile.Merge(extendedUserProfile, autosave: false);
														_scope.Release(extendedUserProfile);
													}
												}
												else
												{
													error = SteamCloudSyncError.InvalidData;
													Log.Warn("Skipping unknown storable {0}.", storable);
													if (storable != null)
													{
														_scope.Release(storable);
													}
												}
											}
											else
											{
												Log.Info("Downloaded {0} as a legacy user profile.", filename);
												if (steamUserProfile == null)
												{
													steamUserProfile = legacyUserProfile;
												}
												else
												{
													steamUserProfile.Merge(legacyUserProfile, autosave: false);
													_scope.Release(legacyUserProfile);
												}
											}
										}
										else
										{
											error = SteamCloudSyncError.InvalidData;
											Log.Warn("Failed to download file! {0}.", fileDownloadRequest.error);
										}
									}
									else
									{
										Log.Info("Skipping file {0} because it is either unknown or can't be synced.", filename);
									}
								}
							}
							int num = fileIndex + 1;
							fileIndex = num;
						}
					}
					else
					{
						Log.Info("No relevant files were found.");
					}
				}
				else
				{
					Log.Warn("Didn't find expected response.");
					error = SteamCloudSyncError.InvalidResponse;
				}
			}
			else
			{
				Log.Warn("Unable to parse result as JSON.");
				error = SteamCloudSyncError.InvalidResponse;
			}
		}
		else
		{
			Log.Warn("File enumeration request error: {0}.", cloudFileEnumerationRequest.error);
			error = SteamCloudSyncError.InvalidResponse;
		}
		if (error == SteamCloudSyncError.InvalidData && (steamUserProfile != null || steamExtendedUserProfile != null))
		{
			error = SteamCloudSyncError.None;
		}
		downloadCompleted(steamUserProfile, steamExtendedUserProfile, error);
	}

	private void StartCoroutine(IEnumerator routine)
	{
		if (_coroutineHost == null)
		{
			GameObject gameObject = new GameObject();
			_coroutineHost = gameObject.AddComponent<CoroutineHost>();
		}
		_coroutineHost.StartCoroutine(routine);
	}
}
