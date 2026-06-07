public class LEQuickInventoryModel : QuickInventoryModelBase<CustomLevelObjectsModel>
{
	protected override bool IsOriginalItem(CustomLevelObjectsModel itemModel)
	{
		return itemModel.Origin == CustomLevelObjectsModel.OriginEnum.Part;
	}

	protected override LEQuickInventoryModel NewInstance<LEQuickInventoryModel>()
	{
		return new LEQuickInventoryModel();
	}
}
