using System;

[Serializable]
public class WwiseRenameInfo : JsonSerializable
{
	public WwiseObjectInfoJsonObject @object;

	public string newName;

	public string oldName;

	public WwiseObjectInfo objectInfo;

	public void ParseInfo()
	{
		objectInfo = @object;
	}
}
