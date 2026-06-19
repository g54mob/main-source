using System.Xml.Serialization;

namespace Origin.Data
{
	public class Request
	{
		[XmlAttribute]
		public string recipient;

		[XmlAttribute]
		public int id;

		[XmlElement(ElementName = "GetProfile")]
		public GetProfileT GetProfile;

		[XmlElement(ElementName = "GetSettings")]
		public GetSettingsT GetSettings;

		[XmlElement(ElementName = "GetAllGameInfo")]
		public GetAllGameInfoT GetAllGameInfo;

		[XmlElement(ElementName = "ShowIGOWindow")]
		public ShowIGOWindowT ShowIGOWindow;

		[XmlElement(ElementName = "ShowIGO")]
		public ShowIGOT ShowIGO;

		[XmlElement(ElementName = "GetUTCTime")]
		public GetUTCTimeT GetUTCTime;

		[XmlElement(ElementName = "QueryFriends")]
		public QueryFriendsT QueryFriends;

		[XmlElement(ElementName = "RequestFriend")]
		public RequestFriendT RequestFriend;

		[XmlElement(ElementName = "RemoveFriend")]
		public RemoveFriendT RemoveFriend;

		[XmlElement(ElementName = "AcceptFriendInvite")]
		public AcceptFriendInviteT AcceptFriendInvite;

		[XmlElement(ElementName = "GetBlockList")]
		public GetBlockListT GetBlockList;

		[XmlElement(ElementName = "BlockUser")]
		public BlockUserT BlockUser;

		[XmlElement(ElementName = "UnblockUser")]
		public UnblockUserT UnblockUser;

		[XmlElement(ElementName = "GetUserProfileByEmailorEAID")]
		public GetUserProfileByEmailorEAIDT GetUserProfileByEAID;

		[XmlElement(ElementName = "QueryAreFriends")]
		public QueryAreFriendsT QueryAreFriends;

		[XmlElement(ElementName = "QueryPresence")]
		public QueryPresenceT QueryPresence;

		[XmlElement(ElementName = "SetPresence")]
		public SetPresenceT SetPresence;

		[XmlElement(ElementName = "SetPresenceVisibility")]
		public SetPresenceVisibilityT SetPresenceVisibility;

		[XmlElement(ElementName = "GetPresenceVisibility")]
		public GetPresenceVisibilityT GetPresenceVisibility;

		[XmlElement(ElementName = "GetPresence")]
		public GetPresenceT GetPresence;

		[XmlElement(ElementName = "QueryImage")]
		public QueryImageT QueryImage;

		[XmlElement(ElementName = "SendInvite")]
		public SendInviteT SendGameInvite;

		[XmlElement(ElementName = "GetAuthCode")]
		public GetAuthCodeT GetAuthCode;

		[XmlElement(ElementName = "GetInternetConnectedState")]
		public GetInternetConnectedStateT GetInternetConnectedState;

		[XmlElement(ElementName = "GoOnline")]
		public GoOnlineT GoOnline;

		[XmlElement(ElementName = "Logout")]
		public LogoutT Logout;

		[XmlElement(ElementName = "BroadcastStart")]
		public BroadcastStartT BroadcastStart;

		[XmlElement(ElementName = "BroadcastStop")]
		public BroadcastStopT BroadcastStop;

		[XmlElement(ElementName = "ChallengeResponse")]
		public ChallengeResponseT ChallengeResponse;

		[XmlElement(ElementName = "GetConfig")]
		public GetConfigT GetConfig;

		[XmlElement(ElementName = "GetWalletBalance")]
		public GetWalletBalanceT GetWalletBalance;

		[XmlElement(ElementName = "Checkout")]
		public CheckoutT Checkout;

		[XmlElement(ElementName = "QueryOffers")]
		public QueryOffersT QueryOffers;

		[XmlElement(ElementName = "QueryContent")]
		public QueryContentT QueryContent;

		[XmlElement(ElementName = "QueryEntitlements")]
		public QueryEntitlementsT QueryEntitlements;

		[XmlElement(ElementName = "QueryManifest")]
		public QueryManifestT QueryManifest;

		[XmlElement(ElementName = "ConsumeEntitlement")]
		public ConsumeEntitlementT ConsumeEntitlement;

		[XmlElement(ElementName = "GrantAchievement")]
		public GrantAchievementT GrantAchievement;

		[XmlElement(ElementName = "PostAchievementEvents")]
		public PostAchievementEventsT PostAchievementEvents;

		[XmlElement(ElementName = "QueryAchievements")]
		public QueryAchievementsT QueryAchievements;

		[XmlElement(ElementName = "AcceptInvite")]
		public AcceptInviteT AcceptGameInvite;

		[XmlElement(ElementName = "SetDownloaderUtilization")]
		public SetDownloaderUtilizationT SetDownloaderUtilization;

		[XmlElement(ElementName = "IsProgressiveInstallationAvailable")]
		public IsProgressiveInstallationAvailableT IsProgressiveInstallationAvailable;

		[XmlElement(ElementName = "AreChunksInstalled")]
		public AreChunksInstalledT AreChunksInstalled;

		[XmlElement(ElementName = "QueryChunkStatus")]
		public QueryChunkStatusT QueryChunkStatus;

		[XmlElement(ElementName = "IsFileDownloaded")]
		public IsFileDownloadedT IsFileDownloaded;

		[XmlElement(ElementName = "SetChunkPriority")]
		public SetChunkPriorityT SetChunkPriority;

		[XmlElement(ElementName = "GetChunkPriority")]
		public GetChunkPriorityT GetChunkPriority;

		[XmlElement(ElementName = "QueryChunkFiles")]
		public QueryChunkFilesT QueryChunkFiles;

		[XmlElement(ElementName = "CreateChunk")]
		public CreateChunkT CreateChunk;

		[XmlElement(ElementName = "RestartGame")]
		public RestartGameT RestartGame;

		[XmlElement(ElementName = "StartGame")]
		public StartGameT StartGame;

		[XmlElement(ElementName = "SendGameMessage")]
		public SendGameMessageT SendGameMessage;

		[XmlElement(ElementName = "ExtendTrial")]
		public ExtendTrialT ExtendTrial;

		[XmlElement(ElementName = "QueryGroup")]
		public QueryGroupT QueryGroup;

		[XmlElement(ElementName = "GetGroupInfo")]
		public GetGroupInfoT GetGroupInfo;

		[XmlElement(ElementName = "SendGroupGameInvite")]
		public SendGroupGameInviteT SendGroupGameInvite;

		[XmlElement(ElementName = "CreateGroup")]
		public CreateGroupT CreateGroup;

		[XmlElement(ElementName = "EnterGroup")]
		public EnterGroupT EnterGroup;

		[XmlElement(ElementName = "LeaveGroup")]
		public LeaveGroupT LeaveGroup;

		[XmlElement(ElementName = "InviteUsersToGroup")]
		public InviteUsersToGroupT InviteUsersToGroup;

		[XmlElement(ElementName = "RemoveUsersFromGroup")]
		public RemoveUsersFromGroupT RemoveUsersFromGroup;

		[XmlElement(ElementName = "SendChatMessage")]
		public SendChatMessageT SendChatMessage;

		[XmlElement(ElementName = "EnableVoip")]
		public EnableVoipT EnableVoip;

		[XmlElement(ElementName = "GetVoipStatus")]
		public GetVoipStatusT GetVoipStatus;

		[XmlElement(ElementName = "MuteUser")]
		public MuteUserT MuteUser;

		[XmlElement(ElementName = "QueryMuteState")]
		public QueryMuteStateT QueryMuteState;
	}
}
