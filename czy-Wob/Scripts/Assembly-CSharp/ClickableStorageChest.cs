public class ClickableStorageChest : ClickableObject
{
	public StorageChest mainChestRest;

	protected override void OnClickInternal()
	{
		base.OnClickInternal();
		mainChestRest.OnClick();
	}
}
