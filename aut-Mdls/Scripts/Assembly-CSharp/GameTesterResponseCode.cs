public enum GameTesterResponseCode
{
	HttpError = -10,
	ResponseParseError = -11,
	Success = -1,
	GeneralError = 0,
	MissingDeveloperToken = 1,
	MissingPlayerAuthentication = 2,
	InvalidDeveloperToken = 3,
	InvalidPlayerConnectToken = 4,
	InvalidPlayerPin = 5,
	MissingDatapoint = 6,
	DataPointDoesNotExist = 7,
	TestNotRunning = 8,
	InvalidPlayerForTest = 9,
	TestAlreadyUnlocked = 10,
	TestNotInSetupState = 11,
	MissingPlayerToken = 12,
	InvalidPlayerToken = 13,
	TestFinished = 14
}
