using System;

[Serializable]
public class WwiseChildModifiedInfo : JsonSerializable
{
	public WwiseObjectInfoJsonObject parent;

	public WwiseObjectInfoJsonObject child;

	public WwiseObjectInfo parentInfo;

	public WwiseObjectInfo childInfo;

	public void ParseInfo()
	{
	}
}
