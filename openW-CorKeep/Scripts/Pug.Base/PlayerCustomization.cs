using System;
using Unity.Collections;

[Serializable]
public struct PlayerCustomization
{
	public FixedString32Bytes name;

	public DataBlockAddress body;

	public DataBlockAddress skinColor;

	public DataBlockAddress hair;

	public DataBlockAddress hairColor;

	public DataBlockAddress hairShadeColor;

	public DataBlockAddress eyes;

	public DataBlockAddress eyesColor;

	public DataBlockAddress shirtColor;

	public DataBlockAddress shirtSkin;

	public DataBlockAddress pantsColor;

	public DataBlockAddress pantsSkin;

	public DataBlockAddress helm;

	public DataBlockAddress breastArmor;

	public DataBlockAddress pantsArmor;

	public byte role;

	public PlayerCustomization(PlayerCustomizationTableDataBlock table)
	{
		name = default(FixedString32Bytes);
		role = 0;
		body = ((table.bodySkinCollection.TryGet(out var dataBlock) && dataBlock.Count > 0) ? dataBlock[0].address : DataBlockAddress.Empty);
		skinColor = ((table.skinReplacementColors.TryGet(out var dataBlock2) && dataBlock2.Count > 0) ? dataBlock2[0].address : DataBlockAddress.Empty);
		hair = ((table.hairSkinCollection.TryGet(out var dataBlock3) && dataBlock3.Count > 0) ? dataBlock3[0].address : DataBlockAddress.Empty);
		hairColor = ((table.hairReplacementColors.TryGet(out var dataBlock4) && dataBlock4.Count > 0) ? dataBlock4[0].address : DataBlockAddress.Empty);
		hairShadeColor = ((table.hairShadeReplacementColors.TryGet(out var dataBlock5) && dataBlock5.Count > 0) ? dataBlock5[0].address : DataBlockAddress.Empty);
		eyes = ((table.eyeSkinCollection.TryGet(out var dataBlock6) && dataBlock6.Count > 0) ? dataBlock6[0].address : DataBlockAddress.Empty);
		eyesColor = ((table.eyeReplacementColors.TryGet(out var dataBlock7) && dataBlock7.Count > 0) ? dataBlock7[0].address : DataBlockAddress.Empty);
		if (table.shirtSkinCollection.TryGet(out var dataBlock8) && dataBlock8.Count > 0)
		{
			shirtSkin = dataBlock8[0].address;
			shirtColor = ((dataBlock8[0].replacementColorsCollectionRef.TryGet(out var dataBlock9) && dataBlock9.Count > 0) ? dataBlock9[0].address : DataBlockAddress.Empty);
		}
		else
		{
			shirtSkin = DataBlockAddress.Empty;
			shirtColor = DataBlockAddress.Empty;
		}
		if (table.pantsSkinCollection.TryGet(out var dataBlock10) && dataBlock10.Count > 0)
		{
			pantsSkin = dataBlock10[0].address;
			pantsColor = ((dataBlock10[0].replacementColorsCollectionRef.TryGet(out var dataBlock11) && dataBlock11.Count > 0) ? dataBlock11[0].address : DataBlockAddress.Empty);
		}
		else
		{
			pantsSkin = DataBlockAddress.Empty;
			pantsColor = DataBlockAddress.Empty;
		}
		helm = DataBlockAddress.Empty;
		breastArmor = DataBlockAddress.Empty;
		pantsArmor = DataBlockAddress.Empty;
	}
}
