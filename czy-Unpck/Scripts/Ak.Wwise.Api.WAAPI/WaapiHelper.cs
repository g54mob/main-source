public static class WaapiHelper
{
	public static WwiseObjectType GetWwiseObjectTypeFromString(string typeString, string workUnitType)
	{
		if (!WaapiKeywords.typeStringDict.ContainsKey(typeString))
		{
			return WwiseObjectType.None;
		}
		if (workUnitType != string.Empty)
		{
			if (workUnitType == "folder")
			{
				return WaapiKeywords.typeStringDict["physicalfolder"];
			}
			return WaapiKeywords.typeStringDict[typeString];
		}
		return WaapiKeywords.typeStringDict[typeString];
	}
}
