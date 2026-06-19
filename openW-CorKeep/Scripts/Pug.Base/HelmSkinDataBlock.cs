using UnityEngine;
using UnityEngine.AddressableAssets;

public class HelmSkinDataBlock : SkinBaseDataBlock
{
	public AssetReferenceTexture2D helmTexture;

	public AssetReferenceTexture2D emissiveHelmTexture;

	public HelmHairType hairType;

	public Vector2Int pixelOffset;
}
