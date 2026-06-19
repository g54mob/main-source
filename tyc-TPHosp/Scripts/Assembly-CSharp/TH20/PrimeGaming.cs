#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FullSerializer;
using TH20.Analytics;
using TMPro;
using UnityConsole;
using UnityEngine;
using UnityEngine.Networking;

namespace TH20
{
	public class PrimeGaming : MustCallDestroy
	{
		private const string AuthorizationEndpoint = "https://api.amazon.com/auth/o2/create/codepair";

		private const string TokenEndpoint = "https://api.amazon.com/auth/o2/token";

		private const string ProfileEndpoint = "https://api.amazon.com/user/profile";

		private const string EntitlementEndpoint = "https://twitch.amazon.com/api/entitlements";

		private const string FulfillEndpoint = "https://twitch.amazon.com/api/fulfill";

		private const string ClientID = "amzn1.application-oa2-client.e0f335aac5794d3d89e157c62c492085";

		private const string PendingMessage = "authorization_pending";

		private const string EntitlementsHeader = "\"Entitlements\":";

		private const string FulfillmentsHeader = "\"FulfillmentStatusUpdates\":";

		private const string EmptyContainer = "{[]}";

		private static readonly char[] CharsToTrim = new char[6] { ' ', '"', '{', '}', '[', ']' };

		private static readonly string[] _dropIDsWithKudosh = new string[4] { "201", "501", "801", "1101" };

		private static readonly int _standardKudoshAward = 1000;

		private static readonly int _retryMax = 3;

		private readonly App _app;

		private DeviceTokenResponse _deviceTokenResponse;

		private RequestCodeResponse _requestCodeResponse;

		private ProfileResponse _profileResponse;

		private bool _tokenRequestInProgress;

		private bool _tokenRequestConcluded;

		private List<EntitlementResponse> _entitlementsToFulfill;

		private List<string> _debugEntitlementsToAdd;

		private int _retryCount;

		public string[] DropIDsWithKudosh => _dropIDsWithKudosh;

		public int StandardKudoshAward => _standardKudoshAward;

		public bool LoggedInWithPrime
		{
			get
			{
				DeviceTokenResponse deviceTokenResponse = _deviceTokenResponse;
				if (deviceTokenResponse == null)
				{
					return false;
				}
				return !deviceTokenResponse.AccessToken.IsNullOrEmpty();
			}
		}

		public PrimeGaming(App app)
		{
			_app = app;
		}

		public void RefreshEntitlements()
		{
			if (_app.UserProfile.PrimeGamingRefreshToken != null)
			{
				GetNewAccessToken();
			}
		}

		public void LoginWithPrime(TMP_Text linkField, TMP_Text codeField, Action<string> callbackSuccess, Action callbackFailure)
		{
			Dictionary<string, string> formFields = new Dictionary<string, string>
			{
				{ "response_type", "device_code" },
				{ "client_id", "amzn1.application-oa2-client.e0f335aac5794d3d89e157c62c492085" },
				{ "scope", "games::prime profile" }
			};
			OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(PostRequest("https://api.amazon.com/auth/o2/create/codepair", formFields, isPollForToken: false, delegate(string response)
			{
				_requestCodeResponse = new RequestCodeResponse(ParseResponse(response));
				linkField.text = _requestCodeResponse.VerificationURL;
				codeField.text = _requestCodeResponse.UserCode;
				_tokenRequestConcluded = false;
				OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(PollForCodeAccepted("https://api.amazon.com/auth/o2/token", _requestCodeResponse.ExpiryTime, _requestCodeResponse.Interval, callbackSuccess, callbackFailure));
			}, callbackFailure));
		}

