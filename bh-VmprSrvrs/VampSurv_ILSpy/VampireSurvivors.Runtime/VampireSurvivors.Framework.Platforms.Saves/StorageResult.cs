namespace VampireSurvivors.Framework.Platforms.Saves;

public enum StorageResult
{
	Successful,
	Failed,
	NotFound,
	SDKNotInitialized,
	StorageNotInitialized,
	StorageIsReinitializing,
	InvalidArg,
	AnotherOperationInProgress,
	NothingToCommit,
	DataCorrupted,
	TargetLocked,
	NoFreeSpace,
	MountNameAlreadyExists
}
