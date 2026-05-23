using System;

[Serializable]
public class MstAttachmentEntities : ICommonEntiies
{
	public eAttachment id;

	public string name;

	public bool isFlagType;

	public bool isLessThanType;

	public bool isMoreThanType;

	public bool isArrayType;

	public string iconPath;

	public string imagePath;

	public string gifPath;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;

	public override string ToString()
	{
		return null;
	}
}
