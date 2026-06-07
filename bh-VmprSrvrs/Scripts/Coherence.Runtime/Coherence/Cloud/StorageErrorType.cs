namespace Coherence.Cloud
{
	public enum StorageErrorType
	{
		None = 0,
		NotLoggedIn = 1,
		RequestException = 2,
		InvalidObjectId = 3,
		InvalidKey = 4,
		InvalidValue = 5,
		KeyNotFound = 6,
		ObjectNotFound = 7,
		NullArgument = 8,
		EmptyArgument = 9,
		CloudStorageHasBeenDisposed = 10,
		SerializationFailed = 11,
		DeserializationFailed = 12
	}
}
