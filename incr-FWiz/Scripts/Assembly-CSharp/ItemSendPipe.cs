using System.Collections.Generic;

public class ItemSendPipe : Pipe
{
	public List<ItemRecievePipe.RecieveTypeSetting> CanSendTo;

	public override bool CanStartConnection => false;

	public override bool Many => false;

	protected override bool CanConnect(Pipe pipe)
	{
		return false;
	}

	public virtual bool TrySendItem(ItemType itemType)
	{
		return false;
	}

	public void AddSendOption(int canSendTo)
	{
	}

	public override List<BuildingSelectorData> GetSelectorTransforms()
	{
		return null;
	}
}
