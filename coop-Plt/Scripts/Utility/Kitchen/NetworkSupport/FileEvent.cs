namespace Kitchen.NetworkSupport
{
	public enum FileEvent
	{
		Null = 0,
		FailedToImportFSIM = 1,
		ReadingFSIM = 2,
		ReadingFSIMNewDirectory = 3,
		ReadingFSIMNewFile = 4,
		ConvertingFSIMFileFailure = 5,
		ReadingFSIMFailedToDeserialise = 6,
		ReadingFSIMNotMessagepack = 7,
		ReadingFSIMNotZippedJSON = 8,
		ReadingFSIMNotPlainJSON = 9,
		ErrorDuringCommit = 10,
		OperationStart = 11,
		OperationEnd = 12,
		ErrorDuringAction = 13,
		SwitchFailedToEnsureUserData = 14,
		SwitchFailedToMount = 15,
		UnableToInitialiseSaveProvider = 16,
		FailedToCreateContainer = 17,
		FileSystemChanged = 18,
		PerformingReloadFromDisk = 19,
		FailedToOpenPrefFile = 20,
		ConvertingFSIMPath = 21,
		FSIMLoad = 22,
		FSIMMarkLoaded = 23,
		SwitchDebugNotRenamingFSM = 24,
		FSIMDebugDir = 25,
		FSIMDebugFile = 26,
		PerformingTimeoutUnmount = 27,
		UpdateLoopError = 28,
		PSFailedToMount = 29,
		PSDeletingCorruptedData = 30,
		PSForcingFSIMReload = 31,
		HasFileError = 32
	}
}
