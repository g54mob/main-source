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
		return ToObjectInfo(info);
	}

	public static WwiseObjectInfo ToObjectInfo(WwiseObjectInfoJsonObject info)
	{
		string obj = ((info.type == null) ? "" : info.type);
		string text = ((info.workunitType == null) ? "" : info.workunitType);
		WwiseObjectType wwiseObjectTypeFromString = WaapiHelper.GetWwiseObjectTypeFromString(obj.ToLower(), text.ToLower());
		Guid parentID = ((info.parent.id == null) ? Guid.Empty : Guid.Parse(info.parent.id));
		Guid objectGUID = ((info.id == null) ? Guid.Empty : Guid.Parse(info.id));
		return new WwiseObjectInfo
		{
			objectGUID = objectGUID,
			name = info.name,
			type = wwiseObjectTypeFromString,
			childrenCount = info.childrenCount,
			path = info.path,
			workUnitType = text,
			parentID = parentID,
			filePath = info.filePath,
			soundbankBnkFilePath = info.soundbankBnkFilePath
		};
	}
}
