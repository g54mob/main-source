namespace LaundryBear.PlatformServices
{
	public delegate void OnLoadBlobsBytesComplete(StorageResult result, (string path, byte[] contents)[] contents);
}
