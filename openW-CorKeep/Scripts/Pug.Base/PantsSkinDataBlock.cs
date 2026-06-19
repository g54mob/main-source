using UnityEngine.AddressableAssets;

public class PantsSkinDataBlock : SkinBaseDataBlock
{
	public AssetReferenceTexture2D pantsTexture;

	public DataBlockRef<SourceColorDataBlock> sourceColors;

	public DataBlockRef<ReplacementColorCollectionDataBlock> replacementColorsCollectionRef;
}
