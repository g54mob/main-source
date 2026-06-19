using System.Xml.Serialization;

namespace Origin.Data
{
	public class Response
	{
		[XmlAttribute]
		public int id;

		[XmlAttribute]
		public string sender;

		[XmlElement(ElementName = "ErrorSuccess")]
		public ErrorSuccessT ErrorSuccess;

		[XmlElement(ElementName = "GroupInfo")]
		public GroupInfoT GroupInfo;

		[XmlElement(ElementName = "GetProfileResponse")]
		public GetProfileResponseT GetProfileResponse;

		[XmlElement(ElementName = "GetSettingsResponse")]
		public GetSettingsResponseT GetSettingsResponse;

		[XmlElement(ElementName = "GetAllGameInfoResponse")]
		public GetAllGameInfoResponseT GetAllGameInfoResponse;

		[XmlElement(ElementName = "GetUTCTimeResponse")]
		public GetUTCTimeResponseT GetUTCTimeResponse;

		[XmlElement(ElementName = "QueryFriendsResponse")]
		public QueryFriendsResponseT QueryFriendsResponse;

		[XmlElement(ElementName = "GetBlockListResponse")]
		public GetBlockListResponseT GetBlockListResponse;

		[XmlElement(ElementName = "GetUserProfileByEmailorEAIDResponse")]
		public GetUserProfileByEmailorEAIDResponseT GetUserProfileByEmailorEAIDResponse;

		[XmlElement(ElementName = "QueryAreFriendsResponse")]
		public QueryAreFriendsResponseT QueryAreFriendsResponse;

		[XmlElement(ElementName = "QueryPresenceResponse")]
		public QueryPresenceResponseT QueryPresenceResponse;

		[XmlElement(ElementName = "GetPresenceVisibilityResponse")]
		public GetPresenceVisibilityResponseT GetPresenceVisibilityResponse;

		[XmlElement(ElementName = "GetPresenceResponse")]
		public GetPresenceResponseT GetPresenceResponse;

		[XmlElement(ElementName = "QueryImageResponse")]
		public QueryImageResponseT QueryImageResponse;

		[XmlElement(ElementName = "AuthCode")]
		public AuthCodeT AuthCode;

		[XmlElement(ElementName = "InternetConnectedState")]
		public InternetConnectedStateT InternetConnectedState;

		[XmlElement(ElementName = "ChallengeAccepted")]
		public ChallengeAcceptedT ChallengeAccepted;

		[XmlElement(ElementName = "GetConfigResponse")]
		public GetConfigResponseT GetConfigResponse;

		[XmlElement(ElementName = "GetWalletBalanceResponse")]
		public GetWalletBalanceResponseT GetWalletBalanceResponse;

		[XmlElement(ElementName = "QueryOffersResponse")]
		public QueryOffersResponseT QueryOffersResponse;

		[XmlElement(ElementName = "QueryContentResponse")]
		public QueryContentResponseT QueryContentResponse;

		[XmlElement(ElementName = "QueryEntitlementsResponse")]
		public QueryEntitlementsResponseT QueryEntitlementsResponse;

		[XmlElement(ElementName = "QueryManifestResponse")]
		public QueryManifestResponseT QueryManifestResponse;

		[XmlElement(ElementName = "ConsumeEntitlementResponse")]
		public ConsumeEntitlementResponseT ConsumeEntitlementResponse;

		[XmlElement(ElementName = "Achievement")]
		public AchievementT Achievement;

		[XmlElement(ElementName = "AchievementSets")]
		public AchievementSetsT AchievementSets;

		[XmlElement(ElementName = "IsProgressiveInstallationAvailableResponse")]
		public IsProgressiveInstallationAvailableResponseT IsProgressiveInstallationAvailableResponse;

		[XmlElement(ElementName = "AreChunksInstalledResponse")]
		public AreChunksInstalledResponseT AreChunksInstalledResponse;

		[XmlElement(ElementName = "QueryChunkStatusResponse")]
		public QueryChunkStatusResponseT QueryChunkStatusResponse;

		[XmlElement(ElementName = "IsFileDownloadedResponse")]
		public IsFileDownloadedResponseT IsFileDownloadedResponse;

		[XmlElement(ElementName = "GetChunkPriorityResponse")]
		public GetChunkPriorityResponseT GetChunkPriorityResponse;

		[XmlElement(ElementName = "QueryChunkFilesResponse")]
		public QueryChunkFilesResponseT QueryChunkFilesResponse;

		[XmlElement(ElementName = "CreateChunkResponse")]
		public CreateChunkResponseT CreateChunkResponse;

		[XmlElement(ElementName = "ExtendTrialResponse")]
		public ExtendTrialResponseT ExtendTrialResponse;

		[XmlElement(ElementName = "QueryGroupResponse")]
		public QueryGroupResponseT QueryGroupResponse;

		[XmlElement(ElementName = "GetVoipStatusResponse")]
		public GetVoipStatusResponseT GetVoipStatusResponse;

		[XmlElement(ElementName = "QueryMuteStateResponse")]
		public QueryMuteStateResponseT QueryMuteStateResponse;
	}
}
