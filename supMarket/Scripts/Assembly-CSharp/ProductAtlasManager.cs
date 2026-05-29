using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductAtlasManager : NoktaSingleton<ProductAtlasManager>
{
	[SerializeField]
	private List<Material> atlasedMaterials;

	public void GetProductIcon(int productID, RawImage image)
	{
	}

	public void ApplyLabelData(int productID, MeshRenderer renderer)
	{
	}

	public void SetLabelData(int productID, MeshRenderer mRend)
	{
	}

	public void SetFurnitureIcon(int furnitureID, MeshRenderer mRend)
	{
	}

	public void SetBucketIcon(int furnitureID, MeshRenderer mRend)
	{
	}

	public void SetIceCreamFlavourIcon(int id, MeshRenderer mRend)
	{
	}

	public void SetFloorIcon(int furnitureID, MeshRenderer mRend)
	{
	}

	public void SetCategorySignIcon(Vector2Int iconIndex, MeshRenderer mRend)
	{
	}
}
