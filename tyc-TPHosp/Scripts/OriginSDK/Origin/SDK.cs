using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Origin.Data;

namespace Origin
{
	public class SDK
	{
		public delegate void DisconnectedEvent();

		public struct StartupInputT
		{
			public string ContentId;

			public string Title;

			public string MultiplayerId;

			public string Language;

			public string SdkVersionOverride;
		}

		public struct StartupOutputT
		{
			public string Version;

			public string ContentId;

			public string ProductId;
		}

		[Flags]
		public enum OriginSDKFlags : short
		{
			None = 0,
			DisableTrial = 1
		}

		private delegate void HandleResponse(LSX lsx);

		public delegate void DebugCallback(byte[] debugline);

		private const int DEFAULT_TIMEOUT = 5000;

		public const string ORIGIN_SDK_VERSION = "10.6.1.10";

		private const string ORIGIN_SDK_PROTOCOL_VERSION = "3";

		private OriginSDKFlags originFlags;

		private Trials trial = new Trials();

		public DisconnectedEvent Disconnected;

		private Connection client;

		private bool encrypted;

		private string originVersion = "UNKNOWN";

		private string contentId = "UNKNOWN";

		private string securityKey = "NoKey";

		private ulong defaultUser;

		private ulong defaultPersona;

		private StartupInputT applicationInput;

		private ManualResetEvent initialized = new ManualResetEvent(initialState: false);

		private OriginErrorT initializeErr = OriginErrorT.ORIGIN_ERROR_CORE_NOTLOADED;

		private Dictionary<FacilityT, string> FacilityToRecipient = new Dictionary<FacilityT, string>();

		private Dictionary<int, ResponseCallbackBase> responseMap = new Dictionary<int, ResponseCallbackBase>();

		private EventHandlerT<object> fallbackEventHandler = new EventHandlerT<object>();

		private int requestId = 1;

		private List<ICallback> callbacks = new List<ICallback>();

		private DebugCallback debugCallback;

		private EventHandlerT<ShowIGOWindowEventT> ShowIGOWindowEventHandler = new EventHandlerT<ShowIGOWindowEventT>();

		private EventHandlerT<IGOUnavailableT> IGOUnavailableEventHandler = new EventHandlerT<IGOUnavailableT>();

		private EventHandlerT<MinimizeRequestT> MinimizeRequestHandler = new EventHandlerT<MinimizeRequestT>();

		private EventHandlerT<RestoreRequestT> RestoreRequestHandler = new EventHandlerT<RestoreRequestT>();

		private EventHandlerT<QueryFriendsResponseT> FriendsEventHandler = new EventHandlerT<QueryFriendsResponseT>();

		private EventHandlerT<GetPresenceResponseT> PresenceEventHandler = new EventHandlerT<GetPresenceResponseT>();

		private EventHandlerT<CurrentUserPresenceEventT> CurrentUserPresenceEventHandler = new EventHandlerT<CurrentUserPresenceEventT>();

		private EventHandlerT<IGOEventT> IGOEventHandler = new EventHandlerT<IGOEventT>();

		private EventHandlerT<BroadcastEventT> BroadcastEventHandler = new EventHandlerT<BroadcastEventT>();

		private EventHandlerT<MultiplayerInviteT> GameInviteEventHandler = new EventHandlerT<MultiplayerInviteT>();

		private EventHandlerT<MultiplayerInvitePendingT> GameInvitePendingEventHandler = new EventHandlerT<MultiplayerInvitePendingT>();

		private EventHandlerT<LoginT> LoginEventHandler = new EventHandlerT<LoginT>();

		private EventHandlerT<ProfileEventT> ProfileEventHandler = new EventHandlerT<ProfileEventT>();

		private EventHandlerT<PurchaseEventT> PurchaseEventHandler = new EventHandlerT<PurchaseEventT>();

		private EventHandlerT<ChatMessageEventT> ChatMessageEventHandler = new EventHandlerT<ChatMessageEventT>();

		private EventHandlerT<CoreContentUpdatedT> ContentEventHandler = new EventHandlerT<CoreContentUpdatedT>();

		private EventHandlerT<BlockListUpdatedT> BlockListUpdatedEventHandler = new EventHandlerT<BlockListUpdatedT>();

		private EventHandlerT<OnlineStatusEventT> OnlineStatusEventHandler = new EventHandlerT<OnlineStatusEventT>();

		private EventHandlerT<PresenceVisibilityEventT> PresenceVisibilityEventHandler = new EventHandlerT<PresenceVisibilityEventT>();

		private EventHandlerT<UserInvitedEventT> UserInvitedEventHandler = new EventHandlerT<UserInvitedEventT>();

		private EventHandlerT<ChallengeT> ChallengeHandler = new EventHandlerT<ChallengeT>();

		private EventHandlerT<QueryEntitlementsResponseT> EntitlementEventHandler = new EventHandlerT<QueryEntitlementsResponseT>();

		private EventHandlerT<AchievementSetsT> AchievementEventHandler = new EventHandlerT<AchievementSetsT>();

		private EventHandlerT<ChunkStatusT> ChunkStatusHandler = new EventHandlerT<ChunkStatusT>();

		private EventHandlerT<GameMessageEventT> GameMessageEventHandler = new EventHandlerT<GameMessageEventT>();

		private EventHandlerT<GroupEventT> GroupEventHandler = new EventHandlerT<GroupEventT>();

		private EventHandlerT<GroupEnterEventT> GroupEnterEventHandler = new EventHandlerT<GroupEnterEventT>();

		private EventHandlerT<GroupLeaveEventT> GroupLeaveEventHandler = new EventHandlerT<GroupLeaveEventT>();

		private EventHandlerT<GroupInviteEventT> GroupInviteEventHandler = new EventHandlerT<GroupInviteEventT>();

		private EventHandlerT<VoipStatusEventT> VoipStatusEventHandler = new EventHandlerT<VoipStatusEventT>();

		private EventHandlerT<ChatStateUpdateEventT> ChatStateUpdateEventHandler = new EventHandlerT<ChatStateUpdateEventT>();

		public string OriginVersion => originVersion;

		public string ContentId => contentId;

		public ulong DefaultUser => defaultUser;

		public ulong DefaultPersona => defaultPersona;

		public bool IsConnected
		{
			get
			{
				if (client != null)
				{
					return client.IsConnected;
				}
				return false;
			}
		}

		public SDK()
		{
			ChallengeHandler.AddCallback(ProcessChallenge);
			OriginSDK.sdk = this;
		}

		internal void AddCallback(ICallback callback)
		{
			lock (callbacks)
			{
				callbacks.Add(callback);
			}
		}

		private void ConnectionSevered()
		{
			if (Disconnected != null)
			{
				Disconnected();
			}
			initialized.Set();
		}

		public OriginErrorT Startup(OriginSDKFlags flags, int port, string securityKey, StartupInputT input, out StartupOutputT output)
		{
			originFlags = flags;
			applicationInput = input;
			if (securityKey.Length > 0)
			{
				this.securityKey = securityKey;
			}
			client = new Connection();
			client.Disconnected += ConnectionSevered;
			client.ReadBuffer.MessageAvailable += ReadMessageAvailable;
			output = default(StartupOutputT);
			string environmentVariable = Environment.GetEnvironmentVariable("EALsxPort");
			int port2 = ((port != 0) ? port : ((environmentVariable == null || environmentVariable.Length == 0) ? 3216 : int.Parse(environmentVariable)));
			if (!client.Connect("127.0.0.1", port2))
			{
				return OriginErrorT.ORIGIN_ERROR_CORE_NOTLOADED;
			}
			for (int num = 1000; num >= 0; num--)
			{
				if (initialized.WaitOne(10))
				{
					initializeErr = OriginErrorT.ORIGIN_SUCCESS;
					break;
				}
				if (num == 0)
				{
					initializeErr = OriginErrorT.ORIGIN_ERROR_LSX_NO_RESPONSE;
					break;
				}
				if ((initializeErr = Update()) != OriginErrorT.ORIGIN_SUCCESS)
				{
					break;
				}
			}
			output.ContentId = contentId;
			output.ProductId = Environment.GetEnvironmentVariable("EAConnectionId");
			output.Version = originVersion;
			return initializeErr;
		}

