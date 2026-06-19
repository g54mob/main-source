public class ItemForkSendPipe : ItemSendPipe
{
	private int RecieverIndex;

	public override bool CanStartConnection => false;

	public override bool Many => false;

	public override bool TrySendItem(ItemType itemType)
	{
		return false;
	}
}
