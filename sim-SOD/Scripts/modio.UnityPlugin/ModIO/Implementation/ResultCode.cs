using System.Collections.Generic;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation
{
	internal static class ResultCode
	{
		public const uint Success = 0u;

		public const uint Unknown = 1u;

		public const uint Init_NotYetInitialized = 20000u;

		public const uint Init_FailedToLoadConfig = 20010u;

		public const uint Init_UserDataFailedToInitialize = 20020u;

		public const uint Init_PersistentDataFailedToInitialize = 20021u;

		public const uint Init_TemporaryDataFailedToInitialize = 20022u;

		public const uint Settings_InvalidServerURL = 20050u;

		public const uint Settings_InvalidGameId = 20051u;

		public const uint Settings_InvalidGameKey = 20052u;

		public const uint Settings_InvalidLanguageCode = 20053u;

		public const uint Settings_UploadsDisabled = 20054u;

		public const uint User_NotAuthenticated = 20100u;

		public const uint User_InvalidToken = 20101u;

		public const uint User_InvalidEmailAddress = 20102u;

		public const uint User_AlreadyAuthenticated = 20103u;

		public const uint User_NotRemoved = 20104u;

		public const uint InvalidParameter_PaginationParams = 20201u;

		public const uint InvalidParameter_ReportNotReady = 20202u;

		public const uint InvalidParameter_ModMetadataTooLarge = 20203u;

		public const uint InvalidParameter_BadCreationToken = 20204u;

		public const uint InvalidParameter_DescriptionTooLarge = 20205u;

		public const uint InvalidParameter_ChangeLogTooLarge = 20206u;

		public const uint InvalidParameter_ModProfileRequiredFieldsNotSet = 20210u;

		public const uint InvalidParameter_ModSummaryTooLarge = 20211u;

		public const uint InvalidParameter_ModLogoTooLarge = 20212u;

		public const uint InvalidParameter_CantBeNull = 20213u;

		public const uint InvalidParameter_MissingModId = 20214u;

		public const uint InvalidParameter_TooMany = 20215u;

		public const uint InvalidParameter_DownloadReferenceIsntValid = 20220u;

		public const uint API_FailedToDeserializeResponse = 20300u;

		public const uint API_FailedToGetResponseFromWebRequest = 20301u;

		public const uint API_FailedToConnect = 20302u;

		public const uint API_FailedToCompleteRequest = 20303u;

		public const uint IO_FilePathInvalid = 20400u;

		public const uint IO_FileDoesNotExist = 20401u;

		public const uint IO_FileCouldNotBeOpened = 20402u;

		public const uint IO_FileCouldNotBeCreated = 20403u;

		public const uint IO_FileCouldNotBeDeleted = 20404u;

		public const uint IO_FileCouldNotBeRead = 20405u;

		public const uint IO_FileCouldNotBeWritten = 20406u;

		public const uint IO_DirectoryDoesNotExist = 20420u;

		public const uint IO_DirectoryCouldNotBeCreated = 20421u;

		public const uint IO_DirectoryCouldNotBeDeleted = 20422u;

		public const uint IO_DirectoryCouldNotBeMoved = 20423u;

		public const uint IO_DirectoryCouldNotBeOpened = 20424u;

		public const uint IO_DirectoryCouldNotBeRead = 20425u;

		public const uint IO_InvalidMountPoint = 20430u;

		public const uint IO_AccessDenied = 20440u;

		public const uint IO_FileSizeTooLarge = 20441u;

		public const uint IO_InsufficientStorage = 20442u;

		public const uint IO_DataServiceForPathNotFound = 20450u;

		public const uint Internal_DuplicateRequestWithDifferingSchemas = 20500u;

		public const uint Internal_FailedToDeserializeObject = 20501u;

		public const uint Internal_RegistryNotInitialized = 20502u;

		public const uint Internal_ModManagementOperationFailed = 20503u;

		public const uint Internal_FileSizeMismatch = 20504u;

		public const uint Internal_FileHashMismatch = 20505u;

		public const uint Internal_OperationCancelled = 20506u;

		public const uint Internal_InvalidParameter = 20507u;

		public const uint WSS_NotConnected = 20600u;

		public const uint WSS_FailedToSend = 20601u;

		public const uint WSS_MessageTimeout = 20602u;

		public const uint WSS_UnexpectedMessage = 20603u;

		public const uint RESTAPI_ServerOutage = 10000u;

		public const uint RESTAPI_CrossOriginRequestForbidden = 10001u;

		public const uint RESTAPI_UnknownServerError = 10002u;

		public const uint RESTAPI_APIVersionInvalid = 10003u;

		public const uint RESTAPI_APIKeyMissing = 11000u;

		public const uint RESTAPI_APIKeyMalformed = 11001u;

		public const uint RESTAPI_APIKeyInvalid = 11002u;

		public const uint RESTAPI_InsufficientWritePermission = 11003u;

		public const uint RESTAPI_InsufficientReadPermission = 11004u;

		public const uint RESTAPI_OAuthTokenExpired = 11005u;

		public const uint RESTAPI_UserAccountDeleted = 11006u;

		public const uint RESTAPI_UserAccountBanned = 11007u;

		public const uint RESTAPI_RateLimitExceeded = 11008u;

		public const uint RESTAPI_11012 = 11012u;

		public const uint RESTAPI_11014 = 11014u;

		public const uint RESTAPI_SubmittedBinaryCorrupt = 13001u;

		public const uint RESTAPI_SubmittedBinaryUnreadable = 13002u;

		public const uint RESTAPI_JSONMalformed = 13004u;

		public const uint RESTAPI_ContentHeaderTypeMissing = 13005u;

		public const uint RESTAPI_ContentHeaderTypeNotSupported = 13006u;

		public const uint RESTAPI_ResponseFormatNotSupported = 13007u;

		public const uint RESTAPI_DataValidationErrors = 13009u;

		public const uint RESTAPI_ResourceIdNotFound = 14000u;

		public const uint RESTAPI_GameIdNotFound = 14001u;

		public const uint RESTAPI_GameDeleted = 14006u;

		public const uint RESTAPI_ModSubscriptionAlreadyExists = 15004u;

		public const uint RESTAPI_ModSubscriptionNotFound = 15005u;

		public const uint RESTAPI_InsufficientCreatePermission = 15006u;

		public const uint RESTAPI_ModfileIdNotFound = 15010u;

		public const uint RESTAPI_InsufficientDeletePermission = 15019u;

		public const uint RESTAPI_ModIdNotFound = 15022u;

		public const uint RESTAPI_ModDeleted = 15023u;

		public const uint RESTAPI_CommentIdNotFound = 15026u;

		public const uint RESTAPI_ModRatingAlreadyExists = 15028u;

		public const uint RESTAPI_ModRatingNotFound = 15043u;

		public const uint RESTAPI_UserIdNotFound = 21000u;

		public const uint RESTAPI_InvalidSteamEncryptedAppTicket = 11018u;

		public const uint RESTAPI_CantVerifyCredentialsExternally = 11032u;

		public const uint RESTAPI_KeyNotAssociatedWithGame = 11016u;

		public const uint RESTAPI_TestKeyForTestEnvOnly = 11017u;

		public const uint RESTAPI_SecretSteamAppTicketNotConfigured = 11019u;

		public const uint RESTAPI_UserMustAgreeToModIoTerms = 11051u;

		public const uint RESTAPI_GogInvalidAppTicket = 11021u;

		public const uint RESTAPI_GogGameNotConfigured = 11022u;

		public const uint RESTAPI_UnableToFetchAccountDataFromItchIo = 11031u;

		public const uint RESTAPI_OculusRiftAppTicketNotConfigured = 11024u;

		public const uint RESTAPI_OculusQuestAppTicketNotConfigured = 11025u;

		public const uint RESTAPI_XboxLiveTokenInvalid = 11027u;

		public const uint RESTAPI_XboxLiveTokenExpired = 11029u;

		public const uint RESTAPI_XboxNotAllowedToInteractWithUGC = 11028u;

		public const uint RESTAPI_XboxLiveChildAccountNotPermitted = 11030u;

		public const uint RESTAPI_NsaIdTokenInvalid = 11035u;

		public const uint RESTAPI_UnableToVerifyNintendoCredentials = 11039u;

		public const uint RESTAPI_NsaIdTokenNotValidYet = 11036u;

		public const uint RESTAPI_NsaIdTokenExpired = 11037u;

		public const uint RESTAPI_NintendoSwitchAppIdNotConfigured = 11040u;

		public const uint RESTAPI_NintendoSwitchNotPermittedToAuthUsers = 11041u;

		public const uint RESTAPI_AccessTokenInvalid = 11052u;

		public const uint RESTAPI_UnableToValidateCredentialsWithGoogle = 11056u;

		public const uint RESTAPI_GoogleAccessTokenNotValidYet = 11053u;

		public const uint RESTAPI_GoogleAccessTokenExpired = 11054u;

		public const uint RESTAPI_DiscordUnableToGetAccountData = 11043u;

		private static HashSet<long> cacheClearingErrorCodes;

		private static Dictionary<uint, string> errorCodesClearText;

		public static bool IsInvalidSession(ErrorObject errorObject)
		{
			return false;
		}

		public static string GetErrorCodeMeaning(uint code)
		{
			return null;
		}
	}
}
