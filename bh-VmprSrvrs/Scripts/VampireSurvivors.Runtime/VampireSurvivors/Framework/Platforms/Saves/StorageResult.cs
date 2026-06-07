namespace VampireSurvivors.Framework.Platforms.Saves
{
	public enum StorageResult
	{
		Successful = 0,
		Failed = 1,
		NotFound = 2,
		SDKNotInitialized = 3,
		StorageNotInitialized = 4,
		StorageIsReinitializing = 5,
		InvalidArg = 6,
		AnotherOperationInProgress = 7,
		NothingToCommit = 8,
		DataCorrupted = 9,
		TargetLocked = 10,
		NoFreeSpace = 11,
		MountNameAlreadyExists = 12
	}
}