		private IEnumerator PollForCodeAccepted(string url, int timeout, int interval, Action<string> callbackSuccess, Action callbackFailure)
		{
			float pollTimer = 0f;
			float overallTimer = 0f;
			Dictionary<string, string> tokenFields = new Dictionary<string, string>
			{
				{ "user_code", _requestCodeResponse.UserCode },
				{ "device_code", _requestCodeResponse.DeviceCode },
				{ "grant_type", "device_code" }
			};
			while (!_tokenRequestConcluded)
			{
				pollTimer += Time.unscaledDeltaTime;
				overallTimer += Time.unscaledDeltaTime;
				if (overallTimer > (float)timeout)
				{
					callbackFailure();
					break;
				}
				if (pollTimer > (float)interval && !_tokenRequestInProgress)
				{
					OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(PostRequest(url, tokenFields, isPollForToken: true, delegate(string response)
					{
						callbackSuccess(response);
						_tokenRequestConcluded = true;
						_deviceTokenResponse = new DeviceTokenResponse(ParseResponse(response));
						_app.UserProfile.PrimeGamingRefreshToken = _deviceTokenResponse.RefreshToken;
						GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.PrimeLogin).AddParam("PrimeLoginSucceeded", "true");
						_app.AnalyticsManager.RecordEvent(gameEvent);
					}, delegate
					{
						callbackFailure();
						_tokenRequestConcluded = true;
					}));
					pollTimer = 0f;
				}
				yield return null;
			}
		}

		private void GetNewAccessToken()
		{
			Dictionary<string, string> formFields = new Dictionary<string, string>
			{
				{ "grant_type", "refresh_token" },
				{
					"refresh_token",
					_app.UserProfile.PrimeGamingRefreshToken
				},
				{ "client_id", "amzn1.application-oa2-client.e0f335aac5794d3d89e157c62c492085" }
			};
			OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(PostRequest("https://api.amazon.com/auth/o2/token", formFields, isPollForToken: false, delegate(string response)
			{
				_deviceTokenResponse = new DeviceTokenResponse(ParseResponse(response));
				_app.UserProfile.PrimeGamingRefreshToken = _deviceTokenResponse.RefreshToken;
				UpdateEntitlements();
			}, null));
		}

