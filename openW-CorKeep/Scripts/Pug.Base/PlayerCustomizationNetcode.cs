using System;
using Unity.Collections;

[Serializable]
public struct PlayerCustomizationNetcode
{
	public FixedString32Bytes name;

	public GuidAsULongs body;

	public GuidAsULongs skinColor;

	public GuidAsULongs hair;

	public GuidAsULongs hairColor;

	public GuidAsULongs hairShadeColor;

	public GuidAsULongs eyes;

	public GuidAsULongs eyesColor;

	public GuidAsULongs shirtSkin;

	public GuidAsULongs shirtColor;

	public GuidAsULongs pantsSkin;

	public GuidAsULongs pantsColor;

	public GuidAsULongs helm;

	public GuidAsULongs breastArmor;

	public GuidAsULongs pantsArmor;

	public byte role;

	public static PlayerCustomization ConvertToAddress(PlayerCustomizationNetcode localData)
	{
		return new PlayerCustomization
		{
			name = localData.name,
			body = localData.body.ToAddress(),
			skinColor = localData.skinColor.ToAddress(),
			hair = localData.hair.ToAddress(),
			hairColor = localData.hairColor.ToAddress(),
			hairShadeColor = localData.hairShadeColor.ToAddress(),
			eyes = localData.eyes.ToAddress(),
			eyesColor = localData.eyesColor.ToAddress(),
			shirtSkin = localData.shirtSkin.ToAddress(),
			shirtColor = localData.shirtColor.ToAddress(),
			pantsSkin = localData.pantsSkin.ToAddress(),
			pantsColor = localData.pantsColor.ToAddress(),
			helm = localData.helm.ToAddress(),
			breastArmor = localData.breastArmor.ToAddress(),
			pantsArmor = localData.pantsArmor.ToAddress(),
			role = localData.role
		};
	}

	public static PlayerCustomizationNetcode ConvertFromAddress(PlayerCustomization netcodeData)
	{
		return new PlayerCustomizationNetcode
		{
			name = netcodeData.name,
			body = GuidAsULongs.FromAddress(netcodeData.body),
			skinColor = GuidAsULongs.FromAddress(netcodeData.skinColor),
			hair = GuidAsULongs.FromAddress(netcodeData.hair),
			hairColor = GuidAsULongs.FromAddress(netcodeData.hairColor),
			hairShadeColor = GuidAsULongs.FromAddress(netcodeData.hairShadeColor),
			eyes = GuidAsULongs.FromAddress(netcodeData.eyes),
			eyesColor = GuidAsULongs.FromAddress(netcodeData.eyesColor),
			shirtSkin = GuidAsULongs.FromAddress(netcodeData.shirtSkin),
			shirtColor = GuidAsULongs.FromAddress(netcodeData.shirtColor),
			pantsSkin = GuidAsULongs.FromAddress(netcodeData.pantsSkin),
			pantsColor = GuidAsULongs.FromAddress(netcodeData.pantsColor),
			helm = GuidAsULongs.FromAddress(netcodeData.helm),
			breastArmor = GuidAsULongs.FromAddress(netcodeData.breastArmor),
			pantsArmor = GuidAsULongs.FromAddress(netcodeData.pantsArmor),
			role = netcodeData.role
		};
	}
}
