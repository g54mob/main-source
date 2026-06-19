using System;

[Serializable]
public struct KeyArtCharacters
{
	public DataBlockRef<BodySkinDataBlock> body;

	public bool bodyIsWildcard;

	public DataBlockRef<HairSkinDataBlock> hair;

	public bool hairIsWildcard;

	public DataBlockRef<ReplacementColorDataBlock> eyesColor;

	public bool eyesColorIsWildcard;

	public DataBlockRef<ReplacementColorDataBlock> hairColor;

	public bool hairColorIsWildcard;

	public DataBlockRef<ReplacementColorDataBlock> skinColor;

	public bool skinColorIsWildcard;

	public DataBlockRef<ReplacementColorDataBlock> shirtColor;

	public bool shirtColorIsWildcard;

	public DataBlockRef<ReplacementColorDataBlock> pantsColor;

	public bool pantsColorIsWildcard;

	public bool Matches(PlayerCustomization customization)
	{
		if ((bodyIsWildcard || customization.body == body.address) && (hairIsWildcard || customization.hair == hair.address) && (eyesColorIsWildcard || customization.eyesColor == eyesColor.address) && (hairColorIsWildcard || customization.hairColor == hairColor.address) && (skinColorIsWildcard || customization.skinColor == skinColor.address) && (shirtColorIsWildcard || customization.shirtColor == shirtColor.address))
		{
			if (!pantsColorIsWildcard)
			{
				return customization.pantsColor == pantsColor.address;
			}
			return true;
		}
		return false;
	}
}
