using System;

[Serializable]
public struct WwiseObjectInfo
{
	public Guid objectGUID;

	public Guid parentID;

	public string name;

	public WwiseObjectType type;

	public int childrenCount;

	public string path;

	public string workUnitType;

	public string filePath;

	public string soundbankBnkFilePath;
}
