using System.Collections.Generic;
using System.Linq;
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

		private static HashSet<long> cacheClearingErrorCodes = new HashSet<long>
		{
			11005L, 11018L, 11032L, 11016L, 11017L, 11019L, 11051L, 11021L, 11022L, 11031L,
			11024L, 11025L, 11027L, 11029L, 11028L, 11030L, 11035L, 11039L, 11036L, 11037L,
			11040L, 11041L, 11052L, 11056L, 11053L, 11054L, 11043L
		};

		private static Dictionary<uint, string> errorCodesClearText = new Dictionary<uint, string>
		{
			{ 0u, "Success!" },
			{ 1u, "Unknown" },
			{ 20000u, "Not yet initialized." },
			{ 20010u, "Failed to load the config." },
			{ 20020u, "User data failed to initialize." },
			{ 20021u, "Persistent data failed to initialize." },
			{ 20022u, "Temporary data failed to initialize." },
			{ 20050u, "Invalid server URL." },
			{ 20051u, "Invalid game id." },
			{ 20052u, "Invalid game key." },
			{ 20053u, "Invalid language code." },
			{ 20054u, "Uploads are disabled." },
			{ 20100u, "User not authenticated." },
			{ 20101u, "User has an invalid token." },
			{ 20102u, "User has an invalid email address." },
			{ 20103u, "User already authenticated." },
			{ 20104u, "User not removed." },
			{ 20201u, "Invalid parameter - pagination params." },
			{ 20202u, "Invalid parameter - report not ready." },
			{ 20203u, "Invalid parameter - mod metadata too large." },
			{ 20204u, "Invalid parameter - bad creation token." },
			{ 20205u, "Invalid parameter - description too large." },
			{ 20206u, "Invalid parameter - changelog too large." },
			{ 20210u, "Invalid parameter - mod prof.ile required fields not set." },
			{ 20211u, "Invalid parameter - mod summary too large." },
			{ 20212u, "Invalid parameter - mod logo too large." },
			{ 20213u, "Invalid parameter - cant be null!" },
			{ 20214u, "Invalid parameter - missing mod id." },
			{ 20300u, "Api failed to deserialize response." },
			{ 20301u, "Api failed to get response from webrequest." },
			{ 20302u, "Api failed to connect." },
			{ 20303u, "Api failed to complete the request." },
			{ 20400u, "IO - File path invalid." },
			{ 20401u, "IO - File does not exist." },
			{ 20402u, "IO - File could not be opened." },
			{ 20403u, "IO - File could not be created." },
			{ 20404u, "IO - File could not be deleted." },
			{ 20405u, "IO - File could not be read." },
			{ 20406u, "IO - File could not be written." },
			{ 20420u, "IO - Directory does not exist." },
			{ 20421u, "IO - Directory could not be created." },
			{ 20422u, "IO - Directory could not be deleted." },
			{ 20423u, "IO - Directory could not be moved." },
			{ 20424u, "IO - Directory could not be opened." },
			{ 20425u, "IO - Directory could not be read." },
			{ 20430u, "IO - Invalid mount point." },
			{ 20440u, "IO - Access Denied!" },
			{ 20441u, "IO - The filesize is too large." },
			{ 20442u, "IO - There is not enough storage space remaining." },
			{ 20450u, "IO - data service for path not found." },
			{ 20500u, "Internal - Duplicate request with differing schemas." },
			{ 20501u, "Internal - Failed to deserialize object." },
			{ 20502u, "Internal - Registry not initialized." },
			{ 20503u, "Internal - Mod management operation failed." },
			{ 20504u, "Internal - File size mismatch." },
			{ 20505u, "Internal - File hash mismatch." },
			{ 20506u, "Internal - Operation cancelled." },
			{ 20507u, "Internal - Invalid parameter" },
			{ 10000u, "mod.io is currently experiencing an outage. (rare)" },
			{ 10001u, "Cross-origin request forbidden." },
			{ 10002u, ".io failed to complete the request, please try again. (rare)" },
			{ 10003u, "API version supplied is invalid." },
			{ 11000u, "api_key is missing from your request." },
			{ 11001u, "api_key supplied is malformed." },
			{ 11002u, "api_key supplied is invalid." },
			{ 11003u, "Access token is missing the write scope to perform the request." },
			{ 11004u, "Access token is missing the read scope to perform the request." },
			{ 11005u, "Access token is expired, or has been revoked." },
			{ 11006u, "Authenticated user account has been deleted." },
			{ 11007u, "Authenticated user account has been banned by mod.io admins." },
			{ 11008u, "You have been ratelimited for making too many requests. See Rate Limiting." },
			{ 11012u, "Invalid security code." },
			{ 11014u, "Security code has expired. Please request a new code." },
			{ 13001u, "The submitted binary file is corrupted." },
			{ 13002u, "The submitted binary file is unreadable." },
			{ 13004u, "You have used the input_json parameter with semantically incorrect JSON." },
			{ 13005u, "The Content-Type header is missing from your request." },
			{ 13006u, "The Content-Type header is not supported for this endpoint." },
			{ 13007u, "You have requested a response format that is not supported (JSON only)." },
			{ 13009u, "The request contains validation errors for the data supplied. See the attached errors field within the Error Object to determine which input failed." },
			{ 14000u, "The requested resource does not exist." },
			{ 14001u, "The requested game could not be found." },
			{ 14006u, "The requested game has been deleted." },
			{ 15004u, "Already subscribed to a mod (can't subscribe)." },
			{ 15005u, "Not subscribed to a mod (can't unsubscribe)." },
			{ 15006u, "You do not have the required permissions to create content for the specified resource." },
			{ 15010u, "The requested modfile could not be found." },
			{ 15019u, "No permission to delete specified resource." },
			{ 15022u, "The requested mod could not be found." },
			{ 15023u, "The requested mod has been deleted." },
			{ 15026u, "The requested comment could not be found." },
			{ 15028u, "The mod rating is already positive/negative" },
			{ 15043u, "The mod rating is already removed" },
			{ 21000u, "The requested user could not be found." },
			{ 11018u, "The steam encrypted app ticket was invalid." },
			{ 11032u, "mod.io was unable to verify the credentials against the external service provider." },
			{ 11016u, "The api_key supplied in the request must be associated with a game." },
			{ 11017u, "The api_key supplied in the request is for test environment purposes only and cannot be used for this functionality." },
			{ 11019u, "The secret steam app ticket associated with this game has not been configured." },
			{ 11051u, "The user has not agreed to the mod.io Terms of Use. Please see terms_agreed parameter description and the Terms endpoint for more information." },
			{ 11021u, "The GOG Galaxy encrypted app ticket was invalid." },
			{ 11022u, "The secret GOG Galaxy app ticket associated with this game has not been configured." },
			{ 11031u, "mod.io was unable to get account data from itch.io servers." },
			{ 11024u, "The secret Oculus Rift app ticket associated with this game has not been configured." },
			{ 11025u, "The secret Oculus Quest app ticket associated with this game has not been configured." },
			{ 11027u, "The Xbox Live token supplied in the request is invalid." },
			{ 11029u, "The Xbox Live token supplied has expired." },
			{ 11028u, "The user is not permitted to interact with UGC. This can be modified in the user's Xbox Live profile." },
			{ 11030u, "Xbox Live users with 'Child' accounts are not permitted to use mod.io." },
			{ 11035u, "The NSA ID token was invalid/malformed." },
			{ 11039u, "mod.io was unable to validate the credentials with Nintendo Servers." },
			{ 11036u, "The NSA ID token is not valid yet." },
			{ 11037u, "The NSA ID token has expired. You should request another token from the Switch SDK and ensure it is delivered to mod.io before it expires." },
			{ 11040u, "The application ID for the Nintendo Switch title has not been configured, this can be setup in the 'Options' tab within your game profile." },
			{ 11041u, "The application ID of the originating Switch title is not permitted to authenticate users. Please check the Switch application id submitted on your games' 'Options' tab and ensure it is the same application id of the Switch title making the authentication request." },
			{ 11052u, "//11052 The access token was invalid/malformed." },
			{ 11056u, "mod.io was unable to validate the credentials with Google's servers." },
			{ 11053u, "The Google access token is not valid yet." },
			{ 11054u, "The Google access token has expired. You should request another token from the Google SDK and ensure it is delivered to mod.io before it expires." },
			{ 11043u, "mod.io was unable to get account data from the Discord servers." }
		};

		public static bool IsInvalidSession(ErrorObject errorObject)
		{
			return cacheClearingErrorCodes.Any((long x) => x == errorObject.error.error_ref);
		}

		public static string GetErrorCodeMeaning(uint code)
		{
			if (errorCodesClearText.TryGetValue(code, out var value))
			{
				return value;
			}
			return "This code is not contained in the error codes clear text repository.";
		}
	}
}
