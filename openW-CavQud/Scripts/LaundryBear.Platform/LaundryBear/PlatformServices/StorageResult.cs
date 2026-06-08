namespace LaundryBear.PlatformServices
{
	public enum StorageResult
	{
		Success = 0,
		FileNotFound = 1,
		DirectoryNotFound = 2,
		DriveNotFound = 3,
		AlreadyExists = 4,
		PathTooLong = 5,
		QuotaExceeded = 6,
		InvalidPath = 7,
		OperationCancelled = 8,
		InvalidPermissions = 9,
		InUse = 10,
		StorageNameTaken = 11,
		StorageCountExceeded = 12,
		Corrupted = 13,
		NotReady = 14,
		ServiceNotReady = 15,
		UnknownFailure = 16
	}
}
