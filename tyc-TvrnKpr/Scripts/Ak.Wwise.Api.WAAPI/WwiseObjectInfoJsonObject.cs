using System;

[Serializable]
public class WwiseObjectInfoJsonObject
{
	public string id;

	public WwiseObjectInfoParent parent;

	public string name;

	public string type;

	public int childrenCount;

	public string path;

	public string filePath;

	public string workunitType;

	public string soundbankBnkFilePath;

	public static implicit operator WwiseObjectInfo(WwiseObjectInfoJsonObject info)
	{
		return default(WwiseObjectInfo);
	}

	public static WwiseObjectInfo ToObjectInfo(WwiseObjectInfoJsonObject info)
	{
		return default(WwiseObjectInfo);
	}
}
