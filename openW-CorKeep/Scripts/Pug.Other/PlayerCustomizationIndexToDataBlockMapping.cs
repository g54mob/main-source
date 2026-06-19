using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class PlayerCustomizationIndexToDataBlockMapping : ScriptableObject
{
	[InfoBox("This asset contains a mapping used to convert old save files. DO NOT CHANGE IT! If you are looking for the actual customization options, they are in the PlayerCustomizationTableDataBlock asset.", EInfoBoxType.Normal)]
	public List<DataBlockRef<BodySkinDataBlock>> bodySkins;

	public List<DataBlockRef<ReplacementColorDataBlock>> skinColors;

	public List<DataBlockRef<HairSkinDataBlock>> hairs;

	public List<DataBlockRef<ReplacementColorDataBlock>> hairColors;

	public List<DataBlockRef<ReplacementColorDataBlock>> hairShadeColors;

	public List<DataBlockRef<EyesSkinDataBlock>> eyes;

	public List<DataBlockRef<ReplacementColorDataBlock>> eyeColors;

	public List<DataBlockRef<ShirtSkinDataBlock>> shirts;

	public List<DataBlockRef<ReplacementColorDataBlock>> shirtColors;

	public List<DataBlockRef<PantsSkinDataBlock>> pants;

	public List<DataBlockRef<ReplacementColorDataBlock>> pantsColors;

	public List<DataBlockRef<HelmSkinDataBlock>> helms;

	public List<DataBlockRef<BreastArmorSkinDataBlock>> breastArmors;

	public List<DataBlockRef<PantsArmorSkinDataBlock>> pantsArmors;
}