		public OriginErrorT Update()
		{
			lock (responseMap)
			{
				foreach (int key in responseMap.Keys)
				{
					if (responseMap[key].timeout < DateTime.Now)
					{
						Response response = new Response();
						response.ErrorSuccess = new ErrorSuccessT();
						response.ErrorSuccess.Code = -1593311231;
						responseMap[key].HandleResponse(response);
						responseMap.Remove(key);
						break;
					}
				}
			}
			lock (callbacks)
			{
				foreach (ICallback callback in callbacks)
				{
					callback.callback();
				}
				callbacks.Clear();
			}
			if (!IsConnected)
			{
				return OriginErrorT.ORIGIN_ERROR_CORE_NOTLOADED;
			}
			return OriginErrorT.ORIGIN_SUCCESS;
		}

		public void Shutdown()
		{
			client.Disconnect();
			OriginSDK.sdk = null;
		}

		public void RegisterFallbackEventHandler(EventCallbackT<object> callback)
		{
			fallbackEventHandler.AddCallback(callback);
		}

		public void RegisterDebugCallback(DebugCallback callback)
		{
			debugCallback = callback;
		}

		private void ReadMessageAvailable()
		{
			do
			{
				byte[] array = client.ReadBuffer.Pop(MessageBuffer.SeparatorMode.RemoveSeparator);
				if (encrypted)
				{
					array = Encryptor.StringToByteArray(Encoding.UTF8.GetString(array));
					array = Encoding.UTF8.GetBytes(Encryptor.decrypt(array));
				}
				if (debugCallback != null)
				{
					debugCallback(array);
				}
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(LSX));
				using MemoryStream stream = new MemoryStream(array);
				using (new StreamReader(stream, Encoding.UTF8))
				{
					LSX lSX = (LSX)xmlSerializer.Deserialize(stream);
					if (lSX.evnt != null)
					{
						ProcessEvent(lSX.evnt);
					}
					else
					{
						if (lSX.response == null)
						{
							continue;
						}
						lock (responseMap)
						{
							if (responseMap.TryGetValue(lSX.response.id, out var value))
							{
								value.HandleResponse(lSX.response);
								responseMap.Remove(lSX.response.id);
							}
						}
						continue;
					}
				}
			}
			while (client.ReadBuffer.HasMessages);
		}

		private LSX CreateRequest()
		{
			LSX lSX = new LSX();
			lSX.request = new Request();
			return lSX;
		}

