namespace LaundryBear.PlatformServices
{
	public delegate void OnLoadBlobsStringComplete(StorageResult result, (string path, string contents)[] contents);
}