		private void GetProfileInformation(Action failureCallback)
		{
			OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetRequest("https://api.amazon.com/user/profile", "access_token", _deviceTokenResponse.AccessToken, delegate(string response)
			{
				_profileResponse = new ProfileResponse(ParseResponse(response));
			}, failureCallback));
		}

		private void UpdateEntitlements()
		{
			OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetRequest("https://twitch.amazon.com/api/entitlements", "x-amz-access-token", _deviceTokenResponse.AccessToken, delegate(string entitlementResponse)
			{
				List<string> list = ParseContainerResponse(entitlementResponse);
				_entitlementsToFulfill = new List<EntitlementResponse>();
				foreach (string item in list)
				{
					EntitlementResponse entitlementResponse2 = new EntitlementResponse(ParseResponse(item));
					if (!(entitlementResponse2.NextInstruction == "NOOP") && entitlementResponse2.NextInstruction == "FULFILL")
					{
						_entitlementsToFulfill.Add(entitlementResponse2);
					}
				}
				if (_entitlementsToFulfill.Count > 0)
				{
					_retryCount = 0;
					FulfillNewEntitlements(_entitlementsToFulfill);
				}
			}, null));
		}

		private void FulfillNewEntitlements(List<EntitlementResponse> entitlementsToFulfill)
		{
			List<FulfillmentData> list = new List<FulfillmentData>();
			bool shouldRetry = false;
			foreach (EntitlementResponse item in entitlementsToFulfill)
			{
				list.Add(new FulfillmentData(item.EntitlementId));
			}
			Dictionary<string, string> formHeaders = new Dictionary<string, string>
			{
				{ "Content-Type", "application/json" },
				{ "x-amz-access-token", _deviceTokenResponse.AccessToken }
			};
			OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(PostRequestAsJSON("https://twitch.amazon.com/api/fulfill", formHeaders, CreateFulfillmentJSON(list), delegate(string rawFulfillmentResponse)
			{
				List<string> list2 = ParseContainerResponse(rawFulfillmentResponse);
				List<FulfillmentResponse> list3 = new List<FulfillmentResponse>();
				foreach (string item2 in list2)
				{
					list3.Add(new FulfillmentResponse(ParseResponse(item2)));
				}
				foreach (EntitlementResponse item3 in entitlementsToFulfill)
				{
					foreach (FulfillmentResponse item4 in list3)
					{
						if (item4.EntitlementId == item3.EntitlementId)
						{
							if (item4.Result == "SUCCESS")
							{
								_app.UserProfile.PrimeGamingEntitlements.AddUnique(item3.VendorProductId);
								_app.UserProfile.SaveToFile();
								GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.PrimeFulfillmentInfo).AddParam("PrimeEntitlementClaimed", item3);
								_app.AnalyticsManager.RecordEvent(gameEvent);
							}
							else if (item4.Result == "ERROR")
							{
								shouldRetry = true;
							}
						}
					}
				}
				if (shouldRetry)
				{
					PrimeGaming primeGaming = this;
					int retryCount = _retryCount;
					primeGaming._retryCount = retryCount + 1;
					if (retryCount <= _retryMax)
					{
						FulfillNewEntitlements(entitlementsToFulfill);
					}
				}
			}, null));
		}

		private IEnumerator PostRequest(string url, Dictionary<string, string> formFields, bool isPollForToken, Action<string> callbackSuccess, Action callbackFailure)
		{
			if (isPollForToken)
			{
				_tokenRequestInProgress = true;
			}
			WWWForm wWWForm = new WWWForm();
			foreach (KeyValuePair<string, string> formField in formFields)
			{
				wWWForm.AddField(formField.Key, formField.Value);
			}
			using (UnityWebRequest webRequest = UnityWebRequest.Post(url, wWWForm))
			{
				yield return webRequest.SendWebRequest();
				if (!isPollForToken || !webRequest.downloadHandler.text.Contains("authorization_pending"))
				{
					if (webRequest.result != UnityWebRequest.Result.Success)
					{
						UnityEngine.Debug.Log("Error While Sending: " + webRequest.error);
						callbackFailure?.Invoke();
					}
					else
					{
						UnityEngine.Debug.Log("Received: " + webRequest.downloadHandler.text);
						callbackSuccess?.Invoke(webRequest.downloadHandler.text);
					}
				}
			}
			if (isPollForToken)
			{
				_tokenRequestInProgress = false;
			}
		}

		private IEnumerator PostRequestAsJSON(string url, Dictionary<string, string> formHeaders, string data, Action<string> callbackSuccess, Action callbackFailure)
		{
			using UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
			webRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
			webRequest.downloadHandler = new DownloadHandlerBuffer();
			foreach (KeyValuePair<string, string> formHeader in formHeaders)
			{
				webRequest.SetRequestHeader(formHeader.Key, formHeader.Value);
			}
			yield return webRequest.SendWebRequest();
			if (webRequest.result != UnityWebRequest.Result.Success)
			{
				UnityEngine.Debug.Log("Error While Sending: " + webRequest.error);
				callbackFailure?.Invoke();
			}
			else
			{
				UnityEngine.Debug.Log("Received: " + webRequest.downloadHandler.text);
				callbackSuccess?.Invoke(webRequest.downloadHandler.text);
			}
		}

		private IEnumerator GetRequest(string url, string formField, string arg, Action<string> callbackSuccess, Action callbackFailure)
		{
			using UnityWebRequest webRequest = UnityWebRequest.Get(url);
			webRequest.SetRequestHeader(formField, arg);
			yield return webRequest.SendWebRequest();
			if (webRequest.result != UnityWebRequest.Result.Success)
			{
				UnityEngine.Debug.Log("Error While Sending: " + webRequest.error);
				callbackFailure?.Invoke();
			}
			else
			{
				UnityEngine.Debug.Log("Received: " + webRequest.downloadHandler.text);
				callbackSuccess?.Invoke(webRequest.downloadHandler.text);
			}
		}

		private Dictionary<string, object> ParseResponse(string response)
		{
			string[] array = response.Split(',');
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new string[1] { "\":" }, StringSplitOptions.None);
				if (array3.Length >= 2)
				{
					dictionary.Add(array3[0].Trim(CharsToTrim), array3[1].Trim(CharsToTrim));
				}
			}
			return dictionary;
		}

		private static string CreateFulfillmentJSON(List<FulfillmentData> fulfillmentData)
		{
			fsSerializer fsSerializer2 = new fsSerializer();
			fsSerializer2.Config.DefaultMemberSerialization = fsMemberSerialization.OptOut;
			fsSerializer2.Config.EnablePropertySerialization = false;
			fsSerializer2.Config.IgnoreSerializeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(NonSerializedAttribute),
				typeof(fsIgnoreAttribute)
			};
			fsData data;
			fsResult fsResult2 = fsSerializer2.TrySerialize(fulfillmentData, out data);
			if (fsResult2.Failed)
			{
				Logging.Error(LogChannels.Preferences, "Failed to serialise preferences; aborting save. Errors: {0}", fsResult2.FormattedMessages);
				return null;
			}
			if (fsResult2.HasWarnings)
			{
				Logging.Warning(LogChannels.Preferences, "Warnings encountered whilst serialising preferences: {0}", fsResult2.FormattedMessages);
			}
			return "{\"FulfillmentStatusUpdates\":" + fsJsonPrinter.CompressedJson(data) + "}";
		}

		private List<string> ParseContainerResponse(string response)
		{
			response = response.Replace("\"Entitlements\":", string.Empty);
			response = response.Replace("\"FulfillmentStatusUpdates\":", string.Empty);
			string[] array = response.Split(new string[1] { "},{" }, StringSplitOptions.None);
			List<string> list = new List<string>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!(text == "{[]}"))
				{
					list.Add(text);
				}
			}
			return list;
		}

		public void CancelAllRequests()
		{
			OnlineManager.BehaviourToRunCoroutinesOn.StopAllCoroutines();
			_tokenRequestInProgress = false;
		}

		public void RestartGame()
		{
			if (_app.PreferencesScreen.isActiveAndEnabled)
			{
				_app.PreferencesScreen.CloseMenu();
			}
			if (_app.OpeningScreen.isActiveAndEnabled)
			{
				_app.OpeningScreen.HideSaveSlots();
			}
			_app.MessageBox.Hide();
			_app.StopGettingLatestOnlineMetadata();
			_app.QuitToMenuDontSave();
		}

		public override void Destroy()
		{
			CancelAllRequests();
		}

		private ConsoleCommandResult DebugAddPrimeEntitlement(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(DebugAddPrimeEntitlementToProfile, args);
		}

		private void DebugAddPrimeEntitlementToProfile(int newID)
		{
			_debugEntitlementsToAdd.Add(newID.ToString());
		}

		private ConsoleCommandResult DebugClearPrimeEntitlements(string[] args)
		{
			_debugEntitlementsToAdd.Clear();
			_app.UserProfile.PrimeGamingKudoshIDsClaimed = new List<string>[3];
			for (int i = 0; i < 3; i++)
			{
				_app.UserProfile.PrimeGamingKudoshIDsClaimed[i] = new List<string>();
			}
			_app.UserProfile.PrimeGamingEntitlements.Clear();
			_app.UserProfile.SaveToFile();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLogOutOfPrime(string[] args)
		{
			_app.UserProfile.PrimeGamingRefreshToken = null;
			_deviceTokenResponse = null;
			return ConsoleCommandResult.Succeeded();
		}
	}
}