		private OriginErrorT SendRequest(FacilityT facility, LSX lsx, ResponseCallbackBase data)
		{
			if (IsConnected)
			{
				byte[] array = null;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
					xmlWriterSettings.Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
					xmlWriterSettings.OmitXmlDeclaration = true;
					xmlWriterSettings.Indent = true;
					using XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(LSX));
					XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
					xmlSerializerNamespaces.Add("", "");
					if (!FacilityToRecipient.TryGetValue(facility, out lsx.request.recipient))
					{
						if (facility == FacilityT.EALS)
						{
							lsx.request.recipient = "EALS";
						}
						if (facility == FacilityT.EbisuSDK)
						{
							lsx.request.recipient = "EbisuSDK";
						}
					}
					lock (responseMap)
					{
						lsx.request.id = requestId++;
						responseMap[lsx.request.id] = data;
					}
					xmlSerializer.Serialize(xmlWriter, lsx, xmlSerializerNamespaces);
					array = memoryStream.ToArray();
					if (debugCallback != null)
					{
						debugCallback(array);
					}
				}
				if (encrypted)
				{
					array = Encryptor.encrypt(Encoding.UTF8.GetString(array));
					array = Encoding.UTF8.GetBytes(Encryptor.ByteArrayToString(array));
				}
				client.WriteBuffer.Push(array, array.Length, MessageBuffer.SeparatorMode.InsertSeparator);
				return OriginErrorT.ORIGIN_SUCCESS;
			}
			return OriginErrorT.ORIGIN_ERROR_CORE_NOTLOADED;
		}

		private void ProcessChallenge(ChallengeT challenge)
		{
			originVersion = challenge.version.Replace(',', '.');
			MD5 mD = MD5.Create();
			byte[] bytes = BitConverter.GetBytes(Environment.TickCount);
			mD.Initialize();
			mD.TransformFinalBlock(bytes, 0, bytes.Length);
			byte[] hash = mD.Hash;
			Encryptor.SetKey(0u);
			contentId = Environment.GetEnvironmentVariable("ContentId");
			contentId = ((contentId != null) ? contentId : applicationInput.ContentId);
			string response = Encryptor.ByteArrayToString(Encryptor.encrypt(challenge.key));
			string text = Encryptor.ByteArrayToString(hash, 16);
			Encryptor.SetKey(64u);
			string text2 = Encryptor.ByteArrayToString(Encryptor.encrypt(text + securityKey + contentId));
			ChallengeResponse(response, text, text2, "3", ContentId, applicationInput.Title, applicationInput.MultiplayerId, applicationInput.Language, "10.6.1.10", 5000, ChallengeAcceptedCallback);
		}

		private void ChallengeAcceptedCallback(ChallengeAcceptedT challengeAccepted, OriginErrorT err)
		{
			if (err == OriginErrorT.ORIGIN_SUCCESS)
			{
				encrypted = true;
				Encryptor.SetKey(((uint)challengeAccepted.response[0] << 8) + challengeAccepted.response[1]);
				GetConfig(5000, GetConfigResponseCallback);
			}
			else
			{
				initializeErr = err;
				initialized.Set();
			}
		}

		private void GetConfigResponseCallback(GetConfigResponseT getConfigResponse, OriginErrorT err)
		{
			if (err == OriginErrorT.ORIGIN_SUCCESS)
			{
				foreach (ServiceT service in getConfigResponse.Services)
				{
					FacilityToRecipient[service.Facility] = service.Name;
				}
				GetProfile(0, 5000, GetProfileResponseCallback);
			}
			else
			{
				initializeErr = err;
				initialized.Set();
			}
		}

		private void GetProfileResponseCallback(GetProfileResponseT resp, OriginErrorT err)
		{
			if (err == OriginErrorT.ORIGIN_SUCCESS)
			{
				defaultUser = resp.UserId;
				defaultPersona = resp.PersonaId;
			}
			GetAllGameInfo(5000, GetAllGameInfoResponseCallback);
		}

		private void GetAllGameInfoResponseCallback(GetAllGameInfoResponseT resp, OriginErrorT err)
		{
			if (err == OriginErrorT.ORIGIN_SUCCESS)
			{
				if (resp.FreeTrial && (originFlags & OriginSDKFlags.DisableTrial) != OriginSDKFlags.DisableTrial)
				{
					trial.Start();
				}
			}
			else
			{
				initializeErr = err;
			}
			initialized.Set();
		}

		public OriginErrorT ShowProfileUI(ulong userId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.WindowId = IGOWindowT.PROFILE;
			showIGOWindowT.Show = true;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowFriendsProfileUI(ulong userId, ulong friendId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.TargetId = new List<ulong> { friendId };
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.PROFILE;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowBrowserUI(int flags, string url, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.Flags = flags;
			showIGOWindowT.String = url;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.BROWSER;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowFriendsUI(ulong userId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.FRIENDS;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowFindFriendsUI(ulong userId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.FIND_FRIENDS;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowChangeAvatarUI(ulong userId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.CHANGE_AVATAR;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowRequestFriendUI(ulong userId, ulong friendId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.TargetId = new List<ulong> { friendId };
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.FRIEND_REQUEST;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowComposeChatUI(ulong userId, ulong friendId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.TargetId = new List<ulong> { friendId };
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.COMPOSE_CHAT;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowInviteUI(ulong userId, List<ulong> friends, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.TargetId = friends;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.INVITE;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowAchievementUI(ulong userId, ulong PersonaId, string gameId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.TargetId = new List<ulong> { PersonaId };
			showIGOWindowT.String = gameId;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.ACHIEVEMENTS;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowGameDetailsUI(ulong userId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.GAMEDETAILS;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowBroadcastUI(ulong userId, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.BROADCAST;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowUpsellUI(ulong userId, string type, string uri, string par, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.Args = new List<string> { type, uri, par };
			showIGOWindowT.Show = true;
			showIGOWindowT.WindowId = IGOWindowT.UPSELL;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowStoreUI(ulong userId, List<string> categories, List<string> masterTitleIds, List<string> offerIds, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.Categories = categories;
			showIGOWindowT.MasterTitleIds = masterTitleIds;
			showIGOWindowT.Offers = offerIds;
			showIGOWindowT.WindowId = IGOWindowT.STORE;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT ShowCheckoutUI(ulong userId, List<string> offerIds, int timeout, ResponseCallbackT<ErrorSuccessT> callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = userId;
			showIGOWindowT.Show = true;
			showIGOWindowT.Offers = offerIds;
			showIGOWindowT.WindowId = IGOWindowT.CHECKOUT;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(timeout, callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public void RegisterShowIGOWindowEventHandler(EventCallbackT<ShowIGOWindowEventT> callback)
		{
			ShowIGOWindowEventHandler.AddCallback(callback);
		}

		public void RegisterIGOUnavailableEventHandler(EventCallbackT<IGOUnavailableT> callback)
		{
			IGOUnavailableEventHandler.AddCallback(callback);
		}

		public void RegisterMinimizeRequestHandler(EventCallbackT<MinimizeRequestT> callback)
		{
			MinimizeRequestHandler.AddCallback(callback);
		}

		public void RegisterRestoreRequestHandler(EventCallbackT<RestoreRequestT> callback)
		{
			RestoreRequestHandler.AddCallback(callback);
		}

		public void RegisterFriendsEventHandler(EventCallbackT<QueryFriendsResponseT> callback)
		{
			FriendsEventHandler.AddCallback(callback);
		}

		public void RegisterPresenceEventHandler(EventCallbackT<GetPresenceResponseT> callback)
		{
			PresenceEventHandler.AddCallback(callback);
		}

		public void RegisterCurrentUserPresenceEventHandler(EventCallbackT<CurrentUserPresenceEventT> callback)
		{
			CurrentUserPresenceEventHandler.AddCallback(callback);
		}

		public void RegisterIGOEventHandler(EventCallbackT<IGOEventT> callback)
		{
			IGOEventHandler.AddCallback(callback);
		}

		public void RegisterBroadcastEventHandler(EventCallbackT<BroadcastEventT> callback)
		{
			BroadcastEventHandler.AddCallback(callback);
		}

		public void RegisterGameInviteEventHandler(EventCallbackT<MultiplayerInviteT> callback)
		{
			GameInviteEventHandler.AddCallback(callback);
		}

		public void RegisterGameInvitePendingEventHandler(EventCallbackT<MultiplayerInvitePendingT> callback)
		{
			GameInvitePendingEventHandler.AddCallback(callback);
		}

		public void RegisterLoginEventHandler(EventCallbackT<LoginT> callback)
		{
			LoginEventHandler.AddCallback(callback);
		}

		public void RegisterProfileEventHandler(EventCallbackT<ProfileEventT> callback)
		{
			ProfileEventHandler.AddCallback(callback);
		}

		public void RegisterPurchaseEventHandler(EventCallbackT<PurchaseEventT> callback)
		{
			PurchaseEventHandler.AddCallback(callback);
		}

		public void RegisterChatMessageEventHandler(EventCallbackT<ChatMessageEventT> callback)
		{
			ChatMessageEventHandler.AddCallback(callback);
		}

		public void RegisterContentEventHandler(EventCallbackT<CoreContentUpdatedT> callback)
		{
			ContentEventHandler.AddCallback(callback);
		}

		public void RegisterBlockListUpdatedEventHandler(EventCallbackT<BlockListUpdatedT> callback)
		{
			BlockListUpdatedEventHandler.AddCallback(callback);
		}

		public void RegisterOnlineStatusEventHandler(EventCallbackT<OnlineStatusEventT> callback)
		{
			OnlineStatusEventHandler.AddCallback(callback);
		}

		public void RegisterPresenceVisibilityEventHandler(EventCallbackT<PresenceVisibilityEventT> callback)
		{
			PresenceVisibilityEventHandler.AddCallback(callback);
		}

		public void RegisterUserInvitedEventHandler(EventCallbackT<UserInvitedEventT> callback)
		{
			UserInvitedEventHandler.AddCallback(callback);
		}

		public void RegisterChallengeHandler(EventCallbackT<ChallengeT> callback)
		{
			ChallengeHandler.AddCallback(callback);
		}

		public void RegisterEntitlementEventHandler(EventCallbackT<QueryEntitlementsResponseT> callback)
		{
			EntitlementEventHandler.AddCallback(callback);
		}

		public void RegisterAchievementEventHandler(EventCallbackT<AchievementSetsT> callback)
		{
			AchievementEventHandler.AddCallback(callback);
		}

		public void RegisterChunkStatusHandler(EventCallbackT<ChunkStatusT> callback)
		{
			ChunkStatusHandler.AddCallback(callback);
		}

		public void RegisterGameMessageEventHandler(EventCallbackT<GameMessageEventT> callback)
		{
			GameMessageEventHandler.AddCallback(callback);
		}

		public void RegisterGroupEventHandler(EventCallbackT<GroupEventT> callback)
		{
			GroupEventHandler.AddCallback(callback);
		}

		public void RegisterGroupEnterEventHandler(EventCallbackT<GroupEnterEventT> callback)
		{
			GroupEnterEventHandler.AddCallback(callback);
		}

		public void RegisterGroupLeaveEventHandler(EventCallbackT<GroupLeaveEventT> callback)
		{
			GroupLeaveEventHandler.AddCallback(callback);
		}

		public void RegisterGroupInviteEventHandler(EventCallbackT<GroupInviteEventT> callback)
		{
			GroupInviteEventHandler.AddCallback(callback);
		}

		public void RegisterVoipStatusEventHandler(EventCallbackT<VoipStatusEventT> callback)
		{
			VoipStatusEventHandler.AddCallback(callback);
		}

		public void RegisterChatStateUpdateEventHandler(EventCallbackT<ChatStateUpdateEventT> callback)
		{
			ChatStateUpdateEventHandler.AddCallback(callback);
		}

		private void ProcessEvent(Event evnt)
		{
			if (evnt.ShowIGOWindowEvent != null)
			{
				if (ShowIGOWindowEventHandler.HasCallbacks)
				{
					ShowIGOWindowEventHandler.HandleEvent(evnt.ShowIGOWindowEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.ShowIGOWindowEvent);
				}
			}
			if (evnt.IGOUnavailableEvent != null)
			{
				if (IGOUnavailableEventHandler.HasCallbacks)
				{
					IGOUnavailableEventHandler.HandleEvent(evnt.IGOUnavailableEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.IGOUnavailableEvent);
				}
			}
			if (evnt.MinimizeRequest != null)
			{
				if (MinimizeRequestHandler.HasCallbacks)
				{
					MinimizeRequestHandler.HandleEvent(evnt.MinimizeRequest);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.MinimizeRequest);
				}
			}
			if (evnt.RestoreRequest != null)
			{
				if (RestoreRequestHandler.HasCallbacks)
				{
					RestoreRequestHandler.HandleEvent(evnt.RestoreRequest);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.RestoreRequest);
				}
			}
			if (evnt.FriendsEvent != null)
			{
				if (FriendsEventHandler.HasCallbacks)
				{
					FriendsEventHandler.HandleEvent(evnt.FriendsEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.FriendsEvent);
				}
			}
			if (evnt.PresenceEvent != null)
			{
				if (PresenceEventHandler.HasCallbacks)
				{
					PresenceEventHandler.HandleEvent(evnt.PresenceEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.PresenceEvent);
				}
			}
			if (evnt.CurrentUserPresenceEvent != null)
			{
				if (CurrentUserPresenceEventHandler.HasCallbacks)
				{
					CurrentUserPresenceEventHandler.HandleEvent(evnt.CurrentUserPresenceEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.CurrentUserPresenceEvent);
				}
			}
			if (evnt.IGOEvent != null)
			{
				if (IGOEventHandler.HasCallbacks)
				{
					IGOEventHandler.HandleEvent(evnt.IGOEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.IGOEvent);
				}
			}
			if (evnt.BroadcastEvent != null)
			{
				if (BroadcastEventHandler.HasCallbacks)
				{
					BroadcastEventHandler.HandleEvent(evnt.BroadcastEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.BroadcastEvent);
				}
			}
			if (evnt.GameInviteEvent != null)
			{
				if (GameInviteEventHandler.HasCallbacks)
				{
					GameInviteEventHandler.HandleEvent(evnt.GameInviteEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GameInviteEvent);
				}
			}
			if (evnt.GameInvitePendingEvent != null)
			{
				if (GameInvitePendingEventHandler.HasCallbacks)
				{
					GameInvitePendingEventHandler.HandleEvent(evnt.GameInvitePendingEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GameInvitePendingEvent);
				}
			}
			if (evnt.LoginEvent != null)
			{
				if (LoginEventHandler.HasCallbacks)
				{
					LoginEventHandler.HandleEvent(evnt.LoginEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.LoginEvent);
				}
			}
			if (evnt.ProfileEvent != null)
			{
				if (ProfileEventHandler.HasCallbacks)
				{
					ProfileEventHandler.HandleEvent(evnt.ProfileEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.ProfileEvent);
				}
			}
			if (evnt.PurchaseEvent != null)
			{
				if (PurchaseEventHandler.HasCallbacks)
				{
					PurchaseEventHandler.HandleEvent(evnt.PurchaseEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.PurchaseEvent);
				}
			}
			if (evnt.ChatMessageEvent != null)
			{
				if (ChatMessageEventHandler.HasCallbacks)
				{
					ChatMessageEventHandler.HandleEvent(evnt.ChatMessageEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.ChatMessageEvent);
				}
			}
			if (evnt.ContentEvent != null)
			{
				if (ContentEventHandler.HasCallbacks)
				{
					ContentEventHandler.HandleEvent(evnt.ContentEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.ContentEvent);
				}
			}
			if (evnt.BlockListUpdatedEvent != null)
			{
				if (BlockListUpdatedEventHandler.HasCallbacks)
				{
					BlockListUpdatedEventHandler.HandleEvent(evnt.BlockListUpdatedEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.BlockListUpdatedEvent);
				}
			}
			if (evnt.OnlineStatusEvent != null)
			{
				if (OnlineStatusEventHandler.HasCallbacks)
				{
					OnlineStatusEventHandler.HandleEvent(evnt.OnlineStatusEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.OnlineStatusEvent);
				}
			}
			if (evnt.PresenceVisibilityEvent != null)
			{
				if (PresenceVisibilityEventHandler.HasCallbacks)
				{
					PresenceVisibilityEventHandler.HandleEvent(evnt.PresenceVisibilityEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.PresenceVisibilityEvent);
				}
			}
			if (evnt.UserInvitedEvent != null)
			{
				if (UserInvitedEventHandler.HasCallbacks)
				{
					UserInvitedEventHandler.HandleEvent(evnt.UserInvitedEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.UserInvitedEvent);
				}
			}
			if (evnt.Challenge != null)
			{
				if (ChallengeHandler.HasCallbacks)
				{
					ChallengeHandler.HandleEvent(evnt.Challenge);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.Challenge);
				}
			}
			if (evnt.EntitlementEvent != null)
			{
				if (EntitlementEventHandler.HasCallbacks)
				{
					EntitlementEventHandler.HandleEvent(evnt.EntitlementEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.EntitlementEvent);
				}
			}
			if (evnt.AchievementEvent != null)
			{
				if (AchievementEventHandler.HasCallbacks)
				{
					AchievementEventHandler.HandleEvent(evnt.AchievementEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.AchievementEvent);
				}
			}
			if (evnt.ChunkStatus != null)
			{
				if (ChunkStatusHandler.HasCallbacks)
				{
					ChunkStatusHandler.HandleEvent(evnt.ChunkStatus);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.ChunkStatus);
				}
			}
			if (evnt.GameMessageEvent != null)
			{
				if (GameMessageEventHandler.HasCallbacks)
				{
					GameMessageEventHandler.HandleEvent(evnt.GameMessageEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GameMessageEvent);
				}
			}
			if (evnt.GroupEvent != null)
			{
				if (GroupEventHandler.HasCallbacks)
				{
					GroupEventHandler.HandleEvent(evnt.GroupEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GroupEvent);
				}
			}
			if (evnt.GroupEnterEvent != null)
			{
				if (GroupEnterEventHandler.HasCallbacks)
				{
					GroupEnterEventHandler.HandleEvent(evnt.GroupEnterEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GroupEnterEvent);
				}
			}
			if (evnt.GroupLeaveEvent != null)
			{
				if (GroupLeaveEventHandler.HasCallbacks)
				{
					GroupLeaveEventHandler.HandleEvent(evnt.GroupLeaveEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GroupLeaveEvent);
				}
			}
			if (evnt.GroupInviteEvent != null)
			{
				if (GroupInviteEventHandler.HasCallbacks)
				{
					GroupInviteEventHandler.HandleEvent(evnt.GroupInviteEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.GroupInviteEvent);
				}
			}
			if (evnt.VoipStatusEvent != null)
			{
				if (VoipStatusEventHandler.HasCallbacks)
				{
					VoipStatusEventHandler.HandleEvent(evnt.VoipStatusEvent);
					return;
				}
				if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.VoipStatusEvent);
				}
			}
			if (evnt.ChatStateUpdateEvent != null)
			{
				if (ChatStateUpdateEventHandler.HasCallbacks)
				{
					ChatStateUpdateEventHandler.HandleEvent(evnt.ChatStateUpdateEvent);
				}
				else if (fallbackEventHandler.HasCallbacks)
				{
					fallbackEventHandler.HandleEvent(evnt.ChatStateUpdateEvent);
				}
			}
		}

		public OriginErrorT GetProfile(int index, int Timeout, ResponseCallbackT<GetProfileResponseT> Callback)
		{
			GetProfileT getProfileT = new GetProfileT();
			getProfileT.index = index;
			LSX lSX = CreateRequest();
			lSX.request.GetProfile = getProfileT;
			ResponseCallbackDataT<GetProfileResponseT> data = new ResponseCallbackDataT<GetProfileResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROFILE, lSX, data);
		}

		public OriginErrorT GetSettings(int Timeout, ResponseCallbackT<GetSettingsResponseT> Callback)
		{
			GetSettingsT getSettings = new GetSettingsT();
			LSX lSX = CreateRequest();
			lSX.request.GetSettings = getSettings;
			ResponseCallbackDataT<GetSettingsResponseT> data = new ResponseCallbackDataT<GetSettingsResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT GetAllGameInfo(int Timeout, ResponseCallbackT<GetAllGameInfoResponseT> Callback)
		{
			GetAllGameInfoT getAllGameInfo = new GetAllGameInfoT();
			LSX lSX = CreateRequest();
			lSX.request.GetAllGameInfo = getAllGameInfo;
			ResponseCallbackDataT<GetAllGameInfoResponseT> data = new ResponseCallbackDataT<GetAllGameInfoResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT ShowIGOWindow(ulong UserId, IGOWindowT WindowId, bool Show, int Flags, string ContentId, List<ulong> TargetId, string String, List<string> Args, List<string> Categories, List<string> MasterTitleIds, List<string> Offers, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			ShowIGOWindowT showIGOWindowT = new ShowIGOWindowT();
			showIGOWindowT.UserId = UserId;
			showIGOWindowT.WindowId = WindowId;
			showIGOWindowT.Show = Show;
			showIGOWindowT.Flags = Flags;
			showIGOWindowT.ContentId = ContentId;
			showIGOWindowT.TargetId = TargetId;
			showIGOWindowT.String = String;
			showIGOWindowT.Args = Args;
			showIGOWindowT.Categories = Categories;
			showIGOWindowT.MasterTitleIds = MasterTitleIds;
			showIGOWindowT.Offers = Offers;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGOWindow = showIGOWindowT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT ShowIGO(bool bShow, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			ShowIGOT showIGOT = new ShowIGOT();
			showIGOT.bShow = bShow;
			LSX lSX = CreateRequest();
			lSX.request.ShowIGO = showIGOT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.IGO, lSX, data);
		}

		public OriginErrorT GetUTCTime(int Timeout, ResponseCallbackT<GetUTCTimeResponseT> Callback)
		{
			GetUTCTimeT getUTCTime = new GetUTCTimeT();
			LSX lSX = CreateRequest();
			lSX.request.GetUTCTime = getUTCTime;
			ResponseCallbackDataT<GetUTCTimeResponseT> data = new ResponseCallbackDataT<GetUTCTimeResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT QueryFriends(ulong UserId, int Timeout, ResponseCallbackT<QueryFriendsResponseT> Callback)
		{
			QueryFriendsT queryFriendsT = new QueryFriendsT();
			queryFriendsT.UserId = UserId;
			LSX lSX = CreateRequest();
			lSX.request.QueryFriends = queryFriendsT;
			ResponseCallbackDataT<QueryFriendsResponseT> data = new ResponseCallbackDataT<QueryFriendsResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.FRIENDS, lSX, data);
		}

		public OriginErrorT RequestFriend(ulong UserId, ulong UserToAdd, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			RequestFriendT requestFriendT = new RequestFriendT();
			requestFriendT.UserId = UserId;
			requestFriendT.UserToAdd = UserToAdd;
			LSX lSX = CreateRequest();
			lSX.request.RequestFriend = requestFriendT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT RemoveFriend(ulong UserId, ulong UserToRemove, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			RemoveFriendT removeFriendT = new RemoveFriendT();
			removeFriendT.UserId = UserId;
			removeFriendT.UserToRemove = UserToRemove;
			LSX lSX = CreateRequest();
			lSX.request.RemoveFriend = removeFriendT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT AcceptFriendInvite(ulong UserId, ulong OtherId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			AcceptFriendInviteT acceptFriendInviteT = new AcceptFriendInviteT();
			acceptFriendInviteT.UserId = UserId;
			acceptFriendInviteT.OtherId = OtherId;
			LSX lSX = CreateRequest();
			lSX.request.AcceptFriendInvite = acceptFriendInviteT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT GetBlockList(int Timeout, ResponseCallbackT<GetBlockListResponseT> Callback)
		{
			GetBlockListT getBlockList = new GetBlockListT();
			LSX lSX = CreateRequest();
			lSX.request.GetBlockList = getBlockList;
			ResponseCallbackDataT<GetBlockListResponseT> data = new ResponseCallbackDataT<GetBlockListResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.BLOCKED_USERS, lSX, data);
		}

		public OriginErrorT BlockUser(ulong UserId, ulong UserIdToBlock, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			BlockUserT blockUserT = new BlockUserT();
			blockUserT.UserId = UserId;
			blockUserT.UserIdToBlock = UserIdToBlock;
			LSX lSX = CreateRequest();
			lSX.request.BlockUser = blockUserT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT UnblockUser(ulong UserId, ulong UserIdToUnblock, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			UnblockUserT unblockUserT = new UnblockUserT();
			unblockUserT.UserId = UserId;
			unblockUserT.UserIdToUnblock = UserIdToUnblock;
			LSX lSX = CreateRequest();
			lSX.request.UnblockUser = unblockUserT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT GetUserProfileByEAID(string KeyWord, int Timeout, ResponseCallbackT<GetUserProfileByEmailorEAIDResponseT> Callback)
		{
			GetUserProfileByEmailorEAIDT getUserProfileByEmailorEAIDT = new GetUserProfileByEmailorEAIDT();
			getUserProfileByEmailorEAIDT.KeyWord = KeyWord;
			LSX lSX = CreateRequest();
			lSX.request.GetUserProfileByEAID = getUserProfileByEmailorEAIDT;
			ResponseCallbackDataT<GetUserProfileByEmailorEAIDResponseT> data = new ResponseCallbackDataT<GetUserProfileByEmailorEAIDResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.GET_USERID, lSX, data);
		}

		public OriginErrorT QueryAreFriends(ulong UserId, List<ulong> Friends, int Timeout, ResponseCallbackT<QueryAreFriendsResponseT> Callback)
		{
			QueryAreFriendsT queryAreFriendsT = new QueryAreFriendsT();
			queryAreFriendsT.UserId = UserId;
			queryAreFriendsT.Friends = Friends;
			LSX lSX = CreateRequest();
			lSX.request.QueryAreFriends = queryAreFriendsT;
			ResponseCallbackDataT<QueryAreFriendsResponseT> data = new ResponseCallbackDataT<QueryAreFriendsResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.FRIENDS, lSX, data);
		}

		public OriginErrorT QueryPresence(ulong UserId, List<ulong> Users, int Timeout, ResponseCallbackT<QueryPresenceResponseT> Callback)
		{
			QueryPresenceT queryPresenceT = new QueryPresenceT();
			queryPresenceT.UserId = UserId;
			queryPresenceT.Users = Users;
			LSX lSX = CreateRequest();
			lSX.request.QueryPresence = queryPresenceT;
			ResponseCallbackDataT<QueryPresenceResponseT> data = new ResponseCallbackDataT<QueryPresenceResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PRESENCE, lSX, data);
		}

		public OriginErrorT SetPresence(ulong UserId, PresenceT Presence, string RichPresence, string GamePresence, string SessionId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SetPresenceT setPresenceT = new SetPresenceT();
			setPresenceT.UserId = UserId;
			setPresenceT.Presence = Presence;
			setPresenceT.RichPresence = RichPresence;
			setPresenceT.GamePresence = GamePresence;
			setPresenceT.SessionId = SessionId;
			LSX lSX = CreateRequest();
			lSX.request.SetPresence = setPresenceT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.PRESENCE, lSX, data);
		}

		public OriginErrorT SetPresenceVisibility(ulong UserId, bool Visible, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SetPresenceVisibilityT setPresenceVisibilityT = new SetPresenceVisibilityT();
			setPresenceVisibilityT.UserId = UserId;
			setPresenceVisibilityT.Visible = Visible;
			LSX lSX = CreateRequest();
			lSX.request.SetPresenceVisibility = setPresenceVisibilityT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.PRESENCE, lSX, data);
		}

		public OriginErrorT GetPresenceVisibility(ulong UserId, int Timeout, ResponseCallbackT<GetPresenceVisibilityResponseT> Callback)
		{
			GetPresenceVisibilityT getPresenceVisibilityT = new GetPresenceVisibilityT();
			getPresenceVisibilityT.UserId = UserId;
			LSX lSX = CreateRequest();
			lSX.request.GetPresenceVisibility = getPresenceVisibilityT;
			ResponseCallbackDataT<GetPresenceVisibilityResponseT> data = new ResponseCallbackDataT<GetPresenceVisibilityResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PRESENCE, lSX, data);
		}

		public OriginErrorT GetPresence(ulong UserId, int Timeout, ResponseCallbackT<GetPresenceResponseT> Callback)
		{
			GetPresenceT getPresenceT = new GetPresenceT();
			getPresenceT.UserId = UserId;
			LSX lSX = CreateRequest();
			lSX.request.GetPresence = getPresenceT;
			ResponseCallbackDataT<GetPresenceResponseT> data = new ResponseCallbackDataT<GetPresenceResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PRESENCE, lSX, data);
		}

		public OriginErrorT QueryImage(string ImageId, int Width, int Height, int Timeout, ResponseCallbackT<QueryImageResponseT> Callback)
		{
			QueryImageT queryImageT = new QueryImageT();
			queryImageT.ImageId = ImageId;
			queryImageT.Width = Width;
			queryImageT.Height = Height;
			LSX lSX = CreateRequest();
			lSX.request.QueryImage = queryImageT;
			ResponseCallbackDataT<QueryImageResponseT> data = new ResponseCallbackDataT<QueryImageResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.RESOURCES, lSX, data);
		}

		public OriginErrorT SendGameInvite(ulong UserId, string Invitation, List<ulong> Invitees, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SendInviteT sendInviteT = new SendInviteT();
			sendInviteT.UserId = UserId;
			sendInviteT.Invitation = Invitation;
			sendInviteT.Invitees = Invitees;
			LSX lSX = CreateRequest();
			lSX.request.SendGameInvite = sendInviteT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT GetAuthCode(ulong UserId, string ClientId, string Scope, bool AppendAuthSource, int Timeout, ResponseCallbackT<AuthCodeT> Callback)
		{
			GetAuthCodeT getAuthCodeT = new GetAuthCodeT();
			getAuthCodeT.UserId = UserId;
			getAuthCodeT.ClientId = ClientId;
			getAuthCodeT.Scope = Scope;
			getAuthCodeT.AppendAuthSource = AppendAuthSource;
			LSX lSX = CreateRequest();
			lSX.request.GetAuthCode = getAuthCodeT;
			ResponseCallbackDataT<AuthCodeT> data = new ResponseCallbackDataT<AuthCodeT>(Timeout, Callback);
			return SendRequest(FacilityT.UTILITY, lSX, data);
		}

		public OriginErrorT GetInternetConnectedState(int Timeout, ResponseCallbackT<InternetConnectedStateT> Callback)
		{
			GetInternetConnectedStateT getInternetConnectedState = new GetInternetConnectedStateT();
			LSX lSX = CreateRequest();
			lSX.request.GetInternetConnectedState = getInternetConnectedState;
			ResponseCallbackDataT<InternetConnectedStateT> data = new ResponseCallbackDataT<InternetConnectedStateT>(Timeout, Callback);
			return SendRequest(FacilityT.UTILITY, lSX, data);
		}

		public OriginErrorT GoOnline(int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			GoOnlineT goOnline = new GoOnlineT();
			LSX lSX = CreateRequest();
			lSX.request.GoOnline = goOnline;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT Logout(int UserIndex, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			LogoutT logoutT = new LogoutT();
			logoutT.UserIndex = UserIndex;
			LSX lSX = CreateRequest();
			lSX.request.Logout = logoutT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT BroadcastStart(int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			BroadcastStartT broadcastStart = new BroadcastStartT();
			LSX lSX = CreateRequest();
			lSX.request.BroadcastStart = broadcastStart;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT BroadcastStop(int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			BroadcastStopT broadcastStop = new BroadcastStopT();
			LSX lSX = CreateRequest();
			lSX.request.BroadcastStop = broadcastStop;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT ChallengeResponse(string response, string key, string securityKey, string ProtocolVersion, string ContentId, string Title, string MultiplayerId, string Language, string SdkVersion, int Timeout, ResponseCallbackT<ChallengeAcceptedT> Callback)
		{
			ChallengeResponseT challengeResponseT = new ChallengeResponseT();
			challengeResponseT.response = response;
			challengeResponseT.key = key;
			challengeResponseT.securityKey = securityKey;
			challengeResponseT.ProtocolVersion = ProtocolVersion;
			challengeResponseT.ContentId = ContentId;
			challengeResponseT.Title = Title;
			challengeResponseT.MultiplayerId = MultiplayerId;
			challengeResponseT.Language = Language;
			challengeResponseT.SdkVersion = SdkVersion;
			LSX lSX = CreateRequest();
			lSX.request.ChallengeResponse = challengeResponseT;
			ResponseCallbackDataT<ChallengeAcceptedT> data = new ResponseCallbackDataT<ChallengeAcceptedT>(Timeout, Callback);
			return SendRequest(FacilityT.EALS, lSX, data);
		}

		public OriginErrorT GetConfig(int Timeout, ResponseCallbackT<GetConfigResponseT> Callback)
		{
			GetConfigT getConfig = new GetConfigT();
			LSX lSX = CreateRequest();
			lSX.request.GetConfig = getConfig;
			ResponseCallbackDataT<GetConfigResponseT> data = new ResponseCallbackDataT<GetConfigResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.EbisuSDK, lSX, data);
		}

		public OriginErrorT GetWalletBalance(ulong UserId, string Currency, int Timeout, ResponseCallbackT<GetWalletBalanceResponseT> Callback)
		{
			GetWalletBalanceT getWalletBalanceT = new GetWalletBalanceT();
			getWalletBalanceT.UserId = UserId;
			getWalletBalanceT.Currency = Currency;
			LSX lSX = CreateRequest();
			lSX.request.GetWalletBalance = getWalletBalanceT;
			ResponseCallbackDataT<GetWalletBalanceResponseT> data = new ResponseCallbackDataT<GetWalletBalanceResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT Checkout(ulong UserId, string Currency, List<string> Offers, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			CheckoutT checkoutT = new CheckoutT();
			checkoutT.UserId = UserId;
			checkoutT.Currency = Currency;
			checkoutT.Offers = Offers;
			LSX lSX = CreateRequest();
			lSX.request.Checkout = checkoutT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT QueryOffers(ulong UserId, List<string> FilterCategories, List<string> FilterMasterTitleIds, List<string> FilterOffers, int Timeout, ResponseCallbackT<QueryOffersResponseT> Callback)
		{
			QueryOffersT queryOffersT = new QueryOffersT();
			queryOffersT.UserId = UserId;
			queryOffersT.FilterCategories = FilterCategories;
			queryOffersT.FilterMasterTitleIds = FilterMasterTitleIds;
			queryOffersT.FilterOffers = FilterOffers;
			LSX lSX = CreateRequest();
			lSX.request.QueryOffers = queryOffersT;
			ResponseCallbackDataT<QueryOffersResponseT> data = new ResponseCallbackDataT<QueryOffersResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT QueryContent(ulong UserId, string MultiplayerId, int ContentType, List<string> GameId, int Timeout, ResponseCallbackT<QueryContentResponseT> Callback)
		{
			QueryContentT queryContentT = new QueryContentT();
			queryContentT.UserId = UserId;
			queryContentT.MultiplayerId = MultiplayerId;
			queryContentT.ContentType = ContentType;
			queryContentT.GameId = GameId;
			LSX lSX = CreateRequest();
			lSX.request.QueryContent = queryContentT;
			ResponseCallbackDataT<QueryContentResponseT> data = new ResponseCallbackDataT<QueryContentResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.CONTENT, lSX, data);
		}

		public OriginErrorT QueryEntitlements(ulong UserId, string Group, bool includeChildGroups, List<string> FilterCategories, List<string> FilterOffers, List<string> FilterItems, List<string> FilterGroups, int Timeout, ResponseCallbackT<QueryEntitlementsResponseT> Callback)
		{
			QueryEntitlementsT queryEntitlementsT = new QueryEntitlementsT();
			queryEntitlementsT.UserId = UserId;
			queryEntitlementsT.Group = Group;
			queryEntitlementsT.includeChildGroups = includeChildGroups;
			queryEntitlementsT.FilterCategories = FilterCategories;
			queryEntitlementsT.FilterOffers = FilterOffers;
			queryEntitlementsT.FilterItems = FilterItems;
			queryEntitlementsT.FilterGroups = FilterGroups;
			LSX lSX = CreateRequest();
			lSX.request.QueryEntitlements = queryEntitlementsT;
			ResponseCallbackDataT<QueryEntitlementsResponseT> data = new ResponseCallbackDataT<QueryEntitlementsResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT QueryManifest(ulong UserId, string Manifest, int Timeout, ResponseCallbackT<QueryManifestResponseT> Callback)
		{
			QueryManifestT queryManifestT = new QueryManifestT();
			queryManifestT.UserId = UserId;
			queryManifestT.Manifest = Manifest;
			LSX lSX = CreateRequest();
			lSX.request.QueryManifest = queryManifestT;
			ResponseCallbackDataT<QueryManifestResponseT> data = new ResponseCallbackDataT<QueryManifestResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT ConsumeEntitlement(ulong UserId, int Uses, bool bOveruse, EntitlementT Entitlement, int Timeout, ResponseCallbackT<ConsumeEntitlementResponseT> Callback)
		{
			ConsumeEntitlementT consumeEntitlementT = new ConsumeEntitlementT();
			consumeEntitlementT.UserId = UserId;
			consumeEntitlementT.Uses = Uses;
			consumeEntitlementT.bOveruse = bOveruse;
			consumeEntitlementT.Entitlement = Entitlement;
			LSX lSX = CreateRequest();
			lSX.request.ConsumeEntitlement = consumeEntitlementT;
			ResponseCallbackDataT<ConsumeEntitlementResponseT> data = new ResponseCallbackDataT<ConsumeEntitlementResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.COMMERCE, lSX, data);
		}

		public OriginErrorT GrantAchievement(ulong UserId, ulong PersonaId, string AchievementId, string AchievementCode, int Progress, int Timeout, ResponseCallbackT<AchievementT> Callback)
		{
			GrantAchievementT grantAchievementT = new GrantAchievementT();
			grantAchievementT.UserId = UserId;
			grantAchievementT.PersonaId = PersonaId;
			grantAchievementT.AchievementId = AchievementId;
			grantAchievementT.AchievementCode = AchievementCode;
			grantAchievementT.Progress = Progress;
			LSX lSX = CreateRequest();
			lSX.request.GrantAchievement = grantAchievementT;
			ResponseCallbackDataT<AchievementT> data = new ResponseCallbackDataT<AchievementT>(Timeout, Callback);
			return SendRequest(FacilityT.ACHIEVEMENT, lSX, data);
		}

		public OriginErrorT PostAchievementEvents(ulong UserId, ulong PersonaId, List<EventT> Events, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			PostAchievementEventsT postAchievementEventsT = new PostAchievementEventsT();
			postAchievementEventsT.UserId = UserId;
			postAchievementEventsT.PersonaId = PersonaId;
			postAchievementEventsT.Events = Events;
			LSX lSX = CreateRequest();
			lSX.request.PostAchievementEvents = postAchievementEventsT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.ACHIEVEMENT, lSX, data);
		}

		public OriginErrorT QueryAchievements(ulong UserId, ulong PersonaId, bool All, List<string> GameId, int Timeout, ResponseCallbackT<AchievementSetsT> Callback)
		{
			QueryAchievementsT queryAchievementsT = new QueryAchievementsT();
			queryAchievementsT.UserId = UserId;
			queryAchievementsT.PersonaId = PersonaId;
			queryAchievementsT.All = All;
			queryAchievementsT.GameId = GameId;
			LSX lSX = CreateRequest();
			lSX.request.QueryAchievements = queryAchievementsT;
			ResponseCallbackDataT<AchievementSetsT> data = new ResponseCallbackDataT<AchievementSetsT>(Timeout, Callback);
			return SendRequest(FacilityT.ACHIEVEMENT, lSX, data);
		}

		public OriginErrorT AcceptGameInvite(ulong UserId, ulong OtherId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			AcceptInviteT acceptInviteT = new AcceptInviteT();
			acceptInviteT.UserId = UserId;
			acceptInviteT.OtherId = OtherId;
			LSX lSX = CreateRequest();
			lSX.request.AcceptGameInvite = acceptInviteT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT SetDownloaderUtilization(float Utilization, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SetDownloaderUtilizationT setDownloaderUtilizationT = new SetDownloaderUtilizationT();
			setDownloaderUtilizationT.Utilization = Utilization;
			LSX lSX = CreateRequest();
			lSX.request.SetDownloaderUtilization = setDownloaderUtilizationT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT IsProgressiveInstallationAvailable(string ItemId, int Timeout, ResponseCallbackT<IsProgressiveInstallationAvailableResponseT> Callback)
		{
			IsProgressiveInstallationAvailableT isProgressiveInstallationAvailableT = new IsProgressiveInstallationAvailableT();
			isProgressiveInstallationAvailableT.ItemId = ItemId;
			LSX lSX = CreateRequest();
			lSX.request.IsProgressiveInstallationAvailable = isProgressiveInstallationAvailableT;
			ResponseCallbackDataT<IsProgressiveInstallationAvailableResponseT> data = new ResponseCallbackDataT<IsProgressiveInstallationAvailableResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT AreChunksInstalled(string ItemId, List<int> ChunkIds, int Timeout, ResponseCallbackT<AreChunksInstalledResponseT> Callback)
		{
			AreChunksInstalledT areChunksInstalledT = new AreChunksInstalledT();
			areChunksInstalledT.ItemId = ItemId;
			areChunksInstalledT.ChunkIds = ChunkIds;
			LSX lSX = CreateRequest();
			lSX.request.AreChunksInstalled = areChunksInstalledT;
			ResponseCallbackDataT<AreChunksInstalledResponseT> data = new ResponseCallbackDataT<AreChunksInstalledResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT QueryChunkStatus(string ItemId, int Timeout, ResponseCallbackT<QueryChunkStatusResponseT> Callback)
		{
			QueryChunkStatusT queryChunkStatusT = new QueryChunkStatusT();
			queryChunkStatusT.ItemId = ItemId;
			LSX lSX = CreateRequest();
			lSX.request.QueryChunkStatus = queryChunkStatusT;
			ResponseCallbackDataT<QueryChunkStatusResponseT> data = new ResponseCallbackDataT<QueryChunkStatusResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT IsFileDownloaded(string ItemId, string Filepath, int Timeout, ResponseCallbackT<IsFileDownloadedResponseT> Callback)
		{
			IsFileDownloadedT isFileDownloadedT = new IsFileDownloadedT();
			isFileDownloadedT.ItemId = ItemId;
			isFileDownloadedT.Filepath = Filepath;
			LSX lSX = CreateRequest();
			lSX.request.IsFileDownloaded = isFileDownloadedT;
			ResponseCallbackDataT<IsFileDownloadedResponseT> data = new ResponseCallbackDataT<IsFileDownloadedResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT SetChunkPriority(string ItemId, List<int> ChunkIds, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SetChunkPriorityT setChunkPriorityT = new SetChunkPriorityT();
			setChunkPriorityT.ItemId = ItemId;
			setChunkPriorityT.ChunkIds = ChunkIds;
			LSX lSX = CreateRequest();
			lSX.request.SetChunkPriority = setChunkPriorityT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT GetChunkPriority(string ItemId, int Timeout, ResponseCallbackT<GetChunkPriorityResponseT> Callback)
		{
			GetChunkPriorityT getChunkPriorityT = new GetChunkPriorityT();
			getChunkPriorityT.ItemId = ItemId;
			LSX lSX = CreateRequest();
			lSX.request.GetChunkPriority = getChunkPriorityT;
			ResponseCallbackDataT<GetChunkPriorityResponseT> data = new ResponseCallbackDataT<GetChunkPriorityResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT QueryChunkFiles(string ItemId, int ChunkId, int Timeout, ResponseCallbackT<QueryChunkFilesResponseT> Callback)
		{
			QueryChunkFilesT queryChunkFilesT = new QueryChunkFilesT();
			queryChunkFilesT.ItemId = ItemId;
			queryChunkFilesT.ChunkId = ChunkId;
			LSX lSX = CreateRequest();
			lSX.request.QueryChunkFiles = queryChunkFilesT;
			ResponseCallbackDataT<QueryChunkFilesResponseT> data = new ResponseCallbackDataT<QueryChunkFilesResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT CreateChunk(string ItemId, List<string> Files, int Timeout, ResponseCallbackT<CreateChunkResponseT> Callback)
		{
			CreateChunkT createChunkT = new CreateChunkT();
			createChunkT.ItemId = ItemId;
			createChunkT.Files = Files;
			LSX lSX = CreateRequest();
			lSX.request.CreateChunk = createChunkT;
			ResponseCallbackDataT<CreateChunkResponseT> data = new ResponseCallbackDataT<CreateChunkResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.PROGRESSIVE_INSTALLATION, lSX, data);
		}

		public OriginErrorT RestartGame(ulong UserId, RestartOptionsT Options, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			RestartGameT restartGameT = new RestartGameT();
			restartGameT.UserId = UserId;
			restartGameT.Options = Options;
			LSX lSX = CreateRequest();
			lSX.request.RestartGame = restartGameT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.CONTENT, lSX, data);
		}

		public OriginErrorT StartGame(string GameId, string MultiplayerId, string CommandLine, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			StartGameT startGameT = new StartGameT();
			startGameT.GameId = GameId;
			startGameT.MultiplayerId = MultiplayerId;
			startGameT.CommandLine = CommandLine;
			LSX lSX = CreateRequest();
			lSX.request.StartGame = startGameT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.CONTENT, lSX, data);
		}

		public OriginErrorT SendGameMessage(string GameId, string Message, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SendGameMessageT sendGameMessageT = new SendGameMessageT();
			sendGameMessageT.GameId = GameId;
			sendGameMessageT.Message = Message;
			LSX lSX = CreateRequest();
			lSX.request.SendGameMessage = sendGameMessageT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT ExtendTrial(ulong UserId, string RequestTicket, int TicketEngine, int Timeout, ResponseCallbackT<ExtendTrialResponseT> Callback)
		{
			ExtendTrialT extendTrialT = new ExtendTrialT();
			extendTrialT.UserId = UserId;
			extendTrialT.RequestTicket = RequestTicket;
			extendTrialT.TicketEngine = TicketEngine;
			LSX lSX = CreateRequest();
			lSX.request.ExtendTrial = extendTrialT;
			ResponseCallbackDataT<ExtendTrialResponseT> data = new ResponseCallbackDataT<ExtendTrialResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.SDK, lSX, data);
		}

		public OriginErrorT QueryGroup(ulong UserId, string GroupId, int Timeout, ResponseCallbackT<QueryGroupResponseT> Callback)
		{
			QueryGroupT queryGroupT = new QueryGroupT();
			queryGroupT.UserId = UserId;
			queryGroupT.GroupId = GroupId;
			LSX lSX = CreateRequest();
			lSX.request.QueryGroup = queryGroupT;
			ResponseCallbackDataT<QueryGroupResponseT> data = new ResponseCallbackDataT<QueryGroupResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT GetGroupInfo(ulong UserId, string GroupId, int Timeout, ResponseCallbackT<GroupInfoT> Callback)
		{
			GetGroupInfoT getGroupInfoT = new GetGroupInfoT();
			getGroupInfoT.UserId = UserId;
			getGroupInfoT.GroupId = GroupId;
			LSX lSX = CreateRequest();
			lSX.request.GetGroupInfo = getGroupInfoT;
			ResponseCallbackDataT<GroupInfoT> data = new ResponseCallbackDataT<GroupInfoT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT SendGroupGameInvite(ulong UserId, string Message, List<ulong> Invitees, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SendGroupGameInviteT sendGroupGameInviteT = new SendGroupGameInviteT();
			sendGroupGameInviteT.UserId = UserId;
			sendGroupGameInviteT.Message = Message;
			sendGroupGameInviteT.Invitees = Invitees;
			LSX lSX = CreateRequest();
			lSX.request.SendGroupGameInvite = sendGroupGameInviteT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT CreateGroup(ulong UserId, string GroupName, GroupTypeT GroupType, int Timeout, ResponseCallbackT<GroupInfoT> Callback)
		{
			CreateGroupT createGroupT = new CreateGroupT();
			createGroupT.UserId = UserId;
			createGroupT.GroupName = GroupName;
			createGroupT.GroupType = GroupType;
			LSX lSX = CreateRequest();
			lSX.request.CreateGroup = createGroupT;
			ResponseCallbackDataT<GroupInfoT> data = new ResponseCallbackDataT<GroupInfoT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT EnterGroup(ulong UserId, string GroupId, int Timeout, ResponseCallbackT<GroupInfoT> Callback)
		{
			EnterGroupT enterGroupT = new EnterGroupT();
			enterGroupT.UserId = UserId;
			enterGroupT.GroupId = GroupId;
			LSX lSX = CreateRequest();
			lSX.request.EnterGroup = enterGroupT;
			ResponseCallbackDataT<GroupInfoT> data = new ResponseCallbackDataT<GroupInfoT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT LeaveGroup(ulong UserId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			LeaveGroupT leaveGroupT = new LeaveGroupT();
			leaveGroupT.UserId = UserId;
			LSX lSX = CreateRequest();
			lSX.request.LeaveGroup = leaveGroupT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT InviteUsersToGroup(ulong UserId, List<ulong> FriendId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			InviteUsersToGroupT inviteUsersToGroupT = new InviteUsersToGroupT();
			inviteUsersToGroupT.UserId = UserId;
			inviteUsersToGroupT.FriendId = FriendId;
			LSX lSX = CreateRequest();
			lSX.request.InviteUsersToGroup = inviteUsersToGroupT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT RemoveUsersFromGroup(ulong UserId, List<ulong> FriendId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			RemoveUsersFromGroupT removeUsersFromGroupT = new RemoveUsersFromGroupT();
			removeUsersFromGroupT.UserId = UserId;
			removeUsersFromGroupT.FriendId = FriendId;
			LSX lSX = CreateRequest();
			lSX.request.RemoveUsersFromGroup = removeUsersFromGroupT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT SendChatMessage(ulong FromId, ulong ToId, string Thread, string Message, string GroupId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			SendChatMessageT sendChatMessageT = new SendChatMessageT();
			sendChatMessageT.FromId = FromId;
			sendChatMessageT.ToId = ToId;
			sendChatMessageT.Thread = Thread;
			sendChatMessageT.Message = Message;
			sendChatMessageT.GroupId = GroupId;
			LSX lSX = CreateRequest();
			lSX.request.SendChatMessage = sendChatMessageT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT EnableVoip(bool Enable, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			EnableVoipT enableVoipT = new EnableVoipT();
			enableVoipT.Enable = Enable;
			LSX lSX = CreateRequest();
			lSX.request.EnableVoip = enableVoipT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT GetVoipStatus(int Timeout, ResponseCallbackT<GetVoipStatusResponseT> Callback)
		{
			GetVoipStatusT getVoipStatus = new GetVoipStatusT();
			LSX lSX = CreateRequest();
			lSX.request.GetVoipStatus = getVoipStatus;
			ResponseCallbackDataT<GetVoipStatusResponseT> data = new ResponseCallbackDataT<GetVoipStatusResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT MuteUser(bool bMute, string GroupId, ulong UserId, int Timeout, ResponseCallbackT<ErrorSuccessT> Callback)
		{
			MuteUserT muteUserT = new MuteUserT();
			muteUserT.bMute = bMute;
			muteUserT.GroupId = GroupId;
			muteUserT.UserId = UserId;
			LSX lSX = CreateRequest();
			lSX.request.MuteUser = muteUserT;
			ResponseCallbackDataT<ErrorSuccessT> data = new ResponseCallbackDataT<ErrorSuccessT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}

		public OriginErrorT QueryMuteState(string GroupId, int Timeout, ResponseCallbackT<QueryMuteStateResponseT> Callback)
		{
			QueryMuteStateT queryMuteStateT = new QueryMuteStateT();
			queryMuteStateT.GroupId = GroupId;
			LSX lSX = CreateRequest();
			lSX.request.QueryMuteState = queryMuteStateT;
			ResponseCallbackDataT<QueryMuteStateResponseT> data = new ResponseCallbackDataT<QueryMuteStateResponseT>(Timeout, Callback);
			return SendRequest(FacilityT.XMPP, lSX, data);
		}
	}
}
