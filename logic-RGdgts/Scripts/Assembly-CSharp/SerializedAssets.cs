using System.Collections.Generic;

public class SerializedAssets
{
	public Dictionary<uint, SerializedAssetMetadata> metadatas;

	public Dictionary<uint, SerializedAsset> assets;

	public SerializedAssets()
	{
	}

	public SerializedAssets(Gadget gadget)
	{
	}
}
