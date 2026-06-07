public class QuickInventoryModel : QuickInventoryModelBase<CreationModel>
{
	protected override bool IsOriginalItem(CreationModel itemModel)
	{
		return itemModel.IsOriginatedFromSchematic;
	}

	protected override QuickInventoryModel NewInstance<QuickInventoryModel>()
	{
		return new QuickInventoryModel();
	}
}
