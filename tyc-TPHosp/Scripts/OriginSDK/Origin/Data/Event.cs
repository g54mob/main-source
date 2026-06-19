using System.Xml.Serialization;

namespace Origin.Data
{
	public class Event
	{
		[XmlAttribute]
		public string sender;

		[XmlElement(ElementName = "ShowIGOWindowEvent")]
		public ShowIGOWindowEventT ShowIGOWindowEvent;

		[XmlElement(ElementName = "IGOUnavailable")]
		public IGOUnavailableT IGOUnavailableEvent;

		[XmlElement(ElementName = "MinimizeRequest")]
		public MinimizeRequestT MinimizeRequest;

		[XmlElement(ElementName = "RestoreRequest")]
		public RestoreRequestT RestoreRequest;

		[XmlElement(ElementName = "QueryFriendsResponse")]
		public QueryFriendsResponseT FriendsEvent;

		[XmlElement(ElementName = "GetPresenceResponse")]
		public GetPresenceResponseT PresenceEvent;

		[XmlElement(ElementName = "CurrentUserPresenceEvent")]
		public CurrentUserPresenceEventT CurrentUserPresenceEvent;

		[XmlElement(ElementName = "IGOEvent")]
		public IGOEventT IGOEvent;

		[XmlElement(ElementName = "BroadcastEvent")]
		public BroadcastEventT BroadcastEvent;

		[XmlElement(ElementName = "MultiplayerInvite")]
		public MultiplayerInviteT GameInviteEvent;

		[XmlElement(ElementName = "MultiplayerInvitePending")]
		public MultiplayerInvitePendingT GameInvitePendingEvent;

		[XmlElement(ElementName = "Login")]
		public LoginT LoginEvent;

		[XmlElement(ElementName = "ProfileEvent")]
		public ProfileEventT ProfileEvent;

		[XmlElement(ElementName = "PurchaseEvent")]
		public PurchaseEventT PurchaseEvent;

		[XmlElement(ElementName = "ChatMessageEvent")]
		public ChatMessageEventT ChatMessageEvent;

		[XmlElement(ElementName = "CoreContentUpdated")]
		public CoreContentUpdatedT ContentEvent;

		[XmlElement(ElementName = "BlockListUpdated")]
		public BlockListUpdatedT BlockListUpdatedEvent;

		[XmlElement(ElementName = "OnlineStatusEvent")]
		public OnlineStatusEventT OnlineStatusEvent;

		[XmlElement(ElementName = "PresenceVisibilityEvent")]
		public PresenceVisibilityEventT PresenceVisibilityEvent;

		[XmlElement(ElementName = "UserInvitedEvent")]
		public UserInvitedEventT UserInvitedEvent;

		[XmlElement(ElementName = "Challenge")]
		public ChallengeT Challenge;

		[XmlElement(ElementName = "QueryEntitlementsResponse")]
		public QueryEntitlementsResponseT EntitlementEvent;

		[XmlElement(ElementName = "AchievementSets")]
		public AchievementSetsT AchievementEvent;

		[XmlElement(ElementName = "ChunkStatus")]
		public ChunkStatusT ChunkStatus;

		[XmlElement(ElementName = "GameMessageEvent")]
		public GameMessageEventT GameMessageEvent;

		[XmlElement(ElementName = "GroupEvent")]
		public GroupEventT GroupEvent;

		[XmlElement(ElementName = "GroupEnterEvent")]
		public GroupEnterEventT GroupEnterEvent;

		[XmlElement(ElementName = "GroupLeaveEvent")]
		public GroupLeaveEventT GroupLeaveEvent;

		[XmlElement(ElementName = "GroupInviteEvent")]
		public GroupInviteEventT GroupInviteEvent;

		[XmlElement(ElementName = "VoipStatusEvent")]
		public VoipStatusEventT VoipStatusEvent;

		[XmlElement(ElementName = "ChatStateUpdateEvent")]
		public ChatStateUpdateEventT ChatStateUpdateEvent;
	}
}
