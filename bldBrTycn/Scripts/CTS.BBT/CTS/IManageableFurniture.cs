namespace CTS
{
	public interface IManageableFurniture : IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		UsableFurnituresCategoriesSO UsableFurnitureCategoryData { get; }
	}
}
