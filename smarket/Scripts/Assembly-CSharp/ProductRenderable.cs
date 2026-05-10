public class ProductRenderable : RenderableInstance
{
	public enum ProductMaterialType
	{
		Opaque = 0,
		Transparent = 1
	}

	public readonly ProductMaterialType MaterialType;

	public ProductRenderable(ProductSO productSo, int submesh = 0, ProductMaterialType materialType = ProductMaterialType.Opaque)
	{
	}
}
