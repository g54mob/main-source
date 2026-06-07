using System;

public class SerializedAssetMetadata
{
	public AssetType type;

	public string name;

	public DateTime creationDate;

	public DateTime lastEditDate;

	public bool securityLock;

	public SerializedAssetMetadata()
	{
	}

	public SerializedAssetMetadata(string name)
	{
	}

	public SerializedAssetMetadata(Asset asset)
	{
	}
}
