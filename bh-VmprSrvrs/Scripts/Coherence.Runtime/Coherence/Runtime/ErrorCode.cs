using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Coherence.Runtime
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ErrorCode
	{
		Unknown = 0,
		[EnumMember(Value = "ERR_TOO_MANY_REQUESTS")]
		TooManyRequests = 1,
		[EnumMember(Value = "ERR_PROJECT_NOT_FOUND")]
		ProjectNotFound = 2,
		[EnumMember(Value = "ERR_SCHEMA_NOT_FOUND")]
		SchemaNotFound = 3,
		[EnumMember(Value = "ERR_RS_VERSION_NOT_FOUND")]
		RSVersionNotFound = 4,
		[EnumMember(Value = "ERR_SIM_NOT_FOUND")]
		SimNotFound = 5,
		[EnumMember(Value = "ERR_INVALID_CREDENTIALS")]
		InvalidCredentials = 6,
		[EnumMember(Value = "ERR_ROOMS_SIMULATORS_NOT_ENABLED")]
		RoomsSimulatorsNotEnabled = 7,
		[EnumMember(Value = "ERR_ROOMS_SIMULATOR_NOT_UPLOADED")]
		RoomsSimulatorsNotUploaded = 8,
		[EnumMember(Value = "ERR_ROOMS_VERSION_NOT_FOUND")]
		RoomsVersionNotFound = 9,
		[EnumMember(Value = "ERR_ROOMS_SCHEMA_NOT_FOUND")]
		RoomsSchemaNotFound = 10,
		[EnumMember(Value = "ERR_ROOMS_REGION_NOT_FOUND")]
		RoomsRegionNotFound = 11,
		[EnumMember(Value = "ERR_ROOMS_INVALID_TAG_OR_KV")]
		RoomsInvalidTagOrKeyValueEntry = 12,
		[EnumMember(Value = "ERR_ROOMS_CCU_LIMIT_EXCEEDED")]
		RoomsCCULimit = 13,
		[EnumMember(Value = "ERR_ROOMS_NOT_FOUND")]
		RoomsNotFound = 14,
		[EnumMember(Value = "ERR_ROOMS_INVALID_SECRET")]
		RoomsInvalidSecret = 15,
		[EnumMember(Value = "ERR_ROOMS_INVALID_MAX_PLAYERS")]
		RoomsInvalidMaxPlayers = 16,
		[EnumMember(Value = "ERR_INVALID_MM_CONFIG")]
		InvalidMatchMakingConfig = 17,
		[EnumMember(Value = "ERR_CLIENT_PERMISSION")]
		ClientPermission = 18,
		[EnumMember(Value = "ERR_CREDIT_LIMIT_EXCEEDED")]
		CreditLimit = 19,
		[EnumMember(Value = "ERR_IN_DEPLOYMENT")]
		InDeployment = 20,
		[EnumMember(Value = "ERR_INVALID_ROOM_LIMIT")]
		InvalidRoomLimit = 21,
		[EnumMember(Value = "ERR_NOT_ENABLED")]
		FeatureDisabled = 22,
		[EnumMember(Value = "ERR_LOBBY_REGION_NOT_FOUND")]
		LobbyRegionNotFound = 23,
		[EnumMember(Value = "ERR_LOBBY_NOT_FOUND")]
		LobbyNotFound = 24,
		[EnumMember(Value = "ERR_LOBBY_ATTR_INVALID")]
		LobbyInvalidAttribute = 25,
		[EnumMember(Value = "ERR_LOBBY_ATTR_SIZE_LIMIT")]
		LobbyAttributeSizeLimit = 26,
		[EnumMember(Value = "ERR_LOBBY_NAME_ALREADY_EXISTS")]
		LobbyNameAlreadyExists = 27,
		[EnumMember(Value = "ERR_LOBBY_NAME_TOO_LONG")]
		LobbyNameTooLong = 28,
		[EnumMember(Value = "ERR_LOBBY_TAG_TOO_LONG")]
		LobbyTagTooLong = 29,
		[EnumMember(Value = "ERR_LOBBY_INVALID_SECRET")]
		LobbyInvalidSecret = 30,
		[EnumMember(Value = "ERR_LOBBY_FULL")]
		LobbyFull = 31,
		[EnumMember(Value = "ERR_LOBBY_ACTION_NOT_ALLOWED")]
		LobbyActionNotAllowed = 32,
		[EnumMember(Value = "ERR_LOBBY_INVALID_SEARCH_FILTER")]
		LobbyInvalidFilter = 33,
		[EnumMember(Value = "ERR_LOBBY_NOT_COMPATIBLE")]
		LobbyNotCompatible = 34,
		[EnumMember(Value = "ERR_LOBBY_SIMULATORS_NOT_ENABLED")]
		LobbySimulatorNotEnabled = 35,
		[EnumMember(Value = "ERR_LOBBY_SIMULATOR_NOT_UPLOADED")]
		LobbySimulatorNotUploaded = 36,
		[EnumMember(Value = "ERR_LOBBY_PLAYER_JOIN_LIMIT")]
		LobbyLimit = 37,
		[EnumMember(Value = "ERR_INVALID_USER_NAME")]
		LoginInvalidUsername = 38,
		[Obsolete("Use LoginInvalidPassword instead.")]
		[Deprecated("3/2025", 1, 6, 0, Reason = "Replaced by LoginInvalidPassword.")]
		[EnumMember(Value = "ERR_WEAK_PASSWORD")]
		LoginWeakPassword = 39,
		[EnumMember(Value = "ERR_RESTRICTED_MODE_CAP_REACHED")]
		RestrictedModeCapReached = 40,
		[EnumMember(Value = "ERR_MULTI_SIM_NOT_LISTENING")]
		MultiSimNotListening = 41,
		[EnumMember(Value = "ERR_DISABLED")]
		LoginDisabled = 42,
		[EnumMember(Value = "ERR_INVALID_APP")]
		LoginInvalidApp = 43,
		[EnumMember(Value = "ERR_NOT_FOUND")]
		LoginNotFound = 44,
		[EnumMember(Value = "ERR_INVALID_PASSWORD")]
		LoginInvalidPassword = 45,
		[EnumMember(Value = "ERR_CODE_EXPIRED")]
		OneTimeCodeExpired = 46,
		[EnumMember(Value = "ERR_CODE_NOT_FOUND")]
		OneTimeCodeNotFound = 47,
		[EnumMember(Value = "ERR_IDENTITY_LIMIT")]
		IdentityLimit = 48,
		[EnumMember(Value = "ERR_IDENTITY_NOT_FOUND")]
		IdentityNotFound = 49,
		[EnumMember(Value = "ERR_IDENTITY_REMOVAL")]
		IdentityRemoval = 50,
		[EnumMember(Value = "ERR_IDENTITY_TAKEN")]
		IdentityTaken = 51,
		[EnumMember(Value = "ERR_IDENTITY_TOTAL_LIMIT")]
		IdentityTotalLimit = 52,
		[EnumMember(Value = "ERR_INVALID_CONFIG")]
		InvalidConfig = 53,
		[EnumMember(Value = "ERR_INVALID_INPUT")]
		InvalidInput = 54,
		[EnumMember(Value = "ERR_PASSWORD_NOT_SET")]
		PasswordNotSet = 55,
		[EnumMember(Value = "ERR_USERNAME_NOT_AVAILABLE")]
		UsernameNotAvailable = 56
	}
}
