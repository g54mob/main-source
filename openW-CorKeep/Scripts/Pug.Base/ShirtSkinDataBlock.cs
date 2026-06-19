using UnityEngine.AddressableAssets;

public class ShirtSkinDataBlock : SkinBaseDataBlock
{
	public AssetReferenceTexture2D shirtTexture;

	public DataBlockRef<SourceColorDataBlock> sourceColors;

	public DataBlockRef<ReplacementColorCollectionDataBlock> replacementColorsCollectionRef;
}
